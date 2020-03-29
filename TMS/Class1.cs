using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace TMS
{
    class report
    {
        public DataTable salerep(string key,string start,string end)
        {
            DataTable dt = new DataTable();
            string query = "select p.pname+' '+p.city,e.eno,FORMAT (e.edate, 'dd-MM-yy') as date,s.bag,s.pc,s.kg,s.rate,s.amount from entry e inner join sale s on e.eno = s.eno and e.etype = 'SALE' inner join party p on p.id = e.partyid inner join product r on s.pcode = r.pcode where s.pcode = '" + key+ "' and e.edate between '" + start + "' and '" + end + "' ";
            db log = new db();
            log.open();
            dt = log.searchquery(query);
            log.close();
                      
            return dt;
        }
    }
}
