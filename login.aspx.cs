using System;
using System.Configuration;
using System.Data.SqlClient;

namespace BusinessLoanPortal
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string username = txtusername.Text;
                string password = txtpassword.Text;

                string query = "SELECT * FROM [User] WHERE username = @username AND password = @password";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    // User is authenticated, redirect to another page
                    label1.Text="login success";
                    Response.Redirect("Customer.aspx");
                }
                else
                {
                    // Invalid credentials, display an error message
                    label1.Text = "Invalid username or password.";
                }
            }
        }
    }
}
