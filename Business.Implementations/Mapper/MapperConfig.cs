using AutoMapper;
using Business.DTO.Request;
using Business.DTO.Response;
using Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Implementations.Mapper
{
    public class MapperConfig : Profile
    {
        public MapperConfig() 
        {
            CreateMap<ClientRequestDTO, Client>()
                .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.Dob));

            CreateMap<Client, ClientResponseDTO>();
        }   
    }
}
