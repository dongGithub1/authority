namespace YX
{
    partial class FrmAppendPropertyEdit
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
            this.label1 = new System.Windows.Forms.Label();
            this.txt_Property_Name = new System.Windows.Forms.TextBox();
            this.txt_Property_ID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_SortCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_Property_width = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.rich_dataSource = new System.Windows.Forms.RichTextBox();
            this.com_controlType = new System.Windows.Forms.ComboBox();
            this.btn_concel = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_Property_Function = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "属性名称：";
            // 
            // txt_Property_Name
            // 
            this.txt_Property_Name.Location = new System.Drawing.Point(103, 42);
            this.txt_Property_Name.Name = "txt_Property_Name";
            this.txt_Property_Name.Size = new System.Drawing.Size(223, 21);
            this.txt_Property_Name.TabIndex = 31;
            // 
            // txt_Property_ID
            // 
            this.txt_Property_ID.Location = new System.Drawing.Point(103, 76);
            this.txt_Property_ID.Name = "txt_Property_ID";
            this.txt_Property_ID.Size = new System.Drawing.Size(223, 21);
            this.txt_Property_ID.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "控  件ID：";
            // 
            // txt_SortCode
            // 
            this.txt_SortCode.Location = new System.Drawing.Point(102, 178);
            this.txt_SortCode.Name = "txt_SortCode";
            this.txt_SortCode.Size = new System.Drawing.Size(223, 21);
            this.txt_SortCode.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 179);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "控件排序：";
            // 
            // txt_Property_width
            // 
            this.txt_Property_width.Location = new System.Drawing.Point(103, 143);
            this.txt_Property_width.Name = "txt_Property_width";
            this.txt_Property_width.Size = new System.Drawing.Size(223, 21);
            this.txt_Property_width.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "控件宽度：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(37, 233);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "数据源：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(31, 109);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 8;
            this.label6.Text = "控件类型：";
            // 
            // rich_dataSource
            // 
            this.rich_dataSource.Location = new System.Drawing.Point(103, 211);
            this.rich_dataSource.Name = "rich_dataSource";
            this.rich_dataSource.Size = new System.Drawing.Size(223, 62);
            this.rich_dataSource.TabIndex = 11;
            this.rich_dataSource.Text = "";
            // 
            // com_controlType
            // 
            this.com_controlType.FormattingEnabled = true;
            this.com_controlType.Location = new System.Drawing.Point(103, 110);
            this.com_controlType.Name = "com_controlType";
            this.com_controlType.Size = new System.Drawing.Size(223, 20);
            this.com_controlType.TabIndex = 12;
            // 
            // btn_concel
            // 
            this.btn_concel.Image = global::YX.Properties.Resources.delete;
            this.btn_concel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_concel.Location = new System.Drawing.Point(191, 282);
            this.btn_concel.Name = "btn_concel";
            this.btn_concel.Size = new System.Drawing.Size(83, 32);
            this.btn_concel.TabIndex = 29;
            this.btn_concel.Text = "关闭";
            this.btn_concel.UseVisualStyleBackColor = true;
            this.btn_concel.Click += new System.EventHandler(this.btn_concel_Click);
            // 
            // btn_save
            // 
            this.btn_save.Image = global::YX.Properties.Resources.save;
            this.btn_save.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_save.Location = new System.Drawing.Point(102, 282);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(83, 32);
            this.btn_save.TabIndex = 28;
            this.btn_save.Text = "保存";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(31, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 30;
            this.label7.Text = "业务分类：";
            // 
            // txt_Property_Function
            // 
            this.txt_Property_Function.Location = new System.Drawing.Point(103, 10);
            this.txt_Property_Function.Name = "txt_Property_Function";
            this.txt_Property_Function.Size = new System.Drawing.Size(222, 21);
            this.txt_Property_Function.TabIndex = 1;
            // 
            // FrmAppendPropertyEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 322);
            this.Controls.Add(this.txt_Property_Function);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btn_concel);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.com_controlType);
            this.Controls.Add(this.rich_dataSource);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_SortCode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_Property_width);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_Property_ID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_Property_Name);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAppendPropertyEdit";
            this.Text = "FrmAppendPropertyEdit";
            this.Load += new System.EventHandler(this.FrmAppendPropertyEdit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_Property_Name;
        private System.Windows.Forms.TextBox txt_Property_ID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_SortCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_Property_width;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox rich_dataSource;
        private System.Windows.Forms.ComboBox com_controlType;
        private System.Windows.Forms.Button btn_concel;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_Property_Function;
    }
}