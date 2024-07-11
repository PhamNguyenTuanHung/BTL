namespace BTL
{
    partial class DateAndTime
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            but_Cancel = new Button();
            but_OK = new Button();
            label1 = new Label();
            listBox1 = new ListBox();
            SuspendLayout();
            // 
            // but_Cancel
            // 
            but_Cancel.Location = new Point(325, 566);
            but_Cancel.Name = "but_Cancel";
            but_Cancel.Size = new Size(115, 33);
            but_Cancel.TabIndex = 1;
            but_Cancel.Text = "Cancel";
            but_Cancel.UseVisualStyleBackColor = true;
            but_Cancel.Click += but_Cancel_Click;
            // 
            // but_OK
            // 
            but_OK.Location = new Point(192, 566);
            but_OK.Name = "but_OK";
            but_OK.Size = new Size(115, 33);
            but_OK.TabIndex = 1;
            but_OK.Text = "OK";
            but_OK.UseVisualStyleBackColor = true;
            but_OK.Click += but_OK_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 21);
            label1.Name = "label1";
            label1.Size = new Size(126, 20);
            label1.TabIndex = 2;
            label1.Text = "&Available formats";
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(25, 54);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(393, 484);
            listBox1.TabIndex = 3;
            // 
            // DateAndTime
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(452, 611);
            Controls.Add(listBox1);
            Controls.Add(label1);
            Controls.Add(but_OK);
            Controls.Add(but_Cancel);
            Name = "DateAndTime";
            Text = "DateAndTime";
            Load += DateAndTime_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button but_Cancel;
        private Button but_OK;
        private Label label1;
        private ListBox listBox1;
    }
}