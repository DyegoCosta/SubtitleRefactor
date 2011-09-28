using System;
using System.Linq;
using SubRefactor.Domain;
using SubRefactor.IRepository;
using SubRefactor.Repository.Infrastructure;

namespace SubRefactor.Repository.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {                        
        }

        public override User Find(Func<User, bool> where)
        {
            return dbSet.Where(where).FirstOrDefault();
        }

        public User FindByLogin(string username)
        {
            return Find(u => u.Username == username);
        }

        public bool UserExist(string username)
        {
            return Count(u => u.Username == username) != 0;
        }

        public bool ValidateUser(User user)
        {         
            return Find(u => u.Username == user.Username && u.Password == user.Password) != null;
        }
    }
}
