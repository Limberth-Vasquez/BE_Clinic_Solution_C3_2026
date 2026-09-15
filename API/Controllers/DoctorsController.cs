using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        [HttpGet]
        public string GetDoctorCorreo()
        {
            return "Datos del médico";
        }
        [HttpGet]
        public string GetDoctor()
        {
            return "Datos del médico";
        }

        [HttpGet]
        public string GetAllDoctors()
        {
            return "Datos de todos los médicos";
        }

        [HttpGet("DemeElDoctorPorSuID")]
        public string GetDoctorById(int doctorId)
        {
            return "Datos del médico por ID: " + doctorId;
        }
    }
}
