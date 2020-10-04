using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class Logger
    {
        public static void Log(Exception exception)
        {
            StringBuilder sbExceptionMessage = new StringBuilder();
            sbExceptionMessage.Append("Exception Type:" + Environment.NewLine);
            sbExceptionMessage.Append(exception.InnerException.GetType().Name);
            sbExceptionMessage.Append(Environment.NewLine + Environment.NewLine);
            sbExceptionMessage.Append("Message:" + Environment.NewLine);
            sbExceptionMessage.Append(exception.InnerException.Message + Environment.NewLine + Environment.NewLine);
            sbExceptionMessage.Append("Stack Trace:" + Environment.NewLine);
            sbExceptionMessage.Append(exception.InnerException.StackTrace + Environment.NewLine + Environment.NewLine);
            LogToDB(sbExceptionMessage.ToString());
        }

        private static void LogToDB(string log)
        {
            using (SqlConnection connection = new SqlConnection(Utilities.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("InsertLog", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    SqlParameter parameter = new SqlParameter("@exceptionMessage", log);
                    command.Parameters.Add(parameter);
                    try
                    {
                        if (connection.State == System.Data.ConnectionState.Closed)
                        {
                            connection.Open();
                            command.ExecuteNonQuery();
                            connection.Close();
                        }
                    }
                    catch (SqlException ex)
                    {
                    }

                    finally
                    {
                        if (connection.State == System.Data.ConnectionState.Open)
                        {
                            connection.Close();
                        }
                    }
                }
            }
        }
    }
}
