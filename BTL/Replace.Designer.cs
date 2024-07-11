namespace BTL
{
    partial class Replace
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
            checkBox2 = new CheckBox();
            checkBox1 = new CheckBox();
            but_Cancel = new Button();
            but_Find_Next = new Button();
            text_find = new TextBox();
            label1 = new Label();
            but_repAll = new Button();
            but_Rep = new Button();
            label2 = new Label();
            txt_replace = new TextBox();
            SuspendLayout();
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(28, 169);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(105, 24);
            checkBox2.TabIndex = 8;
            checkBox2.Text = "Match case";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(28, 139);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(186, 24);
            checkBox1.TabIndex = 9;
            checkBox1.Text = "Match whole only word";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // but_Cancel
            // 
            but_Cancel.Location = new Point(411, 164);
            but_Cancel.Name = "but_Cancel";
            but_Cancel.Size = new Size(111, 29);
            but_Cancel.TabIndex = 6;
            but_Cancel.Text = "&Cancel";
            but_Cancel.UseVisualStyleBackColor = true;
            but_Cancel.Click += but_Cancel_Click;
            // 
            // but_Find_Next
            // 
            but_Find_Next.Location = new Point(411, 53);
            but_Find_Next.Name = "but_Find_Next";
            but_Find_Next.Size = new Size(111, 29);
            but_Find_Next.TabIndex = 7;
            but_Find_Next.Text = "&Find Next";
            but_Find_Next.UseVisualStyleBackColor = true;
            but_Find_Next.Click += but_Find_Next_Click;
            // 
            // text_find
            // 
            text_find.Location = new Point(148, 53);
            text_find.Name = "text_find";
            text_find.Size = new Size(240, 27);
            text_find.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(37, 56);
            label1.Name = "label1";
            label1.Size = new Size(73, 20);
            label1.TabIndex = 4;
            label1.Text = "Find what";
            // 
            // but_repAll
            // 
            but_repAll.Location = new Point(411, 127);
            but_repAll.Name = "but_repAll";
            but_repAll.Size = new Size(111, 29);
            but_repAll.TabIndex = 6;
            but_repAll.Text = "Replace &All";
            but_repAll.UseVisualStyleBackColor = true;
            but_repAll.Click += but_repAll_Click;
            // 
            // but_Rep
            // 
            but_Rep.Location = new Point(411, 88);
            but_Rep.Name = "but_Rep";
            but_Rep.Size = new Size(111, 29);
            but_Rep.TabIndex = 6;
            but_Rep.Text = "&Replace";
            but_Rep.UseVisualStyleBackColor = true;
            but_Rep.Click += but_Rep_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(37, 93);
            label2.Name = "label2";
            label2.Size = new Size(66, 20);
            label2.TabIndex = 4;
            label2.Text = "Replace ";
            // 
            // txt_replace
            // 
            txt_replace.Location = new Point(148, 90);
            txt_replace.Name = "txt_replace";
            txt_replace.Size = new Size(240, 27);
            txt_replace.TabIndex = 5;
            // 
            // Replace
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(549, 225);
            Controls.Add(checkBox2);
            Controls.Add(checkBox1);
            Controls.Add(but_Rep);
            Controls.Add(but_repAll);
            Controls.Add(but_Cancel);
            Controls.Add(but_Find_Next);
            Controls.Add(txt_replace);
            Controls.Add(label2);
            Controls.Add(text_find);
            Controls.Add(label1);
            Name = "Replace";
            ShowIcon = false;
            Text = "Replace";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox checkBox2;
        private CheckBox checkBox1;
        private Button but_Cancel;
        private Button but_Find_Next;
        private TextBox text_find;
        private Label label1;
        private Button but_repAll;
        private Button but_Rep;
        private Label label2;
        private TextBox txt_replace;
    }
}