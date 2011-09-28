
namespace SubRefactor.IRepository
{
    public interface ISubRefactorContext
    {
        void Commit();
        void RollBack();
    }
}
