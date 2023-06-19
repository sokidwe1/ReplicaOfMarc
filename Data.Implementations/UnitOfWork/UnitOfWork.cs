using Data.Abstractions.IRepositories;
using Data.Abstractions.IUnitOfWork;
using Data.Implementations.DatabaseContext;
using Data.Implementations.Repositories;


namespace Data.Implementations.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
       
        private readonly DbContextClass _dbContext;
        private bool disposedValue;

        public IClientRepository Clients { get; private set; }
        public UnitOfWork(DbContextClass dbContext)
        {
            _dbContext = dbContext;
            Clients = new ClientRepository(dbContext);
        }

        public async Task<int> Save()
        {
            return await _dbContext.SaveChangesAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~UnitOfWork()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
