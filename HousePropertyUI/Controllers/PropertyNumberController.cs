using AutoMapper;
using HousePropertyUI.Model;
using HousePropertyUI.Model.DTO.Property;
using HousePropertyUI.Model.DTO.PropertyNumber;
using HousePropertyUI.Models.VM;
using HousePropertyUI.Services;
using HousePropertyUI.Services.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace HousePropertyUI.Controllers
{
    public class PropertyNumberController : Controller
    {
        private readonly IPropertyNumberService propertyNumberService;
        private readonly IPropertyService propertyService;
        private readonly IMapper mapper;

        public PropertyNumberController(IPropertyNumberService _propertyNumberService, IMapper _mapper, IPropertyService _propertyService)
        {
            propertyNumberService = _propertyNumberService;
            mapper = _mapper;
            propertyService = _propertyService;
        }
        public async Task<IActionResult> Index()
        {
            List<PropertyNumberDTO> propertyNumberList = new List<PropertyNumberDTO>();
            var response = await propertyNumberService.GetAllAsync<APIResponse>();
            if (response != null && response.IsSuccess)
            {
                propertyNumberList = JsonConvert.DeserializeObject<List<PropertyNumberDTO>>(Convert.ToString(response.Result));
            }
            return View(propertyNumberList);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            PropertyNumberViewModelCreate propertyNumberViewModelCreate = new PropertyNumberViewModelCreate();
            var response = await propertyService.GetAllAsync<APIResponse>();
            if (response != null && response.IsSuccess)
            {
                propertyNumberViewModelCreate.PropertyList = JsonConvert.DeserializeObject<List<PropertyDTO>>(Convert.ToString(response.Result)).Select(a=> new SelectListItem
                {
                    Text = a.Name,
                    Value = a.Id.ToString(),
                });
            }
            return View(propertyNumberViewModelCreate);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PropertyNumberViewModelCreate obj)
        {
            if (ModelState.IsValid)
            {
                var response = await propertyNumberService.CreateAsync<APIResponse>(obj.PropertyNumber);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    if(response.ErrorMessage.Count > 0)
                    {
                        ModelState.AddModelError("ErrorMessage",response.ErrorMessage.FirstOrDefault());
                    }
                }
            }
            var result = await propertyService.GetAllAsync<APIResponse>();
            if (result != null && result.IsSuccess)
            {
                obj.PropertyList = JsonConvert.DeserializeObject<List<PropertyDTO>>(Convert.ToString(result.Result)).Select(a => new SelectListItem
                {
                    Text = a.Name,
                    Value = a.Id.ToString(),
                });
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
            PropertyNumberViewModelUpdate propertyNumberViewModelUpdate = new PropertyNumberViewModelUpdate();
            var propertyNumberResponse = await propertyNumberService.GetAsync<APIResponse>(id);
            var propertyResponse = await propertyService.GetAllAsync<APIResponse>();
            if (propertyResponse != null && propertyResponse.IsSuccess)
            {
                propertyNumberViewModelUpdate.PropertyList = JsonConvert.DeserializeObject<List<PropertyDTO>>(Convert.ToString(propertyResponse.Result)).Select(a => new SelectListItem
                {
                    Text = a.Name,
                    Value = a.Id.ToString(),
                });
            }
            if (propertyNumberResponse != null && propertyNumberResponse.IsSuccess)
            {
                var data = JsonConvert.DeserializeObject<PropertyNumberDTO>(Convert.ToString(propertyNumberResponse.Result));
                propertyNumberViewModelUpdate.PropertyNumber = mapper.Map<PropertyNumberDTOUpdate>(data);
                return View(propertyNumberViewModelUpdate);
            }
            return NotFound();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PropertyNumberViewModelUpdate obj)
        {
            if (ModelState.IsValid)
            {
                var response = await propertyNumberService.UpdateAsync<APIResponse>(obj.PropertyNumber);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    if (response.ErrorMessage.Count > 0)
                    {
                        ModelState.AddModelError("ErrorMessage", response.ErrorMessage.FirstOrDefault());
                    }
                }
            }
            var result = await propertyService.GetAllAsync<APIResponse>();
            if (result != null && result.IsSuccess)
            {
                obj.PropertyList = JsonConvert.DeserializeObject<List<PropertyDTO>>(Convert.ToString(result.Result)).Select(a => new SelectListItem
                {
                    Text = a.Name,
                    Value = a.Id.ToString(),
                });
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
            PropertyNumberViewModelDelete propertyNumberViewModelDelete = new PropertyNumberViewModelDelete();
            var response = await propertyNumberService.GetAsync<APIResponse>(id);
            if (response != null && response.IsSuccess)
            {
                var data = JsonConvert.DeserializeObject<PropertyNumberDTO>(Convert.ToString(response.Result));
                propertyNumberViewModelDelete.PropertyNumber = data;
                return View(propertyNumberViewModelDelete);
            }
            return NotFound();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(PropertyNumberDTO obj)
        {
            var response = await propertyNumberService.DeleteAsync<APIResponse>(obj.PropertyNo);
            if (response != null && response.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            return View(obj);
        }
    }
}
