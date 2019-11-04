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

            ResetAlert();
        }

        private void ResetAlert()
        {
            string alertClass = "alert alert-danger d-none";
            string alertText = "";

            alert_btnSearchAccount.Attributes.Add("class", alertClass);
            alert_btnSearchAccount.InnerText = alertText;

            alert_btnCreateTransaction.Attributes.Add("class", alertClass);
            alert_btnCreateTransaction.InnerText = alertText;
        }

        private void SetAlertDisplay(string alertID, string alertText)
        {
            string alertClass = "alert alert-danger";

            ResetAlert();

            if (alertID == "alert_btnSearchAccount")
            {
                alert_btnSearchAccount.Attributes.Add("class", alertClass);
                alert_btnSearchAccount.InnerText = alertText;
            }

            if (alertID == "alert_btnCreateTransaction")
            {
                alert_btnCreateTransaction.Attributes.Add("class", alertClass);
                alert_btnCreateTransaction.InnerText = alertText;
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
                    txtBalance.Text = (Math.Floor(accountInfo.accountBalance*100)/100).ToString();
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

                if (depositAmount > 0)
                {
                    if (dc.Deposit(txtIBAN.Text, depositAmount))
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('The given amount has been deposit into "+txtFirstName.Text+" "+txtMiddleName.Text+" "+txtLastname.Text+" IBAN:"+txtIBAN.Text+"');window.location ='Deposit.aspx?IBAN=" + txtIBAN.Text + "';", true);
                    }
                    else
                    {
                        SetAlertDisplay("alert_btnCreateTransaction", "Cannot deposit due to technical issue");
                    }
                }
                else
                {
                    SetAlertDisplay("alert_btnCreateTransaction", "Please deposit more than 0 BAHT");
                }
            }
        }

        protected void btnTransfer_Click(object sender, EventArgs e)
        {
            Response.Redirect("Transfer.aspx?IBAN=" + txtIBAN.Text);
        }
    }
}