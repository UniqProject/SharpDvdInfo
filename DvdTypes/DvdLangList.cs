// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DvdLangList.cs" company="JT-Soft (https://github.com/UniqProject/SharpDvdInfo)">
//   This file is part of the SharpDvdInfo source code - It may be used under the terms of the GNU General Public License.
// </copyright>
// <summary>
//   Defines a list of languages which are supported by DVD
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SharpDvdInfo.DvdTypes
{
    using System.Collections.Generic;

    /// <summary>
    /// The DVD Language list
    /// </summary>
    public class DvdLangList
    {
        private readonly List<DvdLanguage> _langList;
        private string _searchCode;
        private string _searchLang;

        /// <summary>
        /// Creates a new Language list
        /// </summary>
        public DvdLangList()
        {
            _langList = new List<DvdLanguage>
            {
                new DvdLanguage { Code = "  ", Name = "Not Specified" },
                new DvdLanguage { Code = "aa", Name = "Afar" },
                new DvdLanguage { Code = "ab", Name = "Abkhazian" },
                new DvdLanguage { Code = "af", Name = "Afrikaans" },
                new DvdLanguage { Code = "am", Name = "Amharic" },

                new DvdLanguage { Code = "ar", Name = "Arabic" },
                new DvdLanguage { Code = "as", Name = "Assamese" },
                new DvdLanguage { Code = "ay", Name = "Aymara" },
                new DvdLanguage { Code = "az", Name = "Azerbaijani" },
                new DvdLanguage { Code = "ba", Name = "Bashkir" },

                new DvdLanguage { Code = "be", Name = "Byelorussian" },
                new DvdLanguage { Code = "bg", Name = "Bulgarian" },
                new DvdLanguage { Code = "bh", Name = "Bihari" },
                new DvdLanguage { Code = "bi", Name = "Bislama" },
                new DvdLanguage { Code = "bn", Name = "Bengali; Bangla" },

                new DvdLanguage { Code = "bo", Name = "Tibetan" },
                new DvdLanguage { Code = "br", Name = "Breton" },
                new DvdLanguage { Code = "ca", Name = "Catalan" },
                new DvdLanguage { Code = "co", Name = "Corsican" },
                new DvdLanguage { Code = "cs", Name = "Czech" },

                new DvdLanguage { Code = "cy", Name = "Welsh" },
                new DvdLanguage { Code = "da", Name = "Dansk" },
                new DvdLanguage { Code = "de", Name = "Deutsch" },
                new DvdLanguage { Code = "dz", Name = "Bhutani" },
                new DvdLanguage { Code = "el", Name = "Greek" },
                new DvdLanguage { Code = "en", Name = "English" },

                new DvdLanguage { Code = "eo", Name = "Esperanto" },
                new DvdLanguage { Code = "es", Name = "Espanol" },
                new DvdLanguage { Code = "et", Name = "Estonian" },
                new DvdLanguage { Code = "eu", Name = "Basque" },
                new DvdLanguage { Code = "fa", Name = "Persian" },

                new DvdLanguage { Code = "fi", Name = "Suomi" },
                new DvdLanguage { Code = "fj", Name = "Fiji" },
                new DvdLanguage { Code = "fo", Name = "Faroese" },
                new DvdLanguage { Code = "fr", Name = "Francais" },
                new DvdLanguage { Code = "fy", Name = "Frisian" },
                new DvdLanguage { Code = "ga", Name = "Gaelic" },

                new DvdLanguage { Code = "gd", Name = "Scots Gaelic" },
                new DvdLanguage { Code = "gl", Name = "Galician" },
                new DvdLanguage { Code = "gn", Name = "Guarani" },
                new DvdLanguage { Code = "gu", Name = "Gujarati" },
                new DvdLanguage { Code = "ha", Name = "Hausa" },

                new DvdLanguage { Code = "he", Name = "Hebrew" },
                new DvdLanguage { Code = "hi", Name = "Hindi" },
                new DvdLanguage { Code = "hr", Name = "Hrvatski" },
                new DvdLanguage { Code = "hu", Name = "Magyar" },
                new DvdLanguage { Code = "hy", Name = "Armenian" },

                new DvdLanguage { Code = "ia", Name = "Interlingua" },
                new DvdLanguage { Code = "id", Name = "Indonesian" },
                new DvdLanguage { Code = "ie", Name = "Interlingue" },
                new DvdLanguage { Code = "ik", Name = "Inupiak" },
                new DvdLanguage { Code = "in", Name = "Indonesian" },

                new DvdLanguage { Code = "is", Name = "Islenska" },
                new DvdLanguage { Code = "it", Name = "Italiano" },
                new DvdLanguage { Code = "iu", Name = "Inuktitut" },
                new DvdLanguage { Code = "iw", Name = "Hebrew" },
                new DvdLanguage { Code = "ja", Name = "Japanese" },

                new DvdLanguage { Code = "ji", Name = "Yiddish" },
                new DvdLanguage { Code = "jw", Name = "Javanese" },
                new DvdLanguage { Code = "ka", Name = "Georgian" },
                new DvdLanguage { Code = "kk", Name = "Kazakh" },
                new DvdLanguage { Code = "kl", Name = "Greenlandic" },

                new DvdLanguage { Code = "km", Name = "Cambodian" },
                new DvdLanguage { Code = "kn", Name = "Kannada" },
                new DvdLanguage { Code = "ko", Name = "Korean" },
                new DvdLanguage { Code = "ks", Name = "Kashmiri" },
                new DvdLanguage { Code = "ku", Name = "Kurdish" },

                new DvdLanguage { Code = "ky", Name = "Kirghiz" },
                new DvdLanguage { Code = "la", Name = "Latin" },
                new DvdLanguage { Code = "ln", Name = "Lingala" },
                new DvdLanguage { Code = "lo", Name = "Laothian" },
                new DvdLanguage { Code = "lt", Name = "Lithuanian" },

                new DvdLanguage { Code = "lv", Name = "Latvian, Lettish" },
                new DvdLanguage { Code = "mg", Name = "Malagasy" },
                new DvdLanguage { Code = "mi", Name = "Maori" },
                new DvdLanguage { Code = "mk", Name = "Macedonian" },
                new DvdLanguage { Code = "ml", Name = "Malayalam" },

                new DvdLanguage { Code = "mn", Name = "Mongolian" },
                new DvdLanguage { Code = "mo", Name = "Moldavian" },
                new DvdLanguage { Code = "mr", Name = "Marathi" },
                new DvdLanguage { Code = "ms", Name = "Malay" },
                new DvdLanguage { Code = "mt", Name = "Maltese" },

                new DvdLanguage { Code = "my", Name = "Burmese" },
                new DvdLanguage { Code = "na", Name = "Nauru" },
                new DvdLanguage { Code = "ne", Name = "Nepali" },
                new DvdLanguage { Code = "nl", Name = "Nederlands" },
                new DvdLanguage { Code = "no", Name = "Norsk" },
                new DvdLanguage { Code = "oc", Name = "Occitan" },

                new DvdLanguage { Code = "om", Name = "Oromo" },
                new DvdLanguage { Code = "or", Name = "Oriya" },
                new DvdLanguage { Code = "pa", Name = "Punjabi" },
                new DvdLanguage { Code = "pl", Name = "Polish" },
                new DvdLanguage { Code = "ps", Name = "Pashto, Pushto" },

                new DvdLanguage { Code = "pt", Name = "Portugues" },
                new DvdLanguage { Code = "qu", Name = "Quechua" },
                new DvdLanguage { Code = "rm", Name = "Rhaeto-Romance" },
                new DvdLanguage { Code = "rn", Name = "Kirundi" },
                new DvdLanguage { Code = "ro", Name = "Romanian" },

                new DvdLanguage { Code = "ru", Name = "Russian" },
                new DvdLanguage { Code = "rw", Name = "Kinyarwanda" },
                new DvdLanguage { Code = "sa", Name = "Sanskrit" },
                new DvdLanguage { Code = "sd", Name = "Sindhi" },
                new DvdLanguage { Code = "sg", Name = "Sangho" },

                new DvdLanguage { Code = "sh", Name = "Serbo-Croatian" },
                new DvdLanguage { Code = "si", Name = "Sinhalese" },
                new DvdLanguage { Code = "sk", Name = "Slovak" },
                new DvdLanguage { Code = "sl", Name = "Slovenian" },
                new DvdLanguage { Code = "sm", Name = "Samoan" },

                new DvdLanguage { Code = "sn", Name = "Shona" },
                new DvdLanguage { Code = "so", Name = "Somali" },
                new DvdLanguage { Code = "sq", Name = "Albanian" },
                new DvdLanguage { Code = "sr", Name = "Serbian" },
                new DvdLanguage { Code = "ss", Name = "Siswati" },

                new DvdLanguage { Code = "st", Name = "Sesotho" },
                new DvdLanguage { Code = "su", Name = "Sundanese" },
                new DvdLanguage { Code = "sv", Name = "Svenska" },
                new DvdLanguage { Code = "sw", Name = "Swahili" },
                new DvdLanguage { Code = "ta", Name = "Tamil" },

                new DvdLanguage { Code = "te", Name = "Telugu" },
                new DvdLanguage { Code = "tg", Name = "Tajik" },
                new DvdLanguage { Code = "th", Name = "Thai" },
                new DvdLanguage { Code = "ti", Name = "Tigrinya" },
                new DvdLanguage { Code = "tk", Name = "Turkmen" },
                new DvdLanguage { Code = "tl", Name = "Tagalog" },

                new DvdLanguage { Code = "tn", Name = "Setswana" },
                new DvdLanguage { Code = "to", Name = "Tonga" },
                new DvdLanguage { Code = "tr", Name = "Turkish" },
                new DvdLanguage { Code = "ts", Name = "Tsonga" },
                new DvdLanguage { Code = "tt", Name = "Tatar" },
                new DvdLanguage { Code = "tw", Name = "Twi" },

                new DvdLanguage { Code = "ug", Name = "Uighur" },
                new DvdLanguage { Code = "uk", Name = "Ukrainian" },
                new DvdLanguage { Code = "ur", Name = "Urdu" },
                new DvdLanguage { Code = "uz", Name = "Uzbek" },
                new DvdLanguage { Code = "vi", Name = "Vietnamese" },

                new DvdLanguage { Code = "vo", Name = "Volapuk" },
                new DvdLanguage { Code = "wo", Name = "Wolof" },
                new DvdLanguage { Code = "xh", Name = "Xhosa" },
                new DvdLanguage { Code = "yi", Name = "Yiddish" },
                new DvdLanguage { Code = "yo", Name = "Yoruba" },
                new DvdLanguage { Code = "za", Name = "Zhuang" },

                new DvdLanguage { Code = "zh", Name = "Chinese" },
                new DvdLanguage { Code = "zu", Name = "Zulu" },
                new DvdLanguage { Code = "xx", Name = "Unknown" },
                new DvdLanguage { Code = "\0", Name = "Unknown" },
            };
        }

        /// <summary>
        /// Returns a DVD Language from list of supported languages which matches the supplied language code
        /// </summary>
        /// <param name="code">The language code to look for</param>
        /// <returns>The <see cref="DvdLanguage"/></returns>
        public DvdLanguage GetLanguageFromCode(string code)
        {
            this._searchCode = code;
            return _langList.Find(LangCodeMatch);
        }

        /// <summary>
        /// The search predicate for language code lookup
        /// </summary>
        /// <param name="dvdLanguage"></param>
        /// <returns></returns>
        private bool LangCodeMatch(DvdLanguage dvdLanguage)
        {
            return dvdLanguage.Code == this._searchCode;
        }

        /// <summary>
        /// Returns a DVD Language from list of supported languages which matches the supplied language name
        /// </summary>
        /// <param name="name">The language name to look for</param>
        /// <returns>The <see cref="DvdLanguage"/></returns>
        public DvdLanguage GetLanguageFromName(string name)
        {
            this._searchLang = name;
            return _langList.Find(LangNameMatch);
        }

        /// <summary>
        /// The search predicate for language name lookup
        /// </summary>
        /// <param name="dvdLanguage"></param>
        /// <returns></returns>
        private bool LangNameMatch(DvdLanguage dvdLanguage)
        {
            return dvdLanguage.Name == this._searchLang;
        }
    }
}
