using BO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class FamilyMemberRepository
    {
        public int AddFamilyMember(FamilyMember familyMember)
        {
            using (SqlConnection connection = new SqlConnection(Utilities.GetConnectionString()))
            { //do not use sp AddFamilyMember
                using (SqlCommand command = new SqlCommand("AddFamilyMember", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@name", familyMember.Name);
                    command.Parameters.AddWithValue("@cell", familyMember.Cell);
                    command.Parameters.AddWithValue("@work", familyMember.Work);
                    command.Parameters.AddWithValue("@income", familyMember.Income);
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

        public int EditFamilyMember(FamilyMember familyMember)
        {
            using (SqlConnection connection = new SqlConnection(Utilities.GetConnectionString()))
            {
                using(SqlCommand command = new SqlCommand("EditFamilyMember", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@familyMemberId", familyMember.FamilyMemberId);
                    command.Parameters.AddWithValue("@name", familyMember.Name);
                    command.Parameters.AddWithValue("@cell", familyMember.Cell);
                    command.Parameters.AddWithValue("@work", familyMember.Work);
                    command.Parameters.AddWithValue("@income", familyMember.Income);
                    try
                    {
                        if (connection.State == System.Data.ConnectionState.Closed)
                        {
                            connection.Open();
                            int editStatus = command.ExecuteNonQuery();
                            return editStatus;
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

        public int DeleteFamilyMember(int familyMemberId)
        {
            using (SqlConnection connection = new SqlConnection(Utilities.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("DeleteFamilyMember", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@familyMemberId", familyMemberId);
                    try
                    {
                        if (connection.State == System.Data.ConnectionState.Closed)
                        {
                            connection.Open();
                            int status = command.ExecuteNonQuery();
                            return status;
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

        public List<FamilyMember> GetAllFamilyMembers() 
        {
            using (SqlConnection connection = new SqlConnection(Utilities.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("GetAllFamilyMembers", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    try
                    {
                        if (connection.State == System.Data.ConnectionState.Closed)
                        {
                            connection.Open();
                            SqlDataReader dr = command.ExecuteReader();
                            List<FamilyMember> familyMembers = new List<FamilyMember>();
                            while (dr.Read())
                            {
                                FamilyMember familyMember = new FamilyMember();
                                familyMember.FamilyMemberId = Convert.ToInt32(dr["FamilyMemberId"]);
                                familyMember.Name = dr["Name"].ToString();
                                familyMember.Cell = Convert.ToInt64(dr["Cell"]);
                                familyMember.Work = dr["Work"].ToString();
                                familyMember.Income = Convert.ToInt32(dr["Income"]);
                                familyMembers.Add(familyMember);
                            }
                            return familyMembers;
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
    }
}
