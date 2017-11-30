using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.IO;
using System.CodeDom.Compiler;
using System.CodeDom;
using System.Collections.Specialized;

namespace KOU_RFID_Plaka.Utils
{
    class Mysql
    {


        public static String host = null;
        public static String username = null;
        public static String password = null;
        public static String database = null;
        public static int port = 3309;
        public static Mysql Instance = null;
        public MySqlConnection mysqlConn = null;
        public Mysql() { }
        public static Mysql CreateInstance(String host, String username, String password, String database)
        {

            Mysql.host = host;
            Mysql.username = username;
            Mysql.password = password;
            Mysql.database = database;
            Mysql.port = 3309;

            if(Mysql.Instance == null)
            {
                Mysql ins = new Mysql();
                String connStr = "server={0};user={1};password={2};database={3};port=3306;";
                connStr = String.Format(connStr, host, username, password, database);
                ins.mysqlConn = new MySqlConnection(connStr);
                try
                {
                    ins.mysqlConn.Open();
                }
                catch(Exception ex)
                {
                    throw (ex);
                }
                ins.mysqlConn.Close();
                Mysql.Instance = ins;

            }
            return Mysql.Instance;
        }

        public static Mysql CreateInstance(String host, String username, String password, String database, int port)
        {

            Mysql.host = host;
            Mysql.username = username;
            Mysql.password = password;
            Mysql.database = database;
            Mysql.port = port;

            if (Mysql.Instance == null)
            {
                Mysql ins = new Mysql();
                String connStr = "server={0};user={1};password={2};database={3};port={4};";
                connStr = String.Format(connStr, host, username, password, database,port.ToString());
                ins.mysqlConn = new MySqlConnection(connStr);
                try
                {
                    ins.mysqlConn.Open();
                }
                catch (Exception ex)
                {
                    throw (ex);
                }
                ins.mysqlConn.Close();
                Mysql.Instance = ins;
            }
            return Mysql.Instance;
        }
        public MysqlDatas addToCollection(MySqlDataReader reader)
        {
            MysqlDatas datas = new MysqlDatas();
            List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
            datas.hasRows = reader.HasRows;
            //string key = null;
            while (reader.Read())
            {
                Dictionary<string, object> dict = new Dictionary<string, object>();
                for(int i = 0; i < reader.FieldCount; i++){
                    if (!dict.Keys.Contains(reader.GetName(i)))
                    {
                        dict.Add(reader.GetName(i), reader.GetValue(i));
                    }
                }
                datas.datas.Add(dict);
            }
            return datas;
        }

        public MySqlCommand prepare(string query, MySqlConnection conn)
        {
            MySqlCommand cmd = new MySqlCommand(query, conn);
            return cmd;
        }
        public MySqlCommand prepare(string query,MySqlConnection conn, Dictionary<string, object> parameters)
        {
            MySqlCommand cmd = new MySqlCommand(query, conn);
            foreach (var item in parameters)
            {
                cmd.Parameters.AddWithValue(item.Key, item.Value);
            }
            return cmd;
        }
        public static MysqlDatas query(string query)
        {
            Mysql ins = Mysql.getInstance();
            ins.mysqlConn.Open();
            MySqlCommand cmd = ins.prepare(query, ins.mysqlConn);
            MySqlDataReader reader = cmd.ExecuteReader();
            
            MysqlDatas list =  ins.addToCollection(reader);
            ins.mysqlConn.Close();
            return list;
        }
        public static MysqlDatas query(string query,Dictionary<string,object> parameters)
        {
            Mysql ins = Mysql.getInstance();
            ins.mysqlConn.Open();
            MySqlCommand cmd = ins.prepare(query, ins.mysqlConn,parameters);
            MySqlDataReader reader = cmd.ExecuteReader();
            MysqlDatas list = ins.addToCollection(reader);
            ins.mysqlConn.Close();
            return list;
        }


        public static object executeScalar(string query, Dictionary<string, object> parameters)
        {
            Mysql ins = Mysql.getInstance();
            ins.mysqlConn.Open();
            MySqlCommand cmd = ins.prepare(query, ins.mysqlConn, parameters);
            ins.mysqlConn.Close();
            return cmd.ExecuteScalar();
        }

        public static object executeScalar(string query)
        {
            Mysql ins = Mysql.getInstance();
            ins.mysqlConn.Open();
            MySqlCommand cmd = ins.prepare(query, ins.mysqlConn);
            object result = cmd.ExecuteScalar();
            ins.mysqlConn.Close();
            return result;
        }

        public static bool execute(string query, Dictionary<string, object> parameters)
        {
            Mysql ins = Mysql.getInstance();
            ins.mysqlConn.Open();
            MySqlCommand cmd = ins.prepare(query, ins.mysqlConn, parameters);
            int result = cmd.ExecuteNonQuery();
            ins.mysqlConn.Close();
            if (result > 0)
            {
                return true;
            }
            return false;
        }

        public static bool execute(string query)
        {
            Mysql ins = Mysql.getInstance();
            ins.mysqlConn.Open();
            MySqlCommand cmd = ins.prepare(query, ins.mysqlConn);
            int result = cmd.ExecuteNonQuery();
            ins.mysqlConn.Close();
            if (result > 0)
            {
                return true;
            }
            return false;
        }
        public static Mysql getInstance()
        { 
            return Mysql.Instance;
        }
        ~Mysql()
        {
            if (!mysqlConn.Equals(null))
            {
                mysqlConn.Close();
            }
       }
    }
}
