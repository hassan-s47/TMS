using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace TMS
{
    class purchase
    {
        int purchaseno, totalamount;
        string desc, date, party, type;
        db log;
        int rowcount;

        public purchase()
        {

        }
        public int sn
        {
            set
            {
                purchaseno = value;
            }
            get
            {
                return purchaseno;
            }
        }
        public int tm
        {
            set
            {
                totalamount = value;
            }
            get
            {
                return totalamount;
            }
        }

        public string dsc
        {
            set
            {
                desc = value;
            }
            get
            {
                return desc;
            }
        }
        public string dt
        {
            set
            {
                date = value;
            }
            get
            {
                return date;
            }
        }


        public int row
        {
            set { rowcount = value; }
            get { return rowcount; }
        }
        public string prty
        {
            set { party = value; }
            get { return party; }
        }
        public string typ
        {
            set { type = value; }
            get { return type; }
        }

        public bool insert(order[] sorder)
        {
            log = new db();
            int partyno = getpartyno(party);
            string query = "insert into entry values(" + purchaseno + ",'" + type + "'," + totalamount + "," + partyno + ",'" + desc + "','" + date + "')";
            log.open();
            if (log.insertquery(query))
            {
                for (int i = 0; i < rowcount; i++)
                {
                    query = "insert into sale values(" + sorder[i].no + ",'PURCHASE','" + sorder[i].code + "'," + sorder[i].amt + "," + sorder[i].kg + "," + sorder[i].pc + "," + sorder[i].bag + "," + sorder[i].rate + ")";
                    if (!log.insertquery(query))
                        return false;

                }

            }
            else
            {
                log.close();
                return false;
            }
            log.close();
            return true;
        }
        public bool delete(int key)
        {
            log = new TMS.db();
            string query = "delete from entry where eno=" + key + " and etype='PURCHASE'";
            log.open();
            bool success = log.deletequery(query);
            log.close();
            if (success)
                return true;
            else return false;
        }
        public bool update(order[] s, int key)
        {
            bool ins = false;
            bool del = delete(key);
            if (del)
            {
                ins = insert(s);
            }

            return ins;
        }

        public order[] search(int key)
        {
            log = new TMS.db();
            string query = "select * from selectpurchase where eno=" + key + " and etype='PURCHASE'";
            log.open();
            DataTable read;
            order[] s = new order[100];
            read = log.searchquery(query);
            log.close();
            if (read.Rows.Count != 0)
            {
                purchaseno = Convert.ToInt32(read.Rows[0]["eno"].ToString());
                type = read.Rows[0]["etype"].ToString();
                totalamount = Convert.ToInt32(read.Rows[0]["tm"].ToString());
                party = read.Rows[0]["name"].ToString();
                date = read.Rows[0]["edate"].ToString();
                desc = read.Rows[0]["dsc"].ToString();
                row = 0;


                for (int i = 0; i < read.Rows.Count; i++)
                {
                    s[i] = new order();
                    s[i].kg = Convert.ToInt32(read.Rows[i]["kg"].ToString());
                    s[i].pc = Convert.ToInt32(read.Rows[i]["pc"].ToString());
                    s[i].bag = Convert.ToInt32(read.Rows[i]["bag"].ToString());
                    s[i].rate = Convert.ToInt32(read.Rows[i]["rate"].ToString());
                    s[i].amt = Convert.ToInt32(read.Rows[i]["amount"].ToString());
                    s[i].pname = read.Rows[i]["pname"].ToString();
                    s[i].code = read.Rows[i]["pcode"].ToString();
                    row++;
                }
            }
            return s;
        }


        public string getprname(string code)
        {
            string pname;
            DataTable read;
            string query;
            query = "select pname from product where pcode='" + code + "'";
            log.open();
            read = log.searchquery(query);
            log.close();
            if (read.Rows.Count != 0)
                pname = read.Rows[0]["pname"].ToString();
            else pname = "";
            return pname;
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
        public string getpartyname(int key)
        {
            log = new TMS.db();
            log.open();
            string pname;
            DataTable read;


            string query = "select name from partysearch where id = '" + key + "'";
            read = log.searchquery(query);
            log.close();
            pname = read.Rows[0][0].ToString();
            return pname;
        }

        public int getpurchaseid()
        {
            DataTable read;
            log = new db();
            log.open();
            string query = "select ISNULL(CAST(max(eno)+1 as int),0) from entry where etype='PURCHASE'";
            read = log.searchquery(query);
            int key = Convert.ToInt32(read.Rows[0][0].ToString());
            log.close();
            return key;
        }
    }
}
