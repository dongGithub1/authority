using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using YX.BLL;
using WeifenLuo.WinFormsUI.Docking;
using YX.Entity;


namespace YX
{
    public partial class FrmAppendProperty : WindowParent
    {
        SystemAppendProperty_Bll append_bll = new SystemAppendProperty_Bll();
        SystemMenu_Bll menu_bll = new SystemMenu_Bll();
       // SystemAppendProperty_Dal append_dal = new SystemAppendProperty_Dal();
        public FrmAppendProperty(string ParentId)
        {
            InitializeComponent();
            SetButton(ParentId,this.toolStrip1);
        }

        private void FrmAppendProperty_Load(object sender, EventArgs e)
        {
            BindTreeView();
        
            this.dataGridView1.RowsDefaultCellStyle.BackColor = Color.White;
            this.dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.BlanchedAlmond;
             //设置不自动显示数据库中未绑定的列
            this.dataGridView1.AutoGenerateColumns = false;
        }
        private void BindTreeView()
        {
            try
            {
                this.treeView1.Nodes.Clear();
                this.treeView1.ImageList = imageList1;
                var list = append_bll.GetAppendPropertys();
               
                foreach (var item in list)
                {
                    TreeNode tn = new TreeNode();
                    tn.Text = item;
                    tn.Tag = item;
                    tn.ImageIndex = 0;
                    treeView1.Nodes.Add(tn);
                }
                treeView1.ExpandAll();
            }
            catch (Exception ex)
            {
                System_Bll.WriteLogToDB( new Entity.Base_Log{
                        CreateUserID = FrmLogin.LoginUserID,
                        CreateUserName = FrmLogin.loginUserName,
                        LocalIP = FrmLogin.LocalIP,
                        LogMessage =ex.Message,
                        Type = "系统错误",
                    ClassName = typeof(FrmAppendProperty).ToString()
                });
                MessageBox.Show(ex.Message,"提示",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (!string .IsNullOrEmpty(this.treeView1.SelectedNode.Text))
            {
                this.dataGridView1.DataSource = append_bll.AppendProperty_List(treeView1.SelectedNode.Tag.ToString());
            }
        }
        /// <summary>
        /// 显示行号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X,
                e.RowBounds.Location.Y,
                dataGridView1.RowHeadersWidth - 4,
                e.RowBounds.Height);

                TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
                dataGridView1.RowHeadersDefaultCellStyle.Font,
                rectangle,
                dataGridView1.RowHeadersDefaultCellStyle.ForeColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }
        private void btn_add_Click(object sender, EventArgs e)
        {
            FrmAppendPropertyEdit edit = new FrmAppendPropertyEdit(this);
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
                    FrmAppendPropertyEdit edit = new FrmAppendPropertyEdit(this,ref dr);
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
                    int result = append_bll.DeleteAppendProettty(dr.Cells["编号"].Value.ToString());
                    if (result == 1)
                    {
                        MessageBox.Show("删除成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        BindTreeView();
                      //  this.dataGridView1.DataSource = append_dal.AppendProperty_List(treeView1.SelectedNode.Tag.ToString());
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
                    Type = "系统错误",
                    ClassName = typeof(FrmAppendProperty).ToString()
                });
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
             
            }
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
       
            if (!string.IsNullOrEmpty(this.treeView1.SelectedNode.Text))
            {
                this.dataGridView1.DataSource = append_bll.AppendProperty_List(treeView1.SelectedNode.Tag.ToString());
            }
        }
    }
}
