using Data.Abstractions.IRepositories;
using Data.Implementations.DatabaseContext;
using Schema;

namespace Data.Implementations.Repositories
{
    public class ClientRepository:GenericRepository<Client>, IClientRepository
    {
        public ClientRepository(DbContextClass context):base(context)
        {
            
        }
    }
}
