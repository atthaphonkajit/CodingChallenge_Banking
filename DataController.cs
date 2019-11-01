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
            DataTable dtMatchList = new DataTable();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand(stpName, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IBAN", SqlDbType.VarChar).Value = iban;
            try
            {
                conn.Open();
                int result = (Int32)cmd.ExecuteScalar();
                conn.Close();

                if(result == 1)
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