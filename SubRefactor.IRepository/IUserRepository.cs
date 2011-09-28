using SubRefactor.Domain;

namespace SubRefactor.IRepository
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        User FindByLogin(string username);
        bool UserExist(string username);
        bool ValidateUser(User user);
    }
}
