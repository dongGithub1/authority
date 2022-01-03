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
    public partial class FrmMenu : WindowParent
    {
        YX.BLL.SystemMenu_Bll menu_bll = new BLL.SystemMenu_Bll();
        
        public FrmMenu(string ParentId)
        {
            InitializeComponent();

            SetButton(ParentId, this.toolStrip1);//设置按钮权限
        }
      
        private void FrmMenu_Load(object sender, EventArgs e)
        {
            GetComboxList();
            BindTreeView();
            if (treeView1.Nodes.Count > 0)//展开一级节点
            {
                treeView1.Nodes[0].Expand();
            }
            //设置隔行背景色
            this.dataGridView1.RowsDefaultCellStyle.BackColor = Color.White;
            this.dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.BlanchedAlmond;
            //设置不自动显示数据库中未绑定的列
            this.dataGridView1.AutoGenerateColumns = false;
        }
        private void GetComboxList()
        {
           DataTable dt = new DataTable();
            DataColumn Name = new DataColumn("Name");
            DataColumn Value = new DataColumn("Value");
            dt.Columns.Add(Name);
            dt.Columns.Add(Value);

            DataRow dr1 = dt.NewRow();
            dr1["Name"] = "菜单名称";
            dr1["Value"] = "Menu_Name";

            DataRow dr2 = dt.NewRow();
            dr2["Name"] = "创 建 人";
            dr2["Value"] = "CreateUserName";

            dt.Rows.Add(dr1);
            dt.Rows.Add(dr2);
            this.com_querylist.ComboBox.DisplayMember = "name";
            this.com_querylist.ComboBox.ValueMember = "value";
      
            this.com_querylist.ComboBox.DataSource=dt;
        }
        private void BindTreeView()
        {
            try
            {
                this.treeView1.Nodes.Clear();
                this.treeView1.ImageList = imageList1;
                var   list = menu_bll.GetSysMenus();
                var parents = list.Where(o => o.ParentId == "0");
                foreach (var item in parents)
                {
                    TreeNode tn = new TreeNode();
                    tn.Text = item.Menu_Name;
                    tn.Tag = item.Menu_Id;
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
                    ClassName = typeof(FrmMenu).ToString()
                });
                MessageBox.Show(ex.Message);
            }
        }

        private void FillTree(TreeNode node, List<Base_SysMenu> list)
        {

            var childs = list.Where(o => o.ParentId == node.Tag.ToString());
            if (childs.Count() > 0)
            {
                foreach (var item in childs)
                {
                    TreeNode tnn = new TreeNode();
                    tnn.Text = item.Menu_Name;
                    tnn.Tag = item.Menu_Id;
                    tnn.ImageIndex = 0;
                    if (item.ParentId == node.Tag.ToString())
                    {
                        FillTree(tnn, list);
                    }
                    node.Nodes.Add(tnn);
                }

            }
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            FrmMenuEdit edit = new FrmMenuEdit(this);
            edit.ShowDialog();          
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.DataSource == null)
            {
                MessageBox.Show("请选择要编辑的行!","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                DataGridViewRow dr = dataGridView1.SelectedRows[0];
               
                if (dr != null)
                {
                    FrmMenuEdit edit = new FrmMenuEdit(this, ref dr);
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
                     int result= menu_bll.DeleteSysMenu(dr.Cells["Menu_Id"].Value.ToString());
                     if (result == 1)
                     {
                         MessageBox.Show("删除成功！","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
                         this.dataGridView1.DataSource = menu_bll.GetSysMenuChilds(treeView1.SelectedNode.Tag.ToString(),FrmLogin.LoginUserID);
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
                    ClassName = typeof(FrmDeptInfoEdit).ToString()
                });
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
         
            this.dataGridView1.DataSource = menu_bll.GetSysMenuChilds(treeView1.SelectedNode.Tag.ToString());
          
        }

        private void btn_select_Click(object sender, EventArgs e)
        {
            //this.dataGridView1.DataSource= bll.QueryMenusByCondition(this.listView1.SelectedItems[0].Tag.ToString(),com_querylist.ComboBox.SelectedValue.ToString(),txt_query.Text);
            //   string ParentId = this.listView1.SelectedItems[0].Tag.ToString();
            string ParentId = treeView1.SelectedNode.Tag.ToString();
            string condition = com_querylist.ComboBox.SelectedValue.ToString();
            string queryValue = txt_query.Text;
            switch (condition)
            {
                case "Menu_Name":
                    this.dataGridView1.DataSource = menu_bll.GetMenusByCondition(o => o.ParentId == ParentId && o.Menu_Name.Contains(queryValue));
                    break;
                case "CreateUserName":
                    this.dataGridView1.DataSource = menu_bll.GetMenusByCondition(o => o.ParentId == ParentId && o.CreateUserName.Contains(queryValue));
                    break;
            }
          
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (this.treeView1.SelectedNode.Nodes.Count > 0)
            {
                this.dataGridView1.DataSource = menu_bll.GetSysMenuChilds(treeView1.SelectedNode.Tag.ToString());
            }
        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BindTreeView();
            if (treeView1.Nodes.Count > 0)//展开一级节点
            {
                treeView1.Nodes[0].Expand();
            }
        }
    }
}
