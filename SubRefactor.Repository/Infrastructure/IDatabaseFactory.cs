using System;

namespace SubRefactor.Repository.Infrastructure
{
    public interface IDatabaseFactory : IDisposable
    {
        SubRefactorContext Get();
    }
}
