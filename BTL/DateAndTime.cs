using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace BTL
{
    public partial class DateAndTime : Form
    {
        public DateAndTime()
        {
            InitializeComponent();
        }
        public delegate void GETDATA(string data);
        public GETDATA data;
        private void DateAndTime_Load(object sender, EventArgs e)
        {
            DateTime date = DateTime.Now;
            listBox1.Items.Add(date.ToShortTimeString());
            listBox1.Items.Add(date.ToLongDateString());
            listBox1.Items.Add(date.ToShortDateString());
            listBox1.Items.Add(date.ToString());
            listBox1.Items.Add(date.ToLongTimeString());
        }


        private void but_OK_Click(object sender, EventArgs e)
        {
            data(listBox1.SelectedItem.ToString());
            this.Close();
        }

        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void but_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
