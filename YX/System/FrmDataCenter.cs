using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using YX.BLL;
using YX.Entity;

namespace YX
{
    public partial class FrmDataCenter : WindowParent
    {
    
        SystemMenu_Bll menu_bll = new SystemMenu_Bll();
        public FrmDataCenter(string ParentId)
        {
            InitializeComponent();
            SetButton(ParentId, this.toolStrip1);//设置按钮权限
        }

        private void FrmDataCenter_Load(object sender, EventArgs e)
        {
            BindTreeView();
          
        }
        private void BindTreeView()
        {
            try
            {
                this.treeView1.Nodes.Clear();
                this.treeView1.ImageList = imageList1;
                var list = System_Bll.GetTableName();

                foreach (var item in list)
                {
                    TreeNode tn = new TreeNode();
                    tn.Text = item;
                    tn.Tag = item;
                    tn.ImageIndex = 0;
                    treeView1.Nodes.Add(tn);
                }
            }
            catch (Exception ex)
            {

                System_Bll.WriteLogToDB(new Entity.Base_Log
                {
                    CreateUserID = FrmLogin.LoginUserID,
                    CreateUserName = FrmLogin.loginUserName,
                    LocalIP = FrmLogin.LocalIP,
                    LogMessage = ex.Message,
                    Type = "系统错误",
                    ClassName = typeof(FrmDataCenter).ToString()
                });
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (!string.IsNullOrEmpty(this.treeView1.SelectedNode.Text))
            {
                this.dataGridView1.DataSource = System_Bll.GetSyscolumns(treeView1.SelectedNode.Tag.ToString());
            }
        }
        //隔行换色
        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (this.dataGridView1.Rows.Count != 0)
            {
                for (int i = 0; i < this.dataGridView1.Rows.Count;)
                {
                    this.dataGridView1.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.BlanchedAlmond;
                    i += 2;
                }
            }
        }

        private void btn_backup_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否确备份数据库？", "退出", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                try
                {
                    string Path = "D:\\Sam_DB_BackUp\\";

                    CreateDir("D:\\", "Sam_DB_BackUp");
                
                    string Name = "Sam_DB_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".bak";
                    if (System_Bll.DbBackup(Path+Name)>=-1)
                    {
                        MessageBox.Show(string.Format("备份成功!备份地址为{0}", Path + Name));
                    }
                    else
                    {
                        MessageBox.Show("备份失败！");
                    }                                
                }
                catch (Exception ex)
                {
                    System_Bll.WriteLogToDB(new Entity.Base_Log
                    {
                        CreateUserID = FrmLogin.LoginUserID,
                        CreateUserName = FrmLogin.loginUserName,
                        LocalIP = FrmLogin.LocalIP,
                        LogMessage = ex.Message,
                        Type = "系统错误",
                        ClassName=typeof(FrmDataCenter).ToString()

                    });
                    MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
           
        }
        //判断文件夹是否存在
        private void CreateDir(string filePath, string dirname)
        {
            if (!Directory.Exists(filePath + @"\" + dirname))
            {
                Directory.CreateDirectory(filePath + @"\" + dirname);
            }

        }
    }
}
