// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DvdAudioId.cs" company="JT-Soft (https://github.com/UniqProject/SharpDvdInfo)">
//   This file is part of the SharpDvdInfo source code - It may be used under the terms of the GNU General Public License.
// </copyright>
// <summary>
//   Defines the start stream ids for audio streams
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SharpDvdInfo.DvdTypes
{
    /// <summary>
    /// The start ID list container
    /// </summary>
    public struct DvdAudioId
    {
        /// <summary>
        /// stream start ids
        /// </summary>
        public static int[] ID = {  0x80, // AC3
                                    0,    // UNKNOWN
                                    0xC0, // MPEG1
                                    0xC0, // MPEG2
                                    0xA0, // LPCM
                                    0,    // UNKNOWN
                                    0x88  // DTS
                                };
    }
}