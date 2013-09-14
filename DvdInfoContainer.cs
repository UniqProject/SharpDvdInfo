// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DvdInfoContainer.cs" company="JT-Soft (https://github.com/UniqProject/SharpDvdInfo)">
//   This file is part of the SharpDvdInfo source code - It may be used under the terms of the GNU General Public License.
// </copyright>
// <summary>
//   Main DVD info container
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SharpDvdInfo
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using DvdTypes;
    using Model;

    /// <summary>
    /// Container for DVD Specification
    /// </summary>
    public class DvdInfoContainer
    {
        /// <summary>
        /// Length of DVD Sector
        /// </summary>
        private const int SectorLength = 2048;
        
        /// <summary>
        /// DVD directory
        /// </summary>
        private readonly string _path;

        /// <summary>
        /// VMGM properties.
        /// </summary>
        public VmgmInfo Vmgm { get; set; }

        /// <summary>
        /// List of <see cref="TitleInfo"/> containing Title information.
        /// </summary>
        public List<TitleInfo> Titles { get; set; } 

        /// <summary>
        /// Creates a <see cref="DvdInfoContainer"/> and reads stream infos
        /// </summary>
        /// <param name="path">DVD directory</param>
        public DvdInfoContainer(string path)
        {
            _path = path.IndexOf("VIDEO_TS", StringComparison.Ordinal) > 0
                        ? path
                        : Path.Combine(path, "VIDEO_TS");
            Vmgm = new VmgmInfo();
            Titles = new List<TitleInfo>();

            GetVmgmInfo();
            GetTitleInfo();
        }

        /// <summary>
        /// fills the List of <see cref="TitleInfo"/> with informations
        /// </summary>
        private void GetTitleInfo()
        {
            DvdLangList langList = new DvdLangList();

            foreach (TitleInfo item in Titles)
            {
                item.VideoStream = new VideoProperties();
                item.AudioStreams = new List<AudioProperties>();
                item.SubtitleStreams = new List<SubpictureProperties>();
                item.Chapters = new List<TimeSpan>();

                byte[] buffer = new byte[192];
                using (FileStream fs = File.OpenRead(Path.Combine(_path, string.Format("VTS_{0:00}_0.IFO", item.TitleSetNumber))))
                {
                    fs.Seek(0x00C8, SeekOrigin.Begin);
                    fs.Read(buffer, 0, 4);
                    fs.Seek(0x0200, SeekOrigin.Begin);
                    fs.Read(buffer, 0, 2);

                    item.VideoStream.DisplayFormat = (DvdVideoPermittedDisplayFormat) GetBits(buffer, 2, 0);
                    item.VideoStream.AspectRatio = (DvdVideoAspectRatio) GetBits(buffer, 2, 2);
                    item.VideoStream.VideoStandard = (DvdVideoStandard) GetBits(buffer, 2, 4);

                    switch (item.VideoStream.VideoStandard)
                    {
                        case DvdVideoStandard.NTSC:
                            item.VideoStream.Framerate = 30000f/1001f;
                            item.VideoStream.FrameRateNumerator = 30000;
                            item.VideoStream.FrameRateDenominator = 1001;
                            break;
                        case DvdVideoStandard.PAL:
                            item.VideoStream.Framerate = 25f;
                            item.VideoStream.FrameRateNumerator = 25;
                            item.VideoStream.FrameRateDenominator = 1;
                            break;
                    }
                    item.VideoStream.CodingMode = (DvdVideoMpegVersion) GetBits(buffer, 2, 6);
                    item.VideoStream.VideoResolution = (DvdVideoResolution) GetBits(buffer, 3, 11) +
                                                       ((int) item.VideoStream.VideoStandard*8);

                    fs.Read(buffer, 0, 2);
                    int numAudio = GetBits(buffer, 16, 0);
                    for (int audioNum = 0; audioNum < numAudio; audioNum++)
                    {
                        fs.Read(buffer, 0, 8);
                        int langMode = GetBits(buffer, 2, 2);
                        int codingMode = GetBits(buffer, 3, 5);
                        AudioProperties audioStream = new AudioProperties
                        {
                            CodingMode = (DvdAudioFormat) codingMode,
                            Channels = GetBits(buffer, 3, 8) + 1,
                            SampleRate = 48000,
                            Quantization = (DvdAudioQuantization) GetBits(buffer, 2, 14),
                            StreamId = DvdAudioId.ID[codingMode] + audioNum
                        };

                        if (langMode == 1)
                        {
                            char langChar1 = (char) GetBits(buffer, 8, 16);
                            char langChar2 = (char) GetBits(buffer, 8, 24);

                            string langCode = langChar1.ToString(CultureInfo.InvariantCulture) +
                                              langChar2.ToString(CultureInfo.InvariantCulture);
                            
                            audioStream.Language = langList.GetLanguageFromCode(langCode);
                        }
                        else
                        {
                            audioStream.Language = langList.GetLanguageFromCode("xx");
                        }
                        audioStream.Extension = (DvdAudioType) GetBits(buffer, 8, 40);
                        item.AudioStreams.Add(audioStream);
                    }

                    fs.Seek(0x0254, SeekOrigin.Begin);
                    fs.Read(buffer, 0, 2);
                    int numSubs = GetBits(buffer, 16, 0);
                    for (int subNum = 0; subNum < numSubs; subNum++)
                    {
                        fs.Read(buffer, 0, 6);
                        int langMode = GetBits(buffer, 2, 0);
                        SubpictureProperties sub = new SubpictureProperties
                        {
                            Format = (DvdSubpictureFormat) GetBits(buffer, 3, 5),
                            StreamId = 0x20 + subNum
                        };

                        if (langMode == 1)
                        {
                            char langChar1 = (char)GetBits(buffer, 8, 16);
                            char langChar2 = (char)GetBits(buffer, 8, 24);

                            string langCode = langChar1.ToString(CultureInfo.InvariantCulture) +
                                              langChar2.ToString(CultureInfo.InvariantCulture);

                            sub.Language = langList.GetLanguageFromCode(langCode);
                        }
                        else
                        {
                            sub.Language = langList.GetLanguageFromCode("xx");
                        }
                        sub.Extension = (DvdSubpictureType) GetBits(buffer, 8, 40);
                        item.SubtitleStreams.Add(sub);
                    }

                    fs.Seek(0xCC, SeekOrigin.Begin);
                    fs.Read(buffer, 0, 4);
                    int pgciSector = GetBits(buffer, 32, 0);
                    int pgciAdress = pgciSector * SectorLength;

                    fs.Seek(pgciAdress, SeekOrigin.Begin);
                    fs.Read(buffer, 0, 8);

                    fs.Seek(8 * (item.TitleNumberInSet - 1), SeekOrigin.Current);
                    fs.Read(buffer, 0, 8);
                    int offsetPgc = GetBits(buffer, 32, 32);
                    fs.Seek(pgciAdress + offsetPgc + 2, SeekOrigin.Begin);

                    fs.Read(buffer, 0, 6);
                    int numCells = GetBits(buffer, 8, 8);

                    int hour = GetBits(buffer, 8, 16);
                    int minute = GetBits(buffer, 8, 24);
                    int second = GetBits(buffer, 8, 32);
                    int msec = GetBits(buffer, 8, 40);

                    item.VideoStream.Runtime = TimeSpan.FromMilliseconds(DvdTime2Msec(hour, minute, second, msec));

                    fs.Seek(224, SeekOrigin.Current);
                    fs.Read(buffer, 0, 2);
                    int cellmapOffset = GetBits(buffer, 16, 0);

                    fs.Seek(pgciAdress + cellmapOffset + offsetPgc, SeekOrigin.Begin);

                    TimeSpan chapter = new TimeSpan();
                    item.Chapters.Add(chapter);

                    for (int i = 0; i < numCells; i++)
                    {
                        fs.Read(buffer, 0, 24);
                        int chapHour = GetBits(buffer, 8, 4*8);
                        int chapMinute = GetBits(buffer, 8, 5*8);
                        int chapSecond = GetBits(buffer, 8, 6*8);
                        int chapMsec = GetBits(buffer, 8, 7*8);

                        chapter = chapter.Add(TimeSpan.FromMilliseconds(DvdTime2Msec(chapHour, chapMinute, chapSecond, chapMsec)));

                        item.Chapters.Add(chapter);
                    }
                }
            }
        }

        /// <summary>
        /// Gets VMGM info and initializes Title list
        /// </summary>
        private void GetVmgmInfo()
        {
            byte[] buffer = new byte[12];
            using (FileStream fs = File.OpenRead(Path.Combine(_path, "VIDEO_TS.IFO")))
            {
                fs.Seek(0x20, SeekOrigin.Begin);
                fs.Read(buffer, 0, 2);
                Vmgm.MinorVersion = GetBits(buffer, 4, 8);
                Vmgm.MajorVersion = GetBits(buffer, 4, 12);

                fs.Seek(0x3E, SeekOrigin.Begin);
                fs.Read(buffer, 0, 2);
                Vmgm.NumTitleSets = GetBits(buffer, 16, 0);

                fs.Seek(0xC4, SeekOrigin.Begin);
                fs.Read(buffer, 0, 4);
                int sector = GetBits(buffer, 32, 0);
                fs.Seek(sector * SectorLength, SeekOrigin.Begin);
                fs.Read(buffer, 0, 8);
                Vmgm.NumTitles = GetBits(buffer, 16, 0);
                
                for (int i = 0; i < Vmgm.NumTitles; i++)
                {
                    TitleInfo item = new TitleInfo();
                    fs.Read(buffer, 0, 12);

                    item.TitleType = (byte) GetBits(buffer, 8, 0);
                    item.NumAngles = (byte) GetBits(buffer, 8, 1*8);
                    item.NumChapters = (short) GetBits(buffer, 16, 2*8);
                    item.ParentalMask = (short) GetBits(buffer, 16, 4*8);
                    item.TitleSetNumber = (byte) GetBits(buffer, 8, 6*8);
                    item.TitleNumberInSet = (byte) GetBits(buffer, 8, 7*8);
                    item.StartSector = GetBits(buffer, 32, 8*8);

                    Titles.Add(item);
                }
            }
        }

        /// <summary>
        /// Reads up to 32 bits from a byte array and outputs an integer
        /// </summary>
        /// <param name="buffer">bytearray to read from</param>
        /// <param name="length">count of bits to read from array</param>
        /// <param name="start">position to start from</param>
        /// <returns>resulting <see cref="int"/></returns>
        private int GetBits(byte[] buffer, byte length, byte start)
        {
            int result = 0;

            BitArray ba = new BitArray(buffer);

            short j = 0;
            int tempResult = 0;
            for (int i = start; i < start + length; i++)
            {
                if (ba.Get(i))
                    tempResult += (1 << j);
                j++;
                if (j % 8 == 0 || j == length)
                {
                    j = 0;
                    result <<= 8;
                    result += tempResult;
                    tempResult = 0;
                }
            }

            return result;
        }

        /// <summary>
        /// converts bcd formatted time to milliseconds
        /// </summary>
        /// <param name="hour">hours in bcd format</param>
        /// <param name="minute">minutes in bcd format</param>
        /// <param name="second">seconds in bcd format</param>
        /// <param name="msec">milliseconds in bcd format (2 high bits are the frame rate)</param>
        /// <returns>Converted time in milliseconds</returns>
        private long DvdTime2Msec(int hour, int minute, int second, int msec)
        {
            int fpsBits = (msec & 0xc0) >> 6;
            float fps = fpsBits == 1 ? 25f : 30000f / 1001f;

            long ms = (((hour & 0xf0) >> 3) * 5 + (hour & 0x0f)) * 3600000;
            ms += (((minute & 0xf0) >> 3) * 5 + (minute & 0x0f)) * 60000;
            ms += (((second & 0xf0) >> 3) * 5 + (second & 0x0f)) * 1000;

            if (fps > 0)
                ms += (long)(((msec & 0x30) >> 3) * 5 + (msec & 0x0f) * 1000.0 / fps);
            return ms;
        }
    }
}
