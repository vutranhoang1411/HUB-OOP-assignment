using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
namespace WindowsFormsApp1
{
    public partial class studentManagerForm : Form
    {   

        public class studentInfo
        {
            public string maSV { get; set; }
            public string ho { get; set; }
            public string ten { get; set; }
            private DateTime ngaysinh;
            public DateTime NgaySinh
            {
                get
                {
                    return ngaysinh.Date;
                }
                set
                {
                    ngaysinh = value;
                }
            }
            public string gioitinh{get;set;}
            public string makhoa { get; set; }




            public studentInfo( string maSV, string ho, string ten, DateTime ngaysinh, string gioitinh, string makhoa)
            {
                this.ngaysinh = ngaysinh;
                this.gioitinh = gioitinh;
                this.maSV = maSV;
                this.makhoa = makhoa;
                this.ho = ho;
                this.ten = ten;
            }
            public string toString()
            {
                return (this.maSV + "," + this.ho + "," + this.ten + "," + this.ngaysinh.ToString("MM / dd / yyyy") + "," + this.gioitinh + "," + this.makhoa);
            }
            
        }
        private BindingList<studentInfo> studentList;
        public studentManagerForm()
        {
            studentList = new BindingList<studentInfo>();
            getUserListFromCSV(@"F:\userData\userdata.txt");
            
            InitializeComponent();
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.DataSource = studentList;

            int height = this.dataGridView1.RowTemplate.Height*studentList.Count;
            adjustForm(height);

            //this.dataGridView1.AutoSizeColumnsMode= DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private void adjustForm(int height)
        {
            this.dataGridView1.Height += height;
            this.groupBox2.Location = new System.Drawing.Point(56, this.groupBox2.Location.Y + height);
            this.Size = new Size(this.Size.Width, this.Size.Height + height);
        }
        private void getUserListFromCSV(string path)
        {
            string[] lines = System.IO.File.ReadAllLines(path);
            for (int i = 0; i < lines.Length; i++)
            {
                string[] lineData = lines[i].Split(',');
                studentList.Add(new studentInfo(lineData[0], lineData[1], lineData[2], DateTime.Parse(lineData[3]), lineData[4], lineData[5]));
            }
        }
        private void form_Shown(object sender, EventArgs e)
        {
            this.label1.Focus();
        }


        /////////////////////////////////button section///////////////////////////////
        //handle new item init
        private void newItemButton_Click(object sender, EventArgs e)
        {
            this.maSVBox.Clear();
            this.hoSVBox.Clear();
            this.gioitinhBox.SelectedIndex = -1;
            this.tenSVBox.Clear();
            this.makhoaBox.Clear();
            this.dateBox.ResetText();
            this.maSVBox.Focus();

        }
        //handle adding new item

        private bool checkingInput(studentInfo s_info)
        {
            if (s_info.ho == "" || s_info.makhoa == "" || s_info.maSV == "" || s_info.ten == "" || (s_info.gioitinh != "Nam" && s_info.gioitinh != "Nữ")){
                MessageBox.Show("Some field have error value", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;

        }
        private void addButton_Click(object sender, EventArgs e)
        {
            studentInfo newStudent = new studentInfo( this.maSVBox.Text, this.hoSVBox.Text, this.tenSVBox.Text, this.dateBox.Value, this.gioitinhBox.Text, this.makhoaBox.Text);
            if (this.checkingInput(newStudent))
            {
                
                studentList.Add(newStudent);

                //adjust the form
                int height = this.dataGridView1.RowTemplate.Height;
                adjustForm(height);
            }
            //add new student
            
        }

        //handle modify
        private void modifyButton_Click(object sender, EventArgs e)
        {
            this.dataGridView1.ReadOnly = false;
        }

        private void saveFile(string path)
        {
            System.IO.File.WriteAllText(path,String.Empty);
            System.IO.StreamWriter sw = System.IO.File.AppendText(path);
            for (int i = 0; i < studentList.Count; i++)
            {
                sw.Write(studentList[i].toString());
                if (i != studentList.Count - 1) sw.Write('\n');
            }
            sw.Close();
        }
        //save the modify data to the database
        private void saveButton_Click(object sender, EventArgs e)
        {
            for (int i=0; i < studentList.Count; i++)
            {
                if (!checkingInput(studentList[i]))  return;
            }
            saveFile(@"F:\userData\userdata.txt");
        }


        private void eraseButton_Click(object sender, EventArgs e)
        {
            this.dataGridView1.AllowUserToDeleteRows = true;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ReadOnly = true;
        }
        private void handleDeleteRow(object sender,DataGridViewRowEventArgs e)
        {
            int height = -this.dataGridView1.RowTemplate.Height;
            adjustForm(height);
        }

    }
}
