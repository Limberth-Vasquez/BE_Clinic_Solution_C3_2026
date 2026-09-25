using Microsoft.Data.SqlClient;

namespace DataAccess.Dao
{
    public class SqlOperation
    {
        public string ProcedureName { get; set; }
        public List<SqlParameter> parameters;

        public SqlOperation() 
        {
            parameters = new List<SqlParameter>();
        }

        public void AddVarcharParam(string parameterName, string parameterValue)
        {
            parameters.Add(new SqlParameter("@" + parameterName, parameterValue));
        }
        public void AddIntParam(string parameterName, int parameterValue)
        {
            parameters.Add(new SqlParameter("@" + parameterName, parameterValue));
        }
        public void AddDatetimeParam(string parameterName, DateTime parameterValue)
        {
            parameters.Add(new SqlParameter("@" + parameterName, parameterValue));
        }
    }
}
