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
    public partial class FrmAppendPropertyEdit : Form
    {
        SystemAppendProperty_Bll append_bll = new SystemAppendProperty_Bll();
        FrmAppendProperty _frmappend;
        OperationType type;
        string Property_ID;
        public FrmAppendPropertyEdit(FrmAppendProperty frmappend)
        {
            InitializeComponent();
            GetComboxList();
            this.Text = "动态属性维护-添加";
            _frmappend = frmappend;
            type = OperationType.Add;
         
         
        }
        public FrmAppendPropertyEdit(FrmAppendProperty frmappend , ref DataGridViewRow dvr)
        {
            InitializeComponent();
            GetComboxList();
            this.Text = "动态属性维护-修改";
            _frmappend = frmappend;
            type = OperationType.Edit;
            Property_ID = dvr.Cells["Property_ID"].Value==null?"" : dvr.Cells["Property_ID"].Value.ToString();
            txt_Property_Function.Text = dvr.Cells["Property_Function"].Value==null?"" : dvr.Cells["Property_Function"].Value.ToString();
            txt_Property_ID.Text = dvr.Cells["Property_Control_ID"].Value==null?"" : dvr.Cells["Property_Control_ID"].Value.ToString();
            txt_Property_Name.Text = dvr.Cells["Property_Name"].Value==null?"": dvr.Cells["Property_Name"].Value.ToString();
            txt_Property_width.Text = dvr.Cells["Property_Control_Length"].Value==null?"" : dvr.Cells["Property_Control_Length"].Value.ToString();
            txt_SortCode.Text = dvr.Cells["SortCode"].Value==null?"":dvr.Cells["SortCode"].Value.ToString();
            rich_dataSource.Text = dvr.Cells["Property_Control_DataSource"].Value==null? "":dvr.Cells["Property_Control_DataSource"].Value.ToString();
            com_controlType.Text = dvr.Cells["Property_Control_Style"].Value==null?"":dvr.Cells["Property_Control_Style"].Value.ToString();
        }
        private void FrmAppendPropertyEdit_Load(object sender, EventArgs e)
        {
          //com_controlType.DataSource=  GetComboxList();
          //com_controlType.ValueMember = "value";
          //com_controlType.DisplayMember = "name";
         // com_controlType.SelectedIndex = 0;
        }
        private void GetComboxList()
        {
            var ControlTypeList = append_bll.AppendProperty_List("控件类型");
            DataTable dt = new DataTable();
            dt.Columns.Add("name");
            dt.Columns.Add("value");
        
            foreach (var item in ControlTypeList)
            {
                DataRow dr = dt.NewRow();
                dr[0] = item.Property_Name;
                dr[1] = item.Property_Control_ID;
                dt.Rows.Add(dr);
               // com_controlType.Items.Add(new { Property_Control_ID = item.Property_Control_ID, Property_Name = item.Property_Name });
            }
            com_controlType.DataSource = dt;
            com_controlType.ValueMember = "value";
            com_controlType.DisplayMember = "name";
        }
        private bool CheckInputData()
        {
            bool result = true;
            if (string.IsNullOrEmpty(txt_Property_Function.Text))
            {
                MessageBox.Show("请输入业务分类！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_Property_Function.Focus();
                result = false;
            }else
            if (string.IsNullOrEmpty(txt_Property_Name.Text))
            {
                MessageBox.Show("请输入控件属性名称！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_Property_Name.Focus();
                result = false;
            }
            else
            if (string.IsNullOrEmpty(txt_Property_ID.Text))
            {
                MessageBox.Show("请输入控件ID！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_Property_ID.Focus();
                result = false;
            }else
       
            if (string.IsNullOrEmpty(txt_Property_width.Text))
            {
                MessageBox.Show("请输入控件宽度名称！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_Property_width.Focus();
                result = false;
            }else
            if (!string.IsNullOrEmpty(txt_Property_width.Text) && !ValidateUtil.IsNumber(txt_Property_width.Text))
            {
                MessageBox.Show("控件宽度必须是数字！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_Property_width.Focus();
                result = false;
            }else
            if (!string.IsNullOrEmpty(txt_SortCode.Text) && !ValidateUtil.IsNumber(txt_SortCode.Text))
            {
                MessageBox.Show("排序必须为数字！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_SortCode.Focus();
                result = false;
            }
            return result;
        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                if(CheckInputData())
                {
                    Base_AppendProperty append = new Base_AppendProperty();
                    if (!string.IsNullOrEmpty(Property_ID))
                    {
                        append.ModifyDate = DateTime.Now;
                        append.ModifyUserId = FrmLogin.LoginUserID;
                        append.ModifyUserName = FrmLogin.loginUserName;
                        append.Property_ID = Property_ID;
                    }
                    else
                    {
                        append.CreateDate = DateTime.Now;
                        append.CreateUserId = FrmLogin.LoginUserID;
                        append.CreateUserName = FrmLogin.loginUserName;
                        append.Property_ID = Guid.NewGuid().ToString();
                    }
                    append.Property_Control_DataSource = rich_dataSource.Text;
                    append.Property_Control_ID = txt_Property_ID.Text;
                    append.Property_Function = txt_Property_Function.Text;
                    append.Property_Name = txt_Property_Name.Text;
                    append.DeleteMark = 1;
                    append.Property_Control_Length = Convert.ToInt32(txt_Property_width.Text);
                    append.Property_Control_Style = com_controlType.SelectedValue.ToString();
                    append.SortCode = Convert.ToInt32(txt_SortCode.Text);

                    int isOk = 0;
                    if (type == OperationType.Add)
                    {
                        isOk = append_bll.AddAppendProperty(append);
                    }
                    else
                    {
                        isOk = append_bll.UpdateAppendProertty(append);
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
                    ClassName = typeof(FrmAppendPropertyEdit).ToString()
                });
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }         
           
        }

        private void btn_concel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
