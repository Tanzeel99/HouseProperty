using AutoMapper;
using HousePropertyUI.Model;
using HousePropertyUI.Model.DTO;
using HousePropertyUI.Model.DTO.Property;
using HousePropertyUI.Model.DTO.PropertyNumber;

namespace HousePropertyUI
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<PropertyDTO, PropertyDTOCreate>().ReverseMap();
            CreateMap<PropertyDTO, PropertyDTOUpdate>().ReverseMap();

            CreateMap<PropertyNumberDTO, PropertyNumberDTOCreate>().ReverseMap();
            CreateMap<PropertyNumberDTO, PropertyNumberDTOUpdate>().ReverseMap();
        }
    }
}