using DataAccess.Dao;
using DataAccess.Mappers.Interfaces;
using DTO;

namespace DataAccess.Mappers
{
    public class PatientMapper : ICrudStatements, IObjectMapper
    {
        public BaseClass BuildObject(Dictionary<string, object> row)
        {
            var patient = new Patient();

            patient.Id = int.Parse(row["Id"].ToString());
            patient.SocialSecurityId = row["SocialSecurityId"].ToString();
            patient.Name = row["Name"].ToString();
            patient.LastName = row["LastName"].ToString();

            return patient;
        }

        public List<BaseClass> BuildObjects(List<Dictionary<string, object>> rows)
        {
            var results = new List<BaseClass>();

            foreach (var row in rows)
            {
                var patient = BuildObject(row);
                results.Add(patient);
            }

            return results;
        }

        public SqlOperation GetCreateStatement(BaseClass dto)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetDeleteStatement(BaseClass dto)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetRetrieveAllStatement()
        {
            var operation = new SqlOperation();
            operation.ProcedureName = "SP_GET_PATIENTS";
            return operation;
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
