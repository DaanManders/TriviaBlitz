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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace APPR_TriviaBlitz_22SD_Dman
{
    public partial class LoginForm : Form
    {
        #region Login Form Variables.
        string Password = ""; // User Variable.
        string Email = ""; // User Variable.

        // Initialize DataTable.
        DataTable DataTable = null;

        // SQLExpress Connection String.
        string ConnectionString = "Data Source=localhost\\sqlexpress;Initial Catalog=Database101;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

        int Count = 0; // DataTable Row Count.
        int Row = 0; // DataTable Row.
        #endregion

        public LoginForm()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        public void FillDataTable(string Query)
        {
            #region Fill DataTable.
            using (SqlConnection Connection = new SqlConnection(ConnectionString))
            {
                // Checks if the Connection State is Closed.
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
            #region Initialize Variables.
            Email = tbxEmailDman.Text;
            Password = tbxPasswordDman.Text;
            #endregion

            #region Handle Login Form & Authentication.
            if (Email == "")
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
                FillDataTable("SELECT * FROM Users WHERE Email = '" + Email + "' AND Password = '" + Password + "';");

                if (DataTable.Rows.Count > 0)
                {
                    // If User Exists in the DataTable.
                    MessageBox.Show("Login successful!");

                    // Hide Login Form.
                    this.Hide();

                    // Show Controller Form.
                    Controller Controller = new Controller();
                    Controller.Show();
                }
                else
                {
                    // If User doesn't Exist.
                    MessageBox.Show("Invalid Credentials!");

                    tbxEmailDman.Text = ""; // Clear Email.
                    tbxPasswordDman.Text = ""; // Clear Password.
                }
                #endregion
            }
            #endregion
        }

        private void btnRegisterDman_Click(object sender, EventArgs e)
        {
            #region Handle Register Request.
            RegisterForm RegisterForm = new RegisterForm();
            RegisterForm.Show(); // Show Register.

            // Hide Login
            this.Hide();
            #endregion
        }
    }
}
