using AutoMapper;
using HousePropertyUI.Services.IService;
using HousePropertyUI.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using HousePropertyUI.Model.DTO.Property;
using HousePropertyUI.Model;

namespace HousePropertyUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPropertyService propertyService;
        private readonly IMapper mapper;

        public HomeController(IPropertyService _propertyService, IMapper _mapper)
        {
            propertyService = _propertyService;
            mapper = _mapper;
        }
        public async Task<IActionResult> Index()
        {
            List<PropertyDTO> propertyList = new List<PropertyDTO>();
            var response = await propertyService.GetAllAsync<APIResponse>();
            if (response != null && response.IsSuccess)
            { 
                propertyList = JsonConvert.DeserializeObject<List<PropertyDTO>>(Convert.ToString(response.Result));
            }
            return View(propertyList);
        }
    }
}
