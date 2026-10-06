using DataAccess.Crud;
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
            var crud = new PatientCrud();
            return crud.RetrieveAll<Patient>();
        }
    }
}
