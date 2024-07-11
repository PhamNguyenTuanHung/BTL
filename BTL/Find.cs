using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL
{
    public partial class Find : Form
    {
        public Find()
        {
            InitializeComponent();
        }
        public delegate void GETDATA(string data);
        public GETDATA data;


        private void but_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void but_Find_Next_Click(object sender, EventArgs e)
        {
            data(textBox1.Text);
        }
    }
}
