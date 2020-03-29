using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace TMS
{
    class legder
    {
        db log;
        int totalcredit, totaldebit,balance,row;
        public int crow
        {
            set
            {
                row = value;
            }
            get
            {
                return row;
            }
        }
        public int credit
        {
            set
            {
                totalcredit = value;
            }
            get
            {
                return totalcredit;
            }
        }
        public int debit
        {
            set
            {
                totaldebit= value;
            }
            get
            {
                return totaldebit;
            }
        }
        public int bal
        {
            set
            {
                balance = value;
            }
            get
            {
                return balance;
            }
        }


        public int prevbalance(string date,int partyid)
        {
            log = new TMS.db();
            int balance,credit,debit;
            string query = "select ISNULL(CAST(sum(amount) as int),0) as credit from entry where (etype = 'SALE' or etype ='CPV') and partyid =" + partyid + " and edate < '"+date+"'";
            log.open();
            DataTable read = log.searchquery(query);
            if (read.Rows.Count != 0)
            {
                credit = Convert.ToInt32(read.Rows[0]["credit"]);
                query = "select ISNULL(CAST(sum(amount) as int),0) as debit from entry where (etype = 'PURCHASE' or etype ='CRV' ) and partyid =" + partyid + " and edate < '" + date + "'";
                read = log.searchquery(query);
                if (read.Rows.Count != 0)
                {
                    debit = Convert.ToInt32(read.Rows[0]["debit"]);
                }
                else return -1;
            }
            else return -1;
            balance = credit - debit;
            return balance;
        }

        public legdertable[] show(string startdate,string enddate,string pname)
        {
            legdertable[] l = new legdertable[1000];
            int partyid = getpartyno(pname);
            int prevbal = prevbalance(startdate, partyid);

            string query = "select * from entry where edate between '" + startdate + "' and '" + enddate + "' and partyid = "+partyid+" order by edate";
            log = new db();
            log.open();
            DataTable read = log.searchquery(query);
            log.close();
            totalcredit = 0;
            totaldebit = 0;
            balance = 0;
            row = 0;
            l[0] = new legdertable();
            l[0].balance = Math.Abs(prevbal);
            l[0].description = "Brought Forward";
            l[0].type = "";
            l[0].no = 0;
            if (prevbal < 0) l[0].CRDR = "DR"; else l[0].CRDR = "CR";
            l[0].formdate = startdate;
            balance = prevbal;
            if (read.Rows.Count != 0)
            {
                for (int i = 0; i < read.Rows.Count; i++)
                {
                    l[i + 1] = new legdertable();
                    l[i + 1].no = Convert.ToInt32(read.Rows[i]["eno"]);
                    l[i + 1].description = read.Rows[i]["dscrpt"].ToString();
                    l[i + 1].formdate = read.Rows[i]["edate"].ToString();
                    l[i + 1].type = read.Rows[i]["etype"].ToString();
                    if(l[i+1].type=="SALE" || l[i + 1].type == "CPV")
                    {
                        l[i + 1].credit =Convert.ToInt32(read.Rows[i]["amount"]);
                        balance += l[i+1].credit;
                       totalcredit+= l[i + 1].credit;

                    }
                    else
                    {
                        l[i + 1].debit = Convert.ToInt32(read.Rows[i]["amount"]);
                        balance -= l[i + 1].debit;
                        totaldebit+= l[i + 1].debit;
                    }
                    if (balance >= 0)
                        l[i + 1].CRDR = "CR";
                    else
                        l[i + 1].CRDR = "DR";
                    l[i + 1].balance = Math.Abs(balance);
                    row++;
                }
            }
            return l;
        }
        public int getpartyno(string pname)
        {
            log = new TMS.db();
            log.open();
            int key;
            DataTable read;


            string query = "select id from partysearch where name = '" + pname + "'";
            read = log.searchquery(query);
            log.close();
            key = Convert.ToInt32(read.Rows[0][0].ToString());
            return key;
        }

    }
}
