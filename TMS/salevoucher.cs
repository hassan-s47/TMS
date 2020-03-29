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
    public partial class salevoucher : Form
    {
        sale s;
        bool external = false;
        public salevoucher()
        {
            InitializeComponent();
        }

        public void isexternal()
        {
            external = true;
        }
        public void loadrecord(int id)
        {
            dataGridView1.Rows.Clear();
            int key = id;
            sale s = new TMS.sale();
            textBox1.Text = id.ToString();
            order[] sorder = s.search(key);
            if (sorder[0] != null)
            {
                comboBox1.Text = s.prty;
                textBox2.Text = s.dsc;
                textBox3.Text = s.tm.ToString();
                dateTimePicker1.Text = s.dt;

                for (int i = 0; i < s.row; i++)
                {
                    dataGridView1.Rows.Add(1);
                    dataGridView1[0, i].Value = sorder[i].code.ToString();
                    dataGridView1[1, i].Value = sorder[i].pname.ToString();
                    dataGridView1[2, i].Value = sorder[i].bag.ToString();
                    dataGridView1[3, i].Value = sorder[i].pc.ToString();
                    dataGridView1[4, i].Value = sorder[i].kg.ToString();
                    dataGridView1[5, i].Value = sorder[i].rate.ToString();
                    dataGridView1[6, i].Value = sorder[i].amt.ToString();
                }
                button2.Show();
                button3.Show();
                button5.Show();
                button1.Hide();
            }
            else
                MessageBox.Show("No Record Found");
        }
       

        void clear()
        {
            comboBox1.Text = "";
            s = new TMS.sale();
            textBox1.Text = s.getsaleid().ToString();
            dateTimePicker1.Value = DateTime.Now;
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();

            textBox2.Text = "";
            textBox3.Text = "0";
            button2.Hide();
            button3.Hide();
            button5.Hide();
            button1.Show();

        }
        public void counter()
        {
            int amount = 0;
            int tbags = 0, tpc = 0, tkg = 0;
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                amount += Convert.ToInt32(dataGridView1[6, i].Value);
                tbags += Convert.ToInt32(dataGridView1[2, i].Value);
                tpc += Convert.ToInt32(dataGridView1[3, i].Value);
                tkg += Convert.ToInt32(dataGridView1[4, i].Value);
            }
            textBox3.Text = amount.ToString();
            tbag.Text = tbags.ToString();
            label7.Text = tpc.ToString();
            label8.Text = tkg.ToString();

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
        void productload()
        {
            ComboBox cb = new ComboBox();
            product p = new product();
            DataTable dt = p.loadpr();
            for (int i = 0; i < dt.Rows.Count; i++) cb.Items.Add(dt.Rows[i][0].ToString());
            ((DataGridViewComboBoxColumn)dataGridView1.Columns["Column1"]).DataSource = cb.Items;

        }

        private void salevoucher_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'tMSDataSet.product' table. You can move, or remove it, as needed.

            // TODO: This line of code loads data into the 'tMSDataSet.product' table. You can move, or remove it, as needed.
            // TODO: This line of code loads data into the 'partysearch._partysearch' table. You can move, or remove it, as needed.
            loadname();
            productload();
            clear();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7)
            {
                dataGridView1.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                int col = dataGridView1.CurrentCell.ColumnIndex;
                int row = dataGridView1.CurrentCell.RowIndex;

                if (col == 0)
                {
                    dataGridView1.CurrentCell = dataGridView1.Rows[row].Cells[2];
                    dataGridView1.Focus();


                }
                else if (col < dataGridView1.Columns.Count - 3)
                {
                    dataGridView1.CurrentCell = dataGridView1.Rows[row].Cells[col + 1];
                    dataGridView1.Focus();
                }
                else
                {
                    if (dataGridView1[col, row].Value != null)
                    {
                        if (row == dataGridView1.Rows.Count - 1)
                            dataGridView1.Rows.Add(1);
                        dataGridView1.CurrentCell = dataGridView1.Rows[row + 1].Cells[0];
                        dataGridView1.Focus();
                    }
                }


                e.Handled = true;
                counter();
            }

        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                int amount = 0;
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    amount += Convert.ToInt32(dataGridView1[e.ColumnIndex, i].Value.ToString());
                }
                textBox3.Text = amount.ToString();
            }
            if (e.ColumnIndex == 1 && e.RowIndex != -1)
            {
                product p = new product();
                string q = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                if (p.search(q))
                {
                    dataGridView1[0, e.RowIndex].Value = p.code;
                    //      dataGridView1[7, e.RowIndex].Value = p.stk;
                    dataGridView1[5, e.RowIndex].Value = p.sr;
                }
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && dataGridView1[e.ColumnIndex, e.RowIndex].Value != null)
            {
                product p = new product();
                string q = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                if (p.search(q))
                {
                    dataGridView1[1, e.RowIndex].Value = p.name;
                    //      dataGridView1[7, e.RowIndex].Value = p.stk;
                    dataGridView1[5, e.RowIndex].Value = p.sr;
                    SendKeys.Send("{UP}");
                    SendKeys.Send("{Right}");

                    SendKeys.Send("{Right}");
                }
                else
                {
                    MessageBox.Show("Invalid Product Code");
                    SendKeys.Send("{UP}");
                    return;
                }
            }
            else if (e.ColumnIndex == 2 && dataGridView1[e.ColumnIndex, e.RowIndex].Value != null)
            {
                dataGridView1[3, e.RowIndex].Value = null;
                dataGridView1[4, e.RowIndex].Value = null;
                SendKeys.Send("{UP}");
                SendKeys.Send("{Right}");

            }
            else if (e.ColumnIndex == 3 && dataGridView1[e.ColumnIndex, e.RowIndex].Value != null)
            {
                dataGridView1[2, e.RowIndex].Value = null;
                dataGridView1[4, e.RowIndex].Value = null;
                SendKeys.Send("{UP}");
                SendKeys.Send("{Right}");

            }
            else if (e.ColumnIndex == 4 && dataGridView1[e.ColumnIndex, e.RowIndex].Value != null)
            {
                dataGridView1[3, e.RowIndex].Value = null;
                dataGridView1[2, e.RowIndex].Value = null;
                SendKeys.Send("{UP}");
                SendKeys.Send("{Right}");
            }

            else if (e.ColumnIndex < dataGridView1.Columns.Count - 3)
            {
                SendKeys.Send("{UP}");
                SendKeys.Send("{Right}");

            }
            else if (e.ColumnIndex == 5)
            {
                int col = e.ColumnIndex;
                dataGridView1.CurrentCell = dataGridView1[0, e.RowIndex];
                int row = e.RowIndex, unit, rate, amount;
                if (dataGridView1[2, e.RowIndex].Value != null)
                    unit = Convert.ToInt32(dataGridView1[2, e.RowIndex].Value);
                else if (dataGridView1[3, e.RowIndex].Value != null)
                    unit = Convert.ToInt32(dataGridView1[3, e.RowIndex].Value);
                else
                    unit = Convert.ToInt32(dataGridView1[4, e.RowIndex].Value);
                rate = Convert.ToInt32(dataGridView1[col, row].Value);
                amount = unit * rate;
                dataGridView1[col + 1, row].Value = amount;

            }
            counter();

        }

        private void dataGridView1_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            int unit, amount, rate;
            if (e.ColumnIndex == 5)
            {
                if (dataGridView1[2, e.RowIndex].Value != null)
                    unit = Convert.ToInt32(dataGridView1[2, e.RowIndex].Value);
                else if (dataGridView1[3, e.RowIndex].Value != null)
                    unit = Convert.ToInt32(dataGridView1[3, e.RowIndex].Value);
                else
                    unit = Convert.ToInt32(dataGridView1[4, e.RowIndex].Value);
                rate = Convert.ToInt32(dataGridView1[e.ColumnIndex, e.RowIndex].Value);
                amount = unit * rate;
                dataGridView1[e.ColumnIndex + 1, e.RowIndex].Value = amount;
            }
            counter();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && comboBox1.Text != "" && dataGridView1[0, 0].Value.ToString() != "")
            {
                sale s = new TMS.sale();
                s.sn = Convert.ToInt32(textBox1.Text);
                s.prty = comboBox1.Text;
                s.dt = dateTimePicker1.Text;
                s.dsc = textBox2.Text;
                s.tm = Convert.ToInt32(textBox3.Text);
                s.typ = "SALE";
                s.row = dataGridView1.Rows.Count - 1;
                order[] sorder = new order[100];
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    sorder[i] = new order();
                    sorder[i].amt = Convert.ToInt32(dataGridView1[6, i].Value.ToString());
                    sorder[i].no = s.sn;
                    sorder[i].rate = Convert.ToInt32(dataGridView1[5, i].Value);
                    sorder[i].bag = Convert.ToInt32(dataGridView1[2, i].Value);
                    sorder[i].kg = Convert.ToInt32(dataGridView1[4, i].Value);
                    sorder[i].pc = Convert.ToInt32(dataGridView1[3, i].Value);
                    sorder[i].type = s.typ;
                    sorder[i].code = dataGridView1[0, i].Value.ToString();


                }
                bool success = s.insert(sorder);
                MessageBox.Show("Insertion Succesful", "Insert");
                clear();
            }
            else
            {
                MessageBox.Show("PLEASE FILL ALL TEXT BOXES", "ERROR");
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loadrecord(Convert.ToInt32(textBox1.Text));
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if ((MessageBox.Show("Are You Sure to Delete the Record", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes))

            {
                int key = Convert.ToInt32(textBox1.Text);
                sale s = new sale();
                if (s.delete(key))
                    MessageBox.Show("Deletion Successful", "Delete");
                else
                    MessageBox.Show("Deletion Unsuccessful", "Delete");
            }
            clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if ((MessageBox.Show("Are You Sure to Update the Record", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes))

            {
                sale s = new TMS.sale();
                s.sn = Convert.ToInt32(textBox1.Text);
                s.prty = comboBox1.Text;
                s.dt = dateTimePicker1.Text;
                s.dsc = textBox2.Text;
                s.tm = Convert.ToInt32(textBox3.Text);
                s.typ = "SALE";
                s.row = dataGridView1.Rows.Count - 1;
                order[] sorder = new order[100];
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    sorder[i] = new order();
                    sorder[i].amt = Convert.ToInt32(dataGridView1[6, i].Value.ToString());
                    sorder[i].no = s.sn;
                    sorder[i].rate = Convert.ToInt32(dataGridView1[5, i].Value);
                    sorder[i].bag = Convert.ToInt32(dataGridView1[2, i].Value);
                    sorder[i].kg = Convert.ToInt32(dataGridView1[4, i].Value);
                    sorder[i].pc = Convert.ToInt32(dataGridView1[3, i].Value);
                    sorder[i].type = s.typ;
                    sorder[i].code = dataGridView1[0, i].Value.ToString();


                }
                int key = Convert.ToInt32(textBox1.Text);
                s.update(sorder, key);
            }
            clear();
        }

        private void salevoucher_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (external == false)
            {
                Dashboard d = new Dashboard();
                d.Show();
            }
        }

        private void comboBox1_TextUpdate(object sender, EventArgs e)
        {
            if (loadname())
                SendKeys.Send("{END}");
        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            counter();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            DataTable dt2 = new DataTable();
            dt2.Columns.Add("Srno", typeof(string));
            dt2.Columns.Add("Party Name", typeof(string));
            dt2.Columns.Add("Description", typeof(string));
            dt2.Columns.Add("Dated", typeof(string));
            dt2.Columns.Add("Total Amount", typeof(string));
            dt2.Columns.Add("Bags", typeof(string));
            dt2.Columns.Add("Packet", typeof(string));
            dt2.Columns.Add("KG", typeof(string));

            dt2.Rows.Add(textBox1.Text,comboBox1.Text,textBox2.Text,dateTimePicker1.Text,textBox3.Text,tbag.Text,label7.Text,label8.Text);

           
            DataTable dt = new DataTable();
           
            dt.Columns.Add("Pname", typeof(string));
            dt.Columns.Add("kg", typeof(Int32));
            dt.Columns.Add("bag", typeof(Int32));
            dt.Columns.Add("pc", typeof(Int32));
            dt.Columns.Add("Rate", typeof(Int32));
            dt.Columns.Add("Amount", typeof(Int32));


            foreach (DataGridViewRow dgv in dataGridView1.Rows)
            {
                dt.Rows.Add(dgv.Cells[1].Value, dgv.Cells[2].Value, dgv.Cells[3].Value, dgv.Cells[4].Value, dgv.Cells[5].Value, dgv.Cells[6].Value);
            }
            ds.Tables.Add(dt);
            ds.Tables.Add(dt2);
            ds.WriteXmlSchema("SaleVoucher.xml");
            saleprint sp = new saleprint(ds);
            sp.Show();
        }
    }
}
