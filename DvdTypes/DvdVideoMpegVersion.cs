// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DvdVideoMpegVersion.cs" company="JT-Soft (https://github.com/UniqProject/SharpDvdInfo)">
//   This file is part of the SharpDvdInfo source code - It may be used under the terms of the GNU General Public License.
// </copyright>
// <summary>
//   Defines the DVD video coding mode
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SharpDvdInfo.DvdTypes
{
    using System.ComponentModel;

    /// <summary>
    /// The video coding mode
    /// </summary>
    public enum DvdVideoMpegVersion
    {
        /// <summary>
        /// MPEG-1
        /// </summary>
        [Description("MPEG-1")]
        Mpeg1,

        /// <summary>
        /// MPEG-2
        /// </summary>
        [Description("MPEG-2")]
        Mpeg2
    }
}