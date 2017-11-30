using System;
using System.Collections.Generic;
using System.Text;


namespace KOU_RFID_Plaka.Utils.QueryBuilder
{
    public class SqlLiteral
    {
        public static string StatementRowsAffected = "SELECT FOUND_ROWS();";

        private string _value;
        public string Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public SqlLiteral(string value)
        {
            _value = value;
        }
    }

}
