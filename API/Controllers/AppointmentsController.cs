using AppLogic;
using DTO;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentManager _appointmentManager;

        public AppointmentsController(IAppointmentManager appointmentManager)
        {
            _appointmentManager = appointmentManager;
        }

        [HttpPost("CrearCita")]
        public string CreateAppointment(Appointment dto)
        {
            return _appointmentManager.CreateAppointment(dto);
        }
        [HttpGet("ObtenerCitasPorPaciente")]
        public List<Appointment> GetAppointmentByPatientId(int patientId)
        {
            return _appointmentManager.GetAppointmentsByPatientId(patientId);
        }
    }
}
