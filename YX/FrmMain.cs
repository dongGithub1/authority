using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using YX.BLL;

namespace YX
{
    public partial class FrmMain : DockContent
    {
        public FrmMain()
        {      
            InitializeComponent();        
        }

        private void Main_Load(object sender, EventArgs e)
        {
            this.dockPanel1.DockLeftPortion = 200;//左侧菜单宽度
            new FrmLeft(this).Show(this.dockPanel1, DockState.DockLeft);
            //new FrmExpress().Show(this.dockPanel1,DockState.Document);
            this.toolStripLabel1.Text = "当前账号："+FrmLogin.loginUserName;
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("是否确认退出程序？", "退出", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                LogHelper.WriteLog(typeof(FrmMain), "************软件关闭***********");              
                notifyIcon1.Visible = true;
                notifyIcon1.Dispose();
                this.Dispose();
                Environment.Exit(0);               
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //判断是否已经最小化于托盘
            if (WindowState == FormWindowState.Minimized)
            {
                //还原窗体显示 
                WindowState = FormWindowState.Normal;
                //激活窗体并给予它焦点 
               this.Activate();
                //任务栏区显示图标 
                this.ShowInTaskbar = true;
                //托盘区图标隐藏 
                notifyIcon1.Visible = true;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Dispose();
            FrmLogin login = new FrmLogin();
            login.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
