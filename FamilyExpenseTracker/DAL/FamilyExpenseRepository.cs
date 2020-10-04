using BO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class FamilyExpenseRepository
    {
        public int AddFamilyExpense(FamilyExpense familyExpense)
        {
            using (SqlConnection connection = new SqlConnection(Utilities.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("AddFamilyExpense", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@name", familyExpense.Name);
                    command.Parameters.AddWithValue("@purpose", familyExpense.Purpose);
                    command.Parameters.AddWithValue("@amount", familyExpense.Amount);
                    command.Parameters.AddWithValue("@date", familyExpense.Date);
                    try
                    {
                        if (connection.State == System.Data.ConnectionState.Closed)
                        {
                            connection.Open();
                            int insertStatus = command.ExecuteNonQuery();
                            return insertStatus;
                        }
                    }

                    catch (SqlException ex)
                    {
                        throw ex;
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
            return 0;
        }

        public int EditFamilyExpense(FamilyExpense familyExpense)
        {
            using (SqlConnection connection = new SqlConnection(Utilities.GetConnectionString()))
            {

                using (SqlCommand command = new SqlCommand("EditFamilyExpense", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@expenseId", familyExpense.ExpenseId);
                    command.Parameters.AddWithValue("@familyMemberId", familyExpense.FamilyMemberId);
                    command.Parameters.AddWithValue("@purpose", familyExpense.Purpose);
                    command.Parameters.AddWithValue("@amount", familyExpense.Amount);
                    command.Parameters.AddWithValue("@date", familyExpense.Date);
                    try
                    {
                        if (connection.State == System.Data.ConnectionState.Closed)
                        {
                            connection.Open();
                            int status = command.ExecuteNonQuery();
                            return status;
                        }
                    }

                    catch(SqlException ex)
                    {
                        throw ex;
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
            return 0;
        }

        public int DeleteFamilyExpense(int expenseId)
        {
            using (SqlConnection connection = new SqlConnection(Utilities.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("DeleteFamilyExpense", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@expenseId", expenseId);
                    try
                    {
                        if (connection.State == System.Data.ConnectionState.Closed)
                        {
                            connection.Open();
                            int status = command.ExecuteNonQuery();
                            return status;
                        }
                    }

                    catch(SqlException ex)
                    {
                        throw ex;
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
            return 0;
        }

        public List<string> GetAllFamilyMemberNames()
        {
            using (SqlConnection connection = new SqlConnection(Utilities.GetConnectionString()))
            {
                using(SqlCommand command = new SqlCommand("GetAllFamilyMemberNames", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    try
                    {
                        if (connection.State == System.Data.ConnectionState.Closed)
                        {
                            connection.Open();
                            List<string> names = new List<string>();
                            names.Add("--Select Name--");
                            SqlDataReader dr = command.ExecuteReader();
                            while (dr.Read())
                            {
                                names.Add(dr["Name"].ToString());
                            }
                            return names;
                        }
                    }

                    catch(SqlException ex)
                    {
                        throw ex;
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
            return null;

        }

        public List<FamilyExpense> GetAllFamilyExpenses()
        {
            using (SqlConnection connection = new SqlConnection(Utilities.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("GetAllFamilyExpenses", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    try
                    {
                        if (connection.State == System.Data.ConnectionState.Closed)
                        {
                            connection.Open();
                            SqlDataReader dr = command.ExecuteReader();
                            List<FamilyExpense> familyExpenses = new List<FamilyExpense>();
                            while (dr.Read())
                            {
                                FamilyExpense familyExpense = new FamilyExpense();
                                familyExpense.ExpenseId = Convert.ToInt32(dr["ExpenseId"]);
                                familyExpense.FamilyMemberId = Convert.ToInt32(dr["FamilyMemberId"]);
                                familyExpense.Name = dr["Name"].ToString();
                                familyExpense.Purpose = dr["Purpose"].ToString();
                                familyExpense.Amount = Convert.ToInt32(dr["Amount"]);
                                familyExpense.Date = Convert.ToDateTime(dr["DateTime"]);
                                familyExpenses.Add(familyExpense);
                            }
                            return familyExpenses;
                        }
                    }

                    catch(SqlException ex)
                    {
                        throw ex;
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
            return null;
        }

        public List<FamilyExpense> GetAllFamilyExpensesByName(string name)
        {
            using (SqlConnection connection = new SqlConnection(Utilities.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("GetAllFamilyExpensesByName", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@name", name);
                    try
                    {
                        if (connection.State == System.Data.ConnectionState.Closed)
                        {
                            connection.Open();
                            SqlDataReader dr = command.ExecuteReader();
                            List<FamilyExpense> familyExpenses = new List<FamilyExpense>();
                            while (dr.Read())
                            {
                                FamilyExpense familyExpense = new FamilyExpense();
                                familyExpense.ExpenseId = Convert.ToInt32(dr["ExpenseId"]);
                                familyExpense.FamilyMemberId = Convert.ToInt32(dr["FamilyMemberId"]);
                                familyExpense.Name = dr["Name"].ToString();
                                familyExpense.Purpose = dr["Purpose"].ToString();
                                familyExpense.Amount = Convert.ToInt32(dr["Amount"]);
                                familyExpense.Date = Convert.ToDateTime(dr["DateTime"]);
                                familyExpenses.Add(familyExpense);
                            }
                            return familyExpenses;
                        }
                    }

                    catch (SqlException ex)
                    {
                        throw ex;
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
            return null;
        }

        public List<FamilyExpense> GetFamilyExpenseDetailsByDate(string startDate, string endDate)
        {
            using (SqlConnection connection = new SqlConnection(Utilities.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("GetFamilyExpensesByDate", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@startDate", startDate);
                    command.Parameters.AddWithValue("@endDate", endDate);
                    try
                    {
                        if (connection.State == System.Data.ConnectionState.Closed)
                        {
                            connection.Open();
                            SqlDataReader dr = command.ExecuteReader();
                            List<FamilyExpense> familyExpenses = new List<FamilyExpense>();
                            while (dr.Read())
                            {
                                FamilyExpense familyExpense = new FamilyExpense();
                                familyExpense.ExpenseId = Convert.ToInt32(dr["ExpenseId"]);
                                familyExpense.FamilyMemberId = Convert.ToInt32(dr["FamilyMemberId"]);
                                familyExpense.Name = dr["Name"].ToString();
                                familyExpense.Purpose = dr["Purpose"].ToString();
                                familyExpense.Amount = Convert.ToInt32(dr["Amount"]);
                                familyExpense.Date = Convert.ToDateTime(dr["DateTime"]);
                                familyExpenses.Add(familyExpense);
                            }
                            return familyExpenses;
                        }
                    }

                    catch (SqlException ex)
                    {
                        throw ex;
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
            return null;
        }

        //public string GetFamilyExpenseDetailDateByEid(int Eid)
        //{
        //    using (SqlConnection connection = new SqlConnection(Utilities.GetConnectionString()))
        //    {
        //        using (SqlCommand command = new SqlCommand("spGetFamilyExpenseDetailDateByEid", connection))
        //        {
        //            command.CommandType = System.Data.CommandType.StoredProcedure;
        //            command.Parameters.AddWithValue("@eid", Eid);
        //            try
        //            {
        //                if (connection.State == System.Data.ConnectionState.Closed)
        //                { 
        //                    connection.Open();
        //                    SqlDataReader dr = command.ExecuteReader();
        //                    if (dr.Read())
        //                    {
        //                        string date = dr["DateTime"].ToString();
        //                        return date;
        //                    }
        //                    connection.Close();
        //                }
        //            }

        //            catch(SqlException ex)
        //            {

        //            }

        //            finally
        //            {
        //                if (connection.State == System.Data.ConnectionState.Open)
        //                {
        //                    connection.Close();
        //                }
        //            }

        //        }
        //    }
        //    return null;
        //}
    }
}
