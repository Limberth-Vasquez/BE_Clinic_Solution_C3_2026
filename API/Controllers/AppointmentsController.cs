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
        public ApiResponse CreateAppointment(Appointment dto)
        {
            var response = new ApiResponse();
            try
            {
                response.Data = _appointmentManager.CreateAppointment(dto);
                response.Result = "ok";
            }
            catch (Exception ex)
            {
                response.Result = "error";
                response.Message = ex.Message + " " + ex.InnerException?.Message;
            }
            return response;
        }
        [HttpGet("ObtenerCitasPorPaciente")]
        public ApiResponse GetAppointmentByPatientId(int patientId)
        {

            var response = new ApiResponse();
            try
            {
                response.Data = _appointmentManager.GetAppointmentsByPatientId(patientId);
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
