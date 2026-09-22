namespace AppLogic
{
    public interface IDoctorManager
    {
        string GetDoctorCorreo();
        string GetDoctor();
        string GetAllDoctors();
        string GetDoctorById(int doctorId);
    }
    public class DoctorManager : IDoctorManager
    {
        public string GetDoctorCorreo()
        {
            return "Datos del médico";
        }
        public string GetDoctor()
        {
            return "Datos del médico";
        }

        public string GetAllDoctors()
        {
            return "Datos de todos los médicos";
        }

        public string GetDoctorById(int doctorId)
        {
            return "Datos del médico por ID: " + doctorId;
        }
    }
}
