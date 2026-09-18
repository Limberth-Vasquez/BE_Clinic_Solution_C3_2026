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
        public string GetPatient()
        {
            return manager.GetPatient();
        }
        [HttpGet("GetAllPatients")]
        public List<Patient> GetAllPatients()
        {
            return manager.GetAllPatients();
        }
        [HttpGet("GetPatientByDoctor")]
        public string GetPatientByDoctor(int doctorId)
        {
            return manager.GetPatientByDoctor(doctorId);
        }
    }
}
