using KOU_RFID_Plaka.Utils;
using KOU_RFID_Plaka.Utils.QueryBuilder;
using KOU_RFID_Plaka.Utils.QueryBuilder.Enums;
using System;
using System.Collections.Generic;
using System.Windows;

namespace KOU_RFID_Plaka.Models
{
    class User
    {
        protected static readonly string _table = "users";
        public static readonly int limit = 50;


        //Mysql.execute("INSERT INTO users (sicil_no,rfid_no,plate,image,name,lastname,faculty,title,created_at) VALUES(@sicil_no,@rfid_no,@plate,@image,@name,@lastname,@faculty,@title,@created_at)", parameters);
        public static bool addUser(string sicil_no, string rfid_no,string plate,byte[] imageArray,string name,
            string lastname,string faculty, string title, string status,string list)
        {
            if (!(Models.User.getUserFromRfid(rfid_no).hasRows || Models.User.getUserFromSicil(sicil_no).hasRows))
            {
                Mysql.execute("SET GLOBAL max_allowed_packet = 16777216");
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@sicil_no", sicil_no);
                parameters.Add("@rfid_no", rfid_no);
                parameters.Add("@plate", plate);
                parameters.Add("@image", imageArray);
                parameters.Add("@name", name);
                parameters.Add("@lastname", lastname);
                parameters.Add("@faculty", faculty);
                parameters.Add("@title", title);
                parameters.Add("@status", status);
                parameters.Add("@list", list);
                parameters.Add("@created_at", Helper.GetDatabaseDateFormat());
                bool result = Mysql.execute("INSERT INTO users (sicil_no,rfid_no,plate,image,name,lastname,faculty,title,status,list,created_at) VALUES(@sicil_no,@rfid_no,@plate,@image,@name,@lastname,@faculty,@title,@status,@list,@created_at)", parameters);
                return result;
            }
            return false;
        }

        public static bool editUser(int id,string sicil_no, string rfid_no, string plate, byte[] imageArray, string name,
            string lastname, string faculty, string title,string status,string list)
        {
            if (!(Models.User.getUserFromRfidWithId(rfid_no, id).hasRows || Models.User.getUserFromSicilWithId(sicil_no, id).hasRows))
            {
                Mysql.execute("SET GLOBAL max_allowed_packet = 16777216");
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                string query = "";
                if (imageArray != null)
                {
                    query = "UPDATE users SET sicil_no=@sicil_no, rfid_no=@rfid_no,plate=@plate,image=@image,name=@name,lastname=@lastname,faculty=@faculty,title=@title,list=@list WHERE id=@id";
                    parameters.Add("@image", imageArray);
                }
                else
                {
                    query = "UPDATE users SET sicil_no=@sicil_no, rfid_no=@rfid_no,plate=@plate,name=@name,lastname=@lastname,faculty=@faculty,title=@title,status=@status,list=@list WHERE id=@id";
                }
                parameters.Add("@sicil_no", sicil_no);
                parameters.Add("@rfid_no", rfid_no);
                parameters.Add("@plate", plate);
                parameters.Add("@name", name);
                parameters.Add("@lastname", lastname);
                parameters.Add("@faculty", faculty);
                parameters.Add("@title", title);
                parameters.Add("@status", status);
                parameters.Add("@list", list);
                parameters.Add("@id", id);
                bool result = Mysql.execute(query, parameters);
                return result;
            }
            return false;
        }

        public static MysqlDatas getUserFromId(int id)
        {
            SelectQueryBuilder query = new SelectQueryBuilder();
            query.SelectFromTable(_table);
            query.AddWhere("id", Comparison.Equals, id);
            query.LimitClause = new LimitClause(1);
            string cmd = query.BuildQuery();
            MysqlDatas result = Mysql.query(cmd);
            return result;
        }

        public static MysqlDatas getUserFromRfid(string rfid)
        {
            SelectQueryBuilder query = new SelectQueryBuilder();
            query.SelectFromTable(_table);
            query.AddWhere("rfid_no", Comparison.Equals, rfid);
            query.LimitClause = new LimitClause(1);
            string cmd = query.BuildQuery();
            MysqlDatas result = Mysql.query(cmd);
            return result;
        }

        public static MysqlDatas getUserFromSicil(string sicil)
        {
            SelectQueryBuilder query = new SelectQueryBuilder();
            query.SelectFromTable(_table);
            query.AddWhere("sicil_no", Comparison.Equals, sicil);
            query.LimitClause = new LimitClause(1);
            string cmd = query.BuildQuery();
            MysqlDatas result = Mysql.query(cmd);
            return result;
        }

        public static MysqlDatas getUserFromRfidWithId(string rfid,int id)
        {
            SelectQueryBuilder query = new SelectQueryBuilder();
            query.SelectFromTable(_table);
            query.AddWhere("rfid_no", Comparison.Equals, rfid);
            query.AddWhere("id", Comparison.NotEquals, id);
            query.LimitClause = new LimitClause(1);
            string cmd = query.BuildQuery();
            MysqlDatas result = Mysql.query(cmd);
            return result;
        }

        public static MysqlDatas getUserFromSicilWithId(string sicil,int id)
        {
            SelectQueryBuilder query = new SelectQueryBuilder();
            query.SelectFromTable(_table);
            query.AddWhere("sicil_no", Comparison.Equals, sicil);
            query.AddWhere("id", Comparison.NotEquals, id);
            query.LimitClause = new LimitClause(1);
            string cmd = query.BuildQuery();
            MysqlDatas result = Mysql.query(cmd);
            return result;
        }
        public static bool deleteUser(int id)
        {
            /* Hard Delete */
            /*
            DeleteQueryBuilder query = new DeleteQueryBuilder();
            query.Table = _table;
            query.AddWhere("id", Comparison.Equals, id);
            string cmd = query.BuildQuery();
            bool result = Mysql.execute(cmd);
            return result;
            */

            /*Soft Delete*/
            UpdateQueryBuilder query = new UpdateQueryBuilder();
            query.Table = _table;
            query.addSet("status", "deleted");
            query.AddWhere("id", Comparison.Equals, id);
            string cmd = query.BuildQuery();
            bool result = Mysql.execute(cmd);
            return result;
        }
        public static bool blockedUser(int id)
        {
            /* Hard Delete */
            /*
            DeleteQueryBuilder query = new DeleteQueryBuilder();
            query.Table = _table;
            query.AddWhere("id", Comparison.Equals, id);
            string cmd = query.BuildQuery();
            bool result = Mysql.execute(cmd);
            return result;
            */

            /*Soft Delete*/
            UpdateQueryBuilder query = new UpdateQueryBuilder();
            query.Table = _table;
            query.addSet("status", "blocked");
            query.AddWhere("id", Comparison.Equals, id);
            string cmd = query.BuildQuery();
            bool result = Mysql.execute(cmd);
            return result;
        }
        public static int totalCount()
        {
            SelectQueryBuilder query = new SelectQueryBuilder();
            query.SelectFromTable(_table);
            query.SelectCount();
            string cmd = query.BuildQuery();
            object count = Mysql.executeScalar(cmd);
            return Convert.ToInt32(count);
        }

        public static MysqlDatas getUsers(int page)
        {
            int offset = page * limit;
            SelectQueryBuilder query = new SelectQueryBuilder();
            query.SelectFromTable(_table);
            query.SelectColumns(_table + ".*", "faculties.value as facultyValue", "titles.value as titleValue");
            query.AddJoin(JoinType.LeftJoin, "faculties", "id", Comparison.Equals, _table, "faculty");
            query.AddJoin(JoinType.LeftJoin, "titles", "id", Comparison.Equals, _table, "title");
            query.LimitClause = new LimitClause(limit, offset);
            string cmd = query.BuildQuery();
            MysqlDatas result = Mysql.query(cmd);
            return result;
        }

        public static MysqlDatas searchSicil(string value)
        {
            SelectQueryBuilder query = new SelectQueryBuilder();
            query.SelectFromTable("liste");
            query.AddWhere("sicil", Comparison.Equals,value);
            string cmd = query.BuildQuery();
            MysqlDatas result = Mysql.query(cmd);
            return result;
        }
    }
}
