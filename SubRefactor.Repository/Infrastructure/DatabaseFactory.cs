using System;

namespace SubRefactor.Repository.Infrastructure
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private SubRefactorContext _dataContext;

        public SubRefactorContext Get()
        {
            return _dataContext ?? (_dataContext = new SubRefactorContext());
        }

        protected override void DisposeCore()
        {
            if (_dataContext != null)
                _dataContext.Dispose();
        }
    }

    public class Disposable : IDisposable
    {
        private bool isDisposed;

        ~Disposable()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private void Dispose(bool disposing)
        {
            if (!isDisposed && disposing)
            {
                DisposeCore();
            }

            isDisposed = true;
        }

        protected virtual void DisposeCore()
        {
        }
    }
}
