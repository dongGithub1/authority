using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using YX.BLL;
using YX.Common.DoNetCode;
using YX.Entity;

namespace YX
{
    public partial class FrmDeptInfoEdit : Form
    {
   
        YX.BLL.SystemOrganization_Bll org_bll = new BLL.SystemOrganization_Bll();
        OperationType type;
        FrmDeptInfo _frmDeptInfo;
        public FrmDeptInfoEdit(FrmDeptInfo frmDeptInfo)
        {
          
            type = OperationType.Add;
            this._frmDeptInfo = frmDeptInfo;
            InitializeComponent();
            this.Text = "部门信息-添加";
            com_ParentId.DataSource = org_bll.GetInitParentId();
            com_ParentId.DisplayMember = "Organization_Name";
            com_ParentId.ValueMember = "Organization_ID";
        }
        public FrmDeptInfoEdit(FrmDeptInfo frmDeptInfo,ref DataGridViewRow dvr)
        {
          
            type = OperationType.Edit;
            this._frmDeptInfo = frmDeptInfo;
            InitializeComponent();
            this.Text = "部门信息-修改";

            com_ParentId.DataSource = org_bll.GetInitParentId();
            com_ParentId.DisplayMember = "Organization_Name";
            com_ParentId.ValueMember = "Organization_ID";
            try
            {

                this.txt_Organization_Address.Text = dvr.Cells["Organization_Address"].Value==null?"": dvr.Cells["Organization_Address"].Value.ToString();
                this.txt_Organization_Code.Text = dvr.Cells["Organization_Code"].Value==null?"": dvr.Cells["Organization_Code"].Value.ToString();
                this.txt_Organization_AssistantManager.Text = dvr.Cells["Organization_AssistantManager"].Value==null?"" : dvr.Cells["Organization_AssistantManager"].Value.ToString();
                this.txt_Organization_Fax.Text = dvr.Cells["Organization_Fax"].Value == null ? "" : dvr.Cells["Organization_Fax"].Value.ToString();
                this.txt_Organization_InnerPhone.Text = dvr.Cells["Organization_InnerPhone"].Value==null?"": dvr.Cells["Organization_InnerPhone"].Value.ToString();
                this.txt_Organization_Manager.Text = dvr.Cells["Organization_Manager"].Value==null?"": dvr.Cells["Organization_Manager"].Value.ToString();
                this.txt_Organization_Name.Text = dvr.Cells["Organization_Name"].Value==null?"": dvr.Cells["Organization_Name"].Value.ToString();
                this.txt_Organization_OuterPhone.Text = dvr.Cells["Organization_OuterPhone"].Value==null?"": dvr.Cells["Organization_OuterPhone"].Value.ToString();
                this.txt_Organization_Remark.Text = dvr.Cells["Organization_Remark"].Value==null?"": dvr.Cells["Organization_Remark"].Value.ToString();
                this.txt_Organization_Zipcode.Text = dvr.Cells["Organization_Zipcode"].Value==null?"": dvr.Cells["Organization_Zipcode"].Value.ToString();
                this.txt_SortCode.Text = dvr.Cells["SortCode"].Value==null?"": dvr.Cells["SortCode"].Value.ToString();
                com_ParentId.SelectedValue = dvr.Cells["ParentId"].Value==null?"": dvr.Cells["ParentId"].Value.ToString();
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
                    ClassName = typeof(FrmDeptInfoEdit).ToString()

                });
                MessageBox.Show(ex.Message);
            }
        }
        private void FrmDeptInfoEdit_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;

        }

        private void btn_concel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool CheckInputData()
        {
            bool result = true;
            if(string.IsNullOrEmpty(txt_Organization_Code.Text))
            {
                MessageBox.Show("请输入部门编号！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_Organization_Code.Focus();
                result = false;
            }else if (string.IsNullOrEmpty(txt_Organization_Name.Text))
            {
                MessageBox.Show("请输入部门名称！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_Organization_Name.Focus();
                result = false;
            }else if (string.IsNullOrEmpty(txt_SortCode.Text))
            {
                MessageBox.Show("请输入显示顺序！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_SortCode.Focus();
                result = false;
            }else if(!string .IsNullOrEmpty(txt_SortCode.Text) && !ValidateUtil.IsNumber(txt_SortCode.Text.Trim()))
            {
                MessageBox.Show("显示顺序必须为正整数！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_SortCode.Focus();
                result = false;
            }
            else if (string.IsNullOrEmpty(com_ParentId.Text))
            {
                MessageBox.Show("请选择节点位置！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                com_ParentId.Focus();
                result = false;
            }

            return result;
        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckInputData())
                {
                    if (type == OperationType.Add)
                    {
                        Base_Organization Org = new Base_Organization
                        {
                            CreateDate = DateTime.Now,
                            CreateUserId = FrmLogin.LoginUserID,
                            CreateUserName = FrmLogin.loginUserName,
                            Organization_Address = txt_Organization_Address.Text,
                            Organization_AssistantManager = txt_Organization_AssistantManager.Text,
                            Organization_Code = txt_Organization_Code.Text,
                            Organization_Fax = txt_Organization_Fax.Text,
                            Organization_ID = Guid.NewGuid().ToString(),
                            Organization_InnerPhone = txt_Organization_InnerPhone.Text,
                            Organization_Manager = txt_Organization_Manager.Text,
                            Organization_Name = txt_Organization_Name.Text,
                            Organization_OuterPhone = txt_Organization_OuterPhone.Text,
                            Organization_Remark = txt_Organization_Remark.Text,
                            Organization_Zipcode = txt_Organization_Zipcode.Text,
                            ParentId = com_ParentId.SelectedValue.ToString(),
                            SortCode = int.Parse(txt_SortCode.Text),
                            DeleteMark = 1
                        };
                        int result = org_bll.AddSysOrganization(Org);
                        if (result == 1)
                        {
                            MessageBox.Show("添加成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            _frmDeptInfo.BindTreeView();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("添加失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        Base_Organization Org = new Base_Organization
                        {

                            ModifyDate = DateTime.Now,
                            ModifyUserId = FrmLogin.LoginUserID,
                            ModifyUserName = FrmLogin.loginUserName,
                            Organization_Address = txt_Organization_Address.Text,
                            Organization_AssistantManager = txt_Organization_AssistantManager.Text,
                            Organization_Code = txt_Organization_Code.Text,
                            Organization_Fax = txt_Organization_Fax.Text,
                            Organization_ID = _frmDeptInfo.treeView1.SelectedNode.Tag.ToString(),
                            Organization_InnerPhone = txt_Organization_InnerPhone.Text,
                            Organization_Manager = txt_Organization_Manager.Text,
                            Organization_Name = txt_Organization_Name.Text,
                            Organization_OuterPhone = txt_Organization_OuterPhone.Text,
                            Organization_Remark = txt_Organization_Remark.Text,
                            Organization_Zipcode = txt_Organization_Zipcode.Text,
                            ParentId = com_ParentId.SelectedValue.ToString(),
                            SortCode = int.Parse(txt_SortCode.Text),
                            DeleteMark = 1
                        };
                        int result = org_bll.UpdateSysOrganization(Org);
                        if (result == 1)
                        {
                            MessageBox.Show("修改成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            _frmDeptInfo.BindTreeView();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("修改失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
               
            }
            catch (Exception ex)
            {

                System_Bll.WriteLogToDB( new Entity.Base_Log{
                CreateUserID = FrmLogin.LoginUserID,
                CreateUserName = FrmLogin.loginUserName,
                LocalIP = FrmLogin.LocalIP,
                LogMessage = ex.Message,
                Type = "系统错误！",
                ClassName = typeof(FrmDeptInfoEdit).ToString() });
                MessageBox.Show(ex.Message);
            }
        }
    }
}
