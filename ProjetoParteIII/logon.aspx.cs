using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Security;

namespace ProjetoParteIII
{
    public partial class logon : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private bool ValidateUser(string userName, string passWord)
        {
            SqlConnection conn;
            SqlCommand cmd;
            string lookupPassword = null;

            // Check for invalid userName.
            // userName must not be null and must be between 1 and 15 characters.
            if ((null == userName) || (0 == userName.Length) || (userName.Length > 25))
            {
                System.Diagnostics.Trace.WriteLine("[ValidateUser] Input validation of userName failed.");
                return false;
            }

            // Check for invalid passWord.
            // passWord must not be null and must be between 1 and 25 characters.
            if ((null == passWord) || (0 == passWord.Length) || (passWord.Length > 25))
            {
                System.Diagnostics.Trace.WriteLine("[ValidateUser] Input validation of passWord failed.");
                return false;
            }

            try
            {
                conn = new SqlConnection(@"Data Source=VM_WINDOWS8; Initial Catalog=Northwind; Integrated Security=true");
                //conn = new SqlConnection(@"server=DESKTOP-R5I2GJD\SQLEXPRESS;Integrated Security=SSPI;database=Northwind");
                conn.Open();
                cmd = new SqlCommand("SELECT userPassword FROM users WHERE userEmail=@userEmail", conn);
                cmd.Parameters.Add("@userEmail", SqlDbType.NVarChar, 50);
                cmd.Parameters["@userEmail"].Value = userName;
                lookupPassword = (string)cmd.ExecuteScalar();

                cmd = new SqlCommand("SELECT userRole FROM users WHERE userEmail=@userEmail", conn);
                cmd.Parameters.Add("@userEmail", SqlDbType.NVarChar, 50);
                cmd.Parameters["@userEmail"].Value = userName;
                Session["userRole"] = (string)cmd.ExecuteScalar();

                cmd = new SqlCommand("SELECT userCompare FROM users WHERE userEmail=@userEmail", conn);
                cmd.Parameters.Add("@userEmail", SqlDbType.NVarChar, 50);
                cmd.Parameters["@userEmail"].Value = userName;
                Session["userCompare"] = (string)cmd.ExecuteScalar();

                cmd.Dispose();
                conn.Dispose();
            }
            catch (Exception ex)
            {
                // Add error handling here for debugging.
                System.Diagnostics.Trace.WriteLine("[ValidateUser] Exception " + ex.Message);
            }

            // If no password found, return false.
            if (null == lookupPassword)
            {
                // You could write failed login attempts here to event log for additional security.
                return false;
            }

            // Compare lookupPassword and input passWord, using a case-sensitive comparison.
            return (0 == string.Compare(lookupPassword, passWord, false));

        }

        protected void ButtonLogonServer_Click(object sender, EventArgs e)
        {
            if (ValidateUser(TextBoxUserName.Value, TextBoxPassword.Value))
            {
                //Para além de mudar de página, cria o cookie
                //formMasterPage.RedirectFromLoginPage(TextBoxUserName.Value, chkPersistCookie.Checked);
                Response.Redirect("home.aspx", true);
            }
            else
            {
                Response.Redirect("logon.aspx", true);
            }

        }
    }
}