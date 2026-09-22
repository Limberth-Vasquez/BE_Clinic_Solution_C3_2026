using AppLogic;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
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
        public string GetDoctorCorreo()
        {
            return manager.GetDoctorCorreo();
        }
        [HttpGet]
        public string GetDoctor()
        {
            return manager.GetDoctor();
        }

        [HttpGet]
        public string GetAllDoctors()
        {
            return manager.GetAllDoctors();
        }

        [HttpGet("DemeElDoctorPorSuID")]
        public string GetDoctorById(int doctorId)
        {
            return manager.GetDoctorById(doctorId);
        }
    }
}
