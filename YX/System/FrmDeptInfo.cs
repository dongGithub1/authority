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
using YX.Entity;
namespace YX
{
    public partial class FrmDeptInfo : WindowParent
    {

        SystemOrganization_Bll org_bll = new SystemOrganization_Bll();
        SystemMenu_Bll menu_bll = new SystemMenu_Bll();
        public FrmDeptInfo(string ParentId)
        {
            InitializeComponent();
            SetButton(ParentId, this.toolStrip1);//设置按钮权限
        }
      
        private void FrmDeptInfo_Load(object sender, EventArgs e)
        {
 
            //设置不自动显示数据库中未绑定的列
            this.dataGridView1.AutoGenerateColumns = false;
            BindTreeView();
        
        }
        public void BindTreeView()
        {
            try
            {
                treeView1.Nodes.Clear();
               var  list = org_bll.GetOrganizations();
                var parents = list.Where(o=>o.ParentId=="0");
                foreach (var item in parents)
                {
                    TreeNode tn = new TreeNode();
                    tn.Text = item.Organization_Name;
                    tn.Tag = item.Organization_ID;
                    tn.ImageIndex = 0;
                    FillTree(tn, list);
                    treeView1.Nodes.Add(tn);
                }

                treeView1.ExpandAll();
                
            }
            catch (Exception ex)
            {
                System_Bll.WriteLogToDB(
                   new Entity.Base_Log
                  {
                      CreateUserID = FrmLogin.LoginUserID,
                      CreateUserName = FrmLogin.loginUserName,
                      LocalIP = FrmLogin.LocalIP,
                      LogMessage = ex.Message,
                      Type = "系统错误！",
                      ClassName = typeof(FrmDeptInfo).ToString()

                  });
                MessageBox.Show(ex.Message);
            }
        }

        private void FillTree(TreeNode node, List<Base_Organization> list)
        {
           
            var childs = list.Where(o=>o.ParentId==node.Tag.ToString());
            if (childs.Count() > 0)
            {
                foreach (var item in childs)
                {
                    TreeNode tnn = new TreeNode();
                    tnn.Text = item.Organization_Name;
                    tnn.Tag = item.Organization_ID;
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
            string Organization_ID = e.Node.Tag.ToString();                  
            this.dataGridView1.DataSource = org_bll.GetOrganizationDetail(Organization_ID);
            
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            FrmDeptInfoEdit edit = new FrmDeptInfoEdit(this);
            edit.StartPosition = FormStartPosition.CenterParent;
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
                    FrmDeptInfoEdit edit = new FrmDeptInfoEdit(this,ref dr);
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
                    int result = org_bll.DeleteSysOrganization(dr.Cells["Organization_ID"].Value.ToString());
                    if (result == 1)
                    {
                        MessageBox.Show("删除成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.dataGridView1.DataSource = org_bll.GetOrganizationDetail(treeView1.SelectedNode.Tag.ToString());
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

                System_Bll.WriteLogToDB(
                   new Entity.Base_Log
                   {
                       CreateUserID = FrmLogin.LoginUserID,
                       CreateUserName = FrmLogin.loginUserName,
                       LocalIP = FrmLogin.LocalIP,
                       LogMessage = ex.Message,
                       Type = "系统错误！",
                       ClassName = typeof(FrmDeptInfo).ToString()

                   });
                MessageBox.Show(ex.Message);
            }
        }
    }
}
