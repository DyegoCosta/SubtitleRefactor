namespace SubRefactor.IRepository.Infrastructure
{
    public interface IUnitOfWork
    {
        void Commit();
        void RollBack();
    }
}
