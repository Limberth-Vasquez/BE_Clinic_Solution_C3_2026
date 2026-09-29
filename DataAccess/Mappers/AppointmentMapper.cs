using DataAccess.Dao;
using DataAccess.Mappers.Interfaces;
using DTO;

namespace DataAccess.Mappers
{
    public class AppointmentMapper : ICrudStatements
    {
        public SqlOperation GetCreateStatement(BaseClass dto)
        {
            var appointment = (Appointment)dto;

            var operation = new SqlOperation();
            operation.ProcedureName = "SP_INSERT_APPOINTMENT";
            operation.AddIntParam("patientid", appointment.PatientId);
            operation.AddDatetimeParam("date", appointment.AppointmentDate);
            operation.AddVarcharParam("title", appointment.Title);
            operation.AddVarcharParam("specialty", appointment.Speciality);
            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseClass dto)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetRetrieveAllStatement()
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetRetrieveByIdStatement(int pId)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetUpdateStatement(BaseClass dto)
        {
            throw new NotImplementedException();
        }
    }
}
