// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DvdSubpictureFormat.cs" company="JT-Soft (https://github.com/UniqProject/SharpDvdInfo)">
//   This file is part of the SharpDvdInfo source code - It may be used under the terms of the GNU General Public License.
// </copyright>
// <summary>
//   Defines the subpicture format
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SharpDvdInfo.DvdTypes
{
    using System.ComponentModel;

    /// <summary>
    /// The DVD subpicture format
    /// </summary>
    public enum DvdSubpictureFormat
    {
        /// <summary>
        /// 2-bit RLE
        /// </summary>
        [Description("2-bit RLE")]
        RLE,

        /// <summary>
        /// Unknown format
        /// </summary>
        [Description("Unknown")]
        Unknown
    }
}