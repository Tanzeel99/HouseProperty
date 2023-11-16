using AutoMapper;
using Azure;
using HouseProperty.Data;
using HouseProperty.Model;
using HouseProperty.Model.DTO;
using HouseProperty.Model.DTO.Property;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace HouseProperty.Controllers
{
    [Route("api/Property")]
    [ApiController]
    public class PropertyAPIController : ControllerBase
    {
        private readonly dbContext db;
        private readonly IMapper mapper;

        public PropertyAPIController(dbContext _db, IMapper _mapper)
        {
            db = _db;
            mapper = _mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<PropertyDTO>>> GetProperties()
        {
            IEnumerable<Property> propertyList = await db.Properties.ToListAsync();
            return Ok(mapper.Map<List<PropertyDTO>>(propertyList));
        }

        [HttpGet("{id:int}", Name = "GetProperty")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public  async Task<ActionResult<PropertyDTO>> GetProperty(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var property = await db.Properties.FirstOrDefaultAsync(a => a.Id == id);
            if (property == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<PropertyDTO>(property));
        }

        [HttpPost]
        public async Task<ActionResult<PropertyDTO>> AddProperty([FromBody] PropertyDTOCreate obj)
        {
            if(await db.Properties.FirstOrDefaultAsync(a=>a.Name.ToLower() == obj.Name.ToLower()) != null){
                ModelState.AddModelError("CustomError", "Name already exists");
            }
            if (obj == null)
            {
                return BadRequest();
            }

            Property model = mapper.Map<Property>(obj);

            await db.Properties.AddAsync(model);
            await db.SaveChangesAsync();

            return CreatedAtRoute("GetProperty", new { id = model.Id }, model);
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id:int}", Name = "DeleteVilla")]
        /*[Authorize(Roles = "admin")]*/
        public async Task<ActionResult> DeleteVilla(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }
                var villa = await db.Properties.FirstOrDefaultAsync(u => u.Id == id);
                if (villa == null)
                {
                    return NotFound();
                }
                db.Properties.Remove(villa);
                await db.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                /*_response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };*/

            }
            return NoContent();
        }

        [HttpPut("{id:int}", Name = "UpdateVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PropertyDTO>> UpdateVilla(int id, [FromBody] PropertyDTOUpdate obj)
        {
            try
            {
                if (obj == null || id != obj.Id)
                {
                    return BadRequest();
                }

                Property model = mapper.Map<Property>(obj);

                db.Properties.Update(model);
                await db.SaveChangesAsync();
                /*_response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;*/
                return Ok();
            }
            catch (Exception ex)
            {
                /*_response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };*/
            }
            return Ok();
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
            var property = await db.Properties.FirstOrDefaultAsync(u => u.Id == id);

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
            await db.SaveChangesAsync();
            return NoContent();
        }
    }
}
