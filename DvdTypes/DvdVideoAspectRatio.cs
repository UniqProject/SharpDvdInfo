// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DvdVideoAspectRatio.cs" company="JT-Soft (https://github.com/UniqProject/SharpDvdInfo)">
//   This file is part of the SharpDvdInfo source code - It may be used under the terms of the GNU General Public License.
// </copyright>
// <summary>
//   Defines the DVD Aspect ratio
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SharpDvdInfo.DvdTypes
{
    using System.ComponentModel;

    /// <summary>
    /// The Aspect ratio
    /// </summary>
    public enum DvdVideoAspectRatio
    {
        /// <summary>
        /// 4/3
        /// </summary>
        [Description("4/3")]
        Aspect4By3,

        /// <summary>
        /// Not specified, some DVD's use this index for signaling 16/9 aspect ratio, though
        /// </summary>
        [Description("16/9")]
        Aspect16By9NotSpecified,

        /// <summary>
        /// Reserved, do not use
        /// </summary>
        [Description("Reserved")]
        AspectUnknown,

        /// <summary>
        /// 16/9
        /// </summary>
        [Description("16/9")]
        Aspect16By9
    }
}