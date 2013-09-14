// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DvdAudioQuantization.cs" company="JT-Soft (https://github.com/UniqProject/SharpDvdInfo)">
//   This file is part of the SharpDvdInfo source code - It may be used under the terms of the GNU General Public License.
// </copyright>
// <summary>
//   Defines the audio quantization types
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SharpDvdInfo.DvdTypes
{
    using System.ComponentModel;

    /// <summary>
    /// The audio quantization types
    /// </summary>
    public enum DvdAudioQuantization
    {
        /// <summary>
        /// 16 bit Quantization
        /// </summary>
        [Description("16bit")]
        Quant16Bit,

        /// <summary>
        /// 20 bit Quantization
        /// </summary>
        [Description("20bit")]
        Quant20Bit,

        /// <summary>
        /// 24 bit Quantization
        /// </summary>
        [Description("24bit")]
        Quant24Bit,

        /// <summary>
        /// Dynamic Range Control
        /// </summary>
        [Description("DRC")]
        DRC
    }
}