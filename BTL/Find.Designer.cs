namespace BTL
{
    partial class Find
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
            textBox1 = new TextBox();
            but_Find_Next = new Button();
            but_Cancel = new Button();
            checkBox1 = new CheckBox();
            checkBox2 = new CheckBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(29, 49);
            label1.Name = "label1";
            label1.Size = new Size(73, 20);
            label1.TabIndex = 0;
            label1.Text = "Find what";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(140, 46);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(240, 27);
            textBox1.TabIndex = 1;
            // 
            // but_Find_Next
            // 
            but_Find_Next.Location = new Point(412, 45);
            but_Find_Next.Name = "but_Find_Next";
            but_Find_Next.Size = new Size(111, 29);
            but_Find_Next.TabIndex = 2;
            but_Find_Next.Text = "Find Next";
            but_Find_Next.UseVisualStyleBackColor = true;
            but_Find_Next.Click += but_Find_Next_Click;
            // 
            // but_Cancel
            // 
            but_Cancel.Location = new Point(412, 99);
            but_Cancel.Name = "but_Cancel";
            but_Cancel.Size = new Size(111, 29);
            but_Cancel.TabIndex = 2;
            but_Cancel.Text = "Cancel";
            but_Cancel.UseVisualStyleBackColor = true;
            but_Cancel.Click += but_Cancel_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(55, 99);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(186, 24);
            checkBox1.TabIndex = 3;
            checkBox1.Text = "Match whole only word";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(55, 129);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(105, 24);
            checkBox2.TabIndex = 3;
            checkBox2.Text = "Match case";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // Find
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(561, 215);
            Controls.Add(checkBox2);
            Controls.Add(checkBox1);
            Controls.Add(but_Cancel);
            Controls.Add(but_Find_Next);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Name = "Find";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Find";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private Button but_Find_Next;
        private Button but_Cancel;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
    }
}