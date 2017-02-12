using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace StreamWriter_Project
{
    public partial class frmStreamWriterProject : Form
    {
        public frmStreamWriterProject()
        {
            InitializeComponent();
        }
      
        StreamWriter OutFile = new StreamWriter(@"U:\Data\Attendance.txt", true);
              
        private void btnAttendance_Click(object sender, EventArgs e)
        {
            if (OutFile == null || OutFile.BaseStream == null)
            {
                OutFile = File.AppendText(@"U:\Data\Attendance.txt");
            }
            try
            {
                OutFile.WriteLine(txtName.Text);
                MessageBox.Show(txtName.Text + " is on the attendance list now.");
                txtName.Focus();
                txtName.SelectAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            string path = @"U:\Data\Attendance02.txt";
            if (!File.Exists(path))
            {
                File.Create(path).Dispose();
                using (StreamWriter OutFile = new StreamWriter(path, true))
                {
                    try
                    {
                        OutFile.WriteLine(txtName.Text);
                        MessageBox.Show(txtName.Text + " is on the attendance list now.");
                        txtName.Focus();
                        txtName.SelectAll();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else if (File.Exists(path))
            {
                using (StreamWriter OutFile = new StreamWriter(path))
                {
                    MessageBox.Show("File already exits.");
                    
                }
            }
        }
        
            
        private void btnHelloWorld_Click(object sender, EventArgs e)
        {
            try
            {
                StreamWriter outHelloFile;
                outHelloFile = File.AppendText(@"U:\Data\HelloWorld.txt");
                outHelloFile.Write("Hello World! ");
                outHelloFile.Close();
                MessageBox.Show(@"The File U:\Data\HelloWorld.txt is saved");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnNumberList_Click(object sender, EventArgs e)
        {
            StreamWriter numberList;
            numberList = File.CreateText(@"U:\data\numberlist.txt");
            for (int x = 0; x <= 10000; x += 100)
            {
                numberList.WriteLine(x.ToString());
                numberList.Write(x.ToString() + ", ");
                //put numbers on one line but with commas and a space
            }
            numberList.Close();
            MessageBox.Show("Text File numberlist.txt is created.");
        }
    }
}
 