using DTO;

namespace AppLogic
{
    public interface IPatientManager 
    {
        string GetPatient();
        string GetPatientByDoctor(int doctorId);
        List<Patient> GetAllPatients();
    }
    public class PatientManager : IPatientManager
    {
        public string GetPatient()
        {
            return "Datos del paciente";
        }
        public string GetPatientByDoctor(int doctorId)
        {
            return "Datos del paciente por id de médico: " + doctorId;
        }
        public List<Patient> GetAllPatients()
        {
            var pacientes = new List<Patient>();
            pacientes.Add(new Patient() { Name = "Limberth" });
            pacientes.Add(new Patient() { Name = "Kimberly" });
            pacientes.Add(new Patient() { Name = "Carlos" });
            return pacientes;
        }
    }
}
