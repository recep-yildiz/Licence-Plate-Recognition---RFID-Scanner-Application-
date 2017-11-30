using System;
using System.Collections.Generic;
using System.Text;
using KOU_RFID_Plaka.Utils.QueryBuilder.Enums;


//
namespace KOU_RFID_Plaka.Utils.QueryBuilder
{
    /// <summary>
    /// Represents a TOP clause for SELECT statements
    /// </summary>
    public struct LimitClause
    {
        public int Limit;
        public int Offset;
        public LimitClause(int limit)
        {
            this.Limit = limit;
            this.Offset = 0;
        }
        public LimitClause(int limit, int offset)
        {
            this.Limit = limit;
            this.Offset = offset;
            
        }
    }

}
