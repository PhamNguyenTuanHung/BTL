using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BTL
{
    public partial class Replace : Form
    {
        public Replace()
        {
            InitializeComponent();
        }
        public delegate void GETDATAFIND(string data);
        public delegate void GETDATAREPLACE(string data1,string data2);

        public string DataFormMain;
        public GETDATAFIND data;
        public GETDATAREPLACE data_find_replace_once,data_find_replace_all;
        public GETDATAFIND data_set;
        public bool get_data_set(bool data)
        {
            return data;
        }
        
        private void but_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void but_Find_Next_Click(object sender, EventArgs e)
        {
            if (text_find.Text == "")
            {
                MessageBox.Show("Nhập dữ liệu");
                text_find.Focus();
                return;
            }
            data(text_find.Text);
            data_set("0");
        }

        private void but_Rep_Click(object sender, EventArgs e)
        {
            try 
            {
                if (text_find.Text == "")
                {
                    MessageBox.Show("Nhập dữ liệu");
                    text_find.Focus();
                    return;
                }
                if (txt_replace.Text == "")
                {
                    MessageBox.Show("Nhập dữ liệu");
                    txt_replace.Focus();
                    return;
                }
            data_find_replace_once(text_find.Text, txt_replace.Text);
            data_set("1"); 
            }
            catch (NullReferenceException ){ };
        }

        private void but_repAll_Click(object sender, EventArgs e)
        {
            try
            {
                if (text_find.Text == "")
                {
                    MessageBox.Show("Nhập dữ liệu");
                    text_find.Focus();
                    return;
                }
                if (txt_replace.Text == "")
                {
                    MessageBox.Show("Nhập dữ liệu");
                    txt_replace.Focus();
                    return;
                }
                data_find_replace_all(text_find.Text, txt_replace.Text);
                data_set("2");
            }
            catch { };
            }
    }
}
