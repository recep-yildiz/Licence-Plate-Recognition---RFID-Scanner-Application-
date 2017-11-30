using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using KOU_RFID_Plaka.Utils;
using System.Drawing;

namespace Campus_Gate_KOU
{
    public partial class CreateRecord : MetroFramework.Forms.MetroForm
    {
        public MySqlConnection conn;
        public const string str_conn = "Server=localhost;Database=kks;Uid=root;Pwd=;";
        protected MysqlDatas facultyDatas;
        protected MysqlDatas titleDatas;
        string status = "active";
        string list = "green";

        public CreateRecord()
        {
            InitializeComponent();
        }

        private void CreateRecord_Load(object sender, EventArgs e)
        {
            saveTile.Enabled = false;
            editTile.Enabled = true;
            statusCB.SelectedIndex = statusCB.FindStringExact("Aktif");
            securityLevelCB.SelectedIndex = securityLevelCB.FindStringExact("Yeşil");
        }

        private void connectMySql()
        {
            this.closeMySqlConnection();
            conn = new MySqlConnection(str_conn);
            try
            {
                conn.Open();
            }
            catch (Exception e)
            {
                MetroFramework.MetroMessageBox.Show(this, "Veritabanı Bağlantısı Kurulamadı" + e.Message, "KOU Surveillance", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
        }

        private void closeMySqlConnection()
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
                MetroFramework.MetroMessageBox.Show(this, "Veritabanı Bağlantısı Kurulamadı" + e.Message, "KOU Surveillance", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
        }

        //Addin Profile Image
        private void metroButton1_Click(object sender, EventArgs e)
        {
            if(nameTB.Text == "" || trackNoTB.Text == "")
            {
                MetroFramework.MetroMessageBox.Show(this, "Sicil No ve Ad Kısımları Boş Bırakılmamalı!" , "KOU Surveillance", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "JPEG|*.jpg", ValidateNames = true, Multiselect = false })
                {
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        profileImage.Image = Image.FromFile(ofd.FileName);
                        this.profileImage.SizeMode = PictureBoxSizeMode.StretchImage;

                        if (ofd.CheckFileExists)
                        {
                            //Get Current Directory For Saving Images To Folder
                            string appPath = System.IO.Path.GetDirectoryName(Application.ExecutablePath.Substring(0, (Application.ExecutablePath.Length - 19)));
                            System.IO.File.Copy(ofd.FileName, appPath + "\\userProfImg\\" + trackNoTB.Text + nameTB.Text + ".jpg");
                        }
                    }
                }
            }
        }
        
        //Bring Existing Record
        public bool bringRecordScreen()
        {
            connectMySql();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT u.rfid_no, u.sicil_no, u.plate, u.image, u.name, u.lastname,u.fakulte, u.status, u.list, u.bolum " + 
                                    "FROM users u, faculties f, titles t " +
                                    "WHERE  u.sicil_no = '" + trackNoTB.Text + "'";
            MySqlDataReader dr = cmd.ExecuteReader();

            if(dr.FieldCount > 1)
            {
                while(dr.Read())
                {
                    if (dr.GetString("name") != null)
                        nameTB.Text = dr.GetString("name");

                    if (dr.GetString("lastname") != null)
                        surnameTB.Text = dr.GetString("lastname");

                    if (dr.GetString("plate") != null)
                        plateNoTB.Text = dr.GetString("plate");

                    if (dr.GetString("rfid_no") != null)
                        rfidNoTB.Text = dr.GetString("rfid_no");

                    if (dr.GetString("fakulte") != null)
                        facultyCB.SelectedIndex = facultyCB.FindStringExact(dr.GetString("fakulte")); //Interest Line

                    if (dr.GetString("list") != null)
                    {
                        if (dr.GetString("list") == "red")
                            securityLevelCB.SelectedIndex = securityLevelCB.FindStringExact("Kırmızı");
                        else if (dr.GetString("list") == "yellow")
                            securityLevelCB.SelectedIndex = securityLevelCB.FindStringExact("Sarı");
                        else
                            securityLevelCB.SelectedIndex = securityLevelCB.FindStringExact("Yeşil");
                    }

                    if (dr.GetString("status") != null)
                    {
                        if (dr.GetString("status") == "active")
                            statusCB.SelectedIndex = statusCB.FindStringExact("Aktif");
                        else if (dr.GetString("status") == "deleted")
                            statusCB.SelectedIndex = statusCB.FindStringExact("Silinmiş");
                        else
                            statusCB.SelectedIndex = statusCB.FindStringExact("Engelli");
                    }

                    if(trackNoTB.Text.Length > 3)
                        profileImage.Image = Bitmap.FromFile(@"C:\Users\Recep\Documents\Visual Studio 2015\Projects\Campus_Gate_KOU\userPP\" + trackNoTB.Text + nameTB.Text + ".jpg");
                }
            }
            
            if (!dr.HasRows)
            {
                closeMySqlConnection();
                return false;
            }
            else
                return true;
        }


        //Insert Record
        public void saveRecord()
        {
            connectMySql();
            MySqlTransaction tr = conn.BeginTransaction();
            MySqlCommand cmd = conn.CreateCommand();
            string tarih = Helper.GetDatabaseDateFormat();

            if (statusCB.Text == "Aktif") status = "active";
            else if (statusCB.Text == "Silinmiş") status = "deleted";
            else status = "blocked";

            if (securityLevelCB.Text == "Kırmızı") list = "red";
            else if (securityLevelCB.Text == "Sarı") list = "yellow";
            else list = "green";
            
            cmd.CommandText = "INSERT INTO users (rfid_no, sicil_no, plate, image, name, lastname, fakulte, bolum, status, list)" +
            "VALUES('" + rfidNoTB.Text + "', '" + trackNoTB.Text + "','" + plateNoTB.Text + "','" + profileImage.Image + "','" + nameTB.Text + "','"
            + surnameTB.Text + "','" + facultyCB.Text + "','" + "','" + status + "', '" + list + "')";

            try
            {
                cmd.ExecuteNonQuery();
                tr.Commit();
                MetroFramework.MetroMessageBox.Show(this, "Kayıt Başarıyla Tamamlandı!", "KOU Gate Keeper", MessageBoxButtons.OK, MessageBoxIcon.Error);
                statusCB.SelectedIndex = statusCB.FindStringExact("Aktif");
                securityLevelCB.SelectedIndex = securityLevelCB.FindStringExact("Yeşil");
            }   
            catch (Exception)
            {
                tr.Rollback();
                MetroFramework.MetroMessageBox.Show(this, "Kayıt Eklenemedi!", "KOU Gate Keeper", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
            closeMySqlConnection();
            trackNoTB.Text = "";
            nameTB.Text = "";
            surnameTB.Text = "";
            facultyCB.Text = "";
            plateNoTB.Text = "";
            rfidNoTB.Text = "";
            statusCB.SelectedIndex = statusCB.FindStringExact("Aktif");
            securityLevelCB.SelectedIndex = securityLevelCB.FindStringExact("Yeşil");

            if (profileImage.Image != null)
            {
                profileImage.Image.Dispose();
                profileImage.Image = null;
            }
            profileImage.Image = null;
            closeMySqlConnection();
        }  

        private void saveTile_Click(object sender, EventArgs e)
        {
            if (trackNoTB.Text == "" || nameTB.Text == "" || surnameTB.Text == "" || plateNoTB.Text == "" || rfidNoTB.Text == "" || profileImage.Image == null)
            {
                MetroFramework.MetroMessageBox.Show(this, "İlgili Alanları Doğru Bir Şekilde Doldurduğunuzdan Emin Olunuz!", "KOU Gate Keeper", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                saveRecord();
        }

        private void exitTile_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //

        //EditTile ToolTip Info
        private void editTile_MouseEnter(object sender, EventArgs e)
        {
            ToolTip toolTip1 = new ToolTip();
            toolTip1.SetToolTip(this.editTile, "*Düzenlemek istediğiniz kaydın sicil numarasını girip, 'Düzenle' ye tıklayınız.");
            toolTip1.InitialDelay = 50;
            toolTip1.AutoPopDelay = 3000;
        }

        //Editing Records
        private void editTile_Click(object sender, EventArgs e)
        {
            if((nameTB.Text != null) && (surnameTB.Text != null) && (facultyCB.Text != null) && (plateNoTB.Text != null))
            {
                updateSignUpScreen();
            }
            else
                MetroFramework.MetroMessageBox.Show(this, "İlgili Alanları Doğru Bir Şekilde Doldurduğunuzdan Emin Olunuz!", "KOU Gate Keeper", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        //When Track No Entered
        private void trackNoTB_TextChanged(object sender, EventArgs e)
        {
            saveTile.Enabled = false;
            editTile.Enabled = false;
            nameTB.Clear();
            surnameTB.Clear();
            plateNoTB.Clear();
            rfidNoTB.Clear();
            facultyCB.SelectedIndex = -1;       //Reset Selection

            if(trackNoTB.Text != "")
            {
                if (bringRecordScreen() == false)
                    saveTile.Enabled = true;
                else
                    editTile.Enabled = true;
            }
        }

        //Get Record Info Function
        public void updateSignUpScreen()
        {
            connectMySql();
            MySqlTransaction tr = conn.BeginTransaction();
            MySqlCommand cmd = conn.CreateCommand();

            if (statusCB.Text == "Aktif") status = "active";
            else if (statusCB.Text == "Silinmiş") status = "deleted";
            else status = "blocked";

            if (securityLevelCB.Text == "Kırmızı") list = "red";
            else if (securityLevelCB.Text == "Sarı") list = "yellow";
            else list = "green";

            cmd.CommandText = "UPDATE users SET sicil_no = '" + trackNoTB.Text + "' , plate = '" + plateNoTB.Text + "', image = '" + profileImage.Image + "', name = '" + nameTB.Text + "', lastname = '" + surnameTB.Text + "', fakulte = '" + facultyCB.Text + "', status= '" + status + "', list= '" + list + "' " + 
                "where sicil_no = '" + trackNoTB.Text + "'";

            try
            {
                cmd.ExecuteNonQuery();
                tr.Commit();
                MetroFramework.MetroMessageBox.Show(this, "Kayıt Başarılı Bir Şekilde Düzenlendi!", "Onay", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                tr.Rollback();
                MetroFramework.MetroMessageBox.Show(this, "Kayıt Düzenlenirken Bir Hata Oluştu!", "Düzenleme Hatası!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            closeMySqlConnection();
            trackNoTB.Text = "";
            nameTB.Text = "";
            surnameTB.Text = "";
            facultyCB.Text = "";
            plateNoTB.Text = "";
            securityLevelCB.Text = null;
            statusCB.Text = null;
        }

      
    }
}
