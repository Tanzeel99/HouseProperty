using AutoMapper;
using HouseProperty.Model;
using HouseProperty.Model.DTO;
using HouseProperty.Model.DTO.Property;
using HouseProperty.Model.DTO.PropertyNumber;

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


            CreateMap<PropertyNumber, PropertyNumberDTO>().ReverseMap();
            CreateMap<PropertyNumberDTO, PropertyNumber>().ReverseMap();
            CreateMap<PropertyNumber, PropertyNumberDTOCreate>().ReverseMap();
            CreateMap<PropertyNumber, PropertyNumberDTOUpdate>().ReverseMap();
            //CreateMap<ApplicationUser, UserDTO>().ReverseMap();
        }
    }
}