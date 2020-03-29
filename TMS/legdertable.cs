using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS
{
    class legdertable
    {
        string partyname, sdate, edate, fdate, etype, discr, cr_dr; int eno, dbt, crdt, blnc;

        public int no
        {
            set
            {
                eno = value;
            }
            get
            {
                return eno;
            }
        }

        public int debit
        {
            set
            {
                dbt = value;
            }
            get
            {
                return dbt;
            }
        }
        public int credit
        {
            set
            {
                crdt = value;
            }
            get
            {
                return crdt;
            }
        }
        public int balance
        {
            set
            {
                blnc = value;
            }
            get
            {
                return blnc;
            }
        }

        public string CRDR
        {
            set
            {
                cr_dr = value;
            }
            get
            {
                return cr_dr;
            }
        }
        public string pname
        {
            set
            {
                partyname = value;
            }
            get
            {
                return partyname;
            }
        }

        public string description
        {
            set
            {
                discr = value;
            }
            get
            {
                return discr;
            }
        }

        public string formdate
        {
            set
            {
                fdate = value;
            }
            get
            {
                return fdate;
            }
        }
        public string startdate
        {
            set
            {
                sdate = value;
            }
            get
            {
                return sdate;
            }
        }

        public string enddate
        {
            set
            {
                edate = value;
            }
            get
            {
                return edate;
            }
        }

        public string type
        {
            set
            {
                etype = value;
            }
            get
            {
                return etype;
            }
        }
    }
}
