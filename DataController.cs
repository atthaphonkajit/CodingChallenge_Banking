using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CodingChallenge_Banking
{
    public class DataController
    {
        string connStr = ConfigurationManager.ConnectionStrings["webConnectionString"].ConnectionString;

        public bool CheckDuplicateIBAN(string iban)
        {
            string stpName = "STP_ABank_CheckDuplicateIBAN";
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand(stpName, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IBAN", SqlDbType.VarChar).Value = iban;
            try
            {
                conn.Open();
                int result = (Int32)cmd.ExecuteScalar();
                conn.Close();

                if(result == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public bool CreateAccount(Account account)
        {
            string stpName = "STP_ABank_InsertAccount";
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand(stpName, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IBAN", SqlDbType.VarChar).Value = account.IBAN;
            cmd.Parameters.Add("@Firstname", SqlDbType.VarChar).Value = account.firstname;
            cmd.Parameters.Add("@Middlename", SqlDbType.VarChar).Value = account.middlename;
            cmd.Parameters.Add("@Lastname", SqlDbType.VarChar).Value = account.lastname;
            try
            {
                conn.Open();
                int result = (Int32)cmd.ExecuteNonQuery();
                conn.Close();

                if (result == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public Account GetAccountInfo(string iban)
        {
            string stpName = "STP_ABank_GetAccountInfo";
            DataTable dtAccountInfo = new DataTable();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand(stpName, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IBAN", SqlDbType.VarChar).Value = iban;
            Account accountInfo = new Account();
            try
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtAccountInfo);
                conn.Close();

                if(dtAccountInfo.Rows.Count > 0)
                {
                    accountInfo.IBAN = dtAccountInfo.Rows[0]["IBAN"].ToString();
                    accountInfo.firstname = dtAccountInfo.Rows[0]["firstname"].ToString();
                    accountInfo.middlename = dtAccountInfo.Rows[0]["middlename"].ToString();
                    accountInfo.lastname = dtAccountInfo.Rows[0]["lastname"].ToString();
                    accountInfo.accountBalance = (Decimal)dtAccountInfo.Rows[0]["accountBalance"];
                }
                return accountInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public bool Deposit(string iban, decimal depositAmount)
        {
            string stpName = "STP_ABank_Deposit";
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand(stpName, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IBAN", SqlDbType.VarChar).Value = iban;
            cmd.Parameters.Add("@DepositAmount", SqlDbType.VarChar).Value = depositAmount;
            try
            {
                conn.Open();
                int result = (Int32)cmd.ExecuteNonQuery();
                conn.Close();

                if (result == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}