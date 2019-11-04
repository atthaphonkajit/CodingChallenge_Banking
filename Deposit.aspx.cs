using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CodingChallenge_Banking
{
    public partial class Deposit : System.Web.UI.Page
    {
        DataController dc = new DataController();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                txtDepositNumber.Text = "0";
                txtDepositDecimal.Text = "00";

                string iban = Request.QueryString["IBAN"];

                if (!String.IsNullOrEmpty(iban))
                {
                    SearchAccount(iban);
                }
            }
        }

        private void SetAlertDisplay(string alertID, string alertText)
        {
            string alertClass = "alert alert-danger";

            if (alertID == "alert_btnSearchAccount")
            {
                alert_btnSearchAccount.Attributes.Add("class", alertClass);
                alert_btnSearchAccount.InnerText = alertText;
            }
            else
            {
                alert_btnSearchAccount.Attributes.Add("class", alertClass + " d-none");
                alert_btnSearchAccount.InnerText = "";
            }

            if (alertID == "alert_btnCreateTransaction")
            {
                alert_btnCreateTransaction.Attributes.Add("class", alertClass);
                alert_btnCreateTransaction.InnerText = alertText;
            }
            else
            {
                alert_btnCreateTransaction.Attributes.Add("class", alertClass + " d-none");
                alert_btnCreateTransaction.InnerText = "";
            }
        }

        protected void btnSearchAccount_Click(object sender, EventArgs e)
        {
            string iban = txtSearchIBAN.Text.ToLower().Trim();
            SearchAccount(iban);
        }

        private void SearchAccount(string iban)
        {
            Account accountInfo = dc.GetAccountInfo(iban);

            if (String.IsNullOrEmpty(accountInfo.IBAN))
            {
                SetAlertDisplay("alert_btnSearchAccount", "This IBAN is not registered");
            }
            else
            {
                txtIBAN.Text = accountInfo.IBAN;
                txtFirstName.Text = accountInfo.firstname;
                txtMiddleName.Text = accountInfo.middlename;
                txtLastname.Text = accountInfo.lastname;
                if (accountInfo.accountBalance > 0)
                {
                    txtBalance.Text = accountInfo.accountBalance.ToString("#.##");
                }
                else
                {
                    txtBalance.Text = "0.00";
                }
            }
        }

        private bool ValidateDepositAmount(string number, string deci)
        {
            Regex regexIBAN = new Regex("[0-9]");

            if (!regexIBAN.IsMatch(number) || !regexIBAN.IsMatch(deci))
            {
                SetAlertDisplay("alert_btnCreateTransaction", "Deposit amount must be number only");
                return false;
            }

            return true;
        }

        protected void btnCreateTransaction_Click(object sender, EventArgs e)
        {
            string number = txtDepositNumber.Text.Trim();
            string deci = txtDepositDecimal.Text.Trim();
            decimal depositAmount = 0;

            if (ValidateDepositAmount(number, deci))
            {
                depositAmount = Convert.ToDecimal(number + "." + deci);

                if (dc.Deposit(txtIBAN.Text, depositAmount))
                {
                    //Response.Redirect("Deposit.aspx?IBAN=" + txtIBAN.Text);
                    ScriptManager.RegisterStartupScript(this, this.GetType(),"alert","alert('The given amount has been deposit');window.location ='Deposit.aspx?IBAN="+ txtIBAN.Text + "';",true);
                }
                else
                {
                    SetAlertDisplay("alert_btnCreateTransaction", "Cannot deposit due to technical issue");
                }
            }
        }
    }
}