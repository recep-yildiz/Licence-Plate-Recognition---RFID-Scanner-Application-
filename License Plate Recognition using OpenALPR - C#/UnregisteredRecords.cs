using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using KOU_RFID_Plaka.Utils.QueryBuilder;

namespace Campus_Gate_KOU
{
    public partial class UnregisteredRecords : MetroFramework.Forms.MetroForm
    {
        public MySqlConnection conn;
        public const string str_conn = "Server=localhost;Database=kks;Uid=root;Pwd=;";
        protected SelectQueryBuilder query = new SelectQueryBuilder();

        public UnregisteredRecords()
        {
            InitializeComponent();
        }

        private void UnregisteredRecords_Load(object sender, EventArgs e)
        {
            //Fitting Screen
            this.Location = new Point(0, 0);
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;

            //Grid View Bootstrap
            recordList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            recordList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            recordList.AllowUserToOrderColumns = true;
            recordList.AllowUserToResizeColumns = true;
        }

        private void allRecordsBtn_Click(object sender, EventArgs e)
        {
            string connection = "server=localhost;database=kks;user=root;password=";
            MySqlConnection conn = new MySqlConnection(connection);
            conn.Open();
            MySqlCommand command = new MySqlCommand();
            command.Connection = conn;
            MySqlDataAdapter da = new MySqlDataAdapter();
            string sqlSelectAll = "SELECT * from logs_nonuser ORDER BY id DESC";
            da.SelectCommand = new MySqlCommand(sqlSelectAll, conn);
            DataTable table = new DataTable();
            da.Fill(table);

            BindingSource bSource = new BindingSource();
            bSource.DataSource = table;
            recordList.DataSource = bSource;
            conn.Close();
        }

        private void recordSearchBtn_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(str_conn);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM logs_nonuser", conn);

            //If Boxes Are Empty
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.SelectCommand = cmd;
                DataTable dbDataSet = new DataTable();
                da.Fill(dbDataSet);
                BindingSource bSource = new BindingSource();
                bSource.DataSource = dbDataSet;
                recordList.DataSource = bSource;
                da.Update(dbDataSet);
                conn.Close();
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, "Nesne başvurusu bir nesnenin örneğine başvurmadı!" + ex.Message,
                "KOU Surveillance", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }

            string search1 = searchNameTB.Text;
            string search2 = trackNoTB.Text;
            string search3 = plateTb.Text;

            if (!string.IsNullOrEmpty(search1) && search1 != "(Ad, Soyad)")
            {
                //Yeni arama sorgusu, ry
                //1. TextBox
                MySqlCommand cmdS1 = new MySqlCommand("SELECT * FROM logs_nonuser " +
                                 "WHERE name LIKE '%" + search1 + "%' OR " +
                                 "lastname LIKE '%" + search1 + "%'", conn);

                MySqlDataAdapter da = new MySqlDataAdapter(cmdS1);
                da.SelectCommand = cmdS1;
                DataTable dbDataSet = new DataTable();
                da.Fill(dbDataSet);
                BindingSource bSource = new BindingSource();
                bSource.DataSource = dbDataSet;
                recordList.DataSource = bSource;
                da.Update(dbDataSet);
                conn.Close();

                metroLabel10.Visible = true;
                metroProgressSpinner1.Visible = true;
            }
            else if (!string.IsNullOrEmpty(search2) && search2 != "(Sicil No)")
            {
                //2.TextBox
                MySqlCommand cmdS2 = new MySqlCommand("SELECT * FROM logs_nonuser " +
                                 "WHERE sicil_no LIKE '%" + search2 + "%'", conn);

                MySqlDataAdapter da = new MySqlDataAdapter(cmdS2);
                da.SelectCommand = cmdS2;
                DataTable dbDataSet = new DataTable();
                da.Fill(dbDataSet);
                BindingSource bSource = new BindingSource();
                bSource.DataSource = dbDataSet;
                recordList.DataSource = bSource;
                da.Update(dbDataSet);
                conn.Close();

                metroLabel10.Visible = true;
                metroProgressSpinner1.Visible = true;
            }
            else if (!string.IsNullOrEmpty(search3) && search3 != "(Plaka)")
            {
                //3. TextBox
                MySqlCommand cmdS3 = new MySqlCommand("SELECT * FROM logs_nonuser " +
                                 "WHERE plate LIKE '%" + search3 + "%'", conn);

                MySqlDataAdapter da = new MySqlDataAdapter(cmdS3);
                da.SelectCommand = cmdS3;
                DataTable dbDataSet = new DataTable();
                da.Fill(dbDataSet);
                BindingSource bSource = new BindingSource();
                bSource.DataSource = dbDataSet;
                recordList.DataSource = bSource;
                da.Update(dbDataSet);
                conn.Close();

                metroLabel10.Visible = true;
                metroProgressSpinner1.Visible = true;
            }
            else
            {
                if (recordList.IsDisposed)
                    MetroFramework.MetroMessageBox.Show(this, "Nesne başvurusu bir nesnenin örneğine başvurmadı!",
                    "KOU Surveillance", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
        }

        private void enterDate_ValueChanged(object sender, EventArgs e)
        {
            string connection = "server=localhost;database=kks;user=root;password=";
            MySqlConnection conn = new MySqlConnection(connection);
            conn.Open();
            MySqlCommand command = new MySqlCommand();

            command.Connection = conn;
            MySqlDataAdapter da = new MySqlDataAdapter();
            string sqlSelectAll = "SELECT * from logs_nonuser " +
                                  "WHERE input_date BETWEEN '" + enterDate.Value.ToString("yyyy-MM-dd HH:ss") + "' AND '" + exitDate.Value.ToString("yyyy-MM-dd HH:ss") + "'" +
                                  "ORDER BY input_date DESC"; //sql komutlarinin yazilacagi kisim kayitlar tarihe gore azalan siralansin
            da.SelectCommand = new MySqlCommand(sqlSelectAll, conn);
            if (sqlSelectAll == "")
            {
                MetroFramework.MetroMessageBox.Show(this, "Kayıt Bulunamamıştır!", "KOU Surveillance", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                return;
            }
            DataTable table = new DataTable();
            da.Fill(table);

            BindingSource bSource = new BindingSource();
            bSource.DataSource = table;
            recordList.DataSource = bSource;

            conn.Close();
        }

        private void exitDate_ValueChanged(object sender, EventArgs e)
        {
            string connection = "server=localhost;database=kks;user=root;password=";
            MySqlConnection conn = new MySqlConnection(connection);
            conn.Open();
            MySqlCommand command = new MySqlCommand();

            command.Connection = conn;
            MySqlDataAdapter da = new MySqlDataAdapter();
            string sqlSelectAll = "SELECT * from logs_nonuser " +
                                  "WHERE input_date BETWEEN '" + enterDate.Value.ToString("yyyy-MM-dd HH:ss") + "' AND '" + exitDate.Value.ToString("yyyy-MM-dd HH:ss") + "'" +
                                  "ORDER BY output_date DESC"; //sql komutlarinin yazilacagi kisim kayitlar tarihe gore azalan siralansin
            da.SelectCommand = new MySqlCommand(sqlSelectAll, conn);
            if (sqlSelectAll == "")
            {
                MessageBox.Show("Kayit Bulunmamaktadir!");
                return;
            }
            DataTable table = new DataTable();
            da.Fill(table);

            BindingSource bSource = new BindingSource();
            bSource.DataSource = table;
            recordList.DataSource = bSource;

            conn.Close();
        }
    }
}
