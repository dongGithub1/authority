namespace YX
{
    partial class FrmDeptInfo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDeptInfo));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btn_add = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_edit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_delete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_refresh = new System.Windows.Forms.ToolStripButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.Organization_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Organization_Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Organization_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Organization_InnerPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Organization_OuterPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Organization_Manager = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Organization_AssistantManager = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Organization_Fax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Organization_Zipcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Organization_Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ParentId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SortCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Organization_Remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_add,
            this.toolStripSeparator1,
            this.btn_edit,
            this.toolStripSeparator2,
            this.btn_delete,
            this.toolStripSeparator3,
            this.btn_refresh});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(932, 25);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btn_add
            // 
            this.btn_add.Image = ((System.Drawing.Image)(resources.GetObject("btn_add.Image")));
            this.btn_add.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(52, 22);
            this.btn_add.Text = "添加";
            this.btn_add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btn_edit
            // 
            this.btn_edit.Image = ((System.Drawing.Image)(resources.GetObject("btn_edit.Image")));
            this.btn_edit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Size = new System.Drawing.Size(52, 22);
            this.btn_edit.Text = "编辑";
            this.btn_edit.Click += new System.EventHandler(this.btn_edit_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btn_delete
            // 
            this.btn_delete.Image = ((System.Drawing.Image)(resources.GetObject("btn_delete.Image")));
            this.btn_delete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(52, 22);
            this.btn_delete.Text = "删除";
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // btn_refresh
            // 
            this.btn_refresh.Image = ((System.Drawing.Image)(resources.GetObject("btn_refresh.Image")));
            this.btn_refresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(52, 22);
            this.btn_refresh.Text = "刷新";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Organization_ID,
            this.Organization_Code,
            this.Organization_Name,
            this.Organization_InnerPhone,
            this.Organization_OuterPhone,
            this.Organization_Manager,
            this.Organization_AssistantManager,
            this.Organization_Fax,
            this.Organization_Zipcode,
            this.Organization_Address,
            this.ParentId,
            this.SortCode,
            this.Organization_Remark});
            this.dataGridView1.Location = new System.Drawing.Point(201, 25);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(731, 484);
            this.dataGridView1.TabIndex = 7;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "folder.png");
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.treeView1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(195, 488);
            this.panel1.TabIndex = 11;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.imageList1;
            this.treeView1.ItemHeight = 20;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Scrollable = false;
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.Size = new System.Drawing.Size(195, 488);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // Organization_ID
            // 
            this.Organization_ID.DataPropertyName = "Organization_ID";
            this.Organization_ID.HeaderText = "编号";
            this.Organization_ID.Name = "Organization_ID";
            this.Organization_ID.ReadOnly = true;
            // 
            // Organization_Code
            // 
            this.Organization_Code.DataPropertyName = "Organization_Code";
            this.Organization_Code.HeaderText = "部门编码";
            this.Organization_Code.Name = "Organization_Code";
            this.Organization_Code.ReadOnly = true;
            // 
            // Organization_Name
            // 
            this.Organization_Name.DataPropertyName = "Organization_Name";
            this.Organization_Name.HeaderText = "部门名称";
            this.Organization_Name.Name = "Organization_Name";
            this.Organization_Name.ReadOnly = true;
            // 
            // Organization_InnerPhone
            // 
            this.Organization_InnerPhone.DataPropertyName = "Organization_InnerPhone";
            this.Organization_InnerPhone.HeaderText = "内线电话";
            this.Organization_InnerPhone.Name = "Organization_InnerPhone";
            this.Organization_InnerPhone.ReadOnly = true;
            // 
            // Organization_OuterPhone
            // 
            this.Organization_OuterPhone.DataPropertyName = "Organization_OuterPhone";
            this.Organization_OuterPhone.HeaderText = "外线电话";
            this.Organization_OuterPhone.Name = "Organization_OuterPhone";
            this.Organization_OuterPhone.ReadOnly = true;
            // 
            // Organization_Manager
            // 
            this.Organization_Manager.DataPropertyName = "Organization_Manager";
            this.Organization_Manager.HeaderText = "主负责人";
            this.Organization_Manager.Name = "Organization_Manager";
            this.Organization_Manager.ReadOnly = true;
            // 
            // Organization_AssistantManager
            // 
            this.Organization_AssistantManager.DataPropertyName = "Organization_AssistantManager";
            this.Organization_AssistantManager.HeaderText = "副负责人";
            this.Organization_AssistantManager.Name = "Organization_AssistantManager";
            this.Organization_AssistantManager.ReadOnly = true;
            // 
            // Organization_Fax
            // 
            this.Organization_Fax.DataPropertyName = "Organization_Fax";
            this.Organization_Fax.HeaderText = "传真号码";
            this.Organization_Fax.Name = "Organization_Fax";
            this.Organization_Fax.ReadOnly = true;
            // 
            // Organization_Zipcode
            // 
            this.Organization_Zipcode.DataPropertyName = "Organization_Zipcode";
            this.Organization_Zipcode.HeaderText = "行政号码";
            this.Organization_Zipcode.Name = "Organization_Zipcode";
            this.Organization_Zipcode.ReadOnly = true;
            // 
            // Organization_Address
            // 
            this.Organization_Address.DataPropertyName = "Organization_Address";
            this.Organization_Address.HeaderText = "所在地址";
            this.Organization_Address.Name = "Organization_Address";
            this.Organization_Address.ReadOnly = true;
            // 
            // ParentId
            // 
            this.ParentId.DataPropertyName = "ParentId";
            this.ParentId.HeaderText = "节点位置";
            this.ParentId.Name = "ParentId";
            this.ParentId.ReadOnly = true;
            // 
            // SortCode
            // 
            this.SortCode.DataPropertyName = "SortCode";
            this.SortCode.HeaderText = "排序";
            this.SortCode.Name = "SortCode";
            this.SortCode.ReadOnly = true;
            // 
            // Organization_Remark
            // 
            this.Organization_Remark.DataPropertyName = "Organization_Remark";
            this.Organization_Remark.HeaderText = "备注";
            this.Organization_Remark.Name = "Organization_Remark";
            this.Organization_Remark.ReadOnly = true;
            // 
            // FrmDeptInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 513);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "FrmDeptInfo";
            this.Text = "部门管理";
            this.Load += new System.EventHandler(this.FrmDeptInfo_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btn_add;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btn_edit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btn_delete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btn_refresh;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Organization_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Organization_Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn Organization_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Organization_InnerPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn Organization_OuterPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn Organization_Manager;
        private System.Windows.Forms.DataGridViewTextBoxColumn Organization_AssistantManager;
        private System.Windows.Forms.DataGridViewTextBoxColumn Organization_Fax;
        private System.Windows.Forms.DataGridViewTextBoxColumn Organization_Zipcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Organization_Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn ParentId;
        private System.Windows.Forms.DataGridViewTextBoxColumn SortCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Organization_Remark;
    }
}