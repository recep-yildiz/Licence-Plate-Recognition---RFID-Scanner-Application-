using MySql.Data.MySqlClient;
using System.Data;

namespace Campus_Gate_KOU
{
    class loginControl
    {
        public static DataTable getLogIn(string username, string userPassword)
        {
            MySqlConnection conn = new MySqlConnection("Server=Localhost; Database=kks; UId=root; charset=utf8;");
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                string sqlStr = "Select username, password From administrators where username=@username and password=@password";
                MySqlCommand cmd = new MySqlCommand(sqlStr, conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", userPassword);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (MySqlException e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
                throw;
            }
            return dt;
        }
    }
}
