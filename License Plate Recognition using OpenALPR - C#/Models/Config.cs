using KOU_RFID_Plaka.Utils;
using KOU_RFID_Plaka.Utils.QueryBuilder;
using KOU_RFID_Plaka.Utils.QueryBuilder.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KOU_RFID_Plaka.Models
{
    class Config
    {
        protected static readonly string _table = "configs";
        protected static readonly int limit = 50;

        public static bool updateOrNewConfig(string key, string value)
        {
            MysqlDatas data = getValue(key);
            if (!data.hasRows)
            {
                InsertQueryBuilder query = new InsertQueryBuilder();
                query.Table = _table;
                query.addValue("config_key", key);
                query.addValue("config_value", value);
                query.addValue("created_at", Helper.GetDatabaseDateFormat());
                string cmd = query.BuildQuery();
                return Utils.Mysql.execute(cmd);
            }
            else
            {
                UpdateQueryBuilder query = new UpdateQueryBuilder();
                query.Table = _table;
                query.addSet("config_value", value);
                query.AddWhere("config_key", Comparison.Equals, key);
                string cmd = query.BuildQuery();
                return Utils.Mysql.execute(cmd);
            }
            return false;
        }

        public static MysqlDatas getValue(string key)
        {
            SelectQueryBuilder query = new SelectQueryBuilder();
            query.SelectFromTable(_table);
            query.AddWhere("config_key", Comparison.Equals, key);
            query.LimitClause = new LimitClause(1);
            string cmd = query.BuildQuery();
            MysqlDatas result = Utils.Mysql.query(cmd);
            return result;
        }
    }
}
