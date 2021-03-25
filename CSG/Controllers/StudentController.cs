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
    public class StudentController : ControllerBase
    {
        #region ReadOnly Fields

        private readonly IBaseRepo<Student,string> _dbContext;

        #endregion

        #region Constructor

        public StudentController(IBaseRepo<Student,string> dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion

        #region Methods

        [HttpGet]
        public IActionResult GetStudents()
        {
            try
            {
                var result = _dbContext.GetAllAsync();

                if (result == null)
                    return NotFound("No student records found");
                else
                    return Ok(result);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult PostStudent(StudentCommand.V1.Request request)
        {
            try
            {
                var student = MapToEntity(request);
                 _dbContext.InsertEntityAsync(student);

                return Ok(new { student.Id, StatusCode = 200 });
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult DeleteAllStudents()
        {
            try
            {
                _dbContext.DeleteAllAsync();

                return Ok("Students deleted");
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult DeleteStudentById(string id)
        {
            try
            {
                _dbContext.DeleteByIdAsync(id);

                return Ok(id);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion

        #region Private Methods

        private Student MapToEntity(StudentCommand.V1.Request request)
        {
            return new Student(Guid.NewGuid().ToString())
            {
                Name = request.Name,
                Surname = request.Surname,
                DateRegistered = Convert.ToDateTime(request.DateRegistered)
            };
        }

        #endregion
    }
}
