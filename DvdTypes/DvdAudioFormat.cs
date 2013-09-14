// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DvdAudioFormat.cs" company="JT-Soft (https://github.com/UniqProject/SharpDvdInfo)">
//   This file is part of the SharpDvdInfo source code - It may be used under the terms of the GNU General Public License.
// </copyright>
// <summary>
//   Defines the DVD audio formats
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SharpDvdInfo.DvdTypes
{
    /// <summary>
    /// Enumerates valid formats for DVD audio streams
    /// </summary>
    public enum DvdAudioFormat
    {
        /// <summary>
        /// Format AC-3
        /// </summary>
        AC3 = 0,

        /// <summary>
        /// Format MPEG-1
        /// </summary>
        MPEG1 = 2,

        /// <summary>
        /// Format MPEG-2
        /// </summary>
        MPEG2 = 3,

        /// <summary>
        /// Format LPCM
        /// </summary>
        LPCM = 4,

        /// <summary>
        /// Format DTS
        /// </summary>
        DTS = 6
    }
}