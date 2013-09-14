// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DvdVideoResolution.cs" company="JT-Soft (https://github.com/UniqProject/SharpDvdInfo)">
//   This file is part of the SharpDvdInfo source code - It may be used under the terms of the GNU General Public License.
// </copyright>
// <summary>
//   Defines the DVD video stream resolution
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SharpDvdInfo.DvdTypes
{
    using System.ComponentModel;

    /// <summary>
    /// The video resolution
    /// </summary>
    public enum DvdVideoResolution
    {
        /// <summary>
        /// NTSC 720x480
        /// </summary>
        [Description("720x480")]
        Res720By480 = 0,

        /// <summary>
        /// NTSC 704x480
        /// </summary>
        [Description("704x480")]
        Res704By480 = 1,

        /// <summary>
        /// NTSC 352x480
        /// </summary>
        [Description("352x480")]
        Res352By480 = 2,

        /// <summary>
        /// NTSC 352x240
        /// </summary>
        [Description("352x240")]
        Res352By240 = 3,

        
        /// <summary>
        /// PAL 720x576
        /// </summary>
        [Description("720x576")]
        Res720By576 = 8,

        /// <summary>
        /// PAL 704x576
        /// </summary>
        [Description("704x576")]
        Res704By576 = 9,

        /// <summary>
        /// PAL 352x576
        /// </summary>
        [Description("352x576")]
        Res352By576 = 10,

        /// <summary>
        /// PAL 352x288
        /// </summary>
        [Description("352x288")]
        Res352By288 = 11,
    }
}