using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CodingChallenge_Banking
{
    public partial class Transfer : System.Web.UI.Page
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
                    SearchAccount_TransferFrom(iban);
                }
            }

            ResetAlert();
        }

        private void ResetAlert()
        {
            string alertClass = "alert alert-danger d-none";
            string alertText = "";

            alert_btnSearchAccount_TransferFrom.Attributes.Add("class", alertClass);
            alert_btnSearchAccount_TransferFrom.InnerText = alertText;

            alert_btnSearchAccount_TransferTo.Attributes.Add("class", alertClass);
            alert_btnSearchAccount_TransferTo.InnerText = alertText;

            alert_btnCreateTransaction.Attributes.Add("class", alertClass);
            alert_btnCreateTransaction.InnerText = alertText;
        }

        private void SetAlertDisplay(string alertID, string alertText)
        {
            string alertClass = "alert alert-danger";

            ResetAlert();

            if (alertID == "alert_btnSearchAccount_TransferFrom")
            {
                alert_btnSearchAccount_TransferFrom.Attributes.Add("class", alertClass);
                alert_btnSearchAccount_TransferFrom.InnerText = alertText;
            }

            if (alertID == "alert_btnSearchAccount_TransferTo")
            {
                alert_btnSearchAccount_TransferTo.Attributes.Add("class", alertClass);
                alert_btnSearchAccount_TransferTo.InnerText = alertText;
            }

            if (alertID == "alert_btnCreateTransaction")
            {
                alert_btnCreateTransaction.Attributes.Add("class", alertClass);
                alert_btnCreateTransaction.InnerText = alertText;
            }
        }

        private void SearchAccount_TransferFrom(string iban)
        {
            Account accountInfo = dc.GetAccountInfo(iban);

            if (String.IsNullOrEmpty(accountInfo.IBAN))
            {
                SetAlertDisplay("alert_btnSearchAccount_TransferFrom", "This IBAN is not registered");
            }
            else
            {
                txtIBAN_TransferFrom.Text = accountInfo.IBAN;
                txtFirstName_TransferFrom.Text = accountInfo.firstname;
                txtMiddleName_TransferFrom.Text = accountInfo.middlename;
                txtLastname_TransferFrom.Text = accountInfo.lastname;
                if (accountInfo.accountBalance > 0)
                {
                    txtBalance_TransferFrom.Text = (Math.Floor(accountInfo.accountBalance * 100) / 100).ToString();
                }
                else
                {
                    txtBalance_TransferFrom.Text = "0.00";
                }
            }
        }

        private void SearchAccount_TransferTo(string iban)
        {
            Account accountInfo = dc.GetAccountInfo(iban);

            if (String.IsNullOrEmpty(accountInfo.IBAN))
            {
                SetAlertDisplay("alert_btnSearchAccount_TransferTo", "This IBAN is not registered");
            }
            else
            {
                txtIBAN_TransferTo.Text = accountInfo.IBAN;
                txtFirstName_TransferTo.Text = accountInfo.firstname;
                txtMiddleName_TransferTo.Text = accountInfo.middlename;
                txtLastname_TransferTo.Text = accountInfo.lastname;
            }
        }

        protected void btnSearchAccount_TransferFrom_Click(object sender, EventArgs e)
        {
            string iban = txtSearchIBAN_TransferFrom.Text.Trim();
            SearchAccount_TransferFrom(iban);
        }

        protected void btnSearchAccount_TransferTo_Click(object sender, EventArgs e)
        {
            string iban = txtSearchIBAN_TransferTo.Text.Trim();
            SearchAccount_TransferTo(iban);
        }

        protected void btnCreateTransaction_Click(object sender, EventArgs e)
        {
            string number = txtDepositNumber.Text.Trim();
            string deci = txtDepositDecimal.Text.Trim();
            decimal depositAmount = 0;

            if (ValidateTransferAmount(number, deci))
            {
                depositAmount = Convert.ToDecimal(number + "." + deci);
                decimal balance = Convert.ToDecimal(txtBalance_TransferFrom.Text);

                if (depositAmount > 0)
                {
                    if (depositAmount <= balance)
                    {
                        if (dc.Transfer(txtIBAN_TransferFrom.Text, txtIBAN_TransferTo.Text, depositAmount))
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('The given amount has been transfer to " + txtFirstName_TransferTo.Text + " " + txtMiddleName_TransferTo.Text + " " + txtLastname_TransferTo.Text + " IBAN:" + txtIBAN_TransferTo.Text + " ');window.location ='Transfer.aspx?IBAN=" + txtIBAN_TransferFrom.Text + "';", true);
                        }
                        else
                        {
                            SetAlertDisplay("alert_btnCreateTransaction", "Cannot deposit due to technical issue");
                        }
                    }
                    else
                    {
                        SetAlertDisplay("alert_btnCreateTransaction", "Insufficient balance");
                    }
                }
                else
                {
                    SetAlertDisplay("alert_btnCreateTransaction", "Please transfer more than 0 BAHT");
                }
            }
        }

        private bool ValidateTransferAmount(string number, string deci)
        {
            Regex regexIBAN = new Regex("[0-9]");

            if (!regexIBAN.IsMatch(number) || !regexIBAN.IsMatch(deci))
            {
                SetAlertDisplay("alert_btnCreateTransaction", "Transfer amount must be number only");
                return false;
            }

            return true;
        }
    }
}