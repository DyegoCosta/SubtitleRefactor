using System.Data.Entity;
using SubRefactor.Domain;
using SubRefactor.Repository.Configuration;

namespace SubRefactor.Repository
{
    public class SubRefactorContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserConfiguration());
            
            base.OnModelCreating(modelBuilder);
        }

        public void Commit()
        {
            SaveChanges();
        }

        public void RollBack()
        {
            RollBack();
        }
    }
}
