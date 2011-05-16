using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using SubRefactor.Library;

namespace SubRefactor.Models
{
    public class SubtitleTranslationViewModel
    {
        [Required]
        public HttpPostedFileBase File { get; set; }

        [Required]
        public Translators Translator { get; set; }

        [Required]
        public string FromLanguage { get; set; }
        
        [Required]
        public string ToLanguage { get; set; }
    }
}