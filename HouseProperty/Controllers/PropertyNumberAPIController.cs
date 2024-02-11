using AutoMapper;
using HouseProperty.Data;
using HouseProperty.Model;
using HouseProperty.Model.DTO.Property;
using HouseProperty.Model.DTO.PropertyNumber;
using HouseProperty.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace HouseProperty.Controllers
{
    [Route("api/PropertyNumber")]
    [ApiController]
    public class PropertyNumberAPIController : ControllerBase
    {
        protected APIResponse response;
        internal readonly dbContext db;
        private readonly IMapper mapper;
        private readonly IPropertyNumberRepo repo;
        private readonly IPropertyRepo propertyRepo;
        public PropertyNumberAPIController(dbContext _db, IMapper _mapper, IPropertyNumberRepo _repo, IPropertyRepo _propertyRepo) {
            this.db = _db;
            this.mapper = _mapper;
            this.repo = _repo;
            this.propertyRepo = _propertyRepo;
            this.response = new APIResponse();
        }

        [HttpGet]
        public async Task<ActionResult<APIResponse>> GetAllPropertyNumber()
        {
            try
            {
                IEnumerable<PropertyNumber> propertyNumberlist = await repo.GetAll(includeProperties: "Property");
                response.Result = mapper.Map<List<PropertyNumberDTO>>(propertyNumberlist);
                response.IsSuccess = true;
                response.StatusCode = HttpStatusCode.OK;

                return Ok(response);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessage = new List<string>() { ex.Message };
                return BadRequest(response);
            }
        }


        [HttpGet("{id:int}", Name = "GetPropertyNumber")]
        public async Task<ActionResult<APIResponse>> GetPropertyNumber(int id)
        {
            try
            {
                if(id == 0)
                {
                    return BadRequest();
                }

                var result = await db.PropertyNumbers.FirstOrDefaultAsync(a=>a.PropertyNo.Equals(id));

                if(result == null)
                {
                    return NotFound();
                }

                response.Result = result;
                response.IsSuccess = true;
                response.StatusCode = HttpStatusCode.OK;

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
        public async Task<ActionResult<APIResponse>> AddPropertyNumber([FromBody] PropertyNumberDTOCreate obj)
        {
            try
            {
                if (await repo.Get(a => a.PropertyID == obj.PropertyNo) != null)
                {
                    ModelState.AddModelError("ErrorMessage", "Property No already exists");
                    return BadRequest(ModelState);
                }
                
                if (obj == null)
                {
                    return BadRequest();
                }
                
                if (await propertyRepo.Get(a => a.Id == obj.PropertyID) == null)
                {
                    ModelState.AddModelError("ErrorMessage", "Property ID is Invalid");
                    return BadRequest(ModelState);
                }

                PropertyNumber model = mapper.Map<PropertyNumber>(obj);

                await repo.Create(model);
                response.Result = mapper.Map<PropertyNumberDTO>(model);
                response.StatusCode = HttpStatusCode.Created;
                response.IsSuccess = true;

                return CreatedAtRoute("GetPropertyNumber", new { id = model.PropertyNo}, response);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessage = new List<string>() { ex.Message };
                return BadRequest(response);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<APIResponse>> UpdatePropertyNumber(int id, [FromBody] PropertyNumberDTOUpdate obj)
        {
            try
            {
                if (obj == null || id != obj.PropertyNo)
                {
                    return BadRequest();
                }

                if (await propertyRepo.Get(a => a.Id == obj.PropertyID) == null)
                {
                    ModelState.AddModelError("ErrorMessage", "Property ID is Invalid");
                    return BadRequest(ModelState);
                }

                PropertyNumber model = mapper.Map<PropertyNumber>(obj);

                await repo.Update(model);

                response.Result = model;
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

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<APIResponse>> DeletePropertyNumber(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }
                var propertyNumber = await repo.Get(u => u.PropertyNo == id);
                if (propertyNumber == null)
                {
                    return NotFound();
                }
                await repo.Delete(propertyNumber);

                response.Result = propertyNumber;
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
    }
}
