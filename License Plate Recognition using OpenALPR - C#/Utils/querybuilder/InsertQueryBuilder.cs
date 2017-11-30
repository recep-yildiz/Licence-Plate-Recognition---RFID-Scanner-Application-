using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KOU_RFID_Plaka.Utils.QueryBuilder
{
    class InsertQueryBuilder : IQueryBuilder
    {
        protected NameValueCollection _value = new NameValueCollection();
        protected string _table;

        public string Table
        {
            get { return _table; }
            set { _table = value; }
        }
        public string BuildQuery()
        {
            string queryString = "INSERT INTO " + _table + " (";
            for (int i = 0; i < _value.Count; i++)
            {
                queryString += _value.Keys[i] + (i + 1 == _value.Count ? "" : ",");
            }
            queryString += ") VALUES (";

            for (int i = 0; i < _value.Count; i++)
            {
                queryString += Escape.EscapeString(_value[_value.Keys[i]]) + (i + 1 == _value.Count ? ("") : (","));
            }
            queryString += ");";
            return queryString;
        }
        public void addValue(string key, string value)
        {
            _value.Add(key, value);
        }
    }
}
