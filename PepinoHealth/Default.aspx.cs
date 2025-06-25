using System;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using PepinoHealth.Common;
using System.Web.UI;

namespace PepinoHealth
{
    public partial class _Default : Page
    {
        #region Variable declarations
        SqlConnection sqlConnection = null;
        SqlCommand sqlCommand = null;
        SqlDataAdapter sqlDataAdapter = null;
        DataTable dataTable = null;
        dynamic returnNull = null;
        #endregion
        #region Internal Common Methods

        private DBConnection DBConnection()
        {
            return new DBConnection();
        }

        private SqlConnection AccessToDB()
        {
            try
            {
                sqlConnection = DBConnection().AccessToPepinoHealthApp();
            }
            catch (Exception ex)
            {
            }
            return sqlConnection;
        }

        private void CheckNOpen()
        {
            if (sqlConnection.State != ConnectionState.Open)
            {
                sqlConnection.Open();
            }
        }



        private void CheckNClose()
        {
            if (sqlConnection.State != ConnectionState.Closed)
            {
                sqlConnection.Close();
            }
        }

        #endregion
        #region InvoiceDetails Read, Write and Delete Methods
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                lblMessage.Text = "";
                if(string.IsNullOrWhiteSpace(txtUser.Text))
                {
                    lblMessage.Text = "Please enter user name";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    lblMessage.Text = "Please enter user password";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                sqlConnection = AccessToDB();
                string query = "select * from User_Master1 where User_Name='"+ txtUser.Text + "' and Password='" + txtPassword.Text + "'";
                sqlCommand = new SqlCommand();
                //sqlCommand.Parameters.AddWithValue("@username", txtUser.Text);
                //sqlCommand.Parameters.AddWithValue("@password", txtPassword.Text);
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = query;
                sqlCommand.CommandType = CommandType.Text;
                SqlDataAdapter sda = new SqlDataAdapter(sqlCommand);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                CheckNOpen();
                int i = sqlCommand.ExecuteNonQuery();
                CheckNClose();
                if (dt.Rows.Count > 0)
                {
                    Response.Redirect("DoctorDesk.aspx");
                }
                else
                {
                    lblMessage.Text = "Your username and password is incorrect";
                    lblMessage.ForeColor = System.Drawing.Color.Red;

                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                
            }

            
            
        }
        #endregion
    }
}