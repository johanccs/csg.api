using CSG.Api.Commands;
using CSG.Data.DataEntities;
using CSG.Interfaces.BaseRepo;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CSG.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        #region ReadOnly Fields

        private readonly IBaseRepo<ClassEntity, string> _dbContext;

        #endregion

        #region Constructor
        
        public ClassController(IBaseRepo<ClassEntity, string> dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion

        #region Methods

        [HttpGet]
        public async Task<IActionResult> GetClasses()
        {
            try
            {
                var result = await _dbContext.GetAllAsync();

                if (result == null)
                    return NotFound("No class records found");
                else
                    return Ok(result);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("PostNewClass")]
        public async Task<IActionResult> PostClass(ClassCommand.V1.Request request)
        {
            try
            {
                var classEntity = MapToEntity(request);
                await _dbContext.InsertEntityAsync(classEntity);

                return Ok(new { classEntity.Id, StatusCode = 200 });
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAllClasses()
        {
            try
            {
                await _dbContext.DeleteAllAsync();

                return Ok("Classes deleted");
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteClassById(string id)
        {
            try
            {
                await _dbContext.DeleteByIdAsync(id);

                return Ok(id);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion

        #region Private Methods

        private ClassEntity MapToEntity(ClassCommand.V1.Request classRequest)
        {
            return new ClassEntity(Guid.NewGuid().ToString())
            {
                ClassName = classRequest.ClassName,
                Description = classRequest.Description
            };
        }

        #endregion
    }
}
