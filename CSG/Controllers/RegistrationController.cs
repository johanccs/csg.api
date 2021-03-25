using CSG.Api.Commands;
using CSG.Data.DataEntities;
using CSG.Interfaces.BaseRepo;
using Microsoft.AspNetCore.Mvc;
using System;

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
        public IActionResult GetRegistrations()
        {
            try
            {
                var result = _dbContext.GetAllAsync();

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
        public IActionResult PostRegistration(RegistrationCommand.V1.Requests request)
        {
            try
            {
                foreach (var req in request.Collection)
                {
                    var registration = MapToEntity(req);
                    _dbContext.InsertEntityAsync(registration);
                }

                return Ok(0);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult DeleteAllregistrations()
        {
            try
            {
                _dbContext.DeleteAllAsync();

                return Ok("Registrations deleted");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult DeleteRegistrationById(string id)
        {
            try
            {
                _dbContext.DeleteByIdAsync(id);

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
                //AttendanceStatusId = request.AttendanceStatusId,
                Grade = request.Grade
            };
        }

        #endregion
    }
}
