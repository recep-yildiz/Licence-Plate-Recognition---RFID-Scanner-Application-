using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Data.SQLite;
using System.Windows.Forms;

namespace KOU_RFID_Plaka.Utils
{
   /* class Sqlite
    {
        public static String filaname = null;
        public static String password = null;
        public static Sqlite Instance = null;
        public SQLiteConnection sqliteConn;
        private Sqlite() { }

        public static Sqlite CreateInstance(String filename, String password)
        {
            Sqlite.filaname = filename;
            Sqlite.password = password;
            if (Sqlite.Instance == null)
            {
                Sqlite ins = new Sqlite();
                String dataSource = System.IO.Path.GetFullPath(filename);
                String connString = "Data Source={0};Version=3;Password={1};Pooling=True;Max Pool Size=100;FailIfMissing=True;";
                connString = String.Format(connString, dataSource, password);
                try
                {
                    ins.sqliteConn = new SQLiteConnection(connString);
            
                    ins.sqliteConn.Open();
                }
                catch(SQLiteException ex)
                {
                    SQLiteConnection.CreateFile(dataSource);
                    ins.sqliteConn = new SQLiteConnection(connString);
                    ins.sqliteConn.Open();
                    ins.sqliteConn.ChangePassword(password);
                    ins.Migrate();
                }
                Sqlite.Instance = ins;
            }
            return Sqlite.Instance;
        }
        public void Migrate()
        {
            String securityTable = "CREATE TABLE IF NOT EXISTS security(id INTEGER PRIMARY KEY AUTOINCREMENT DEFAULT NULL,type VARCHAR(5),created_date DATETIME,updated_date DATETIME)";
            String cameraTable = "CREATE TABLE IF NOT EXISTS camera(id INTEGER PRIMARY KEY AUTOINCREMENT DEFAULT NULL,ip VARCHAR(15),username VARCHAR(255),password VARCHAR(255),rfid_device_id INTEGER,created_date DATETIME,updated_date DATETIME)";
            String mysqlTable = "CREATE TABLE IF NOT EXISTS mysql(id INTEGER PRIMARY KEY AUTOINCREMENT DEFAULT NULL,host VARCHAR(255),username VARCHAR(255),password VARCHAR(255)," +
                    "database VARCHAR(255),created_date DATETIME,updated_date DATETIME)";
            String rfidTable = "CREATE TABLE IF NOT EXISTS rfid(id INTEGER PRIMARY KEY AUTOINCREMENT DEFAULT NULL,ip VARCHAR(15),port INTEGER,device_id INTEGER,created_date DATETIME,updated_date DATETIME)";
            String rfidDevicesTable = "CREATE TABLE IF NOT EXISTS rfid_devices(id INTEGER PRIMARY KEY AUTOINCREMENT DEFAULT NULL,rfid_id INTEGER,name VARCHAR(255),no INTEGER,relay_no INTEGER,ip VARCHAR(15),port INTEGER,created_date DATETIME,updated_date DATETIME)";
            SQLiteCommand cmd = new SQLiteCommand(securityTable, this.sqliteConn);
            cmd.ExecuteNonQuery();
            cmd = new SQLiteCommand(cameraTable, this.sqliteConn);
            cmd.ExecuteNonQuery();
            cmd = new SQLiteCommand(mysqlTable, this.sqliteConn);
            cmd.ExecuteNonQuery();
            cmd = new SQLiteCommand(rfidTable, this.sqliteConn);
            cmd.ExecuteNonQuery();
            cmd = new SQLiteCommand(rfidDevicesTable, this.sqliteConn);
            cmd.ExecuteNonQuery();
        }
        public SqliteDatas addToCollection(SQLiteDataReader reader)
        {
            SqliteDatas datas = new SqliteDatas();
            List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
            datas.hasRows = reader.HasRows;
            string key = null;
            while (reader.Read())
            {
                Dictionary<string, object> dict = new Dictionary<string, object>();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    if (!dict.Keys.Contains(reader.GetName(i)))
                    {
                        dict.Add(reader.GetName(i), reader.GetValue(i));
                    }
                }
                datas.datas.Add(dict);
            }
            return datas;
        }
        public SQLiteCommand prepare(string query, SQLiteConnection conn)
        {
            SQLiteCommand cmd = new SQLiteCommand(query, conn);
            return cmd;
        }
        public SQLiteCommand prepare(string query, SQLiteConnection conn, Dictionary<string, object> parameters)
        {
            SQLiteCommand cmd = new SQLiteCommand(query, conn);
            foreach (var item in parameters)
            {
                cmd.Parameters.AddWithValue(item.Key, item.Value);
            }
            return cmd;
        }
        public static SqliteDatas query(string query)
        {
            Sqlite ins = Sqlite.getInstance();
        
            SQLiteCommand cmd = ins.prepare(query, ins.sqliteConn);
            SQLiteDataReader reader = cmd.ExecuteReader();

            SqliteDatas list = ins.addToCollection(reader);
  
            return list;
        }
        public static SqliteDatas query(string query, Dictionary<string, object> parameters)
        {
            Sqlite ins = Sqlite.getInstance();
            SQLiteCommand cmd = ins.prepare(query, ins.sqliteConn, parameters);
            SQLiteDataReader reader = cmd.ExecuteReader();
            SqliteDatas list = ins.addToCollection(reader);
            return list;
        }
        public static object executeScalar(string query, Dictionary<string, object> parameters)
        {
            Sqlite ins = Sqlite.getInstance();
            SQLiteCommand cmd = ins.prepare(query, ins.sqliteConn, parameters);
            return cmd.ExecuteScalar();
        }
        public static object executeScalar(string query)
        {
            Sqlite ins = Sqlite.getInstance();
            SQLiteCommand cmd = ins.prepare(query, ins.sqliteConn);
            object result = cmd.ExecuteScalar();
            return cmd.ExecuteScalar();
        }
        public static bool execute(string query, Dictionary<string, object> parameters)
        {
            Sqlite ins = Sqlite.getInstance();
            SQLiteCommand cmd = ins.prepare(query, ins.sqliteConn, parameters);
            int result = cmd.ExecuteNonQuery();
            if (result > 0)
            {
                return true;
            }
            return false;
        }
        public static bool execute(string query)
        {
            Sqlite ins = Sqlite.getInstance();
            SQLiteCommand cmd = ins.prepare(query, ins.sqliteConn);
            int result = cmd.ExecuteNonQuery();
            if (result > 0)
            {
                return true;
            }
            return false;
        }


        public static long lastId()
        {
            return (long)Sqlite.executeScalar("SELECT last_insert_rowid()");
        }
        public static Sqlite getInstance()
        {
            return Sqlite.Instance;
        }

        ~Sqlite() { }
    }*/
}
