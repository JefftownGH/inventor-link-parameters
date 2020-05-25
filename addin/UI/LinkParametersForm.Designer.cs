namespace LinkParameters.UI
{
    partial class LinkParametersForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LinkParametersForm));
            this._btnApply = new System.Windows.Forms.Button();
            this._btnCancel = new System.Windows.Forms.Button();
            this._btnOK = new System.Windows.Forms.Button();
            this._buttonImages = new System.Windows.Forms.ImageList(this.components);
            this._splitContainer = new System.Windows.Forms.SplitContainer();
            this._sourceParameterList = new System.Windows.Forms.ListView();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this._targetParameterList = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this._targetParametersMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this._deleteMappingMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._deleteAllMappingsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._autoMapParamsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this._cbRootAsmAsSrc = new System.Windows.Forms.CheckBox();
            this._labelSourceComponent = new System.Windows.Forms.Label();
            this._labelTargetComponent = new System.Windows.Forms.Label();
            this._bOptions = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this._bFilters = new System.Windows.Forms.Button();
            this._btnSelectTarget = new System.Windows.Forms.Button();
            this._btnSelectSource = new System.Windows.Forms.Button();
            this._bAutoMap = new System.Windows.Forms.Button();
            this._splitContainer.Panel1.SuspendLayout();
            this._splitContainer.Panel2.SuspendLayout();
            this._splitContainer.SuspendLayout();
            this._targetParametersMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // _btnApply
            // 
            this._btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnApply.Enabled = false;
            this._btnApply.Location = new System.Drawing.Point(499, 333);
            this._btnApply.Name = "_btnApply";
            this._btnApply.Size = new System.Drawing.Size(75, 23);
            this._btnApply.TabIndex = 0;
            this._btnApply.Text = "Apply";
            this._btnApply.UseVisualStyleBackColor = true;
            this._btnApply.Click += new System.EventHandler(this.Handle_BtnApply_Click);
            // 
            // _btnCancel
            // 
            this._btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._btnCancel.Location = new System.Drawing.Point(418, 333);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(75, 23);
            this._btnCancel.TabIndex = 0;
            this._btnCancel.Text = "Cancel";
            this._btnCancel.UseVisualStyleBackColor = true;
            this._btnCancel.Click += new System.EventHandler(this.Handle_BtnCancel_Click);
            // 
            // _btnOK
            // 
            this._btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._btnOK.Location = new System.Drawing.Point(337, 333);
            this._btnOK.Name = "_btnOK";
            this._btnOK.Size = new System.Drawing.Size(75, 23);
            this._btnOK.TabIndex = 0;
            this._btnOK.Text = "OK";
            this._btnOK.UseVisualStyleBackColor = true;
            this._btnOK.Click += new System.EventHandler(this.Handle_BtnOK_Click);
            // 
            // _buttonImages
            // 
            this._buttonImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("_buttonImages.ImageStream")));
            this._buttonImages.TransparentColor = System.Drawing.Color.Magenta;
            this._buttonImages.Images.SetKeyName(0, "Pick.png");
            this._buttonImages.Images.SetKeyName(1, "Filter_Off.ico");
            this._buttonImages.Images.SetKeyName(2, "Filter_On.ico");
            // 
            // _splitContainer
            // 
            this._splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._splitContainer.Location = new System.Drawing.Point(13, 110);
            this._splitContainer.Name = "_splitContainer";
            // 
            // _splitContainer.Panel1
            // 
            this._splitContainer.Panel1.Controls.Add(this._sourceParameterList);
            // 
            // _splitContainer.Panel2
            // 
            this._splitContainer.Panel2.Controls.Add(this._targetParameterList);
            this._splitContainer.Size = new System.Drawing.Size(561, 209);
            this._splitContainer.SplitterDistance = 276;
            this._splitContainer.TabIndex = 1;
            // 
            // _sourceParameterList
            // 
            this._sourceParameterList.AllowDrop = true;
            this._sourceParameterList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5});
            this._sourceParameterList.Dock = System.Windows.Forms.DockStyle.Fill;
            this._sourceParameterList.FullRowSelect = true;
            this._sourceParameterList.GridLines = true;
            this._sourceParameterList.HideSelection = false;
            this._sourceParameterList.Location = new System.Drawing.Point(0, 0);
            this._sourceParameterList.MultiSelect = false;
            this._sourceParameterList.Name = "_sourceParameterList";
            this._sourceParameterList.ShowItemToolTips = true;
            this._sourceParameterList.Size = new System.Drawing.Size(276, 209);
            this._sourceParameterList.TabIndex = 0;
            this.toolTip1.SetToolTip(this._sourceParameterList, "Display Driving Component Parameters");
            this._sourceParameterList.UseCompatibleStateImageBehavior = false;
            this._sourceParameterList.View = System.Windows.Forms.View.Details;
            this._sourceParameterList.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.Handle_SourceParameterList_ItemDrag);
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Name";
            this.columnHeader4.Width = 100;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Value";
            this.columnHeader5.Width = 172;
            // 
            // _targetParameterList
            // 
            this._targetParameterList.AllowDrop = true;
            this._targetParameterList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this._targetParameterList.ContextMenuStrip = this._targetParametersMenu;
            this._targetParameterList.Dock = System.Windows.Forms.DockStyle.Fill;
            this._targetParameterList.FullRowSelect = true;
            this._targetParameterList.GridLines = true;
            this._targetParameterList.HideSelection = false;
            this._targetParameterList.Location = new System.Drawing.Point(0, 0);
            this._targetParameterList.MultiSelect = false;
            this._targetParameterList.Name = "_targetParameterList";
            this._targetParameterList.ShowItemToolTips = true;
            this._targetParameterList.Size = new System.Drawing.Size(281, 209);
            this._targetParameterList.TabIndex = 0;
            this.toolTip1.SetToolTip(this._targetParameterList, "Display Driven Component Parameters");
            this._targetParameterList.UseCompatibleStateImageBehavior = false;
            this._targetParameterList.View = System.Windows.Forms.View.Details;
            this._targetParameterList.DragDrop += new System.Windows.Forms.DragEventHandler(this.Handle_TargetParameterList_DragDrop);
            this._targetParameterList.DragEnter += new System.Windows.Forms.DragEventHandler(this.Handle_TargetParameterList_DragEnter);
            this._targetParameterList.DragOver += new System.Windows.Forms.DragEventHandler(this.Handle_TargetParameterList_DragOver);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Value";
            this.columnHeader2.Width = 78;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Mapping";
            this.columnHeader3.Width = 99;
            // 
            // _targetParametersMenu
            // 
            this._targetParametersMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._deleteMappingMenuItem,
            this._deleteAllMappingsMenuItem,
            this._autoMapParamsMenuItem});
            this._targetParametersMenu.Name = "_targetParametersMenu";
            this._targetParametersMenu.Size = new System.Drawing.Size(361, 70);
            // 
            // _deleteMappingMenuItem
            // 
            this._deleteMappingMenuItem.Name = "_deleteMappingMenuItem";
            this._deleteMappingMenuItem.Size = new System.Drawing.Size(360, 22);
            this._deleteMappingMenuItem.Text = "Delete Mapping";
            // 
            // _deleteAllMappingsMenuItem
            // 
            this._deleteAllMappingsMenuItem.Name = "_deleteAllMappingsMenuItem";
            this._deleteAllMappingsMenuItem.Size = new System.Drawing.Size(360, 22);
            this._deleteAllMappingsMenuItem.Text = "Delete All Mappings";
            // 
            // _autoMapParamsMenuItem
            // 
            this._autoMapParamsMenuItem.Name = "_autoMapParamsMenuItem";
            this._autoMapParamsMenuItem.Size = new System.Drawing.Size(360, 22);
            this._autoMapParamsMenuItem.Text = "Map All Parameters with same name in Source and Target";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Source Component";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(334, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Target Component";
            // 
            // _cbRootAsmAsSrc
            // 
            this._cbRootAsmAsSrc.AutoSize = true;
            this._cbRootAsmAsSrc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._cbRootAsmAsSrc.Location = new System.Drawing.Point(12, 10);
            this._cbRootAsmAsSrc.Name = "_cbRootAsmAsSrc";
            this._cbRootAsmAsSrc.Size = new System.Drawing.Size(218, 17);
            this._cbRootAsmAsSrc.TabIndex = 3;
            this._cbRootAsmAsSrc.Text = "UseTop-level Assembly as Source";
            this.toolTip1.SetToolTip(this._cbRootAsmAsSrc, "Automatically use Top-Level Assembly as Source component");
            this._cbRootAsmAsSrc.UseVisualStyleBackColor = true;
            this._cbRootAsmAsSrc.CheckedChanged += new System.EventHandler(this.cbRootAsmAsSrc_CheckedChanged);
            // 
            // _labelSourceComponent
            // 
            this._labelSourceComponent.AutoSize = true;
            this._labelSourceComponent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._labelSourceComponent.Location = new System.Drawing.Point(9, 87);
            this._labelSourceComponent.Name = "_labelSourceComponent";
            this._labelSourceComponent.Size = new System.Drawing.Size(114, 13);
            this._labelSourceComponent.TabIndex = 4;
            this._labelSourceComponent.Text = "Driving Parameters";
            // 
            // _labelTargetComponent
            // 
            this._labelTargetComponent.AutoSize = true;
            this._labelTargetComponent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._labelTargetComponent.Location = new System.Drawing.Point(294, 87);
            this._labelTargetComponent.Name = "_labelTargetComponent";
            this._labelTargetComponent.Size = new System.Drawing.Size(111, 13);
            this._labelTargetComponent.TabIndex = 5;
            this._labelTargetComponent.Text = "Driven Parameters";
            // 
            // _bOptions
            // 
            this._bOptions.Location = new System.Drawing.Point(214, 333);
            this._bOptions.Name = "_bOptions";
            this._bOptions.Size = new System.Drawing.Size(75, 23);
            this._bOptions.TabIndex = 6;
            this._bOptions.Text = "Options...";
            this.toolTip1.SetToolTip(this._bOptions, "Rule Creation Options ");
            this._bOptions.UseVisualStyleBackColor = true;
            this._bOptions.Click += new System.EventHandler(this.bOptions_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 3000;
            // 
            // _bFilters
            // 
            this._bFilters.BackgroundImage = global::LinkParameters.Properties.Resources.Filter_Off;
            this._bFilters.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this._bFilters.ImageList = this._buttonImages;
            this._bFilters.Location = new System.Drawing.Point(13, 331);
            this._bFilters.Name = "_bFilters";
            this._bFilters.Size = new System.Drawing.Size(25, 25);
            this._bFilters.TabIndex = 8;
            this.toolTip1.SetToolTip(this._bFilters, "Parameters Filter");
            this._bFilters.UseVisualStyleBackColor = true;
            this._bFilters.Click += new System.EventHandler(this.bFilters_Click);
            // 
            // _btnSelectTarget
            // 
            this._btnSelectTarget.ImageIndex = 0;
            this._btnSelectTarget.ImageList = this._buttonImages;
            this._btnSelectTarget.Location = new System.Drawing.Point(293, 42);
            this._btnSelectTarget.Name = "_btnSelectTarget";
            this._btnSelectTarget.Size = new System.Drawing.Size(35, 35);
            this._btnSelectTarget.TabIndex = 0;
            this.toolTip1.SetToolTip(this._btnSelectTarget, "Select the Target component from assembly occurrences");
            this._btnSelectTarget.UseVisualStyleBackColor = true;
            this._btnSelectTarget.Click += new System.EventHandler(this.Handle_BtnSelectTarget_Click);
            // 
            // _btnSelectSource
            // 
            this._btnSelectSource.ImageIndex = 0;
            this._btnSelectSource.ImageList = this._buttonImages;
            this._btnSelectSource.Location = new System.Drawing.Point(12, 42);
            this._btnSelectSource.Name = "_btnSelectSource";
            this._btnSelectSource.Size = new System.Drawing.Size(35, 35);
            this._btnSelectSource.TabIndex = 0;
            this.toolTip1.SetToolTip(this._btnSelectSource, "Select the Source component from assembly occurrences");
            this._btnSelectSource.UseVisualStyleBackColor = true;
            this._btnSelectSource.Click += new System.EventHandler(this.Handle_BtnSelectSource_Click);
            // 
            // _bAutoMap
            // 
            this._bAutoMap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._bAutoMap.Location = new System.Drawing.Point(452, 48);
            this._bAutoMap.Name = "_bAutoMap";
            this._bAutoMap.Size = new System.Drawing.Size(122, 23);
            this._bAutoMap.TabIndex = 9;
            this._bAutoMap.Text = "Map Matching Names";
            this.toolTip1.SetToolTip(this._bAutoMap, "Map All Parameters with same name in Source and Target components");
            this._bAutoMap.UseVisualStyleBackColor = true;
            this._bAutoMap.Click += new System.EventHandler(this._bAutoMap_Click);
            // 
            // LinkParametersForm
            // 
            this.AcceptButton = this._btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._btnCancel;
            this.ClientSize = new System.Drawing.Size(594, 368);
            this.Controls.Add(this._bAutoMap);
            this.Controls.Add(this._labelTargetComponent);
            this.Controls.Add(this._bOptions);
            this.Controls.Add(this._labelSourceComponent);
            this.Controls.Add(this._cbRootAsmAsSrc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._splitContainer);
            this.Controls.Add(this._bFilters);
            this.Controls.Add(this._btnSelectTarget);
            this.Controls.Add(this._btnSelectSource);
            this.Controls.Add(this._btnOK);
            this.Controls.Add(this._btnCancel);
            this.Controls.Add(this._btnApply);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "LinkParametersForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Link Parameters [Rule: Rule 1]";
            this.toolTip1.SetToolTip(this, "Link Parameters Controller");
            this.Load += new System.EventHandler(this.Handle_Form_Load);
            this._splitContainer.Panel1.ResumeLayout(false);
            this._splitContainer.Panel2.ResumeLayout(false);
            this._splitContainer.ResumeLayout(false);
            this._targetParametersMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _btnApply;
        private System.Windows.Forms.Button _btnCancel;
        private System.Windows.Forms.Button _btnOK;
        private System.Windows.Forms.Button _btnSelectSource;
        private System.Windows.Forms.Button _btnSelectTarget;
        private System.Windows.Forms.SplitContainer _splitContainer;
        private System.Windows.Forms.ListView _sourceParameterList;
        private System.Windows.Forms.ListView _targetParameterList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ContextMenuStrip _targetParametersMenu;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
       
        private System.Windows.Forms.ImageList _buttonImages;
        private System.Windows.Forms.CheckBox _cbRootAsmAsSrc;
        private System.Windows.Forms.Label _labelSourceComponent;
        private System.Windows.Forms.Label _labelTargetComponent;
        private System.Windows.Forms.Button _bOptions;
        private System.Windows.Forms.Button _bFilters;
        private System.Windows.Forms.ToolTip toolTip1;

        private System.Windows.Forms.ToolStripMenuItem _autoMapParamsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _deleteMappingMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _deleteAllMappingsMenuItem;
        private System.Windows.Forms.Button _bAutoMap;
    }
}