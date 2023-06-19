using Data.Abstractions.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Abstractions.IUnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IClientRepository Clients { get; }
        Task<int> Save();
    }
}
