using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace TMS
{
    class party
    {
        string  pname, paddress, pcity,pcontact;
        int pbalance;int pid;
        db log;
        public string name
        {
            set { pname = value; }
            get { return pname; }
        }

        public string address
        {
            set { paddress = value; }
            get { return paddress; }
        }

        public string city
        {
            set { pcity = value; }
            get { return pcity; }
        }

        public string contact
        {
            set { pcontact = value; }
            get { return pcontact; }
        }
        public int balance
        {
            set { pbalance = value; }
            get { return pbalance; }
        }
        public int id
        {
            set { pid = value; }
            get { return pid; }
        }
        public bool add()
        {
            log = new TMS.db();
            log.open();
            string query;
            query = "insert into party(pname,address,city,contact,balance) values('"+pname+"', '"+paddress+"', '"+pcity+"', '"+contact+"', '"+pbalance+"')";
          bool success= log.insertquery(query);
            log.close();
            if (success)
                return true;
            else return false;
        }
    
        public void update()
        {
            log = new db();
            log.open();
            
            log.close();

        }
        public void del(string searchkey)
        {
            log = new TMS.db();
            log.open();
            int key;
            DataTable read;


            string query = "select id from partysearch where name = '" + searchkey + "'";
            read = log.searchquery(query);

            key = Convert.ToInt32(read.Rows[0][0].ToString());
            query = "delete from party where id = " + key + "";
            log.deletequery(query);
            log.close();
        }
        public void update(string searchkey)
        {
            log = new TMS.db();
            log.open();
            int key;
            DataTable read;


            string query = "select id from partysearch where name = '" + searchkey + "'";
            read = log.searchquery(query);

            key = Convert.ToInt32(read.Rows[0][0].ToString());
            query = "update party set pname='"+pname+"',address='"+paddress+"',city='"+pcity+"',contact='"+pcontact+"',balance="+pbalance+ " where id = " + key + "";
            log.updatequery(query);
            log.close();
        }
        public void search(string searchkey)
        {
             log = new TMS.db();
            log.open();
            int key;
            DataTable read;


            string query = "select id from partysearch where name = '" + searchkey + "'";
            read = log.searchquery(query);

             key = Convert.ToInt32(read.Rows[0][0].ToString());
            query = "select * from party where id = " + key + "";
            read = log.searchquery(query);
            log.close();


            pname= read.Rows[0]["pname"].ToString();
            pcity = read.Rows[0]["city"].ToString();
            pbalance = Convert.ToInt32(read.Rows[0]["balance"]);
            paddress = read.Rows[0]["address"].ToString();
            pcontact = read.Rows[0]["contact"].ToString();
            
        }
        public DataTable getpname(string key)
        {
            string query = "select name from partysearch where name like '" + key + "%'";

            log = new db();
            log.open();
            DataTable read = log.searchquery(query);
            log.close();
            return read;
        }
    }

}
