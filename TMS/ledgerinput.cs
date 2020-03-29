using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TMS
{
    public partial class ledgerinput : Form
    {
        public ledgerinput()
        {
            InitializeComponent();
        }

        private void ledgerinput_Load(object sender, EventArgs e)
        {
            button2.Hide();
            loadname();
            //crystalReportViewer1.Hide();
            // TODO: This line of code loads data into the 'partysearch._partysearch' table. You can move, or remove it, as needed.
             comboBox1.Text = "";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (comboBox1.Text != "")
            {
                button2.Show();

                //     crystalReportViewer1.Hide();
                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();
                string startdate, enddate, partyname;
                startdate = dateTimePicker1.Text;
                enddate = dateTimePicker2.Text;
                partyname = comboBox1.Text;
                legder c = new legder();
                legdertable[] l = c.show(startdate, enddate, partyname);
                textBox1.Text = c.debit.ToString();
                textBox2.Text = c.credit.ToString();
                textBox3.Text = Math.Abs(c.bal).ToString();
                if (c.bal < 0) label8.Text = "CR"; else label8.Text = "DR";
                for (int i = 0; i <= c.crow; i++)
                {
                    dataGridView1.Rows.Add(1);
                    dataGridView1[0, i].Value = l[i].formdate;
                    dataGridView1[1, i].Value = l[i].no;
                    dataGridView1[2, i].Value = l[i].type;
                    dataGridView1[3, i].Value = l[i].description;
                    dataGridView1[4, i].Value = l[i].debit;
                    dataGridView1[5, i].Value = l[i].credit;
                    dataGridView1[6, i].Value = l[i].balance;
                    dataGridView1[7, i].Value = l[i].CRDR;

                }
            }
            else
            {
                MessageBox.Show("PLEASE ENTER REQUIRED DATA", "ERROR");
            }
        }
        public bool loadname()
        {
            try
            {
                string key = comboBox1.Text;
                party p = new party();
                DataTable read = new DataTable();
                read = p.getpname(key);
                bool success = false;
                if (read.Rows.Count != 0)
                {
                    if (comboBox1.Items.Count != 0)
                        comboBox1.Items.Clear();
                    for (int i = 0; i < read.Rows.Count; i++)
                    {
                        comboBox1.Items.Add(read.Rows[i]["name"]);

                    }
                    success = true;

                }
                return success;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            return false;
        }
        private void button3_Click(object sender, EventArgs e)
        {
       //    crystalReportViewer1.Show();
            comboBox1.Text = "";
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
            label8.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            DataTable dt2 = new DataTable();
            dt2.Columns.Add("From", typeof(string));
            dt2.Columns.Add("To", typeof(string));
            dt2.Columns.Add("Party", typeof(string));
            dt2.Columns.Add("Tdebit", typeof(string));
            dt2.Columns.Add("Tcredit", typeof(string));
            dt2.Columns.Add("bal", typeof(string));
            dt2.Rows.Add(dateTimePicker1.Text,dateTimePicker2.Text,comboBox1.Text,textBox1.Text.ToString(),textBox2.Text.ToString(),textBox3.Text.ToString());

            DataTable dt = new DataTable();
            dt.Columns.Add("Date", typeof(string));
            dt.Columns.Add("E No", typeof(Int32));
            dt.Columns.Add("E Type", typeof(string));
            dt.Columns.Add("Description", typeof(string));
            dt.Columns.Add("Debit", typeof(Int32));
            dt.Columns.Add("Credit", typeof(Int32));
            dt.Columns.Add("Balance", typeof(Int32));
            dt.Columns.Add("CR/DR", typeof(string));
            foreach(DataGridViewRow dgv in dataGridView1.Rows)
            {
                dt.Rows.Add(dgv.Cells[0].Value, dgv.Cells[1].Value, dgv.Cells[2].Value, dgv.Cells[3].Value, dgv.Cells[4].Value, dgv.Cells[5].Value, dgv.Cells[6].Value, dgv.Cells[7].Value);
            }
            ds.Tables.Add(dt);
            ds.Tables.Add(dt2);
            ds.WriteXmlSchema("Ledgers.xml");

            partylegprint a = new partylegprint(ds);
            a.Show();
         
        }

        private void ledgerinput_FormClosed(object sender, FormClosedEventArgs e)
        {
            Dashboard d = new Dashboard();
            d.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void comboBox1_TextUpdate(object sender, EventArgs e)
        {
            if (loadname())
                SendKeys.Send("{END}");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 8)
            {
                int row = e.RowIndex;
                if (dataGridView1[2,row].Value.ToString() == "SALE")
                {
                    salevoucher s = new salevoucher();
                    s.Show();
                    s.isexternal();
                    s.loadrecord(Convert.ToInt32(dataGridView1[1, row].Value));
                }
                if (dataGridView1[2, row].Value.ToString() == "PURCHASE")
                {
                    purchasevoucher s = new purchasevoucher();
                    s.Show();
                    s.isexternal();
                    s.loadrecord(Convert.ToInt32(dataGridView1[1, row].Value));
                }
                if (dataGridView1[2, row].Value.ToString() == "CPV")
                {
                    cpvoucher s = new cpvoucher();
                    s.Show();
                    s.isexternal();
                    s.loadrecord(Convert.ToInt32(dataGridView1[1, row].Value));
                }
                if (dataGridView1[2, row].Value.ToString() == "CRV")
                {
                    crvoucher s = new crvoucher();
                    s.Show();
                    s.isexternal();
                    s.loadrecord(Convert.ToInt32(dataGridView1[1, row].Value));
                }

            }
        }
    }
}
