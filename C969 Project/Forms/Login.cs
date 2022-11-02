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

namespace C969_Project.Forms
{
    public partial class Login : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C: \\Users\\hallt\\source\\repos\\C969 Project\\C969 Project\\Database.mdf\";Integrated Security=True");
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var user = txtUser.Text.Trim();
            string pass = txtPass.Text.Trim();

            try
            {
                conn.Open();
                string query = "SELECT Password FROM [User] WHERE UserName = @UserName";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("UserName", user);

                var reader = cmd.ExecuteReader();

                if (pass == reader[0].ToString())
                {
                    conn.Close();
                    Close();
                }
                conn.Close();
            }
            catch
            {
                conn.Close();
            }
        }
    }
}
