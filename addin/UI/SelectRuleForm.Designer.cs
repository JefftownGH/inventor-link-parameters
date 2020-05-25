namespace LinkParameters.UI
{
    partial class SelectRuleForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this._lbRules = new System.Windows.Forms.ListBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this._lbRules);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(112, 196);
            this.panel1.TabIndex = 0;
            // 
            // _lbRules
            // 
            this._lbRules.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._lbRules.Dock = System.Windows.Forms.DockStyle.Fill;
            this._lbRules.FormattingEnabled = true;
            this._lbRules.HorizontalScrollbar = true;
            this._lbRules.Items.AddRange(new object[] {
            "Rule 1",
            "Rule 2",
            "Rule 3"});
            this._lbRules.Location = new System.Drawing.Point(0, 0);
            this._lbRules.Name = "_lbRules";
            this._lbRules.Size = new System.Drawing.Size(112, 195);
            this._lbRules.TabIndex = 1;
            // 
            // SelectRuleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(112, 196);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SelectRuleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "SelectRuleForm";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox _lbRules;
    }
}