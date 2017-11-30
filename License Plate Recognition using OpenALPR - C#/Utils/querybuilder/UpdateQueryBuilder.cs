using KOU_RFID_Plaka.Utils.QueryBuilder.Enums;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KOU_RFID_Plaka.Utils.QueryBuilder
{
    class UpdateQueryBuilder : IQueryBuilder
    {
        protected NameValueCollection _set = new NameValueCollection();
        protected NameValueCollection _where = new NameValueCollection();
        protected string _table;
        protected WhereStatement _whereStatement = new WhereStatement();
        internal WhereStatement WhereStatement
        {
            get { return _whereStatement; }
            set { _whereStatement = value; }
        }

        public WhereStatement Where
        {
            get { return _whereStatement; }
            set { _whereStatement = value; }
        }

        public void AddWhere(WhereClause clause) { AddWhere(clause, 1); }
        public void AddWhere(WhereClause clause, int level)
        {
            _whereStatement.Add(clause, level);
        }
        public WhereClause AddWhere(string field, Comparison @operator, object compareValue) { return AddWhere(field, @operator, compareValue, 1); }
        public WhereClause AddWhere(Enum field, Comparison @operator, object compareValue) { return AddWhere(field.ToString(), @operator, compareValue, 1); }
        public WhereClause AddWhere(string field, Comparison @operator, object compareValue, int level)
        {
            WhereClause NewWhereClause = new WhereClause(field, @operator, compareValue);
            _whereStatement.Add(NewWhereClause, level);
            return NewWhereClause;
        }
        public WhereClause AddWhere(string field, Comparison @operator, object compareValue, int level, LogicOperator @logicOperator)
        {
            WhereClause NewWhereClause = new WhereClause(field, @operator, compareValue, @logicOperator);
            _whereStatement.Add(NewWhereClause, level);
            return NewWhereClause;
        }
        public string Table
        {
            get { return _table; }
            set { _table = value; }
        }
        public string BuildQuery()
        {
            string queryString = "UPDATE " + _table + " SET";
            for (int i = 0; i < _set.Count; i++)
            {
                queryString += " " + _set.Keys[i] + "=" + Escape.EscapeString(_set[_set.Keys[i]]) + (i + 1 == _set.Count ? ("") : (","));

            }
            if (_whereStatement.ClauseLevels > 0)
            {
                queryString += " WHERE " + _whereStatement.BuildWhereStatement();
            }
            queryString += ";";
            return queryString;
        }
        public void addSet(string key, string value)
        {
            _set.Add(key, value);
        }
    }
}
