using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace TMS
{
    class order
    {
        string pcode, qtype,qpname;
        int qkg,qpc,qbag, qunit, qrate, qamount,qno;
    
        public string code
        { set { pcode = value; }get { return pcode; } }

        public int kg
        { set { qkg = value; }get { return qkg; } }
        public int unit
        {
            set { qunit = value; }
            get { return qunit; }
        }
        public string pname
        {
            set { qpname = value; }
            get { return qpname; }
        }
        public int no
        {
            set { qno = value; }
            get { return qno; }
        }
        public string type
        {
            set { qtype = value; }
            get { return qtype; }
        }

        public int rate
        {
            set { qrate = value; }
            get { return qrate; }
        }
        public int pc
        {
            set { qpc = value; }
            get { return qpc; }
        }
        public int bag
        {
            set { qbag = value; }
            get { return qbag; }
        }
        public int amt
        {
            set { qamount = value; }
            get { return qamount; }
        }
        public void insert()
        {

        }
        public DataTable search(int saleno)
        {
            DataTable data = new DataTable();
             
            return data;
        }


    }
    
}
