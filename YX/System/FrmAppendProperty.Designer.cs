namespace YX
{
    partial class FrmAppendProperty
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAppendProperty));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btn_add = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_edit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_delete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_refresh = new System.Windows.Forms.ToolStripButton();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.Property_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Property_Function = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Property_Control_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Property_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Property_Control_DataSource = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Property_Control_Length = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Property_Control_Style = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SortCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateUserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ModifyDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ModifyUserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
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
            this.toolStrip1.Size = new System.Drawing.Size(1004, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btn_add
            // 
            this.btn_add.Image = ((System.Drawing.Image)(resources.GetObject("btn_add.Image")));
            this.btn_add.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(52, 22);
            this.btn_add.Text = "添加";
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
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
            this.btn_refresh.Click += new System.EventHandler(this.btn_refresh_Click);
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeView1.ItemHeight = 20;
            this.treeView1.Location = new System.Drawing.Point(0, 25);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(191, 470);
            this.treeView1.TabIndex = 5;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
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
            this.Property_ID,
            this.Property_Function,
            this.Property_Control_ID,
            this.Property_Name,
            this.Property_Control_DataSource,
            this.Property_Control_Length,
            this.Property_Control_Style,
            this.SortCode,
            this.CreateDate,
            this.CreateUserName,
            this.ModifyDate,
            this.ModifyUserName});
            this.dataGridView1.Location = new System.Drawing.Point(197, 28);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(807, 467);
            this.dataGridView1.TabIndex = 6;
            //this.dataGridView1.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView1_DataBindingComplete);
            this.dataGridView1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView1_RowPostPaint);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "42.png");
            // 
            // Property_ID
            // 
            this.Property_ID.DataPropertyName = "Property_ID";
            this.Property_ID.HeaderText = "编号";
            this.Property_ID.Name = "Property_ID";
            this.Property_ID.ReadOnly = true;
            // 
            // Property_Function
            // 
            this.Property_Function.DataPropertyName = "Property_Function";
            this.Property_Function.HeaderText = "业务分类";
            this.Property_Function.Name = "Property_Function";
            this.Property_Function.ReadOnly = true;
            // 
            // Property_Control_ID
            // 
            this.Property_Control_ID.DataPropertyName = "Property_Control_ID";
            this.Property_Control_ID.HeaderText = "控件ID";
            this.Property_Control_ID.Name = "Property_Control_ID";
            this.Property_Control_ID.ReadOnly = true;
            // 
            // Property_Name
            // 
            this.Property_Name.DataPropertyName = "Property_Name";
            this.Property_Name.HeaderText = "属性名称";
            this.Property_Name.Name = "Property_Name";
            this.Property_Name.ReadOnly = true;
            // 
            // Property_Control_DataSource
            // 
            this.Property_Control_DataSource.DataPropertyName = "Property_Control_DataSource";
            this.Property_Control_DataSource.HeaderText = "数据源";
            this.Property_Control_DataSource.Name = "Property_Control_DataSource";
            this.Property_Control_DataSource.ReadOnly = true;
            // 
            // Property_Control_Length
            // 
            this.Property_Control_Length.DataPropertyName = "Property_Control_Length";
            this.Property_Control_Length.HeaderText = "控件宽度";
            this.Property_Control_Length.Name = "Property_Control_Length";
            this.Property_Control_Length.ReadOnly = true;
            // 
            // Property_Control_Style
            // 
            this.Property_Control_Style.DataPropertyName = "Property_Control_Style";
            this.Property_Control_Style.HeaderText = "控件类型";
            this.Property_Control_Style.Name = "Property_Control_Style";
            this.Property_Control_Style.ReadOnly = true;
            // 
            // SortCode
            // 
            this.SortCode.DataPropertyName = "SortCode";
            this.SortCode.HeaderText = "排序";
            this.SortCode.Name = "SortCode";
            this.SortCode.ReadOnly = true;
            // 
            // CreateDate
            // 
            this.CreateDate.DataPropertyName = "CreateDate";
            this.CreateDate.HeaderText = "创建时间";
            this.CreateDate.Name = "CreateDate";
            this.CreateDate.ReadOnly = true;
            // 
            // CreateUserName
            // 
            this.CreateUserName.DataPropertyName = "CreateUserName";
            this.CreateUserName.HeaderText = "创建人";
            this.CreateUserName.Name = "CreateUserName";
            this.CreateUserName.ReadOnly = true;
            // 
            // ModifyDate
            // 
            this.ModifyDate.DataPropertyName = "ModifyDate";
            this.ModifyDate.HeaderText = "修改时间";
            this.ModifyDate.Name = "ModifyDate";
            this.ModifyDate.ReadOnly = true;
            // 
            // ModifyUserName
            // 
            this.ModifyUserName.DataPropertyName = "ModifyUserName";
            this.ModifyUserName.HeaderText = "修改人";
            this.ModifyUserName.Name = "ModifyUserName";
            this.ModifyUserName.ReadOnly = true;
            // 
            // FrmAppendProperty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 495);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "FrmAppendProperty";
            this.Text = "附加属性";
            this.Load += new System.EventHandler(this.FrmAppendProperty_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip toolStrip1;
        public System.Windows.Forms.ToolStripButton btn_add;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btn_edit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btn_delete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btn_refresh;
        public System.Windows.Forms.TreeView treeView1;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Property_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Property_Function;
        private System.Windows.Forms.DataGridViewTextBoxColumn Property_Control_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Property_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Property_Control_DataSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn Property_Control_Length;
        private System.Windows.Forms.DataGridViewTextBoxColumn Property_Control_Style;
        private System.Windows.Forms.DataGridViewTextBoxColumn SortCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateUserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModifyDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModifyUserName;
    }
}