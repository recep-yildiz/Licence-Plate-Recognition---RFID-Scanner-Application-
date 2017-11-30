using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Campus_Gate_KOU
{
    public partial class AuthorizeLogin : MetroFramework.Forms.MetroForm
    {
        public MySqlConnection conn;
        public const string cons = "Server=localhost;Database=kks;Uid=root;Pwd=;";

        public AuthorizeLogin()
        {
            InitializeComponent();
        }

        private void AuthorizeLogin_Load(object sender, EventArgs e)
        {

        }

        //MySql Connect/Close
        private void connectMySql()
        {
            conn = new MySqlConnection(cons);
            try
            {
                conn.Open();
            } 
            catch(Exception e)
            {
                MetroFramework.MetroMessageBox.Show(this, "Bağlantı Kurulamadı!" + e.Message, "KOU Gate Keeper - Hata!", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
        }

        private void closeMySqlConnection()
        {
            try
            {
                if(conn != null)
                {
                    conn.Close();
                }
            }
            catch (Exception e)
            {
                MetroFramework.MetroMessageBox.Show(this, "Bağlantı Sonlandırılamadı!" + e.Message, "KOU Gate Keeper - Hata!", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
        }

        private void entryBtn_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = loginControl.getLogIn(userNameTB.Text.ToString(), passwordTB.Text.ToString());

                if (dt.Rows.Count > 0)
                {
                    CreateRecord signUpNew = new CreateRecord();
                    signUpNew.Show();
                    this.Hide();
                    closeMySqlConnection();
                }
                else
                {
                    MetroFramework.MetroMessageBox.Show(this, "Kullanıcı Adı veya Parola Hatalı!", "KOU Gate Keeper - Hata!", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                //
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
    }
}
