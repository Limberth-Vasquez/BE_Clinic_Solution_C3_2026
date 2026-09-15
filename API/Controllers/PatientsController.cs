using DTO;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        [HttpGet("GetPatient2")]
        public string GetPatient2()
        {
            return "Datos del paciente";
        }
        [HttpGet("GetPatient3")]
        public string GetPatient3()
        {
            return "Datos del paciente";
        }
        [HttpGet("GetPatient")]
        public string GetPatient()
        {
            return "Datos del paciente";
        }
        [HttpGet("GetAllPatients")]
        public List<Patient> GetAllPatients()
        {
            var pacientes = new List<Patient>();
            pacientes.Add(new Patient() { Name = "Limberth" });
            pacientes.Add(new Patient() { Name = "Kimberly" });
            pacientes.Add(new Patient() { Name = "Carlos" });
            return pacientes;
        }
        [HttpGet("GetPatientByDoctor")]
        public string GetPatientByDoctor(int doctorId)
        {
            return "Datos del paciente por id de médico: " + doctorId;
        }
    }
}
