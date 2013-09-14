// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DvdLanguage.cs" company="JT-Soft (https://github.com/UniqProject/SharpDvdInfo)">
//   This file is part of the SharpDvdInfo source code - It may be used under the terms of the GNU General Public License.
// </copyright>
// <summary>
//   Defines a single DVD language
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SharpDvdInfo.DvdTypes
{
    /// <summary>
    /// The DVD language
    /// </summary>
    public class DvdLanguage
    {
        /// <summary>
        /// Language code
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Language name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Creates an empty language
        /// </summary>
        public DvdLanguage()
        {
            Code = string.Empty;
            Name = string.Empty;
        }
    }
}