// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DvdVideoStandard.cs" company="JT-Soft (https://github.com/UniqProject/SharpDvdInfo)">
//   This file is part of the SharpDvdInfo source code - It may be used under the terms of the GNU General Public License.
// </copyright>
// <summary>
//   Defines the DVD video standard
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SharpDvdInfo.DvdTypes
{
    using System.ComponentModel;

    /// <summary>
    /// The video standard
    /// </summary>
    public enum DvdVideoStandard
    {
        /// <summary>
        /// NTSC
        /// </summary>
        [Description("NTSC")]
        NTSC,

        /// <summary>
        /// PAL
        /// </summary>
        [Description("PAL")]
        PAL
    }
}