using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace W2S
{
	public partial class Login : System.Web.UI.Page
	{
        string w2s = ConfigurationManager.ConnectionStrings["W2S"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
		{
            if (!IsPostBack)
            {
               
                Session["Username"] = txtUsername.Text;
              
               // Response.Redirect("ViewImage.aspx");
            }
           
        }

        public void btnLogin_Click(object sender, EventArgs e)
        {
           


            try
            {
                using (SqlConnection connection = new SqlConnection(w2s))
                {
                    connection.Open();
                    string query = "SELECT Username, Password FROM Users WHERE Username = @UName AND Password = @Password";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@UName", txtUsername.Text);
                    cmd.Parameters.AddWithValue("@Password", txtPassword.Text);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        Session["Username"] = txtUsername.Text;
                        string User = Session["Username"].ToString();
                        Session["Password"] = txtPassword.Text;


                        Response.Redirect("ViewImage.aspx");
                        Context.ApplicationInstance.CompleteRequest();
                    }
                    else
                    {
                        string script = "alert('Invalid username or password');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ErrorScript", script, true);
                    }
                }
            }
            catch (Exception ex)
            {
                string errorMessage = ex.Message;
                string script = $"alert('{errorMessage}');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ErrorScript", script, true);
            }

        }

        private void ShowAlert(string message)
        {
            string script = "alert('" + message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "AlertScript", script, true);
        }
       

    }
}
