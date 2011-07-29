using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SubRefactor.Models
{
    public class SubtitleSynchronizationViewModel
    {
        [Required]
        public HttpPostedFileBase File { get; set; }
        
        [Required]
        public int Delay { get; set; }
    }
}
