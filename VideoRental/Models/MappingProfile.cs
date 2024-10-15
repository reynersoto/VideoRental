using AutoMapper;
using WebMvcPruebaMosh.DTOs;

namespace WebMvcPruebaMosh.Models

{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
           CreateMap<Customer, CustomerDTO>();
           CreateMap<CustomerDTO, Customer>();

           CreateMap<Movies, MovieDTO>();
           CreateMap<MovieDTO,Movies>();

           CreateMap<MembershipTypes,MembershipTypeDTO>().ReverseMap();
           
           CreateMap<Genre, GenreDTO>().ReverseMap();
        }
    }
}
