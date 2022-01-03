using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using YX.Entity;
using YX.BLL;
namespace YX
{
    public partial class FrmRole : WindowParent
    {
        SystemMenu_Bll menu_bll = new SystemMenu_Bll();
        SystemRole_Bll role_bll = new SystemRole_Bll();
  
        public FrmRole(string ParentId)
        {
            InitializeComponent();
            SetButton(ParentId, this.toolStrip1);//设置按钮权限

        }
    
        private void FrmRole_Load(object sender, EventArgs e)
        {
            BindTreeView();
            if (treeView1.Nodes.Count > 0)
            {
                treeView1.Nodes[0].Expand();
            }
            //设置不自动显示数据库中未绑定的列
            this.dataGridView1.AutoGenerateColumns = false;
        }
        public void BindTreeView()
        {
            try
            {
                treeView1.ImageList = imageList1;
                treeView1.Nodes.Clear();
                var list = role_bll.GetRoles();
                var parents = list.Where(o => o.ParentId == "0");
                foreach (var item in parents)
                {
                    TreeNode tn = new TreeNode();
                    tn.Text = item.Roles_Name;
                    tn.Tag = item.Roles_ID;
                    tn.ImageIndex = 0;
                    FillTree(tn, list);
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
                    Type = "系统错误！",
                    ClassName = typeof(FrmRole).ToString()
                });
                MessageBox.Show(ex.Message);
            }
        }

        private void FillTree(TreeNode node, List<Base_Roles> list)
        {

            var childs = list.Where(o => o.ParentId == node.Tag.ToString());
            if (childs.Count() > 0)
            {
                foreach (var item in childs)
                {
                    TreeNode tnn = new TreeNode();
                    tnn.Text = item.Roles_Name;
                    tnn.Tag = item.Roles_ID;
                    tnn.ImageIndex = 0;
                    if (item.ParentId == node.Tag.ToString())
                    {
                        FillTree(tnn, list);
                    }
                    node.Nodes.Add(tnn);
                }

            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string roleID = e.Node.Tag.ToString();
            this.dataGridView1.DataSource = role_bll.GetRoleByRoleId(roleID);
            
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            FrmRoleEdit edit = new FrmRoleEdit(this);
         
            edit.ShowDialog();
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.DataSource == null)
            {
                MessageBox.Show("请选择要编辑的行!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DataGridViewRow dr = dataGridView1.SelectedRows[0];
                if (dr != null)
                {
                    FrmRoleEdit edit = new FrmRoleEdit(this, ref dr);
                    edit.ShowDialog();
                }
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow dr = dataGridView1.SelectedRows[0];
                if (dr != null)
                {
                    int result = role_bll.DeleteRole(dr.Cells["Roles_ID"].Value.ToString());
                    if (result == 1)
                    {
                        MessageBox.Show("删除成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.dataGridView1.DataSource = role_bll.GetRoleByRoleId(treeView1.SelectedNode.Tag.ToString());
                        BindTreeView();
                    }
                    else
                    {
                        MessageBox.Show("删除失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
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
                    Type = "系统错误！",
                    ClassName = typeof(FrmRole).ToString()
                });
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                this.dataGridView1.DataSource = role_bll.GetRoleByRoleId(this.treeView1.SelectedNode.Tag.ToString());
            }
          
        }
        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BindTreeView();
            if (treeView1.Nodes.Count > 0)
            {
                treeView1.Nodes[0].Expand();
            }
        }
    }
}
