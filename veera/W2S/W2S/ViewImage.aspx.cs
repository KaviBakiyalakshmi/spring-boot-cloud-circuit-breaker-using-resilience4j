using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace W2S
{
	public partial class ViewImage : System.Web.UI.Page
	{
        string w2s = ConfigurationManager.ConnectionStrings["W2S"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
		{

            if (!IsPostBack)
            {
                if (Session["Username"]!=null)
                {

                    string loggedInUsername = "";
                    loggedInUsername = Session["Username"].ToString();

                    if (string.IsNullOrWhiteSpace(loggedInUsername))
                    {

                        ShowAlert("User not logged in. Please log in to view this page.");


                        Response.Redirect("Login.aspx");
                    }
                    else
                    {

                        GetUserImage(loggedInUsername);
                    }
                }

                
            }
        }

        private void GetUserImage(string username)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(w2s)) 
                {
                    con.Open();

                    string query = "SELECT Username, ImagePath,Email FROM Users WHERE Username = @Username";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string imagePath = reader["ImagePath"].ToString();
                                string email = reader["Email"].ToString();

                                if (!string.IsNullOrEmpty(imagePath))
                                {
                                    imgUser.ImageUrl = imagePath;
                                    txtName.Text = username;
                                    TxtEmail.Text = email;
                                }
                                else
                                {
                                    ShowAlert("No image found for this user.");
                                }
                            }
                            else
                            {
                                ShowAlert("User not found in the database.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ShowAlert("Error retrieving image: " + ex.Message.Replace("'", "\\'"));
            }
        }
        private void ShowAlert(string message)
        {
            string script = "alert('" + message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "AlertScript", script, true);
        }
    }
}
