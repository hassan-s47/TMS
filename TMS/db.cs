using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace TMS
{
    class db
    {
        string conn;
        SqlCommand smd;
        SqlDataAdapter sda;
        DataTable dt;
        SqlConnection sc;
        SqlDataReader rd;


        public void open()
        {
            try
            {
                conn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|TMS.mdf;Integrated Security=True";
                sc = new SqlConnection(conn);
                sc.Open();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message, "Error");
            }

        }

        public bool insertquery(string q)
        {
            try
            {
                smd = new SqlCommand(q, sc);
                int flag = smd.ExecuteNonQuery();

                if (flag > 0)
                    return true;
                else return false;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");
            }
            return false;
        }
      public DataTable searchquery(string q)
        {
            try
            {


                sda = new SqlDataAdapter(q, sc);
                dt = new DataTable();
                sda.Fill(dt);
                return dt;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message, "Error");
            }
            return dt;
        }
        public bool deletequery(string q)
        {
            try
            {
                smd = new SqlCommand(q, sc);
                int flag = smd.ExecuteNonQuery();

                if (flag > 0)
                    return true;
                else return false;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");
            }
            return false;
        }
        public bool updatequery(string q)
        {
            try
            {
                smd = new SqlCommand(q, sc);
                int flag = smd.ExecuteNonQuery();

                if (flag > 0)
                    return true;
                else return false;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");
            }
            return false;
        }
        public BindingSource Select_Query(string query)
        {
            sda = new SqlDataAdapter();
            smd = new SqlCommand(query, this.sc)
            ;
            sda.SelectCommand = smd;
            DataTable datatable = new DataTable();
            sda.Fill(datatable);
            BindingSource bindingsource = new BindingSource();
            bindingsource.DataSource = datatable;
            return bindingsource;

        }
        public void close()
        {
            sc.Close();
        }
    }
}
