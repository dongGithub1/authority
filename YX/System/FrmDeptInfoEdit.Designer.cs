namespace YX
{
    partial class FrmDeptInfoEdit
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.com_ParentId = new System.Windows.Forms.ComboBox();
            this.btn_concel = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.txt_Organization_Remark = new System.Windows.Forms.RichTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txt_Organization_Address = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txt_SortCode = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_Organization_Zipcode = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_Organization_Fax = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_Organization_InnerPhone = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_Organization_OuterPhone = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_Organization_AssistantManager = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_Organization_Manager = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_Organization_Name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_Organization_Code = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.com_ParentId);
            this.panel1.Controls.Add(this.btn_concel);
            this.panel1.Controls.Add(this.btn_save);
            this.panel1.Controls.Add(this.txt_Organization_Remark);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.txt_Organization_Address);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.txt_SortCode);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.txt_Organization_Zipcode);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txt_Organization_Fax);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txt_Organization_InnerPhone);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txt_Organization_OuterPhone);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txt_Organization_AssistantManager);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txt_Organization_Manager);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txt_Organization_Name);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txt_Organization_Code);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(464, 356);
            this.panel1.TabIndex = 0;
            // 
            // com_ParentId
            // 
            this.com_ParentId.FormattingEnabled = true;
            this.com_ParentId.Location = new System.Drawing.Point(86, 154);
            this.com_ParentId.Name = "com_ParentId";
            this.com_ParentId.Size = new System.Drawing.Size(136, 20);
            this.com_ParentId.TabIndex = 26;
            // 
            // btn_concel
            // 
            this.btn_concel.Image = global::YX.Properties.Resources.delete;
            this.btn_concel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_concel.Location = new System.Drawing.Point(237, 312);
            this.btn_concel.Name = "btn_concel";
            this.btn_concel.Size = new System.Drawing.Size(83, 32);
            this.btn_concel.TabIndex = 25;
            this.btn_concel.Text = "关闭";
            this.btn_concel.UseVisualStyleBackColor = true;
            this.btn_concel.Click += new System.EventHandler(this.btn_concel_Click);
            // 
            // btn_save
            // 
            this.btn_save.Image = global::YX.Properties.Resources.save;
            this.btn_save.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_save.Location = new System.Drawing.Point(148, 312);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(83, 32);
            this.btn_save.TabIndex = 24;
            this.btn_save.Text = "保存";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // txt_Organization_Remark
            // 
            this.txt_Organization_Remark.Location = new System.Drawing.Point(83, 218);
            this.txt_Organization_Remark.Name = "txt_Organization_Remark";
            this.txt_Organization_Remark.Size = new System.Drawing.Size(360, 72);
            this.txt_Organization_Remark.TabIndex = 23;
            this.txt_Organization_Remark.Text = "";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(36, 249);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 12);
            this.label12.TabIndex = 22;
            this.label12.Text = "备注：";
            // 
            // txt_Organization_Address
            // 
            this.txt_Organization_Address.Location = new System.Drawing.Point(85, 185);
            this.txt_Organization_Address.Name = "txt_Organization_Address";
            this.txt_Organization_Address.Size = new System.Drawing.Size(358, 21);
            this.txt_Organization_Address.TabIndex = 21;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(14, 188);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 12);
            this.label11.TabIndex = 20;
            this.label11.Text = "所在地址：";
            // 
            // txt_SortCode
            // 
            this.txt_SortCode.Location = new System.Drawing.Point(306, 154);
            this.txt_SortCode.Name = "txt_SortCode";
            this.txt_SortCode.Size = new System.Drawing.Size(137, 21);
            this.txt_SortCode.TabIndex = 19;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(235, 158);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 18;
            this.label9.Text = "显示顺序：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(14, 157);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 16;
            this.label10.Text = "节点位置：";
            // 
            // txt_Organization_Zipcode
            // 
            this.txt_Organization_Zipcode.Location = new System.Drawing.Point(306, 122);
            this.txt_Organization_Zipcode.Name = "txt_Organization_Zipcode";
            this.txt_Organization_Zipcode.Size = new System.Drawing.Size(137, 21);
            this.txt_Organization_Zipcode.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(235, 127);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 14;
            this.label7.Text = "行政号码：";
            // 
            // txt_Organization_Fax
            // 
            this.txt_Organization_Fax.Location = new System.Drawing.Point(85, 122);
            this.txt_Organization_Fax.Name = "txt_Organization_Fax";
            this.txt_Organization_Fax.Size = new System.Drawing.Size(137, 21);
            this.txt_Organization_Fax.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 127);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 12;
            this.label8.Text = "传真号码：";
            // 
            // txt_Organization_InnerPhone
            // 
            this.txt_Organization_InnerPhone.Location = new System.Drawing.Point(306, 90);
            this.txt_Organization_InnerPhone.Name = "txt_Organization_InnerPhone";
            this.txt_Organization_InnerPhone.Size = new System.Drawing.Size(137, 21);
            this.txt_Organization_InnerPhone.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(235, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "内线电话：";
            // 
            // txt_Organization_OuterPhone
            // 
            this.txt_Organization_OuterPhone.Location = new System.Drawing.Point(85, 89);
            this.txt_Organization_OuterPhone.Name = "txt_Organization_OuterPhone";
            this.txt_Organization_OuterPhone.Size = new System.Drawing.Size(137, 21);
            this.txt_Organization_OuterPhone.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 8;
            this.label6.Text = "外线电话：";
            // 
            // txt_Organization_AssistantManager
            // 
            this.txt_Organization_AssistantManager.Location = new System.Drawing.Point(306, 58);
            this.txt_Organization_AssistantManager.Name = "txt_Organization_AssistantManager";
            this.txt_Organization_AssistantManager.Size = new System.Drawing.Size(137, 21);
            this.txt_Organization_AssistantManager.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(235, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "副负责人：";
            // 
            // txt_Organization_Manager
            // 
            this.txt_Organization_Manager.Location = new System.Drawing.Point(85, 58);
            this.txt_Organization_Manager.Name = "txt_Organization_Manager";
            this.txt_Organization_Manager.Size = new System.Drawing.Size(137, 21);
            this.txt_Organization_Manager.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "主负责人：";
            // 
            // txt_Organization_Name
            // 
            this.txt_Organization_Name.Location = new System.Drawing.Point(306, 27);
            this.txt_Organization_Name.Name = "txt_Organization_Name";
            this.txt_Organization_Name.Size = new System.Drawing.Size(137, 21);
            this.txt_Organization_Name.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(235, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "部门名称：";
            // 
            // txt_Organization_Code
            // 
            this.txt_Organization_Code.Location = new System.Drawing.Point(85, 27);
            this.txt_Organization_Code.Name = "txt_Organization_Code";
            this.txt_Organization_Code.Size = new System.Drawing.Size(137, 21);
            this.txt_Organization_Code.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "部门编号：";
            // 
            // FrmDeptInfoEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 356);
            this.Controls.Add(this.panel1);
            this.Name = "FrmDeptInfoEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "部门编辑";
            this.Load += new System.EventHandler(this.FrmDeptInfoEdit_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox txt_Organization_Remark;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txt_Organization_Address;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txt_SortCode;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_Organization_Zipcode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_Organization_Fax;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_Organization_InnerPhone;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_Organization_OuterPhone;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_Organization_AssistantManager;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_Organization_Manager;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_Organization_Name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_Organization_Code;
        private System.Windows.Forms.Button btn_concel;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.ComboBox com_ParentId;
    }
}