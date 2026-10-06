using AppLogic;
using DTO;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [EnableCors("Demo_Policy")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorManager manager;
        public DoctorsController(IDoctorManager pManager)
        {
            manager = pManager;
        }

        [HttpGet]
        public ApiResponse GetDoctorCorreo()
        {

            var response = new ApiResponse();
            try
            {
                response.Data = manager.GetDoctorCorreo();
                response.Result = "ok";
            }
            catch (Exception ex)
            {
                response.Result = "error";
                response.Message = ex.Message + " " + ex.InnerException?.Message;
            }
            return response;
        }
        [HttpGet]
        public ApiResponse GetDoctor()
        {
            var response = new ApiResponse();
            try
            {
                response.Data = manager.GetDoctor();
                response.Result = "ok";
            }
            catch (Exception ex)
            {
                response.Result = "error";
                response.Message = ex.Message + " " + ex.InnerException?.Message;
            }
            return response;
        }

        [HttpGet]
        public ApiResponse GetAllDoctors()
        {
            var response = new ApiResponse();
            try
            {
                response.Data = manager.GetAllDoctors();
                response.Result = "ok";
            }
            catch (Exception ex)
            {
                response.Result = "error";
                response.Message = ex.Message + " " + ex.InnerException?.Message;
            }
            return response;
        }

        [HttpGet("DemeElDoctorPorSuID")]
        public ApiResponse GetDoctorById(int doctorId)
        {
            var response = new ApiResponse();
            try
            {
                response.Data = manager.GetDoctorById(doctorId);
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
