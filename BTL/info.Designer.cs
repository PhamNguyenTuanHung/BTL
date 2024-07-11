namespace BTL
{
    partial class info
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
            label1 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 15F);
            label1.Location = new Point(66, 84);
            label1.Name = "label1";
            label1.Size = new Size(464, 163);
            label1.TabIndex = 0;
            label1.Text = "Ứng dụng này được làm bởi:\r\nNguyễn Hùng Thiên Lộc - 2251012086\r\nNguyễn Phạm Tuấn Hùng - \r\n";
            // 
            // info
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(562, 300);
            Controls.Add(label1);
            Name = "info";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "INFORMATION";
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
    }
}