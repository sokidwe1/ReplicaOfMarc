
using Business.DTO.ValidationAttribute;

namespace Business.DTO.Request
{
    public class ClientRequestDTO
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        [AboveEighteen]
        public DateTimeOffset Dob { get; set; }
    }
}
