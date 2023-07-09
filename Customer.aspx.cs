using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;




namespace BusinessLoanPortal
{
    public partial class Customer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Submit_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            
            // Save customer profile
            int customerId = SaveCustomerProfile(connectionString);

            // Upload documents
            UploadDocuments(connectionString, customerId);

            // Save loan application
            SaveLoanApplication(connectionString, customerId);

            // Save review
            SaveReview(connectionString, customerId);

            // Redirect to success page or display success message
            Response.Redirect("success.aspx");
        }

        private int SaveCustomerProfile(string connectionString)
        {
            string fullName = txtFullName.Value;
            string contactNumber = txtContactNumber.Value;
            string address = txtAddress.Value;
            string businessName = txtBusinessName.Value;
            string businessType = txtBusinessType.Value;
            // Retrieve other_profile_fields... if necessary
            
            int customerId = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Customer (user_id, full_name, contact_number, address) VALUES (@userId, @fullName, @contactNumber, @address); SELECT SCOPE_IDENTITY();";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Set parameter values
                    command.Parameters.AddWithValue("@userId", "");
                    command.Parameters.AddWithValue("@fullName", fullName);
                    command.Parameters.AddWithValue("@contactNumber", contactNumber);
                    command.Parameters.AddWithValue("@address", address);

                    connection.Open();
                    customerId = Convert.ToInt32(command.ExecuteScalar());
                }
            }

            // Save business-related fields in the Profile table if necessary

            return customerId;
        }

        private void UploadDocuments(string connectionString, int customerId)
        {
            // Retrieve file paths and save them in the Document table for the given customer_id
            string aadhaarCardPath = UploadFile(fileAadhaarCard.PostedFile);
            string panCardPath = UploadFile(filePANCard.PostedFile);
            string paySlipsPath = UploadFile(filePaySlips.PostedFile);
            string bankStatementsPath = UploadFile(fileBankStatements.PostedFile);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Document (customer_id, document_type, document_file) VALUES (@customerId, @documentType, @documentFile);";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Set parameter values for each document
                    command.Parameters.AddWithValue("@customerId", customerId);
                    command.Parameters.AddWithValue("@documentType", "Aadhaar Card");
                    command.Parameters.AddWithValue("@documentFile", aadhaarCardPath);
                    // Execute the command for Aadhaar Card

                    // Repeat the above steps for other document types
                }
            }
        }

        private string UploadFile(HttpPostedFile file)
        {
            string filePath = "";
            if (file.ContentLength > 0)
            {
                string fileName = Path.GetFileName(file.FileName);
                filePath = Path.Combine(Server.MapPath("~/Uploads"), fileName);
                file.SaveAs(filePath);
            }
            return filePath;
        }

        private void SaveLoanApplication(string connectionString, int customerId)
        {
            int loanAmount = Convert.ToInt32(txtLoanAmount.Value);
            string purpose = txtLoanPurpose.Value;
            string repaymentTerm = txtRepaymentTerm.Value;
            // Retrieve other_application_fields... if necessary

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO LoanApplication (customer_id, loan_amount, purpose, repayment_term, status) VALUES (@customerId, @loanAmount, @purpose, @repaymentTerm, 'pending');";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Set parameter values
                    command.Parameters.AddWithValue("@customerId", customerId);
                    command.Parameters.AddWithValue("@loanAmount", loanAmount);
                    command.Parameters.AddWithValue("@purpose", purpose);
                    command.Parameters.AddWithValue("@repaymentTerm", repaymentTerm);

                    connection.Open();
                   command.ExecuteNonQuery();
                }
            }
        }

        private void SaveReview(string connectionString, int customerId)
        {
            string reviewText = txtReview.Value;
            int rating = Convert.ToInt32(txtRating.Value);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Review (customer_id, review_text, rating, review_date) VALUES (@customerId, @reviewText, @rating, GETDATE());";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Set parameter values
                    command.Parameters.AddWithValue("@customerId", customerId);
                    command.Parameters.AddWithValue("@reviewText", reviewText);
                    command.Parameters.AddWithValue("@rating", rating);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}