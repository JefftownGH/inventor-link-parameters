namespace LinkParameters.UI
{
    partial class RuleNameForm
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
            this._bOk = new System.Windows.Forms.Button();
            this._bCancel = new System.Windows.Forms.Button();
            this._bRuleList = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this._tbRuleName = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // _bOk
            // 
            this._bOk.Enabled = false;
            this._bOk.Location = new System.Drawing.Point(88, 82);
            this._bOk.Name = "_bOk";
            this._bOk.Size = new System.Drawing.Size(75, 23);
            this._bOk.TabIndex = 0;
            this._bOk.Text = "OK";
            this._bOk.UseVisualStyleBackColor = true;
            this._bOk.Click += new System.EventHandler(this.bOk_Click);
            // 
            // _bCancel
            // 
            this._bCancel.Location = new System.Drawing.Point(169, 82);
            this._bCancel.Name = "_bCancel";
            this._bCancel.Size = new System.Drawing.Size(75, 23);
            this._bCancel.TabIndex = 1;
            this._bCancel.Text = "Cancel";
            this._bCancel.UseVisualStyleBackColor = true;
            this._bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // _bRuleList
            // 
            this._bRuleList.Location = new System.Drawing.Point(185, 30);
            this._bRuleList.Name = "_bRuleList";
            this._bRuleList.Size = new System.Drawing.Size(28, 20);
            this._bRuleList.TabIndex = 2;
            this._bRuleList.Text = "...";
            this.toolTip1.SetToolTip(this._bRuleList, "Select existing rule...");
            this._bRuleList.UseVisualStyleBackColor = true;
            this._bRuleList.Click += new System.EventHandler(this.bRuleList_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Name:";
            // 
            // _tbRuleName
            // 
            this._tbRuleName.Location = new System.Drawing.Point(15, 30);
            this._tbRuleName.Name = "_tbRuleName";
            this._tbRuleName.Size = new System.Drawing.Size(162, 20);
            this._tbRuleName.TabIndex = 4;
            this._tbRuleName.TextChanged += new System.EventHandler(this.tbRuleName_TextChanged);
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 3000;
            // 
            // RuleNameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(256, 117);
            this.Controls.Add(this._tbRuleName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._bRuleList);
            this.Controls.Add(this._bCancel);
            this.Controls.Add(this._bOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "RuleNameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Rule Name";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _bOk;
        private System.Windows.Forms.Button _bCancel;
        private System.Windows.Forms.Button _bRuleList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _tbRuleName;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}