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
    public class TeacherController : ControllerBase
    {
        #region ReadOnly Fields

        private readonly IBaseRepo<Teacher, string> _dbContext;

        #endregion

        #region Constructor

        public TeacherController(IBaseRepo<Teacher, string> dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion

        #region Methods

        [HttpGet]
        public async Task<IActionResult> GetTeachers()
        {
            try
            {
                var result = await _dbContext.GetAllAsync();

                if (result == null)
                    return NotFound("No teacher records found");
                else
                    return Ok(result);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("PostNewTeacher")]       
        public async Task<IActionResult> PostTeacher(TeacherCommand.V1.Request teacherCommand)
        {
            try
            {
                if (teacherCommand == null)
                {
                    return StatusCode(500, "Invalid Parameter");
                }

                var teacher = MapToEntity(teacherCommand);
                await _dbContext.InsertEntityAsync(teacher);

                return Ok(new { teacher.Id, StatusCode=200 });
            }
            catch (Exception ex)
            {
                return StatusCode(500,ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAllTeachers()
        {
            try
            {
                await _dbContext.DeleteAllAsync();

                return Ok("Teachers deleted");
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTeacherById(string id)
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

        private Teacher MapToEntity(TeacherCommand.V1.Request request)
        {
            return new Teacher(Guid.NewGuid().ToString())
            {
                DateRegistered = Convert.ToDateTime(request.DateRegistered),
                Name = request.Name,
                Surname = request.Surname
            };
        }

        #endregion

    }
}
