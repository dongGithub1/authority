using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using YX.Entity;
namespace YX
{
    public partial class FrmLeft : DockContent
    {
        FrmMain _frmMain;
       List< Base_SysMenu> m_Parent;
        YX.BLL.SystemMenu_Bll bll = new BLL.SystemMenu_Bll();
        public FrmLeft(FrmMain frmMain)
        {
            this._frmMain = frmMain;
            InitializeComponent();
        }
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmLeft_Load(object sender, EventArgs e)
        {
            Init();
        }
        private void Init()
        {
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(this.listView1);
            this.listView1.Clear();
            //查询菜单的父节点，先把父节点打上去
            m_Parent = bll.GetSysMenusParent(FrmLogin.LoginUserID);
            int i = m_Parent.Count;
            foreach (var item in m_Parent)
            {
                Button b = new Button();
                b.Text = item.Menu_Name;
                b.Dock = DockStyle.Top;
                b.Size = new System.Drawing.Size(244, 30);
                b.Tag = item.Menu_Id;
                b.TabIndex = i;
                b.Click += new System.EventHandler(this.ButtonClick);
                this.panel1.Controls.Add(b);
                i--;
            }
        }
        void ButtonClick(object sender, System.EventArgs e)
        {          
            Button clickedButton = (Button)sender;          
            int clickedButtonTabIndex = clickedButton.TabIndex;        
            foreach (Control ctl in this.panel1.Controls)
            {
                if (ctl is Button)
                {
                    Button btn = (Button)ctl;
                    if (btn.TabIndex > clickedButtonTabIndex)
                    {
                        if (btn.Dock != DockStyle.Bottom)
                        {
                            btn.Dock = DockStyle.Bottom;

                            btn.BringToFront();
                        }
                    }
                    else
                    {
                        if (btn.Dock != DockStyle.Top)
                        {
                            btn.Dock = DockStyle.Top;
                            btn.BringToFront();
                        }
                    }
                }
            }
            foreach (var item in m_Parent)
            {
                 if (clickedButton.Tag.ToString() == item.Menu_Id)
                 {
                     this.listView1.Clear();
       
                    //通过父节点去查找子节点绘制
                     List<Base_SysMenu> Childs = bll.GetSysMenuChilds(clickedButton.Tag.ToString(),FrmLogin.LoginUserID);
                     listView1.LargeImageList = new FrmListImages().imageList1;
                     this.listView1.BeginUpdate();

                     foreach (var itemChilds in Childs)
                     {
                         listView1.Items.Add(new ListViewItem 
                         { 
                             Text = itemChilds.Menu_Name,
                             Tag = itemChilds.Menu_Tag,
                             Name=itemChilds.Menu_Id,
                             ImageIndex = itemChilds.Menu_Img == null ? 0 : itemChilds.Menu_Img.Value 
                         });

                     }

                     this.listView1.EndUpdate();
                     break;
                 }
            }
            listView1.BringToFront();  
           
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.listView1.SelectedIndices.Count > 0)
                {
                    //反射动态实例化窗口
                    object FrmWindow = this.listView1.SelectedItems[0].Tag;
                    object MenuID = this.listView1.SelectedItems[0].Name;
                    if (CheckFormIsOpen(FrmWindow.ToString()))
                    {
                        //DockContent doc = (DockContent)Assembly.Load("YX").CreateInstance("YX." + FrmWindow);
                        //doc.Show(_frmMain.dockPanel1, DockState.Document);

                        Assembly assembly = Assembly.GetExecutingAssembly(); // 获取当前程序集                   
                        object[] parameters = new object[1];
                        parameters[0] = MenuID;
                        DockContent obj = (DockContent)assembly.CreateInstance("YX." + FrmWindow, true, System.Reflection.BindingFlags.Default, null, parameters, null, null);// 创建类的实例 
                        obj.Show(_frmMain.dockPanel1, DockState.Document);
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("还没有配置");
            }

        }

        /// <summary>
        /// 检查窗体是否已经被打开
        /// </summary>
        /// <param name="ChildForm"></param>
        /// <returns></returns>

        private bool CheckFormIsOpen(string Forms)
        {
            bool bResult = true;
            foreach (Form frm in Application.OpenForms)
            {
                if (frm.Name == Forms)
                {
                    frm.BringToFront();
                    bResult = false;
                    break;
                }
            }
            return bResult;
        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
            Init();
        }
    }
}
