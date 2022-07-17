using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class bookControlForm : Form
    {
        public bookControlForm()
        {
            InitializeComponent();
        }

        private void bookControlForm_Load(object sender, EventArgs e)
        {
            this.label10.Text = "";
            this.checkBox1.Enabled = false;
            this.checkBox2.Enabled = false;
            this.comboBox1.Enabled = false;
            this.comboBox2.Enabled = false;
            this.button1.Enabled = false;
            this.button2.Enabled = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.checkBox1.Enabled = true;
            this.checkBox2.Enabled = true;
            this.comboBox1.Enabled = true;
            this.comboBox2.Enabled = true;
            this.button1.Enabled =true;
            this.button2.Enabled = true;
            this.comboBox1.Text = "0";
            this.comboBox2.Text = "0";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.textBox1.Clear();
            this.label10.Text = "";
            this.checkBox1.Enabled = false;
            this.checkBox2.Enabled = false;
            this.comboBox1.Enabled = false;
            this.comboBox2.Enabled = false;
            this.button1.Enabled = false;
            this.button2.Enabled = false;
            this.checkBox1.Checked = false;
            this.checkBox2.Checked = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void handleExit(object sender, FormClosingEventArgs e)
        {
                DialogResult dialog = MessageBox.Show("Bạn muốn thoát không?", "", MessageBoxButtons.YesNo);

                if (dialog == DialogResult.No)
                {
                    e.Cancel = true;
                }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int total = 0;
            if (this.checkBox1.Checked) total += 100000;
            if (this.checkBox2.Checked) total += 150000;
            int temp;
            if (Int32.TryParse(this.comboBox1.Text, out temp))
            {
                total += (temp * 150000);
            }
            if (Int32.TryParse(this.comboBox2.Text,out temp))
            {
                total += (temp * 200000);
            }
            this.label10.Text = (total.ToString() + "Đ");
            MessageBox.Show($"Tổng số tiền khách hàng {this.textBox1.Text} thanh toán: {total.ToString()} đồng");
            
        }
    }
}
