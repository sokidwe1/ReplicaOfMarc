using AutoMapper;
using Business.Abstractions;
using Business.DTO.Request;
using Data.Abstractions.IUnitOfWork;
using Schema;

namespace Business.Implementations
{
    public class ClientEngine : BaseEngine, IClientEngine
    {
        public ClientEngine(IMapper mapper, IUnitOfWork uow) : base(mapper, uow)
        {
        }

        public async Task CreateClient(ClientRequestDTO client)
        {
            var record = _mapper.Map<Client>(client);
            await _uow.Clients.AddAsync(record);
            await _uow.Save();
        }

        public async Task UpdateClient(int id, ClientRequestDTO client)
        {
            var record = _mapper.Map<Client>(client);
            record.Id = id;
            await _uow.Clients.Update(record);
            await _uow.Save();

        }
    }
}
