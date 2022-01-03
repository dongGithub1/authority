using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using YX.BLL;
using YX.Common.DotNetEncrypt;
using YX.Entity;

namespace YX
{
    public partial class FrmUserInfoEdit : Form
    {
        FrmUserInfo _frmUserInfo;
        SystemAppendProperty_Bll app_bll = new SystemAppendProperty_Bll();
        SystemMenu_Bll menu_bll = new SystemMenu_Bll();
        SystemUserInfo_Bll user_bll = new SystemUserInfo_Bll();
        SystemOrganization_Bll org_bll = new SystemOrganization_Bll();
        SystemRole_Bll role_bll = new SystemRole_Bll();
        string User_ID = "";
        OperationType type;
        public FrmUserInfoEdit(FrmUserInfo frmUserInfo)
        {
           
            this._frmUserInfo = frmUserInfo;
            InitializeComponent();
            this.Text = "用户信息-添加";
            type = OperationType.Add;
        }
        public FrmUserInfoEdit(FrmUserInfo frmUserInfo,ref DataGridViewRow dvr)
        {                 
            InitializeComponent();
            type = OperationType.Edit;
            this._frmUserInfo = frmUserInfo;
            User_ID = dvr.Cells["User_ID"].Value.ToString();
            txt_Email.Text = dvr.Cells["邮箱"].Value.ToString();
            txt_Title.Text = dvr.Cells["职称"].Value.ToString();
            txt_User_Account.Text = dvr.Cells["登录账户"].Value.ToString();
            txt_User_Code.Text = dvr.Cells["用户工号"].Value.ToString();
            txt_User_Name.Text = dvr.Cells["用户名称"].Value.ToString();
           // txt_User_Pwd.Text = dvr.Cells["登陆密码"].Value.ToString();
            com_User_Sex.Text = dvr.Cells["性别"].Value.ToString();
            richTextBox1.Text = dvr.Cells["备注"].Value.ToString();
            this.Text = "用户信息-编辑";
        }

        private void FrmUserInfoEdit_Load(object sender, EventArgs e)
        {
          
            GetAppendProperty();
            BindUsertRightTreeView();
            BindUserDeptTreeView();
            BindRoleTreeView();
            if (tree_Dept.Nodes.Count > 0)//展开一级节点
            {
                tree_Dept.Nodes[0].Expand();
            }
            if (tree_UserRight.Nodes.Count > 0)//展开一级节点
            {
                tree_UserRight.Nodes[0].Expand();
            }
            if (tree_UserRight.Nodes.Count > 0)//展开一级节点
            {
                tree_UserRole.Nodes[0].Expand();
            }
        }
        #region 用户权限
        /// <summary>
        /// 用户权限菜单树列表
        /// </summary>
        public void BindUsertRightTreeView()
        {
            try
            {
                this.tree_UserRight.ImageList = imageList1;
                tree_UserRight.Nodes.Clear();
                var list = menu_bll.GetSysMenus();
                var user_right_list = menu_bll.GetUserRightByCondition(o=>o.Base_UserInfo.User_ID==User_ID);
                var parents = list.Where(o => o.ParentId == "0");
                foreach (var item in parents)
                {
                    TreeNode tn = new TreeNode();
                    tn.Text = item.Menu_Name;
                    tn.Tag = item.Menu_Id;
                    tn.ImageIndex = item.Menu_Img == null ? 0 : item.Menu_Img.Value;
                    foreach (var user_right in user_right_list)
                    {
                        if (item.Menu_Id == user_right.Menu_Id)
                        {
                            tn.Checked = true;
                        }
                    }
                    UserRightFillTree(tn, list, user_right_list);
                    tree_UserRight.Nodes.Add(tn);
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
                    ClassName = typeof(FrmUserInfoEdit).ToString()
                });
                MessageBox.Show(ex.Message);
            }
        }

        private void UserRightFillTree(TreeNode node, List<Base_SysMenu> list,List<Base_UserRight> user_right_list)
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
                    foreach (var user_right in user_right_list)
                    {
                        if (item.Menu_Id == user_right.Menu_Id)
                        {
                            tnn.Checked = true;
                        }
                    }
                    if (item.ParentId == node.Tag.ToString())
                    {
                        UserRightFillTree(tnn, list, user_right_list);
                    }
                    node.Nodes.Add(tnn);
                }

            }
        } 
        #endregion

        #region 所属部门
        /// <summary>
        /// 用户权限菜单树列表
        /// </summary>
        public void BindUserDeptTreeView()
        {
            try
            {
                tree_Dept.ImageList = imageList1;
                tree_Dept.Nodes.Clear();
              
                var list = org_bll.GetOrganizations();
                var staff_list = org_bll.GetStaffOrganize(User_ID);
                var parents = list.Where(o => o.ParentId == "0");
                foreach (var item in parents)
                {
                    TreeNode tn = new TreeNode();
                    tn.Text = item.Organization_Name;
                    tn.Tag = item.Organization_ID;
                    tn.ImageIndex = 0;
                    foreach (var staff in staff_list)
                    {
                        if (item.Organization_ID == staff.Organization_ID)
                        {
                            tn.Checked = true;
                        }
                    }

                    UserDeptFillTree(tn, list,staff_list);
                    tree_Dept.Nodes.Add(tn);
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
                    ClassName = typeof(FrmUserInfoEdit).ToString()
                });
                MessageBox.Show(ex.Message);
            }
        }

        private void UserDeptFillTree(TreeNode node, List<Base_Organization> list,List<Base_StaffOrganize>staff_list)
        {

            var childs = list.Where(o => o.ParentId == node.Tag.ToString());
            if (childs.Count() > 0)
            {
                foreach (var item in childs)
                {
                    TreeNode tnn = new TreeNode();
                    tnn.Text = item.Organization_Name;
                    tnn.Tag = item.Organization_ID;
                    tnn.ImageIndex = 635;
                    foreach(var staff in staff_list)
                    {
                        if (item.Organization_ID == staff.Organization_ID)
                        {
                            tnn.Checked = true;
                        }
                    }
                   // tnn.Checked = true;
                    if (item.ParentId == node.Tag.ToString())
                    {
                        UserDeptFillTree(tnn, list,staff_list);
                    }
                    node.Nodes.Add(tnn);
                }

            }
        }
        #endregion

        #region 所属角色
        public void BindRoleTreeView()
        {
            try
            {
                tree_UserRole.ImageList = imageList1;
                tree_UserRole.Nodes.Clear();
                var list = role_bll.GetRoles();
                var user_role_list = role_bll.GetUserRoleByUserID(User_ID);
                var parents = list.Where(o => o.ParentId == "0");
                foreach (var item in parents)
                {
                    TreeNode tn = new TreeNode();
                    tn.Text = item.Roles_Name;
                    tn.Tag = item.Roles_ID;
                    foreach (var user_role in user_role_list)
                    {
                        if (item.Roles_ID == user_role.Roles_ID)
                        {
                            tn.Checked = true;
                        }
                      
                    }
              
                    tn.ImageIndex = 188;
                    RoleFillTree(tn, list, user_role_list);
                    tree_UserRole.Nodes.Add(tn);
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
                    ClassName = typeof(FrmUserInfoEdit).ToString()
                });
                MessageBox.Show(ex.Message);
            }
        }

        private void RoleFillTree(TreeNode node, List<Base_Roles> list,List<Base_UserRole> user_role_list)
        {

            var childs = list.Where(o => o.ParentId == node.Tag.ToString());
            if (childs.Count() > 0)
            {
                foreach (var item in childs)
                {
                    TreeNode tnn = new TreeNode();
                    tnn.Text = item.Roles_Name;
                    tnn.Tag = item.Roles_ID;
                    tnn.ImageIndex = 188;
                    foreach (var user_role in user_role_list)
                    {
                        if (item.Roles_ID == user_role.Roles_ID)
                        {
                            tnn.Checked = true;
                        }

                    }
                    if (item.ParentId == node.Tag.ToString())
                    {
                        RoleFillTree(tnn, list, user_role_list);
                    }
                    node.Nodes.Add(tnn);
                }

            }
        }
        #endregion

        #region 附加属性
        /// <summary>
        /// 附加属性动态绘制
        /// </summary>
        public void GetAppendProperty()
        {
            try
            {
                List<Base_AppendProperty> list = app_bll.AppendProperty_List("用户附加信息");
                List<Base_AppendPropertyInstance> listValue = app_bll.GetPropertyInstancepk("用户附加信息", User_ID);//获取附件字段值

                for (int i = 0; i < list.Count; i++)
                {

                    Label lab = new Label();
                    lab.Name = "lab_" + list[i].Property_Control_ID;
                    lab.Text = list[i].Property_Name + "：";
                    this.flowLayoutPanel1.Controls.Add(lab);
                    lab.Size = new Size(65, 12);
                    if (list[i].Property_Control_Style == "txt")
                    {
                        TextBox text = new TextBox();
                        text.Name = list[i].Property_Control_ID;
                        text.Size = new Size(list[i].Property_Control_Length, 21);
                        foreach (var value in listValue)
                        {
                            if (text.Name == value.Property_Control_ID)
                            {
                                text.Text = value.PropertyInstance_Value;
                            }
                        }
                        this.flowLayoutPanel1.Controls.Add(text);
                    }
                    else if (list[i].Property_Control_Style == "select")
                    {
                        string[] strSource = list[i].Property_Control_DataSource.Split('|');
                        ComboBox combox = new ComboBox();
                        combox.Name = list[i].Property_Control_ID;
                        combox.Size = new Size(list[i].Property_Control_Length, 21);
                        combox.Text = strSource[0];
                        foreach (var item in strSource)
                        {
                            combox.Items.Add(item);
                        }
                        foreach (var value in listValue)
                        {
                            if (combox.Name == value.Property_Control_ID)
                            {
                                combox.Text = value.PropertyInstance_Value;
                            }
                        }
                        this.flowLayoutPanel1.Controls.Add(combox);
                    }
                    else if (list[i].Property_Control_Style == "richText")
                    {
                        RichTextBox text = new RichTextBox();
                        text.Name = list[i].Property_Control_ID;
                        text.Size = new Size(list[i].Property_Control_Length, 100);
                        foreach (var value in listValue)
                        {
                            if (text.Name == value.Property_Control_ID)
                            {
                                text.Text = value.PropertyInstance_Value;
                            }
                        }
                        this.flowLayoutPanel1.Controls.Add(text);
                    }
                    else if (list[i].Property_Control_Style == "date")
                    {
                        DateTimePicker date = new DateTimePicker();
                        date.Name = list[i].Property_Control_ID;
                        date.Size = new Size(list[i].Property_Control_Length, 21);
                        foreach (var value in listValue)
                        {
                            if (date.Name == value.Property_Control_ID)
                            {
                                date.Text = value.PropertyInstance_Value;
                            }
                        }
                        this.flowLayoutPanel1.Controls.Add(date);
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
                    ClassName = typeof(FrmUserInfoEdit).ToString()
                });
                MessageBox.Show(ex.Message);
            }
          
        } 
        #endregion

        #region 保存事件
        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                Base_UserInfo userinfo = new Base_UserInfo();
                if (!string.IsNullOrEmpty(User_ID))
                {
                    userinfo.ModifyDate = DateTime.Now;
                    userinfo.ModifyUserId = FrmLogin.LoginUserID;
                    userinfo.ModifyUserName = FrmLogin.loginUserName;

                }
                else
                {
                    userinfo.CreateDate = DateTime.Now;
                    userinfo.CreateUserId = FrmLogin.LoginUserID;
                    userinfo.CreateUserName = FrmLogin.loginUserName;

                    User_ID = Guid.NewGuid().ToString();
                }
                userinfo.DeleteMark = 1;
                userinfo.Email = txt_Email.Text;
                userinfo.Title = txt_Title.Text;
                userinfo.User_Account = txt_User_Account.Text;
                userinfo.User_Code = txt_User_Code.Text;
                userinfo.User_ID = User_ID;
                userinfo.User_Name = txt_User_Name.Text;
                //userinfo.User_Pwd =Md5Helper.Md5( txt_User_Pwd.Text);
                userinfo.User_Remark = richTextBox1.Text;
                userinfo.User_Sex = com_User_Sex.Text;
                StaffOrgList.Clear();
                UserRightList.Clear();
                RoleList.Clear();
                CheckRoleTreeViewNode(tree_UserRole.Nodes);
                CheckUsertRightTreeViewNode(this.tree_UserRight.Nodes);//获取勾选值
                CheckUsertDeptTreeViewNode(this.tree_Dept.Nodes);//获取勾选值
                GetAllAppendValue();//获取附加属性值
                userinfo.Base_UserRight = UserRightList;
                userinfo.Base_StaffOrganize = StaffOrgList;
                userinfo.Base_UserRole = RoleList;
                userinfo.Base_AppendPropertyInstance = appendList;
                int isOk = 0;
                if (type == OperationType.Add)
                {
                    isOk = user_bll.AddUserInfo(userinfo);
                }
                else
                {
                    isOk = user_bll.EditUserInfo(userinfo);
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
                    ClassName = typeof(FrmUserInfoEdit).ToString()
                });
                MessageBox.Show(ex.Message);
            }
        }
        List<Base_UserRight> UserRightList = new List<Base_UserRight>();
        List<Base_StaffOrganize> StaffOrgList = new List<Base_StaffOrganize>();
        List<Base_AppendPropertyInstance> appendList = new List<Base_AppendPropertyInstance>();
        List<Base_UserRole> RoleList = new List<Base_UserRole>();
        /// <summary>
        /// 遍历用户权限选中节点
        /// </summary>
        /// <param name="node"></param>
        public void CheckUsertRightTreeViewNode(TreeNodeCollection node)
        {
       
            foreach (TreeNode n in node)
            {
                if (n.Checked)
                {
                    UserRightList.Add(new Base_UserRight { UserRight_ID = Guid.NewGuid().ToString(), Menu_Id = n.Tag.ToString(),
                        CreateUserName=FrmLogin.loginUserName, CreateUserId=FrmLogin.LoginUserID, CreateDate=DateTime .Now });
                }
                CheckUsertRightTreeViewNode(n.Nodes);
            }
        }
        /// <summary>
        /// 遍历所属部门选中节点
        /// </summary>
        /// <param name="node"></param>
        public void CheckUsertDeptTreeViewNode(TreeNodeCollection node)
        {
        
            foreach (TreeNode n in node)
            {
                if (n.Checked)
                {
                    StaffOrgList.Add(new Base_StaffOrganize
                    {
                        StaffOrganize_Id = Guid.NewGuid().ToString(),
                        Organization_ID = n.Tag.ToString(),
                        CreateUserName = FrmLogin.loginUserName,
                        CreateUserId = FrmLogin.LoginUserID,
                        CreateDate = DateTime.Now 
                      
                    });
                }
                CheckUsertDeptTreeViewNode(n.Nodes);
            }
        } 
        /// <summary>
        /// 遍历附加属性
        /// </summary>
        public void GetAllAppendValue()
        {
            foreach(var control in this.flowLayoutPanel1.Controls)
            {
                //遍历所有TextBox...
                if (control is TextBox)
                {
                    TextBox t = (TextBox)control;
                    if(!string.IsNullOrEmpty(t.Text))
                    {
                        appendList.Add(new Base_AppendPropertyInstance { PropertyInstance_ID = Guid.NewGuid().ToString(), Property_Control_ID = t.Name, PropertyInstance_Value = t.Text });
                    }
              
                }
                if(control is RichTextBox)
                {
                    RichTextBox r = (RichTextBox)control;
                    if (!string.IsNullOrEmpty(r.Text))
                    {
                        appendList.Add(new Base_AppendPropertyInstance { PropertyInstance_ID = Guid.NewGuid().ToString(), Property_Control_ID = r.Name, PropertyInstance_Value = r.Text });
                    }
                  
                }
                if(control is ComboBox)
                {
                    ComboBox c = (ComboBox)control;
                    if(!string.IsNullOrEmpty(c.Text)&& c.Text!= "==请选择==")
                    {
                        appendList.Add(new Base_AppendPropertyInstance { PropertyInstance_ID = Guid.NewGuid().ToString(), Property_Control_ID = c.Name, PropertyInstance_Value = c.Text });
                    }
                    
                }
               // 遍历所有DateTimePicker...
                if (control is DateTimePicker)
                {
                    DateTimePicker d = (DateTimePicker)control;
                    if (!string.IsNullOrEmpty(d.Text))
                    {
                        appendList.Add(new Base_AppendPropertyInstance { PropertyInstance_ID = Guid.NewGuid().ToString(), Property_Control_ID = d.Name, PropertyInstance_Value = d.Text });
                    }
                }
            }
        }
        /// <summary>
        /// 遍历角色权限选中节点
        /// </summary>
        /// <param name="node"></param>
        public void CheckRoleTreeViewNode(TreeNodeCollection node)
        {

            foreach (TreeNode n in node)
            {
                if (n.Checked)
                {
                    RoleList.Add(new Base_UserRole
                    {                        
                        UserRole_ID = Guid.NewGuid().ToString(),
                         
                        //User_ID = User_ID,
                        Roles_ID= n.Tag.ToString(),
                        CreateUserName = FrmLogin.loginUserName,
                        CreateUserId = FrmLogin.LoginUserID,
                        CreateDate = DateTime.Now
                    });
                }
                CheckRoleTreeViewNode(n.Nodes);
            }
        }
        #endregion

        private void btn_concel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
