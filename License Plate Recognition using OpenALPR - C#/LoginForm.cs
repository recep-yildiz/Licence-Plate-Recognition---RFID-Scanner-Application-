using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Campus_Gate_KOU
{
    public partial class LoginForm : MetroFramework.Forms.MetroForm
    {

        public MySqlConnection conn;
        public const string cons = "Server=localhost;Database=kks;Uid=root;Pwd=;";
        public LoginForm()
        {
            InitializeComponent();
        }

        private void connectMySql()
        {
            conn = new MySqlConnection(cons);
            try
            {
                conn.Open();
            }
            catch (Exception e)
            {
                MessageBox.Show("Bağlantı krurulamadı! Hata:" + e.Message, "Hata");
            }
        }

        public void closeMySqlConnection()
        {
            try
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Bağlantı kapatılamadı! Hata:" + e.Message, "Hata");
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            //Non-Resizable Login Form
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }
        
        private void freeLogBtn_Click(object sender, EventArgs e)
        {
            userLoadingSpinner.Visible = true;
            userLoadingLabel.Visible = true;
            //Free Login
            MetroFramework.MetroMessageBox.Show(this, "(Kısıtlı Erişim)", "KOU Gate Keeper - Hoşgeldiniz!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            MainWindow mw = new MainWindow();
            mw.FormClosed += new FormClosedEventHandler(mw_FormClosed);
            mw.Show();
            mw.authControl();   //Limited Access Function
            this.Hide();
        }

        private void mw_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();   //When MainWindow Closed, Closes Program
        }

        public bool loginCheck() // eger kullanici adi ve sifre var ise true deger uretir
        {
            try
            {
                connectMySql();
                MySqlCommand com = new MySqlCommand();
                com.CommandText = " Select username, password from administrators" +
                                  "WHERE username = '" + userNameTB.Text + "' AND password = '" + passwordTB.Text + "'";
                MySqlDataReader dr = com.ExecuteReader();
                if (dr.FieldCount > 0)
                {
                    closeMySqlConnection();
                    return true;
                }
                else
                {
                    closeMySqlConnection();
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kullanici kontrol baglanti hatasi! Hata:" + ex.Message, "Hata");
                closeMySqlConnection();
                return false;
            }

        }

        private void girBtn_Click(object sender, EventArgs e)
        {
            //Authorized Login Here
            userLoadingSpinner.Visible = true;
            userLoadingLabel.Visible = true;

            DataTable dt = new DataTable();
            try
            {
                dt =  loginControl.getLogIn(userNameTB.Text.ToString(), passwordTB.Text.ToString());

                if (loginCheck() == true)
                {
                    MetroFramework.MetroMessageBox.Show(this, "(Tam Erişim - Yönetici)", "KOU Gate Keeper - Hoşgeldiniz!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    MainWindow mw = new MainWindow();
                    mw.FormClosed += new FormClosedEventHandler(mw_FormClosed);
                    mw.Show();
                    this.Hide();
                }
                else
                {
                    MetroFramework.MetroMessageBox.Show(this, "(Giriş Bilgilerinizi Kontrol Ediniz)", "KOU Gate Keeper - Erişim Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}
