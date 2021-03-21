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
    public class RegistrationController : ControllerBase
    {
        #region ReadOnly Fields

        private readonly IBaseRepo<Registration, string> _dbContext;

        #endregion

        #region Constructor

        public RegistrationController(IBaseRepo<Registration, string> dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion

        #region Methods

        [HttpGet]
        public async Task<IActionResult> GetRegistrations()
        {
            try
            {
                var result = await _dbContext.GetAllAsync();

                if (result == null)
                    return NotFound("No registration records found");
                else
                    return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("PostNewRegistration")]
        public async Task<IActionResult> PostRegistration(RegistrationCommand.V1.Request request)
        {
            try
            {
                var registration = MapToEntity(request);
                await _dbContext.InsertEntityAsync(registration);

                return Ok(registration.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAllregistrations()
        {
            try
            {
                await _dbContext.DeleteAllAsync();

                return Ok("Registrations deleted");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteRegistrationById(string id)
        {
            try
            {
                await _dbContext.DeleteByIdAsync(id);

                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion

        #region Private Methods

        private Registration MapToEntity(RegistrationCommand.V1.Request request)
        {
            return new Registration(Guid.NewGuid().ToString())
            {
                StudentId = request.StudentId,
                TeacherId = request.TeacherId,
                ClassId = request.ClassId,
                AttendanceDate = Convert.ToDateTime(request.AttendanceDate),
                AttendanceStatusId = request.AttendanceStatusId,
                Grade = request.Grade
            };
        }

        #endregion
    }
}
