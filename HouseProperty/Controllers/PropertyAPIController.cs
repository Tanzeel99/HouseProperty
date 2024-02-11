using AutoMapper;
using Azure;
using HouseProperty.Data;
using HouseProperty.Model;
using HouseProperty.Model.DTO;
using HouseProperty.Model.DTO.Property;
using HouseProperty.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Runtime.InteropServices;

namespace HouseProperty.Controllers
{
    [Route("api/Property")]
    [ApiController]
    public class PropertyAPIController : ControllerBase
    {
        protected APIResponse response;
        private readonly IPropertyRepo repo;
        private readonly IMapper mapper;

        public PropertyAPIController(IPropertyRepo _repo, IMapper _mapper)
        {
            repo = _repo;
            mapper = _mapper;
            this.response = new APIResponse();
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetProperties()
        {
            try
            {
                var propertyList = await repo.GetAll();
                response.Result = mapper.Map<List<PropertyDTO>>(propertyList);
                response.StatusCode = HttpStatusCode.OK;
                response.IsSuccess = true;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessage = new List<string>() { ex.Message };
                return BadRequest(response);
            }
        }

        [HttpGet("{id:int}", Name = "GetProperty")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public  async Task<ActionResult<APIResponse>> GetProperty(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }
                var property = await repo.Get(a => a.Id == id);
                if (property == null)
                {
                    return NotFound();
                }
                response.Result = mapper.Map<PropertyDTO>(property);
                response.StatusCode = HttpStatusCode.OK;
                response.IsSuccess = true;

                return Ok(response);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessage = new List<string>() { ex.Message };
                return BadRequest(response);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> AddProperty([FromBody] PropertyDTOCreate obj)
        {
            try
            {
                if (await repo.Get(a => a.Name.ToLower() == obj.Name.ToLower()) != null)
                {
                    ModelState.AddModelError("ErrorMessage", "Name already exists");
                    return BadRequest(ModelState);
                }
                if (obj == null)
                {
                    return BadRequest();
                }

                Property model = mapper.Map<Property>(obj);

                await repo.Create(model);
                response.Result = mapper.Map<PropertyDTO>(model);
                response.StatusCode = HttpStatusCode.Created;
                response.IsSuccess = true;

                return CreatedAtRoute("GetProperty", new { id = model.Id }, response);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessage = new List<string>() { ex.Message };
                return BadRequest(response);
            }
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id:int}", Name = "DeleteProperty")]
        public async Task<ActionResult> DeleteProperty(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }
                var property = await repo.Get(u => u.Id == id);
                if (property == null)
                {
                    return NotFound();
                }
                await repo.Delete(property);

                response.Result = property;
                response.StatusCode = HttpStatusCode.NoContent;
                response.IsSuccess = true;

                return Ok(response);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessage = new List<string>() { ex.Message };
                return BadRequest(response);

            }
        }

        [HttpPut("{id:int}", Name = "UpdateVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> UpdateVilla(int id, [FromBody] PropertyDTOUpdate obj)
        {
            try
            {
                if (obj == null || id != obj.Id)
                {
                    return BadRequest();
                }

                Property model = mapper.Map<Property>(obj);

                await repo.Update(model);
                
                response.Result = model;
                response.StatusCode = HttpStatusCode.NoContent;
                response.IsSuccess= true;

                return Ok(response);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessage = new List<string>() { ex.Message };
                return BadRequest(response);
            }
        }

        [HttpPatch("{id:int}", Name = "UpdatePartialVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdatePartialVilla(int id, JsonPatchDocument<PropertyDTOUpdate> obj)
        {
            if (obj == null || id == 0)
            {
                return BadRequest();
            }
            var property = await repo.Get(u => u.Id == id, tracked:false);

            PropertyDTOUpdate propertyDTO = mapper.Map<PropertyDTOUpdate>(property);


            if (property == null)
            {
                return BadRequest();
            }
            obj.ApplyTo(propertyDTO, ModelState);

            Property propertyModel = mapper.Map<Property>(propertyDTO);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await repo.Update(propertyModel);
            return NoContent();
        }
    }
}
