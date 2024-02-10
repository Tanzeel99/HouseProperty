using AutoMapper;
using HousePropertyUI.Model;
using HousePropertyUI.Model.DTO;
using HousePropertyUI.Model.DTO.Property;
using HousePropertyUI.Services.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HousePropertyUI.Controllers
{
    public class PropertyController : Controller
    {
        private readonly IPropertyService propertyService;
        private readonly IMapper mapper;

        public PropertyController(IPropertyService _propertyService, IMapper _mapper)
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
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PropertyDTOCreate obj)
        {
            if (ModelState.IsValid)
            {
                var response = await propertyService.CreateAsync<APIResponse>(obj);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(obj);
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (id == 0)
            {
                return BadRequest(ModelState);
            }
            var response = await propertyService.GetAsync<APIResponse>(id);
            if (response != null && response.IsSuccess)
            {
                var data = JsonConvert.DeserializeObject<PropertyDTO>(Convert.ToString(response.Result));
                return View(mapper.Map<PropertyDTOUpdate>(data));
            }
            return NotFound();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PropertyDTOUpdate obj)
        {
            if (ModelState.IsValid)
            {
                var response = await propertyService.UpdateAsync<APIResponse>(obj);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(obj);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest(ModelState);
            }
            var response = await propertyService.GetAsync<APIResponse>(id);
            if (response != null && response.IsSuccess)
            {
                var data = JsonConvert.DeserializeObject<PropertyDTO>(Convert.ToString(response.Result));
                return View(data);
            }
            return NotFound();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(PropertyDTO obj)
        {
            var response = await propertyService.DeleteAsync<APIResponse>(obj.Id);
            if (response != null && response.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            return View(obj);
        }
    }
}
