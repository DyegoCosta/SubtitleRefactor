using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace SubRefactor.Library.Languages
{
    public class MicrosoftServiceLanguages
    {
        public IEnumerable GetLanguages()
        {
            var languages = new Dictionary<string, string>();

                        languages.Add("Arabic","ar");
            languages.Add("Czech","cs");
            languages.Add("Danish","da");
            languages.Add("German","de");
            languages.Add("English","en");
            languages.Add("Estonian","et");
            languages.Add("Finnish","fi");
            languages.Add("French","fr");
            languages.Add("Dutch","nl");
            languages.Add("Greek","el");
            languages.Add("Hebrew","he");
            languages.Add("Haitian Creole","ht");
            languages.Add("Hungarian","hu");
            languages.Add("Indonesian","id");
            languages.Add("Italian","it");
            languages.Add("Japanese","ja");
            languages.Add("Korean","ko");
            languages.Add("Lithuanian","lt");
            languages.Add("Latvian","lv");
            languages.Add("Norwegian","no");
            languages.Add("Polish","pl");
            languages.Add("Portuguese","pt");
            languages.Add("Romanian","ro");
            languages.Add("Spanish","es");
            languages.Add("Russian","ru");
            languages.Add("Slovak","sk");
            languages.Add("Slovene","sl");
            languages.Add("Swedish","sv");
            languages.Add("Thai","th");
            languages.Add("Turkish","tr");
            languages.Add("Ukrainian","uk");
            languages.Add("Vietnamese","vi");
            languages.Add("Simplified Chinese","zh-CHS");
            languages.Add("Traditional Chinese","zh-CHT");

            return languages.ToList();
        }
    }
}
