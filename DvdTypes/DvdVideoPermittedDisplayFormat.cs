// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DvdVideoPermittedDisplayFormat.cs" company="JT-Soft (https://github.com/UniqProject/SharpDvdInfo)">
//   This file is part of the SharpDvdInfo source code - It may be used under the terms of the GNU General Public License.
// </copyright>
// <summary>
//   Defines the permitted display format for DVD video stream
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SharpDvdInfo.DvdTypes
{
    using System.ComponentModel;

    /// <summary>
    /// The permitted display format
    /// </summary>
    public enum DvdVideoPermittedDisplayFormat
    {
        /// <summary>
        /// Pan &amp; Scan + Letterbox
        /// </summary>
        [Description("Pan & Scan + Letterbox")]
        PanScanLetterbox,

        /// <summary>
        /// Pan &amp; Scan only
        /// </summary>
        [Description("Pan & Scan")]
        PanScan,

        /// <summary>
        /// Letterbox only
        /// </summary>
        [Description("Letterbox")]
        Letterbox,

        /// <summary>
        /// None
        /// </summary>
        [Description("None")]
        None
    }
}