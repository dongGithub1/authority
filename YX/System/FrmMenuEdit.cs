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
    public partial class FrmMenuEdit : Form
    {
        YX.BLL.SystemMenu_Bll bll = new BLL.SystemMenu_Bll();
        
        FrmMenu _frmMenu;
        OperationType type;
        string MenuID = "";
        public FrmMenuEdit(FrmMenu frmMenu)
        {
         
            type = OperationType.Add;
            this._frmMenu = frmMenu;
            InitializeComponent();
            this.Text = "菜单信息-添加";
            this.txt_parent.Text = _frmMenu.treeView1.SelectedNode.Text;
        }
        public FrmMenuEdit(FrmMenu frmMenu, ref DataGridViewRow dvr)
        {
            try
            {

                type = OperationType.Edit;
                this._frmMenu = frmMenu;
                InitializeComponent();
                this.Text = "菜单信息-编辑";
                //  this.com_Parent.Text=dvr.Cells["节点位置"].Value==null?"": dvr.Cells["节点位置"].Value.ToString();
                this.txt_parent.Text = _frmMenu.treeView1.SelectedNode.Text;
                this.txt_MenuName.Text = dvr.Cells["Menu_Name"].Value == null ? "" : dvr.Cells["Menu_Name"].Value.ToString();
                txt_MenuTag.Text = dvr.Cells["Menu_Tag"].Value == null ? "" : dvr.Cells["Menu_Tag"].Value.ToString();
                txt_Sort.Text = dvr.Cells["SortCode"].Value == null ? "0" : dvr.Cells["SortCode"].Value.ToString();
                pic_menu.Image = new FrmListImages(this).imageList1.Images[dvr.Cells["Menu_Img"].Value==null? 0 : int.Parse(dvr.Cells["Menu_Img"].Value.ToString())];
                pic_menu.Tag = dvr.Cells["Menu_Img"].Value==null ? 0 : int.Parse(dvr.Cells["Menu_Img"].Value.ToString());
                MenuID = dvr.Cells["Menu_Id"].Value == null ? "" : dvr.Cells["Menu_Id"].Value.ToString();
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
                    ClassName = typeof(FrmMenuEdit).ToString()
                });
                MessageBox.Show(ex.Message);
            }
        }

    
   
        private void FrmMenuEdit_Load(object sender, EventArgs e)
        {

            //var ParentID= _frmMenu.treeView1.SelectedNode==null?"": _frmMenu.treeView1.SelectedNode.Tag;
            //com_Parent.DataSource = bll.GetSysMenusParent(FrmLogin.LoginUserID);
            //com_Parent.DisplayMember = "Menu_Name";
            //com_Parent.ValueMember = "Menu_Id";
            //com_Parent.SelectedValue = ParentID;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
    
                if (type == OperationType.Add)
                {
                    Base_SysMenu info = new Base_SysMenu
                    {
                        CreateDate = DateTime.Now,
                        CreateUserId = FrmLogin.LoginUserID,
                        CreateUserName = FrmLogin.loginUserName,
                        Menu_Img = int.Parse(pic_menu.Tag.ToString()),
                        Menu_Name = txt_MenuName.Text,
                        Menu_Tag = txt_MenuTag.Text,                      
                        ParentId = _frmMenu.treeView1.SelectedNode.Tag.ToString(),
                        SortCode = int.Parse(txt_Sort.Text),                   
                        Menu_Id = Guid.NewGuid().ToString()

                    };
                  int result=  bll.AddSysMenu(info);
                  if (result == 1)
                  {
                      MessageBox.Show("添加成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                      _frmMenu.dataGridView1.DataSource = bll.GetSysMenuChilds(_frmMenu.treeView1.SelectedNode.Tag.ToString(),FrmLogin.LoginUserID);
                      this.Close();
                  }
                  else
                  {
                      MessageBox.Show("添加失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                  }
                }
                else
                {
                    Base_SysMenu info = new Base_SysMenu
                    {

                        Menu_Img = int.Parse(pic_menu.Tag.ToString()),
                        Menu_Name = txt_MenuName.Text,
                        Menu_Tag = txt_MenuTag.Text,
                        ParentId = _frmMenu.treeView1.SelectedNode.Tag.ToString(),
                        SortCode = int.Parse(txt_Sort.Text),
                        ModifyUserName = FrmLogin.loginUserName,
                        ModifyDate = DateTime.Now,
                        ModifyUserId = FrmLogin.LoginUserID,
                        Menu_Id = MenuID
                       

                    };
                    int result=  bll.UpdateSysMenu(info);
                    if (result == 1)
                    {
                        MessageBox.Show("修改成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _frmMenu.dataGridView1.DataSource = bll.GetSysMenuChilds(_frmMenu.treeView1.SelectedNode.Tag.ToString(),FrmLogin.LoginUserID);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("修改失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    ClassName = typeof(FrmMenuEdit).ToString()
                });
                MessageBox.Show(ex.Message);
            }
           
        }

        private void pic_menu_Click(object sender, EventArgs e)
        {
            FrmListImages image = new FrmListImages(this);
            image.ShowDialog();
        }

        private void btn_concel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
