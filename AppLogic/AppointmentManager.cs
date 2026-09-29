using DataAccess.Crud;
using DTO;

namespace AppLogic
{
    public interface IAppointmentManager 
    {
        string CreateAppointment(Appointment dto);
        List<Appointment> GetAppointmentsByPatientId(int patientId);
    }
    public class AppointmentManager : IAppointmentManager
    {
        public string CreateAppointment(Appointment dto)
        {
            var appointmentCrud = new AppointmentCrud();
            appointmentCrud.Create(dto);
            return "Cita registrada de manera correcta";
        }

        public List<Appointment> GetAppointmentsByPatientId(int patientId)
        {
            var appointmentCrud = new AppointmentCrud();
            return appointmentCrud.RetrieveAllByPatientId<Appointment>(patientId);
        }
    }
}
