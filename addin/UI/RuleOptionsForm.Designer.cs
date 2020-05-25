namespace LinkParameters.UI
{
    partial class RuleOptionsForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbUpdateWhenDone = new System.Windows.Forms.CheckBox();
            this.cbRunAuto = new System.Windows.Forms.CheckBox();
            this.cbFireDep = new System.Windows.Forms.CheckBox();
            this._bCancel = new System.Windows.Forms.Button();
            this._bOk = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbUpdateWhenDone);
            this.groupBox1.Controls.Add(this.cbRunAuto);
            this.groupBox1.Controls.Add(this.cbFireDep);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(202, 105);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Rule Behavior:";
            // 
            // cbUpdateWhenDone
            // 
            this.cbUpdateWhenDone.AutoSize = true;
            this.cbUpdateWhenDone.Location = new System.Drawing.Point(6, 74);
            this.cbUpdateWhenDone.Name = "cbUpdateWhenDone";
            this.cbUpdateWhenDone.Size = new System.Drawing.Size(122, 17);
            this.cbUpdateWhenDone.TabIndex = 2;
            this.cbUpdateWhenDone.Text = "Update When Done";
            this.cbUpdateWhenDone.UseVisualStyleBackColor = true;
            // 
            // cbRunAuto
            // 
            this.cbRunAuto.AutoSize = true;
            this.cbRunAuto.Location = new System.Drawing.Point(6, 51);
            this.cbRunAuto.Name = "cbRunAuto";
            this.cbRunAuto.Size = new System.Drawing.Size(133, 17);
            this.cbRunAuto.TabIndex = 1;
            this.cbRunAuto.Text = "Don\'t run automatically";
            this.cbRunAuto.UseVisualStyleBackColor = true;
            // 
            // cbFireDep
            // 
            this.cbFireDep.AutoSize = true;
            this.cbFireDep.Location = new System.Drawing.Point(6, 28);
            this.cbFireDep.Name = "cbFireDep";
            this.cbFireDep.Size = new System.Drawing.Size(179, 17);
            this.cbFireDep.TabIndex = 0;
            this.cbFireDep.Text = "Fire dependent rules immediately";
            this.cbFireDep.UseVisualStyleBackColor = true;
            // 
            // _bCancel
            // 
            this._bCancel.Location = new System.Drawing.Point(180, 133);
            this._bCancel.Name = "_bCancel";
            this._bCancel.Size = new System.Drawing.Size(75, 23);
            this._bCancel.TabIndex = 3;
            this._bCancel.Text = "Cancel";
            this._bCancel.UseVisualStyleBackColor = true;
            this._bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // _bOk
            // 
            this._bOk.Location = new System.Drawing.Point(99, 133);
            this._bOk.Name = "_bOk";
            this._bOk.Size = new System.Drawing.Size(75, 23);
            this._bOk.TabIndex = 2;
            this._bOk.Text = "OK";
            this._bOk.UseVisualStyleBackColor = true;
            this._bOk.Click += new System.EventHandler(this.bOk_Click);
            // 
            // RuleOptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 166);
            this.Controls.Add(this._bCancel);
            this.Controls.Add(this._bOk);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "RuleOptionsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Create Rule Options";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cbUpdateWhenDone;
        private System.Windows.Forms.CheckBox cbRunAuto;
        private System.Windows.Forms.CheckBox cbFireDep;
        private System.Windows.Forms.Button _bCancel;
        private System.Windows.Forms.Button _bOk;
    }
}