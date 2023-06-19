using Business.DTO.Request;


namespace Business.Abstractions
{
    public interface IClientEngine
    {
        Task CreateClient(ClientRequestDTO client);
        Task UpdateClient(int id, ClientRequestDTO client);
    }
}
