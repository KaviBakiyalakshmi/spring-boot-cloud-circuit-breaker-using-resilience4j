using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using System.Web.Services;
using System.Security.Cryptography;

namespace W2S
{
	public partial class Registration : System.Web.UI.Page
	{
        string w2s = ConfigurationManager.ConnectionStrings["W2S"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
		{
           

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {


            try
            {
                using (SqlConnection con = new SqlConnection(w2s))
                {
                    con.Open();
            

                    if (string.IsNullOrWhiteSpace(txtUsername.Text))
                    {
                        ShowAlert("Please enter a Username.");
                        txtUsername.Focus();
                        return;
                    }
                    if (string.IsNullOrWhiteSpace(txtPassword.Text))
                    {
                        ShowAlert("Please enter a Password.");
                        txtPassword.Focus();
                        return;
                    }
                    if (string.IsNullOrWhiteSpace(txtEmail.Text))
                    {
                        ShowAlert("Please enter a Mail.");
                        txtEmail.Focus();
                        return;
                    }

                    string imagePath = null;

                     HttpPostedFile uploadedFile = fileUpload.PostedFile;
                    string filename = Path.GetFileName(uploadedFile.FileName);
                    string filepath = Path.Combine(Server.MapPath("~/photos/"),filename);
                    uploadedFile.SaveAs(filepath);
                    imagePath = "~/photos/" + filename;

                   

                    string query = "INSERT INTO Users ( Username, Password, Email,Education, ImagePath) " +
                                  "VALUES ( @UName, @Password, @Mail,@Education, @ImagePath)";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@UName", txtUsername.Text);
                        cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                        cmd.Parameters.AddWithValue("@Mail", txtEmail.Text);
                        cmd.Parameters.AddWithValue("@Education", DDlEdu.Text);
                        cmd.Parameters.AddWithValue("@ImagePath", imagePath);


                        cmd.ExecuteNonQuery();
                        ShowAlert("New User added successfully.");
                    }
                }

              
                Response.Redirect("Login.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
            catch (Exception ex)
            {
                ShowAlert("Data insert failed: " + ex.Message.Replace("'", "\\'"));
            }
         
        }
        private void ShowAlert(string message)
        {
            string script = "alert('" + message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "AlertScript", script, true);
        }

        public int GetNextUserId()
        {
            string w2s = ConfigurationManager.ConnectionStrings["W2S"].ConnectionString;
            int nextId;

            try
            {
                using (SqlConnection connection = new SqlConnection(w2s))
                {
                    connection.Open();
                    string query = "SELECT ISNULL(MAX(Id), 0) + 1 FROM Users";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        object result = command.ExecuteScalar();
                        nextId = Convert.ToInt32(result);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving User ID: " + ex.Message);
            }

            return nextId;
        }


     
     

    }
}