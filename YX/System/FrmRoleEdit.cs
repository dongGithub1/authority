using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using YX.BLL;
using YX.Entity;

namespace YX
{
    public partial class FrmRoleEdit : Form
    {
        SystemMenu_Bll menu_bll = new SystemMenu_Bll();
        SystemRole_Bll role_bll = new SystemRole_Bll();
        OperationType type;
        FrmRole _frmRole;
        string RoleID = "";
        public FrmRoleEdit(FrmRole frmRole)
        {
            InitializeComponent();
            _frmRole = frmRole;
            type = OperationType.Add;
            this.Text = "角色管理-添加";
            com_ParentId.DataSource = role_bll.GetRoleParentId();
            com_ParentId.DisplayMember = "Roles_Name";
            com_ParentId.ValueMember = "Roles_ID";
        }
        public FrmRoleEdit(FrmRole frmRole,ref DataGridViewRow dvr)
        {
            InitializeComponent();
            _frmRole = frmRole;
            type = OperationType.Edit;
            this.Text = "角色管理-修改";
            com_ParentId.DataSource = role_bll.GetRoleParentId();
            com_ParentId.DisplayMember = "Roles_Name";
            com_ParentId.ValueMember = "Roles_ID";

            RoleID = dvr.Cells["Roles_ID"].Value.ToString();
            txt_RoleName.Text= dvr.Cells["Roles_Name"].Value.ToString();
            txt_RoleRemark.Text= dvr.Cells["Roles_Remark"].Value==null?"": dvr.Cells["Roles_Remark"].Value.ToString();
            txt_SortCode.Text= dvr.Cells["SortCode"].Value.ToString();
            com_ParentId.SelectedValue= dvr.Cells["ParentId"].Value.ToString();

        }

        private void FrmRoleEdit_Load(object sender, EventArgs e)
        {
            BindRoleRightTreeView();
            if (tree_RoleRight.Nodes.Count > 0)
            {
                tree_RoleRight.Nodes[0].Expand();
            }
            
        }
        private void btn_concel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #region 角色权限
        /// <summary>
        /// 用户权限菜单树列表
        /// </summary>
        public void BindRoleRightTreeView()
        {
            try
            {
                this.tree_RoleRight.ImageList = imageList1;
               this.tree_RoleRight.Nodes.Clear();
                var list = menu_bll.GetSysMenus();
                var role_right_list = menu_bll.GetRoleRightByCondition(o => o.Base_Roles.Roles_ID == RoleID);
                var parents = list.Where(o => o.ParentId == "0");
                foreach (var item in parents)
                {
                    TreeNode tn = new TreeNode();
                    tn.Text = item.Menu_Name;
                    tn.Tag = item.Menu_Id;
                    tn.ImageIndex = item.Menu_Img == null ? 0 : item.Menu_Img.Value;
                    foreach (var role_right in role_right_list)
                    {
                        if (item.Menu_Id == role_right.Menu_Id)
                        {
                            tn.Checked = true;
                        }
                    }
                    RoleRightFillTree(tn, list, role_right_list);
                    tree_RoleRight.Nodes.Add(tn);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void RoleRightFillTree(TreeNode node, List<Base_SysMenu> list, List<Base_RoleRight> role_right_list)
        {

            var childs = list.Where(o => o.ParentId == node.Tag.ToString());
            if (childs.Count() > 0)
            {
                foreach (var item in childs)
                {
                    TreeNode tnn = new TreeNode();
                    tnn.Text = item.Menu_Name;
                    tnn.Tag = item.Menu_Id;
                    tnn.ImageIndex = item.Menu_Img == null ? 0 : item.Menu_Img.Value;
                    foreach (var role_right in role_right_list)
                    {
                        if (item.Menu_Id == role_right.Menu_Id)
                        {
                            tnn.Checked = true;
                        }
                    }
                    if (item.ParentId == node.Tag.ToString())
                    {
                        RoleRightFillTree(tnn, list, role_right_list);
                    }
                    node.Nodes.Add(tnn);
                }

            }
        }
        #endregion

        #region 保存
        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                Base_Roles roles = new Base_Roles();
                if (string.IsNullOrEmpty(RoleID))
                {
                    roles.CreateDate = DateTime.Now;
                    roles.CreateUserId = FrmLogin.LoginUserID;
                    roles.CreateUserName = FrmLogin.loginUserName;
                    roles.Roles_ID = Guid.NewGuid().ToString();
                }
                else
                {
                    roles.ModifyDate = DateTime.Now;
                    roles.ModifyUserId = FrmLogin.LoginUserID;
                    roles.ModifyUserName = FrmLogin.loginUserName;
                    roles.Roles_ID = RoleID;
                }
                RoleRightList.Clear();
                CheckRoleRightTreeViewNode(tree_RoleRight.Nodes);
                roles.Base_RoleRight = RoleRightList;
                roles.ParentId = com_ParentId.SelectedValue.ToString();
                roles.Roles_Name = txt_RoleName.Text;
                roles.Roles_Remark = txt_RoleRemark.Text;
                roles.SortCode = int.Parse(txt_SortCode.Text);
                int isOk = 0;
                if (type == OperationType.Add)
                {
                    isOk = role_bll.AddRoles(roles);
                }
                else if (type == OperationType.Edit)
                {
                    isOk = role_bll.UpdateRoles(roles);
                }
                if (isOk > 0)
                {
                    MessageBox.Show("保存成功！");

                    this.Close();
                }
                else
                {
                    MessageBox.Show("保存失败！");
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
                    ClassName = typeof(FrmRoleEdit).ToString()
                });
                MessageBox.Show(ex.Message);
            }
        }


        List<Base_RoleRight> RoleRightList = new List<Base_RoleRight>();
        /// <summary>
        /// 遍历角色权限选中节点
        /// </summary>
        /// <param name="node"></param>
        public void CheckRoleRightTreeViewNode(TreeNodeCollection node)
        {

            foreach (TreeNode n in node)
            {
                if (n.Checked)
                {
                    RoleRightList.Add(new Base_RoleRight
                    {
                        RoleRight_ID = Guid.NewGuid().ToString(),
                        Menu_Id = n.Tag.ToString(),
                        CreateUserName = FrmLogin.loginUserName,
                        CreateUserId = FrmLogin.LoginUserID,
                        CreateDate = DateTime.Now
                    });
                }
                CheckRoleRightTreeViewNode(n.Nodes);
            }
        } 
        #endregion
    }
}
