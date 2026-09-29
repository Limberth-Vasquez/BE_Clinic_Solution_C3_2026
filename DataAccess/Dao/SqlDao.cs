using Microsoft.Data.SqlClient;

namespace DataAccess.Dao
{
    public class SqlDao
    {
        private string connectionString = "server=limberth\\MSSQLSERVER01;Database=Clinic_Solution_C3_2026;Trusted_Connection=True;TrustServerCertificate=True;";

        //singleton instance
        private static SqlDao? instance;

        public static SqlDao GetInstance() 
        {
            if (instance == null)
            {
                instance = new SqlDao();
            }
            return instance;
        }
        /*
        C  --> void
        R -->Result
        U --> void
        D --> void
         */

        // CREATE UPDATE y DELETE
        public void ExecuteStoredProcedure(SqlOperation pOperation) 
        {
            try
            {

                SqlConnection conn = new SqlConnection(connectionString);

                SqlCommand cmd = conn.CreateCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = pOperation.ProcedureName;

                foreach (SqlParameter param in pOperation.parameters)
                {
                    cmd.Parameters.Add(param);
                }

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //SELECT
        public List<Dictionary<string, object>> ExecuteStoredProcedureWithQuery(SqlOperation pOperation)
        {
            try
            {
                var listResults = new List<Dictionary<string, object>>();
                SqlConnection conn = new SqlConnection(connectionString);

                SqlCommand cmd = conn.CreateCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = pOperation.ProcedureName;

                foreach (SqlParameter param in pOperation.parameters)
                {
                    cmd.Parameters.Add(param);
                }

                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read()) 
                    {
                        var rowDictionary = new Dictionary<string, object>();
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            rowDictionary.Add(reader.GetName(i), reader.GetValue(i));
                        }
                        listResults.Add(rowDictionary);
                    }
                }

                conn.Close();

                return listResults;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
