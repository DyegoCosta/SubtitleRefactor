using System.Collections.Generic;
using System.Linq;
using System.Collections;

namespace SubRefactor.Library.Languages
{
    public class ServicesLanguages
    {
        public IList GetBingLanguages()
        {
            var languages = new Dictionary<string, string>
                                {
                                    {"Arabic", "ar"},
                                    {"Czech", "cs"},
                                    {"Danish", "da"},
                                    {"German", "de"},
                                    {"English", "en"},
                                    {"Estonian", "et"},
                                    {"Finnish", "fi"},
                                    {"French", "fr"},
                                    {"Dutch", "nl"},
                                    {"Greek", "el"},
                                    {"Hebrew", "he"},
                                    {"Haitian Creole", "ht"},
                                    {"Hungarian", "hu"},
                                    {"Indonesian", "id"},
                                    {"Italian", "it"},
                                    {"Japanese", "ja"},
                                    {"Korean", "ko"},
                                    {"Lithuanian", "lt"},
                                    {"Latvian", "lv"},
                                    {"Norwegian", "no"},
                                    {"Polish", "pl"},
                                    {"Portuguese", "pt"},
                                    {"Romanian", "ro"},
                                    {"Spanish", "es"},
                                    {"Russian", "ru"},
                                    {"Slovak", "sk"},
                                    {"Slovene", "sl"},
                                    {"Swedish", "sv"},
                                    {"Thai", "th"},
                                    {"Turkish", "tr"},
                                    {"Ukrainian", "uk"},
                                    {"Vietnamese", "vi"},
                                    {"Simplified Chinese", "zh-CHS"},
                                    {"Traditional Chinese", "zh-CHT"}
                                };

            return languages.ToList();
        }

        public IList GetGoogleLanguages()
        {
            var languages = new Dictionary<string, string>
                                {
                                    {"Afrikaans", "af"},
                                    {"Albanian", "sq"},
                                    {"Arabic", "ar"},
                                    {"Belarusian", "be"},
                                    {"Bulgarian", "bg"},
                                    {"Catalan", "ca"},
                                    {"Chinese Simplified", "zh-CN"},
                                    {"Chinese Traditional", "zh-TW"},
                                    {"Croatian", "hr"},
                                    {"Czech", "cs"},
                                    {"Danish", "da"},
                                    {"Dutch", "nl"},
                                    {"English", "en"},
                                    {"Estonian", "et"},
                                    {"Filipino", "tl"},
                                    {"Finnish", "fi"},
                                    {"French", "fr"},
                                    {"Galician", "gl"},
                                    {"German", "de"},
                                    {"Greek", "el"},
                                    {"Haitian Creole", "ht"},
                                    {"Hebrew", "iw"},
                                    {"Hindi", "hi"},
                                    {"Hungarian", "hu"},
                                    {"Icelandic", "is"},
                                    {"Indonesian", "id"},
                                    {"Irish", "ga"},
                                    {"Italian", "it"},
                                    {"Japanese", "ja"},
                                    {"Latvian", "lv"},
                                    {"Lithuanian", "lt"},
                                    {"Macedonian", "mk"},
                                    {"Malay", "ms"},
                                    {"Maltese", "mt"},
                                    {"Norwegian", "no"},
                                    {"Persian", "fa"},
                                    {"Polish", "pl"},
                                    {"Portuguese", "pt"},
                                    {"Romanian", "ro"},
                                    {"Russian", "ru"},
                                    {"Serbian", "sr"},
                                    {"Slovak", "sk"},
                                    {"Slovenian", "sl"},
                                    {"Spanish", "es"},
                                    {"Swahili", "sw"},
                                    {"Swedish", "sv"},
                                    {"Thai", "th"},
                                    {"Turkish", "tr"},
                                    {"Ukrainian", "uk"},
                                    {"Vietnamese", "vi"},
                                    {"Welsh", "cy"},
                                    {"Yiddish", "yi"}
                                };

            return languages.ToList();
        }
    }
}
