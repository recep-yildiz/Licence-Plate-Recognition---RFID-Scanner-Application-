using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace KOU_RFID_Plaka.Utils
{
    public class MysqlDatas
    {
        public List<Dictionary<string, object>> datas = new List<Dictionary<string, object>>();
        public bool hasRows;
        public int search(string key, object value)
        {
            int i = 0;
            foreach(var item in datas)
            {
                if(i == 0 && !item.Keys.Contains(key))
                {
                    return -1;
                }
                if(item[key].ToString().Equals(value.ToString()))
                {
                    return i;
                }
                i++;
            }
            return -1;
        }
    }
}
