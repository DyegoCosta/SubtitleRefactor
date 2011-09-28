using System.Collections.Generic;

namespace SubRefactor.Domain
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }        
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Subtitle> Subtitles { get; set; }
    }
}
