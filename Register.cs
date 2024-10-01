using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APPR_TriviaBlitz_22SD_Dman
{
    public partial class RegisterForm : Form
    {
        #region Register Form Variables.
        string Username = ""; // User Variable.
        string Email = ""; // User Variable.
        string Password = ""; // User Variable.

        // Initialize DataTable.
        DataTable DataTable = null;

        // SQLExpress Connection String.
        string ConnectionString = "Data Source=localhost\\sqlexpress;Initial Catalog=Database101;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

        int Count = 0; // DataTable Row Count.
        int Row = 0; // DataTable Row.
        #endregion

        public RegisterForm()
        {
            InitializeComponent();
        }

        private void Register_Load(object sender, EventArgs e)
        {
            
        }

        private void btnRegisterDman_Click(object sender, EventArgs e)
        {
            #region Initialize Variables.
            Username = tbxUsernameDman.Text;
            Email = tbxEmailDman.Text;
            Password = tbxPasswordDman.Text;
            #endregion

            #region Handle Register Form & Authentication.
            if (Username == "")
            {
                // If Username is Empty.
                MessageBox.Show("Username is missing!");
                return;
            }
            else if (Email == "") 
            {
                // If Email is Empty.
                MessageBox.Show("Email is missing!");
                return;
            }
            else if (Password == "")
            {
                // If Password is Empty.
                MessageBox.Show("Password is missing!");
                return;
            }
            else
            {
                #region Handle DataTable.
                // Fill DataTable with Executed SQL Query.
                FillDataTable("SELECT * FROM Users WHERE Email = '" + Email + "';");

                if (DataTable.Rows.Count == 0)
                {
                    // Insert into DataTable if User doesn't Exist.
                    ExecuteQuery("INSERT INTO [dbo].[Users] ([Username], [Email], [Password]) VALUES (N'" + Username + "', N'" + Email + "', N'" + Password + "')");

                    // Reassure Register.
                    MessageBox.Show("Account created successfuly!");
                }
                else if (DataTable.Rows.Count > 0)
                {
                    // If User Exists.
                    MessageBox.Show("Email must be unique!");

                    tbxEmailDman.Text = ""; // Clear Username.
                    tbxPasswordDman.Text = ""; // Clear Password.
                }
                #endregion
            }
            #endregion
        }

        public void ExecuteQuery(string Query)
        {
            #region Execute SQL Query.
            using (SqlConnection Connection = new SqlConnection(ConnectionString))
            {
                // CHecks the State of the Connection.
                if (Connection.State == ConnectionState.Closed)
                {
                    Connection.Open();
                }

                // Executes Query inside the Users DataTable.
                using (DataTable = new DataTable("Users"))
                {
                    using (SqlCommand Command = new SqlCommand(Query, Connection))
                    {
                        // Define the Adapter.
                        SqlDataAdapter Adapter = new SqlDataAdapter(Command);
                        Command.ExecuteNonQuery();
                    }
                }
            }
            #endregion
        }

        public void FillDataTable(string Query)
        {
            #region Fill DataTable.
            using (SqlConnection Connection = new SqlConnection(ConnectionString))
            {
                if (Connection.State == ConnectionState.Closed)
                {
                    Connection.Open();
                }

                // Selecting the User DataTable.
                using (DataTable = new DataTable("Users"))
                {
                    // Runs SQL Command (Query & Connection).
                    using (SqlCommand Command = new SqlCommand(Query, Connection))
                    {
                        SqlDataAdapter Adapter = new SqlDataAdapter(Command);
                        Adapter.Fill(DataTable); // Fill User DataTable.
                    }
                }
            }
            #endregion
        }

        private void btnLoginDman_Click(object sender, EventArgs e)
        {
            #region Handle Login Request.
            LoginForm LoginForm = new LoginForm();
            LoginForm.Show(); // Show Login.

            // Hide Register.
            this.Hide();
            #endregion
        }
    }
}
