using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace TMS
{
    public partial class SaleReport : Form
    {
        public SaleReport()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void SaleReport_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter && textBox1.Text != "")
                {
                    dataGridView1.Rows.Clear();
                    dataGridView1.Refresh();
                    report r = new report();
                    string start = dateTimePicker1.Text;
                    string end = dateTimePicker2.Text;
                    string key = textBox1.Text;
                    DataTable read = r.salerep(key, start, end);
                    int bags = 0, pc = 0, kg = 0, total = 0;
                    for (int i = 0; i < read.Rows.Count; i++)
                    {

                        dataGridView1.Rows.Add(read.Rows[i][0], read.Rows[i][1], read.Rows[i][2], read.Rows[i][3], read.Rows[i][4], read.Rows[i][5], read.Rows[i][6], read.Rows[i][7]);
                        bags += Convert.ToInt32(read.Rows[i][3]);
                        pc += Convert.ToInt32(read.Rows[i][4]);
                        kg += Convert.ToInt32(read.Rows[i][5]);
                        total += Convert.ToInt32(read.Rows[i][7]);

                    }
                    label4.Text = bags.ToString();
                    label5.Text = pc.ToString();
                    label6.Text = kg.ToString();
                    label7.Text = total.ToString();

                }
            }
            catch(Exception x)
            {
                MessageBox.Show(x.ToString(), "Error");
            }
        }

        private void SaleReport_FormClosed(object sender, FormClosedEventArgs e)
        {
            Dashboard d = new Dashboard();
            d.Show();
        }
    }
}
