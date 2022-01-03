﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using YX.BLL;
using YX.Entity;
namespace YX
{
    public partial class FrmUserInfo : WindowParent
    {
        SystemOrganization_Bll organization_bll = new SystemOrganization_Bll();
        // SystemUserInfo_Dal user_dal = new SystemUserInfo_Dal();
        SystemUserInfo_Bll user_bll = new SystemUserInfo_Bll();
        SystemMenu_Bll menu_bll = new SystemMenu_Bll();
        public FrmUserInfo(string ParentId)
        {
            InitializeComponent();
            SetButton(ParentId, this.toolStrip1);//设置按钮权限
        }
   
        private void FrmUserInfo_Load(object sender, EventArgs e)
        {
            GetComboxList();
            BindTreeView(organization_bll.GetOrganizations());
            if (treeView1.Nodes.Count > 0)//展开一级节点
            {
                treeView1.Nodes[0].Expand();
            }
               
        }
        private void GetComboxList()
        {
            DataTable dt = new DataTable();
            DataColumn Name = new DataColumn("Name");
            DataColumn Value = new DataColumn("Value");
            dt.Columns.Add(Name);
            dt.Columns.Add(Value);

            DataRow dr1 = dt.NewRow();
            dr1["Name"] = "工号";
            dr1["Value"] = "User_Code";

            DataRow dr2 = dt.NewRow();
            dr2["Name"] = "账户";
            dr2["Value"] = "User_Account";

            DataRow dr3 = dt.NewRow();
            dr3["Name"] = "姓名";
            dr3["Value"] = "User_Name";
            dt.Rows.Add(dr1);
            dt.Rows.Add(dr2);
            dt.Rows.Add(dr3);
            this.com_Searchwhere.ComboBox.DisplayMember = "Name";
            this.com_Searchwhere.ComboBox.ValueMember = "Value";

            this.com_Searchwhere.ComboBox.DataSource = dt;
        }
        private void BindTreeView(List<Base_Organization> list)
        {
            try
            {
                treeView1.Nodes.Clear();
                list = organization_bll.GetOrganizations();
                var parents = list.Where(o => o.ParentId == "0");
                foreach (var item in parents)
                {
                    TreeNode tn = new TreeNode();
                    tn.Text = item.Organization_Name;
                    tn.Tag = item.Organization_ID;
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
                    ClassName = typeof(FrmUserInfo).ToString()
                });
                MessageBox.Show(ex.Message);
            }
        }

        private void FillTree(TreeNode node, List<Base_Organization> list)
        {

            var childs = list.Where(o => o.ParentId == node.Tag.ToString());
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
            StringBuilder SqlWhere = new StringBuilder();
            IList<SqlParameter> IList_param = new List<SqlParameter>();
            if (!string.IsNullOrEmpty(Organization_ID))
            {
                SqlWhere.Append(" AND S.Organization_ID =@Organization_ID");
                IList_param.Add(new SqlParameter("@Organization_ID", Organization_ID ));
            }
            this.dataGridView1.DataSource = user_bll.GetUserInfoByOrganization_Id(SqlWhere, IList_param);
     
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (this.dataGridView1.Rows.Count != 0)
            {
                for (int i = 0; i < this.dataGridView1.Rows.Count; )
                {
                    this.dataGridView1.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.BlanchedAlmond;
                    i += 2;
                }
            } 
        }

        private void btn_select_Click(object sender, EventArgs e)
        {
            StringBuilder SqlWhere = new StringBuilder();
            IList<SqlParameter> IList_param = new List<SqlParameter>();
            if (!string.IsNullOrEmpty(txt_Search.Text))
            {
                SqlWhere.Append(" and U." + com_Searchwhere.ComboBox.SelectedValue.ToString()+ " like @obj ");
                IList_param.Add(new SqlParameter("@obj", '%' + txt_Search.Text.Trim() + '%'));
            }
            if (!string.IsNullOrEmpty(treeView1.SelectedNode.Tag.ToString()))
            {
                SqlWhere.Append(" AND S.Organization_ID =@Organization_ID");
                IList_param.Add(new SqlParameter("@Organization_ID", treeView1.SelectedNode.Tag.ToString()));
            }
          this.dataGridView1.DataSource= user_bll.GetUserInfoByOrganization_Id(SqlWhere, IList_param);
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            FrmUserInfoEdit edit = new FrmUserInfoEdit(this);
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
                    FrmUserInfoEdit edit = new FrmUserInfoEdit(this,ref dr);
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
                    //int result = bll.DeleteSysMenu(dr.Cells["Menu_Id"].Value.ToString());
                   // if (result == 1)
                   // {
                        MessageBox.Show("删除成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                       // this.dataGridView1.DataSource = dal.GetSysMenuChilds(this.listView1.SelectedItems[0].Tag.ToString());
                   // }
                    //else
                   // {
                        MessageBox.Show("删除失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   // }
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
                    ClassName = typeof(FrmUserInfo).ToString()
                });
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                string Organization_ID = treeView1.SelectedNode.Tag.ToString();
                StringBuilder SqlWhere = new StringBuilder();
                IList<SqlParameter> IList_param = new List<SqlParameter>();
                if (!string.IsNullOrEmpty(Organization_ID))
                {
                    SqlWhere.Append(" AND S.Organization_ID =@Organization_ID");
                    IList_param.Add(new SqlParameter("@Organization_ID", Organization_ID));
                }
                this.dataGridView1.DataSource = user_bll.GetUserInfoByOrganization_Id(SqlWhere, IList_param);
            }
           
        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BindTreeView(organization_bll.GetOrganizations());
            if (treeView1.Nodes.Count > 0)//展开一级节点
            {
                treeView1.Nodes[0].Expand();
            }
        }
    }
}
