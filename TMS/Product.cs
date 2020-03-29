using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
namespace TMS
{
    class product
    {
        string pcode, pname;
        int pkg,ppc,pbag, prate, srate;
        db log;
        public product()
        {
            pcode = pname = "";
            pkg=ppc=pbag = srate = prate = 0;
        }
      
        public string code
        {
            set
            {
                pcode = value;
            }
            get
            {
                return pcode;
            }
        }
        public string name
        {
            set
            {
                pname = value;
            }
            get
            {
                return pname;
            }
        }
        public int  bag
        {
            set
            {
                pbag = value;
            }
            get
            {
                return pbag;
            }
        }
        public int pc
        {
            set
            {
                ppc = value;
            }
            get
            {
                return ppc;
            }
        }
        public int kg
        {
            set
            {
                pkg = value;
            }
            get
            {
                return pkg;
            }
        }
        public int sr
        {
            set
            {
                srate = value;
            }
            get
            {
                return srate;
            }
        }
        public int pr
        {
            set
            {
                prate = value;
            }
            get
            {
                return prate;
            }
        }
       
         public bool add()
        {
            log = new TMS.db();
            log.open();
            string query;
            query = "insert into product(pcode,pname,srate,prate) values('" + pcode + "', '" + pname + "', " + srate + ", " + prate + ")";
            bool success = log.insertquery(query);
            log.close();
            if (success)
                return true;
            else return false;
        }
    
        public bool update(string key)
        {
            log = new db();
            log.open();
            string query = "update product set pcode='"+pcode+"',pname='"+pname+"',srate="+srate+",prate="+prate+" where pcode = '" + key + "'";
            bool success = log.insertquery(query);
            log.close();
            if (success)
                return true;
            else return false;
        }
        public bool del(string key)
        {
            log = new db();
            log.open();
            string query = "delete from product where pcode = '" + key + "' ";
            bool success = log.insertquery(query);
            log.close();
            if (success)
                return true;
            else return false;
        }
        public bool search(string key)
        {
            log = new db();
            log.open();
            string query = "select * from product where pcode = '"+key+ "' or pname = '" + key + "'";
            DataTable read = log.searchquery(query);
            log.close();
            if (read.Rows.Count != 0)
            {
                pname = read.Rows[0]["pname"].ToString();
                code = read.Rows[0]["pcode"].ToString();
                srate = Convert.ToInt32(read.Rows[0]["srate"]);
                prate = Convert.ToInt32(read.Rows[0]["prate"]);
                return true;
            }
            else return false;
               


        }
        public DataTable loadpr()
        {
            string query = "Select pname from product";
            log = new db();
            log.open();
            DataTable read = log.searchquery(query);
            log.close();
            return read;

        }

    }

}

