using System.Data;
using System.Data.SqlClient;

namespace CSG.Data.Extensions
{
    public static class SqlCommandExt
    {
        public static void AddSqlParameters(this SqlCommand sqlCommand, SqlCommand cmd)
        {
            if (!IsParametersRequired(cmd))
                return;

            var errMessageParam = new SqlParameter("@errorMessage", SqlDbType.VarChar, 300);
            errMessageParam.Direction = ParameterDirection.Output;

            var errNumberParam = new SqlParameter("@errorNumber", SqlDbType.VarChar, 10);
            errNumberParam.Direction = ParameterDirection.Output;

            var errSeverityParam = new SqlParameter("@errorSeverity", SqlDbType.VarChar, 100);
            errSeverityParam.Direction = ParameterDirection.Output;

            var errStateParam = new SqlParameter("@errorState", SqlDbType.VarChar, 100);
            errStateParam.Direction = ParameterDirection.Output;

            var errProcedureParam = new SqlParameter("@errorProcedure", SqlDbType.VarChar, 100);
            errProcedureParam.Direction = ParameterDirection.Output;

            var errLineParam = new SqlParameter("@errorLine", SqlDbType.VarChar, 100);
            errLineParam.Direction = ParameterDirection.Output;

            cmd.Parameters.Add(errMessageParam);
            cmd.Parameters.Add(errNumberParam);
            cmd.Parameters.Add(errSeverityParam);
            cmd.Parameters.Add(errStateParam);
            cmd.Parameters.Add(errProcedureParam);
            cmd.Parameters.Add(errLineParam);
        }

        private static bool IsParametersRequired(SqlCommand cmd)
        {
            var sp = cmd.CommandText;
            var results = sp.Split('_');

            return !results[1].ToUpper().StartsWith("GET");
        }
    }
}
