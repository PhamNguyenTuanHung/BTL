using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Drawing.Text;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace BTL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Default Setting
        Font f_text;
        int Size_Font = 8;
        string fontDefault;
        Color color_font = Color.Black;
        Color color_highlighter = Color.Transparent;
        bool check_Bold = false;  // Dùng để check Font Bold
        bool check_Italic = false;  // Dùng để chck Font Italic
        bool check_UnderLine = false; // Dùng để check Font Underline
        bool check_StrikeThrough = false; // Dùng để check Font StrikeThrough
        bool check_supText = false; // Dùng để check Font supText
        bool check_subText = false; // Dùng để check Font subText      
        //End font 

        // Setting paragraph
        bool check_list = false;
        double number_lineSpacing = 1.0;
        string Text_Before_Justified;
        string fileName = "NoName";
        // Ending paragraph

        bool check_word_wrap = false;

        //Setting dateAndTime
        public string s_time;
        public string set;// Lưu lựa chọn replace
        public string find;// Lưu  find;
        public string replace;// lưu replace;

        //End dateAndTime

        private void richTextBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                conMenu_ClickRight.Show(this, this.PointToClient(MousePosition));
            }

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Load_Font(); // Dùng để load các font vào trong combo_box
            Load_Paragraph();
            this.Text = fileName;

        }
        void Load_Font()
        {

            foreach (FontFamily f in FontFamily.Families)       // Đọc các font 
            {
                comb_Font.Items.Add(f.Name);        // Add vô combo_box
            }
            comb_Font.SelectedIndex = 0;    // Mặc định là cái đầu tiên

            int[] fontSizes = { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 }; //Font size default
            foreach (var fontSize in fontSizes)
            {
                comb_fontSize.Items.Add(fontSize);      // chèn font size vô comboBox
            }
            comb_fontSize.SelectedItem = 16;        //Font Size default là 16
            comb_Font.SelectedItem = "Arial";       //Font default là Arial

            fontDefault = "Arial";  //Font default là Arial
            Size_Font = 16;  //Font Size default là 16

            f_text = new Font(fontDefault, Size_Font);
            lab_ColorText.BackColor = color_font;       // Hiển thị màu chữ default
            richTextBox1.SelectionIndent = 90;          // Lề mặc định 
            richTextBox1.SelectionRightIndent = 90;
            richTextBox1.Font = f_text;                 // Gán font mặc định
            richTextBox1.AutoWordSelection = true;
            hScrollBar1.Visible = false;
        }

        private void butIncreaseSize_Click(object sender, EventArgs e)
        {
            if (comb_fontSize.SelectedIndex < comb_fontSize.Items.Count - 1) // Kiểm tra xem mình có thể tăng được nữa không
            {
                comb_fontSize.SelectedIndex += 1; //Tăng font size
            }
        }

        private void butDecreaseSize_Click(object sender, EventArgs e)
        {
            if (comb_fontSize.SelectedIndex > 0)        // Kiểm tra xem mình có thể giảm được nữa không :?
            {
                comb_fontSize.SelectedIndex -= 1;       //Giảm font size
            }
        }

        private void comb_Font_SelectedIndexChanged(object sender, EventArgs e)
        {
            fontDefault = comb_Font.SelectedItem.ToString();        // Gán font mới vô default
            f_text = new Font(fontDefault, Size_Font);              // Tạo font mới
            richTextBox1.SelectionFont = f_text;                    // Gán font cho văn bản từ bây giờ
        }

        private void comb_fontSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comb_fontSize.SelectedItem.ToString() == null) { return; }
                Size_Font = int.Parse(comb_fontSize.SelectedItem.ToString());
                f_text = new Font(fontDefault, Size_Font);
                richTextBox1.SelectionFont = f_text;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void but_color_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                color_font = colorDialog1.Color; // Set màu cho font chữ
                lab_ColorText.BackColor = color_font; //Set màu cho hiện thị màu
                richTextBox1.SelectionColor = color_font; // Set màu cho chữ
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                color_highlighter = colorDialog1.Color; // Set màu cho font highlighter
                lab_ColorHighLighter.BackColor = color_highlighter; //Set màu cho hiện thị màu cho highlighter
                richTextBox1.SelectionBackColor = color_highlighter; //Set màu cho chữ
            }
        }


        // Setting các button option font
        private void but_BoldFont_Click(object sender, EventArgs e)
        {
            if (check_Bold)     //Check có bold hay không
            {
                check_Bold = false;     //Đổi lại bold
                but_BoldFont.BackColor = Color.Transparent;     //Nếu là không chọn thì không hiện thị màu ở button

            }
            else
            {
                check_Bold = true;      //Chọn bold
                but_BoldFont.BackColor = Color.LightGreen;      //Hiển thị để biết mình chọn button
            }
            check_font();       //Kiểm tra xem mình còn có chọn các FontStyle khác 
            richTextBox1.Focus();
        }

        private void butItalicFont_Click(object sender, EventArgs e)
        {
            if (check_Italic)       //Kiểm tra xem mình có chọn Italic
            {
                check_Italic = false;       // Đánh đấu là mình không chọn Italic
                butItalicFont.BackColor = Color.Transparent;        // Đổi màu trong suốt cho button
            }
            else
            {
                check_Italic = true;        //  Đánh dấu là mình chọn Italic
                butItalicFont.BackColor = Color.LightGreen;     // Đổi màu cho button
            }
            check_font();  //Kiểm tra xem mình còn có chọn các FontStyle khác 
            richTextBox1.Focus();
        }

        private void butUndLineFont_Click(object sender, EventArgs e)
        {
            if (check_UnderLine)
            {
                check_UnderLine = false;
                butUndLineFont.BackColor = Color.Transparent;
            }
            else
            {
                check_UnderLine = true;
                butUndLineFont.BackColor = Color.LightGreen;
            }
            check_font();
            richTextBox1.Focus();
        }

        private void butStrikeThroughFont_Click(object sender, EventArgs e)
        {
            if (check_StrikeThrough)
            {
                check_StrikeThrough = false;
                butStrikeThroughFont.BackColor = Color.Transparent;
            }
            else
            {
                check_StrikeThrough = true;
                butStrikeThroughFont.BackColor = Color.LightGreen;
            }
            check_font();
            richTextBox1.Focus();
        }

        private void but_subText_Click(object sender, EventArgs e)
        {
            Font f;
            if (check_supText)
            {
                check_supText = false;
                but_supText.BackColor = Color.Transparent;
                richTextBox1.SelectionCharOffset = 1;
                richTextBox1.SelectionFont = f_text;
            }
            if (check_subText)
            {
                check_subText = false;
                but_subText.BackColor = Color.Transparent;
                richTextBox1.SelectionCharOffset = 1;
                richTextBox1.SelectionFont = f_text;

            }
            else
            {
                check_subText = true;
                but_subText.BackColor = Color.LightGreen;
                richTextBox1.SelectionCharOffset = -5;
                f = new Font(fontDefault, Size_Font - 5);
                f = check_font(f);
                richTextBox1.SelectionFont = f;
            }

        }

        private void but_supText_Click(object sender, EventArgs e)//Bug
        {
            Font f;
            if (check_subText)
            {
                check_subText = false;
                but_subText.BackColor = Color.Transparent;
                richTextBox1.SelectionCharOffset = 1;
                richTextBox1.SelectionFont = f_text;

            }
            if (check_supText)
            {
                check_supText = false;
                but_supText.BackColor = Color.Transparent;
                richTextBox1.SelectionCharOffset = 1;
                richTextBox1.SelectionFont = f_text;
            }
            else
            {
                check_supText = true;
                but_supText.BackColor = Color.LightGreen;
                richTextBox1.SelectionCharOffset = 5;
                f = new Font(fontDefault, Size_Font - 5);
                f = check_font(f);
                richTextBox1.SelectionFont = f;

            }

        }
        void check_font()
        {
            FontStyle fs = FontStyle.Regular;
            if (check_Bold) fs |= FontStyle.Bold;
            if (check_Italic) fs |= FontStyle.Italic;
            if (check_StrikeThrough) fs |= FontStyle.Strikeout;
            if (check_UnderLine) fs |= FontStyle.Underline;
            f_text = new Font(f_text, fs);
            richTextBox1.SelectionFont = f_text;
        }
        Font check_font(Font f_text)
        {
            FontStyle fs = FontStyle.Regular;
            if (check_Bold) fs |= FontStyle.Bold;
            if (check_Italic) fs |= FontStyle.Italic;
            if (check_StrikeThrough) fs |= FontStyle.Strikeout;
            if (check_UnderLine) fs |= FontStyle.Underline;
            f_text = new Font(f_text, fs);
            //richTextBox1.Font = f_text;
            return f_text;
        }
        private void comb_fontSize_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Size_Font = int.Parse(comb_fontSize.Text);
                f_text = new Font(fontDefault, Size_Font);
                f_text = check_font(f_text);
                richTextBox1.SelectionFont = f_text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //End seting buttons option font




        //Setting paragraph
        private void but_DecreaseIndent_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionIndent > 0)
            {
                richTextBox1.SelectionIndent -= 30;
            }
        }

        private void but_IncreaseIndent_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionIndent += 30;
        }

        private void but_List_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionBullet)
            {
                richTextBox1.SelectionBullet = false;
                but_List.BackColor = Color.Transparent;
            }
            else
            {
                richTextBox1.SelectionBullet = true;
                but_List.BackColor = Color.LightGreen;
            }

        }
        void Load_Paragraph()
        {
            richTextBox1.SelectionCharOffset = 16;
            toolStripMenuItem2.Checked = true;
            richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
            but_alignLeft.BackColor = Color.LightGreen;
        }

        private void but_LineSpacing_Click(object sender, EventArgs e)
        {
            conMenu_LineSpacing.Show(this, this.PointToClient(MousePosition));
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            toolStripMenuItem3.Checked = false;
            toolStripMenuItem4.Checked = false;
            toolStripMenuItem2.Checked = false;
            toolStripMenuItem5.Checked = true;
            if (toolStripMenuItem5.Checked)
                richTextBox1.SelectionCharOffset = (int)(4 * 2);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            toolStripMenuItem5.Checked = false;
            toolStripMenuItem4.Checked = false;
            toolStripMenuItem3.Checked = false;
            toolStripMenuItem2.Checked = true;
            if (toolStripMenuItem2.Checked)
                richTextBox1.SelectionCharOffset = (int)(4 * 1.0);
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            toolStripMenuItem5.Checked = false;
            toolStripMenuItem4.Checked = false;
            toolStripMenuItem2.Checked = false;
            toolStripMenuItem3.Checked = true;

            if (toolStripMenuItem3.Checked)
                richTextBox1.SelectionCharOffset = (int)(4 * 1.25);
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            toolStripMenuItem5.Checked = false;
            toolStripMenuItem3.Checked = false;
            toolStripMenuItem2.Checked = false;
            toolStripMenuItem4.Checked = true;
            if (toolStripMenuItem4.Checked)
                richTextBox1.SelectionCharOffset = (int)(4.0 * 1.5);
        }

        private void but_alignLeft_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
            but_alignLeft.BackColor = Color.LightGreen;
            but_AlignRight.BackColor = Color.Transparent;
            but_AlignCenter.BackColor = Color.Transparent;
            but_AlignJustify.BackColor = Color.Transparent;
        }

        private void but_AlignCenter_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
            but_alignLeft.BackColor = Color.Transparent;
            but_AlignRight.BackColor = Color.Transparent;
            but_AlignCenter.BackColor = Color.LightGreen;
            but_AlignJustify.BackColor = Color.Transparent;
        }

        private void but_AlignRight_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
            but_alignLeft.BackColor = Color.Transparent;
            but_AlignRight.BackColor = Color.LightGreen;
            but_AlignCenter.BackColor = Color.Transparent;
            but_AlignJustify.BackColor = Color.Transparent;
        }

        private void but_AlignJustify_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectedText = JustifyText(richTextBox1.SelectedText, richTextBox1.Width - richTextBox1.SelectionIndent - richTextBox1.SelectionRightIndent);
            but_alignLeft.BackColor = Color.Transparent;
            but_AlignRight.BackColor = Color.Transparent;
            but_AlignCenter.BackColor = Color.Transparent;
            but_AlignJustify.BackColor = Color.LightGreen;
        }
        static string JustifyText(string text, int totalWidth)
        {
            string[] words = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int wordCount = words.Length;
            int totalSpaces = totalWidth - text.Length + wordCount - 1;
            int spacesBetweenWords = wordCount > 1 ? totalSpaces / (wordCount - 1) : totalSpaces;
            int extraSpaces = wordCount > 1 ? totalSpaces % (wordCount - 1) : 0;

            string justifiedText = "";
            for (int i = 0; i < wordCount; i++)
            {
                justifiedText += words[i];
                if (i < wordCount - 1)
                {
                    justifiedText += new string(' ', spacesBetweenWords + (i < extraSpaces ? 1 : 0));
                }
            }

            return justifiedText;
        }


        //Ending setting paragraph

        //Setting insert 

        private void but_Picture_Click(object sender, EventArgs e)
        {
            if (openFileImage.ShowDialog() == DialogResult.OK)
            {
                openFileImage.Filter = "Image files|*.jpg;*.jpeg;*.png;*.gif;*.tif;...";
                Image ima = Image.FromFile(openFileImage.FileName);
                Clipboard.SetImage(ima);
                richTextBox1.Paste();
            }
        }
        //End insert

        //Setting editing 
        private void but_SelectAll_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
            richTextBox1.Focus();
            //MessageBox(richTextBox);
            // richTextBox1.SelectionBackColor = Color.Gray;
        }

        public void GETVALUE(string data)
        {
            richTextBox1.Text += data;
        }


        public void GET(string data)
        {
            set = data;
        }


        int index = 0, startindex = 0;
        string TuCu;// Từ vừa tìm kiếm
        MatchCollection matches;
        //List<int> position = new List<int>();
        public void FINDVALUE(string data)
        {
            if (richTextBox1.Find(data, 0, RichTextBoxFinds.None) == -1)
            {
                MessageBox.Show("Không tìm thấy");
                return;
            }
            if (startindex > richTextBox1.Text.Length)
                startindex = 0;
            index = richTextBox1.Find(data, startindex, RichTextBoxFinds.None);
            if (index == -1)
            {
                index = 0;
            }
            richTextBox1.Select(index, data.Length);
            richTextBox1.Focus();
            startindex = index + data.Length;
            /*if (data == TuCu)
            {
                if (i > matches.Count - 1 || i < 0)
                    i = 0;
            }
            else
            {

                matches = Regex.Matches(richTextBox1.Text, data);
                if (matches.Count <= 0)
                {
                    MessageBox.Show("Không tìm được");
                    return;
                }
                if (matches.Count > 0)
                {
                    position.Clear();
                    if (i > matches.Count - 1 || i < 0)
                        i = 0;
                    foreach (Match match in matches)
                    {
                        position.Add(match.Index);
                    }
                }
                richTextBox1.Select(position[i], matches[i].Length);
                richTextBox1.Focus();
                i++;*/
        }

        /*if (richTextBox1.Find(data) != -1)
        {
            // Character found, set selection start and end positions
            richTextBox1.Select(richTextBox1.Find(data), data.Length); // Select only the character (length of 1)
            richTextBox1.Focus(); // Set focus to RichTextBox for visual selection
        }
        else
        {
            // Character not found, handle it (e.g., show message)
            MessageBox.Show("Character not found!");
        }*/
        public void REP_ALL_VALUE(string data1, string data2)
        {

            /*List<int> positions = new List<int>();
            foreach (Match match in matches)
            {
                positions.Add(match.Index);
            }
            for (int j= 0;j < positions.Count;j++)
            {
                richTextBox1.Select(positions[j], matches[j].Length);
                richTextBox1.SelectedText = data2;
            }    */
            Font font = richTextBox1.SelectionFont;
            richTextBox1.Text=Regex.Replace(richTextBox1.Text,data1,data2,RegexOptions.IgnoreCase);
            //richTextBox1.Text = richTextBox1.Text.Replace(data1, data2);
            richTextBox1.Font = font;

            MessageBox.Show("Thay thế  thành công");
        }
        public void REP_ONCE_VALUE(string data1, string data2)
        {
            FINDVALUE(data1);
            richTextBox1.SelectedText = data2;
            richTextBox1.Focus();
        }
        private void but_Find_Click(object sender, EventArgs e)
        {
            Find f_form = new Find();
            f_form.data = new Find.GETDATA(FINDVALUE);
            f_form.Show();
        }
        private void but_replace_Click(object sender, EventArgs e)
        {

            Replace r_form = new Replace();
            r_form.data_set = new Replace.GETDATAFIND(GET);
            r_form.data = new Replace.GETDATAFIND(FINDVALUE);
            r_form.data_find_replace_all = new Replace.GETDATAREPLACE(REP_ALL_VALUE);
            r_form.data_find_replace_once = new Replace.GETDATAREPLACE(REP_ONCE_VALUE);

            switch (set)
            {
                case "0":
                    {
                        r_form.data = new Replace.GETDATAFIND(FINDVALUE);
                        break;
                    }
                case "1":
                    {

                        r_form.data_find_replace_once = new Replace.GETDATAREPLACE(REP_ONCE_VALUE);
                        break;
                    }
                case "2":
                    {

                        r_form.data_find_replace_all = new Replace.GETDATAREPLACE(REP_ALL_VALUE);
                        break;
                    }
            }
            r_form.Show();
        }

        private void but_DateAndTime_Click(object sender, EventArgs e)
        {
            DateAndTime date = new DateAndTime();
            date.data = new DateAndTime.GETDATA(GETVALUE);
            date.ShowDialog();
        }

        // End setting editing 


        // Setting clipboard
        private void but_Cut_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void but_Copy_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void but_Paste_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }


        // End clipboard

        // Setting zoom
        private void but_ZoomIn_Click(object sender, EventArgs e)
        {
            if (label1.Width > 0)
            {
                label1.Width -= 10;
                label2.Width -= 10;
                richTextBox1.ZoomFactor += 0.01f;
            }
            //    
        }

        private void but_ZoomOut_Click(object sender, EventArgs e)
        {
            if (ClientRectangle.Width - (label1.Width + label2.Width) > 300)
            {
                label1.Width += 10;
                label2.Width += 10;
                richTextBox1.ZoomFactor -= 0.01f;
            }
        }

        private void but_NormalZoom_Click(object sender, EventArgs e)
        {
            label1.Width = 300;
            label2.Width = 300;
            richTextBox1.ZoomFactor = 1;
        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        //private void ckb_Ruler_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (!ckb_Ruler.Checked)
        //    {
        //        tableLayoutPanel1.RowCount = 2;
        //        Label l = new Label();
        //        l.AutoSize = false;
        //        l.BackColor = Color.Black;
        //        l.Dock = DockStyle.Fill;
        //        tableLayoutPanel1.Controls.Add(l);
        //        ckb_Ruler.Checked = false;
        //    }
        //    else
        //    {
        //        tableLayoutPanel1.RowCount = 1;
        //        ckb_Ruler.Checked = true;
        //    }

        //}

        private void ckb_StatusBar_CheckedChanged(object sender, EventArgs e)
        {
            if (ckb_StatusBar.Checked)
            {
                label22.Visible = true;
                but_DecZoom.Visible = true;
                but_IncZoom.Visible = true;
                hScrollBar1.Visible = true;
            }
            else
            {
                label22.Visible = false;
                but_DecZoom.Visible = false;
                but_IncZoom.Visible = false;
                hScrollBar1.Visible = false;
            }
        }

        private void label22_Click_1(object sender, EventArgs e)
        {

        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            if (hScrollBar1.Value > 0)
            {
                float value = (hScrollBar1.Value * (float)1) / (hScrollBar1.Maximum / 2);
                richTextBox1.ZoomFactor = value;
            }
        }

        private void but_DecZoom_Click(object sender, EventArgs e)
        {
            if (hScrollBar1.Value > 10)
            {
                hScrollBar1.Value -= 10;
                if (richTextBox1.ZoomFactor > 0)
                    richTextBox1.ZoomFactor -= 0.05f;
            }
        }

        private void but_IncZoom_Click(object sender, EventArgs e)
        {
            if (hScrollBar1.Value < 191)
            {
                hScrollBar1.Value += 10;
                richTextBox1.ZoomFactor += 0.1f;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!check_word_wrap)
            {
                richTextBox1.WordWrap = true;
                check_word_wrap = true;
                button1.BackColor = Color.LightGreen;
            }
            else
            {
                richTextBox1.WordWrap = false;
                check_word_wrap = false;
                button1.BackColor = Color.Transparent;
            }
        }

        private void but_Exit_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Modified)
            {
                if (MessageBox.Show("Bạn có muốn lưu tập tin đang soạn thảo hay không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    but_SaveFile_Click(null, null);
                }
            }
            this.Close();
        }

        private void but_NewFile_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Modified)
            {
                if (MessageBox.Show("Bạn có muốn lưu tập tin đang soạn thảo hay không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    but_SaveFile_Click(null, null);
                }
            }
            fileName = "NoName";
            richTextBox1.Text = "";
            this.Text = "Wordpad - " + fileName;
        }

        private void but_OpenFile_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Modified)
            {
                if (MessageBox.Show("Bạn có muốn lưu tập tin đang soạn thảo hay không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    but_SaveFile_Click(null, null);
                }
            }
            if (openFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                openFile.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                fileName = openFile.FileName;
                richTextBox1.Text = File.ReadAllText(fileName);
                this.Text = "Loc's word - " + fileName;
            }
        }

        private void but_SaveFile_Click(object sender, EventArgs e)
        {
            if (fileName == "NoName")
            {
                but_SaveAs_Click(null, null);
            }
            else
            {
                System.IO.File.WriteAllText(fileName, richTextBox1.Text);
                saveFile.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                this.Text = "Loc's word - " + fileName;

            }
        }

        private void but_SaveAs_Click(object sender, EventArgs e)
        {
            if (saveFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                saveFile.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                fileName = saveFile.FileName;
                System.IO.File.WriteAllText(fileName, richTextBox1.Text);
                this.Text = "Loc's word - " + fileName;
            }
        }

        private void but_Print_Click(object sender, EventArgs e)
        {
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();

            }
        }

        private int linesPrinted = 0;
        private string[] lines;

        private void printDocument1_BeginPrint_1(object sender, PrintEventArgs e)
        {
            lines = richTextBox1.Text.Split(new char[] { '\n' });
            int i = 0;
            foreach (string s in lines)
            {
                lines[i++] = s.TrimEnd('\r');
            }
        }
        private void printDocument1_PrintPage_1(object sender, PrintPageEventArgs e)
        {
            int x = e.MarginBounds.Left;
            int y = e.MarginBounds.Top;
            Brush brush = new SolidBrush(richTextBox1.ForeColor);
            while (linesPrinted < lines.Length && y < e.MarginBounds.Bottom)
            {
                e.Graphics.DrawString(lines[linesPrinted++], richTextBox1.Font, brush, x, y);
                y += 15;
            }
            e.HasMorePages = linesPrinted < lines.Length;
        }

        private void but_PageSetUp_Click(object sender, EventArgs e)
        {
            pageSetupDialog1.PageSettings =
   new System.Drawing.Printing.PageSettings();

            // Initialize dialog's PrinterSettings property to hold user
            // set printer settings.
            pageSetupDialog1.PrinterSettings =
                new System.Drawing.Printing.PrinterSettings();

            //Do not show the network in the printer dialog.
            pageSetupDialog1.ShowNetwork = false;

            //Show the dialog storing the result.
            DialogResult result = pageSetupDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                object[] results = new object[]{
            pageSetupDialog1.PageSettings.Margins,
            pageSetupDialog1.PageSettings.PaperSize,
            pageSetupDialog1.PageSettings.Landscape,
            pageSetupDialog1.PrinterSettings.PrinterName,
            pageSetupDialog1.PrinterSettings.PrintRange};
            }
        }

        private void but_InfoApp_Click(object sender, EventArgs e)
        {
            info f_info = new info();
            f_info.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (richTextBox1.Modified)
            {
                if (MessageBox.Show("Bạn có muốn lưu tập tin đang soạn thảo hay không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    but_SaveFile_Click(null, null);
                }
            }
        }

        //End zoom

    }

}
