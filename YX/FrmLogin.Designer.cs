namespace YX
{
    partial class FrmLogin
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
            this.btn_concel = new System.Windows.Forms.Button();
            this.txt_UserPwd = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_User_Account = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_login = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_concel
            // 
            this.btn_concel.Location = new System.Drawing.Point(180, 142);
            this.btn_concel.Name = "btn_concel";
            this.btn_concel.Size = new System.Drawing.Size(80, 40);
            this.btn_concel.TabIndex = 11;
            this.btn_concel.Text = "取消";
            this.btn_concel.UseVisualStyleBackColor = true;
            // 
            // txt_UserPwd
            // 
            this.txt_UserPwd.Location = new System.Drawing.Point(116, 90);
            this.txt_UserPwd.Name = "txt_UserPwd";
            this.txt_UserPwd.PasswordChar = '*';
            this.txt_UserPwd.Size = new System.Drawing.Size(165, 21);
            this.txt_UserPwd.TabIndex = 10;
            this.txt_UserPwd.Text = "system";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(69, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "密码：";
            // 
            // txt_User_Account
            // 
            this.txt_User_Account.Location = new System.Drawing.Point(116, 51);
            this.txt_User_Account.Name = "txt_User_Account";
            this.txt_User_Account.Size = new System.Drawing.Size(165, 21);
            this.txt_User_Account.TabIndex = 8;
            this.txt_User_Account.Text = "admin";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(69, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "账号：";
            // 
            // btn_login
            // 
            this.btn_login.Location = new System.Drawing.Point(94, 142);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(80, 40);
            this.btn_login.TabIndex = 6;
            this.btn_login.Text = "登陆";
            this.btn_login.UseVisualStyleBackColor = true;
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(333, 212);
            this.Controls.Add(this.btn_concel);
            this.Controls.Add(this.txt_UserPwd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_User_Account);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_login);
            this.Name = "FrmLogin";
            this.Text = "登录";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_concel;
        private System.Windows.Forms.TextBox txt_UserPwd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_User_Account;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_login;
    }
}