using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace TMS
{
    public struct point
    { public int start, end;
    };
    class cr
    {
        int eno, amount,party,rowcount;
        string etype, description, cdate,partyname;
        db log;
        public cr()
        {
        }
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
        public string name
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

        public int amt
        {

            set
            {
                amount = value;
            }
            get
            {
                return amount;
            }
        }
        public int row
        {

            set
            {
                rowcount = value;
            }
            get
            {
                return rowcount;
            }
        }
        public int partyn
        {

            set
            {
                party = value;
            }
            get
            {
                return party;
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
        public string descri
        {

            set
            {
                description = value;
            }
            get
            {
                return description;
            }
        }


        public string date
        {

            set
            {
                cdate = value;
            }
            get
            {
                return cdate;
            }
        }
        public point getpoint(int key)
        {
            point p = new point();
            DataTable read;
            log = new db();
            log.open();
            string query = "select * from cr where start <= "+key+" and fin >= "+key+" ";
            read = log.searchquery(query);
            p.start = Convert.ToInt32(read.Rows[0][0].ToString());
            p.end = Convert.ToInt32(read.Rows[0][1].ToString());
            log.close();
           
        

            return p;
        }
        public bool insert()
        {
            log = new db();
            int partyno = getpartyno(partyname);


            string query = "insert into entry values(" +eno + ",'CRV','" + amt + "'," + partyno + ",'" +description + "','" +date + "')";
            log.open();
            bool sucess=log.insertquery(query);
            log.close();
            return sucess;
        }
        public int getsaleid()
        {
            DataTable read;
            log = new db();
            log.open();
            string query = "select ISNULL(CAST(max(eno)+1 as int),0) from entry where etype='CRV'";
            read = log.searchquery(query);
            int key = Convert.ToInt32(read.Rows[0][0].ToString());
            log.close();
            return key;        }
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

        public bool search(int key)
        {
            log = new TMS.db();
            log.open();
            DataTable read;

            string query = "select * from payselect where eno=" + key + " and etype='CRV'";
            read = log.searchquery(query);
            bool success = false;
            log.close();
            if (read.Rows.Count!=0)
            {
                success = true;
                eno = Convert.ToInt32(read.Rows[0]["eno"]);
                amount = Convert.ToInt32(read.Rows[0]["amount"]);
                party = Convert.ToInt32(read.Rows[0]["partyid"]);
                partyname = read.Rows[0]["name"].ToString();
                description = read.Rows[0]["dscrpt"].ToString();
                date = read.Rows[0]["edate"].ToString();
            }
                return success;
        }
        public bool points(int start,int end)
        {
            log = new db();
            int partyno = getpartyno(partyname);


            string query = "insert into cr values(" + start + "," + end + ")";
            log.open();
            bool sucess = log.insertquery(query);
            log.close();
            return sucess;

        }
        public bool delete()
        {
        

            log = new TMS.db();
            string query = "delete from entry where eno=" + no + " and etype='CRV'";
            log.open();
            bool success = log.deletequery(query);
            log.close();
            if (success)
                return true;
            else return false;
            

           
        }
        public bool update()
        {
            bool ins = false;
            bool del = delete();
            if (del)
            {
                ins = insert();
            }

            return ins;
        }

    }
}
