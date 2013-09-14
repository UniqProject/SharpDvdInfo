// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DvdAudioType.cs" company="JT-Soft (https://github.com/UniqProject/SharpDvdInfo)">
//   This file is part of the SharpDvdInfo source code - It may be used under the terms of the GNU General Public License.
// </copyright>
// <summary>
//   Defines the stream content types
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SharpDvdInfo.DvdTypes
{
    using System.ComponentModel;

    /// <summary>
    /// The stream content type
    /// </summary>
    public enum DvdAudioType
    {
        /// <summary>
        /// Undefined
        /// </summary>
        [Description("Unspecified")]
        Undefined,

        /// <summary>
        /// Normal
        /// </summary>
        [Description("Normal")]
        Normal,

        /// <summary>
        /// For visually impaired
        /// </summary>
        [Description("For visually impaired")]
        Impaired,

        /// <summary>
        /// Director's comments
        /// </summary>
        [Description("Director's comments")]
        Comments1,

        /// <summary>
        /// Alternate director's comments
        /// </summary>
        [Description("Alternate director's comments")]
        Comments2
    }
}