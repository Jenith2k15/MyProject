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
    public class ConsolidatedReportRepository
    {
        public AccountBreakUp GetFamilyIncomeExpenditureAndSaving()
        {
            using (SqlConnection connection = new SqlConnection(Utilities.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("GetFamilyIncomeExpenditureAndSaving", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    try
                    {
                        if (connection.State == System.Data.ConnectionState.Closed)
                        {
                            try
                            {
                                connection.Open();
                                SqlDataReader dr = command.ExecuteReader();
                                AccountBreakUp accountBreakUp = new AccountBreakUp();
                                if (dr.Read())
                                {
                                    accountBreakUp.Income = Convert.ToInt32(dr["Income"]);
                                    accountBreakUp.Expenditure = Convert.ToInt32(dr["Expenditure"]);
                                    accountBreakUp.Savings = Convert.ToInt32(dr["Saving"].ToString());
                                }
                                return accountBreakUp;
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

        public List<List<ConsolidatedReport>> GetTodayYesterdayAndMonthlyExpense()
        {
            using (SqlConnection connection = new SqlConnection(Utilities.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("GetTodayYesterdayAndMonthlyExpense", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    try
                    {
                        if (connection.State == System.Data.ConnectionState.Closed)
                        {
                            connection.Open();
                            using (SqlDataReader dr = command.ExecuteReader())
                            {
                                List<ConsolidatedReport> todayFamilyExpenses = new List<ConsolidatedReport>();
                                List<ConsolidatedReport> yesterdayFamilyExpenses = new List<ConsolidatedReport>();
                                List<ConsolidatedReport> monthlyFamilyExpenses = new List<ConsolidatedReport>();

                                while (dr.Read())
                                {
                                    ConsolidatedReport todayFamilyExpense = new ConsolidatedReport();
                                    todayFamilyExpense.Name = dr["Name"].ToString();
                                    todayFamilyExpense.Spent = (int)dr["SpentToday"];
                                    todayFamilyExpense.Remark = dr["Remark"].ToString();
                                    todayFamilyExpenses.Add(todayFamilyExpense);
                                }

                                if (dr.NextResult())
                                {
                                    while (dr.Read())
                                    {
                                        ConsolidatedReport yesterdayFamilyExpense = new ConsolidatedReport();
                                        yesterdayFamilyExpense.Name = dr["Name"].ToString();
                                        yesterdayFamilyExpense.Spent = (int)dr["SpentYesterday"];
                                        yesterdayFamilyExpense.Remark = dr["Remark"].ToString();
                                        yesterdayFamilyExpenses.Add(yesterdayFamilyExpense);
                                    }
                                }

                                if (dr.NextResult())
                                {
                                    while (dr.Read())
                                    {
                                        ConsolidatedReport monthlyFamilyExpense = new ConsolidatedReport();
                                        monthlyFamilyExpense.Name = dr["Name"].ToString();
                                        monthlyFamilyExpense.Spent = (int)dr["SpentMonthly"];
                                        monthlyFamilyExpense.Remark = dr["Remark"].ToString();
                                        monthlyFamilyExpenses.Add(monthlyFamilyExpense);
                                    }
                                }

                                List<List<ConsolidatedReport>> consolidatedReports =
                                    new List<List<ConsolidatedReport>>()
                                    {
                                        todayFamilyExpenses,yesterdayFamilyExpenses,monthlyFamilyExpenses
                                    };
                                return consolidatedReports;
                            }
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
            return null;
        }

        public List<ConsolidatedReport> GetCumulativeFamilyExpenseByDate(string startDate, string endDate)
        {
            using (SqlConnection connection = new SqlConnection(Utilities.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("GetCumulativeFamilyExpenseByDate", connection))
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
                            List<ConsolidatedReport> consolidatedReports = new List<ConsolidatedReport>();
                            while (dr.Read())
                            {
                                ConsolidatedReport consolidatedReport = new ConsolidatedReport();
                                consolidatedReport.Name = dr["Name"].ToString();
                                consolidatedReport.Spent = (int)dr["Spent"];
                                consolidatedReports.Add(consolidatedReport);
                            }
                            return consolidatedReports;
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
