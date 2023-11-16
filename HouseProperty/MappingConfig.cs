using AutoMapper;
using HouseProperty.Model;
using HouseProperty.Model.DTO;
using HouseProperty.Model.DTO.Property;

namespace HouseProperty
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Property, PropertyDTO>();
            CreateMap<PropertyDTO, Property>();

            CreateMap<Property, PropertyDTOCreate>().ReverseMap();
            CreateMap<Property, PropertyDTOUpdate>().ReverseMap();


            /*CreateMap<PropertyNumber, PropertyNumberDTO>().ReverseMap();
            CreateMap<PropertyNumber, PropertyNumberDTOCreate>().ReverseMap();
            CreateMap<PropertyNumber, PropertyNumberDTOUpdate>().ReverseMap();
            CreateMap<ApplicationUser, UserDTO>().ReverseMap();*/
        }
    }
}