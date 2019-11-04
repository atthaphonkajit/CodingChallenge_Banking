using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CodingChallenge_Banking
{
    public partial class CreateAccount : System.Web.UI.Page
    {
        DataController dc = new DataController();
        protected void Page_Load(object sender, EventArgs e)
        {
            ResetAlert();
        }

        private void ResetAlert()
        {
            string alertClass = "alert alert-danger d-none";
            string alertText = "";

            alert_txtFirstName.Attributes.Add("class", alertClass);
            alert_txtFirstName.InnerText = alertText;

            alert_txtMiddleName.Attributes.Add("class", alertClass);
            alert_txtMiddleName.InnerText = alertText;

            alert_txtLastname.Attributes.Add("class", alertClass);
            alert_txtLastname.InnerText = alertText;

            alert_txtIBAN.Attributes.Add("class", alertClass);
            alert_txtIBAN.InnerText = alertText;

            alert_btnCreateAccount.Attributes.Add("class", alertClass);
            alert_btnCreateAccount.InnerText = alertText;
        }

        private void SetAlertDisplay(string alertID, string alertText)
        {
            string alertClass = "alert alert-danger";

            ResetAlert();

            if (alertID == "alert_txtFirstName")
            {
                alert_txtFirstName.Attributes.Add("class", alertClass);
                alert_txtFirstName.InnerText = alertText;
            }

            if (alertID == "alert_txtMiddleName")
            {
                alert_txtMiddleName.Attributes.Add("class", alertClass);
                alert_txtMiddleName.InnerText = alertText;
            }

            if (alertID == "alert_txtLastname")
            {
                alert_txtLastname.Attributes.Add("class", alertClass);
                alert_txtLastname.InnerText = alertText;
            }

            if (alertID == "alert_txtIBAN")
            {
                alert_txtIBAN.Attributes.Add("class", alertClass);
                alert_txtIBAN.InnerText = alertText;
            }

            if (alertID == "alert_btnCreateAccount")
            {
                alert_btnCreateAccount.Attributes.Add("class", alertClass);
                alert_btnCreateAccount.InnerText = alertText;
            }
        }

        private bool ValidateAccount(string firstname, string middlename, string lastname, string iban)
        {
            bool isValid = true;

            Regex regexIBAN = new Regex("[A-Za-z0-9]");

            if (String.IsNullOrEmpty(iban))
            {
                SetAlertDisplay("alert_txtIBAN", "Please fill in IBAN");
                isValid = false;
            }
            else if (!regexIBAN.IsMatch(iban))
            {
                SetAlertDisplay("alert_txtIBAN", "IBAN must be alphabet and number only");
                isValid = false;
            }
            else if (iban.Length < 18 || iban.Length > 18)
            {
                SetAlertDisplay("alert_txtIBAN", "IBAN must be 18 letters only");
                isValid = false;
            }

            Regex regex = new Regex("[A-Za-z]");

            if (String.IsNullOrEmpty(lastname))
            {
                SetAlertDisplay("alert_txtLastname", "Please fill in Lastname");
                isValid = false;
            }
            else if (!regex.IsMatch(lastname))
            {
                SetAlertDisplay("alert_txtLastname", "Lastname must be alphabet only");
                isValid = false;
            }

            if (!String.IsNullOrEmpty(middlename))
            {
                if (!regex.IsMatch(middlename))
                {
                    SetAlertDisplay("alert_txtMiddleName", "MiddleName must be alphabet only");
                    isValid = false;
                }
            }

            if (String.IsNullOrEmpty(firstname))
            {
                SetAlertDisplay("alert_txtFirstName", "Please fill in FirstName");
                isValid = false;
            }
            else if (!regex.IsMatch(firstname))
            {
                SetAlertDisplay("alert_txtFirstName", "FirstName must be alphabet only");
                isValid = false;
            }

            return isValid;
        }

        protected void btnCreateAccount_Click(object sender, EventArgs e)
        {
            Account account = new Account();
            account.IBAN = txtIBAN.Text.ToUpper().Trim();
            account.firstname = txtFirstName.Text.ToUpper().Trim();
            account.middlename = txtMiddleName.Text.ToUpper().Trim();
            account.lastname = txtLastname.Text.ToUpper().Trim();

            if (ValidateAccount(account.firstname, account.middlename, account.lastname, account.IBAN))
            {
                if (dc.CheckDuplicateIBAN(account.IBAN))
                {
                    if (dc.CreateAccount(account))
                    {
                        Response.Redirect("Deposit.aspx?IBAN=" + account.IBAN);
                    }
                    else
                    {
                        SetAlertDisplay("alert_btnCreateAccount", "Cannot create account due to technical issue");
                    }
                }
                else
                {
                    SetAlertDisplay("alert_btnCreateAccount", "This IBAN has been registered");
                }
            }
        }
    }
}