using System.Data.Entity.ModelConfiguration;
using SubRefactor.Domain;

namespace SubRefactor.Repository.Configuration
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            ToTable("Users");
            HasKey(u => u.Id);
            Ignore(u => u.AuthenticationType);
            Property(u => u.AuthenticationTypeId).IsRequired();            
        }    
    }
}
