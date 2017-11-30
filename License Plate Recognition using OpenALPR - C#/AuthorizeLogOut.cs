using System;
using System.Data;
using System.Windows.Forms;

namespace Campus_Gate_KOU
{
    public partial class AuthorizeLogOut : MetroFramework.Forms.MetroForm
    {
        public AuthorizeLogOut()
        {
            InitializeComponent();
        }

        private void AuthorizeLogOut_Load(object sender, EventArgs e)
        {
            //
        }

        private void girBtn_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = loginControl.getLogIn(userNameTB.Text.ToString(), passwordTB.Text.ToString());

                if (dt.Rows.Count > 0)
                {
                    Application.Exit();
                }
                else
                {
                    MessageBox.Show("Kullanıcı Adı veya Parola hatalı");
                }
            }
            catch (Exception)
            {
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
