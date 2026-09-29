using AppLogic;
using DTO;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientManager manager;
        public PatientsController(IPatientManager pmanager)
        {
            manager = pmanager;
        }

        [HttpGet("GetPatient")]
        public ApiResponse GetPatient()
        {
            var response = new ApiResponse();
            try
            {
                response.Data = manager.GetPatient();
                response.Result = "ok";
            }
            catch (Exception ex)
            {
                response.Result = "error";
                response.Message = ex.Message + " " + ex.InnerException?.Message;
            }
            return response;
        }
        [HttpGet("GetAllPatients")]
        public ApiResponse GetAllPatients()
        {
            var response = new ApiResponse();
            try
            {
                response.Data = manager.GetAllPatients();
                response.Result = "ok";
            }
            catch (Exception ex)
            {
                response.Result = "error";
                response.Message = ex.Message + " " + ex.InnerException?.Message;
            }
            return response;
        }
        [HttpGet("GetPatientByDoctor")]
        public ApiResponse GetPatientByDoctor(int doctorId)
        {
            var response = new ApiResponse();
            try
            {
                response.Data = manager.GetPatientByDoctor(doctorId);
                response.Result = "ok";
            }
            catch (Exception ex)
            {
                response.Result = "error";
                response.Message = ex.Message + " " + ex.InnerException?.Message;
            }
            return response;
        }
    }
}
