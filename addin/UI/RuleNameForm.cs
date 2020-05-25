////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// Copyright (c) Autodesk, Inc. All rights reserved 
// Written by Jan Liska & Philippe Leefsma 2011 - ADN/Developer Technical Services
//
// This software is provided as is, without any warranty that it will work. You choose to use this tool at your own risk.
// Neither Autodesk nor the authors can be taken as responsible for any damage this tool can cause to 
// your data. Please always make a back up of your data prior to use this tool.
//
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Autodesk.iLogic.Interfaces;
using Inventor;
using LinkParameters.Utilities;

namespace LinkParameters.UI
{
    public partial class RuleNameForm : Form
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern IntPtr SetFocus(IntPtr hWnd);

        public RuleNameForm()
        {
            InitializeComponent();

            this.Activated += new EventHandler(RuleNameForm_Activated);

            this.DialogResult = DialogResult.Cancel;
        }

        void RuleNameForm_Activated(object sender, EventArgs e)
        {
            _tbRuleName.Text = GenerateDefaultRuleName();
            _tbRuleName.Focus();
            _tbRuleName.SelectAll();
        }

        public string RuleName
        {
            get
            {
                return _tbRuleName.Text;
            }
        }

        public DialogResult ShowModal()
        {
            return base.ShowDialog(); //new WinUtilities((IntPtr)InventorUtilities.Application.MainFrameHWND));
        }

        private void bRuleList_Click(object sender, EventArgs e)
        {
            SelectRuleForm selRuleForm = new SelectRuleForm();

            System.Drawing.Point formPos = new System.Drawing.Point(
               _bRuleList.Location.X,
               _bRuleList.Location.Y + _bRuleList.Height);

            selRuleForm.Location = this.PointToScreen(formPos);

            DialogResult res = selRuleForm.ShowDialog();//new WinUtilities(this.Handle));

            if (res != DialogResult.OK)
                return;

            _tbRuleName.Text = selRuleForm.RuleName;
            _tbRuleName.Focus();
            _tbRuleName.Select(_tbRuleName.Text.Length, 0);

            selRuleForm.Dispose();
        }

        private void bOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;

            Close();
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tbRuleName_TextChanged(object sender, EventArgs e)
        {
            if (_tbRuleName.Text.Length > 0)
            {
                _bOk.Enabled = true;
            }
            else
            {
                _bOk.Enabled = false;
            }
        }

        private string GenerateDefaultRuleName()
        {
            Document doc = AdnInventorUtilities.InvApplication.ActiveDocument;

            System.Collections.IEnumerable rules = 
                iLogicUtilities.GetiLogicAutomation().get_Rules(doc);

            int idx = 0;
            string name = "Rule";

            if (rules != null)
            {
                List<string> ruleNames = new List<string>();

                foreach (iLogicRule rule in rules)
                {
                    ruleNames.Add(rule.Name);
                }

                while (ruleNames.Contains(name + idx.ToString()))
                    ++idx;
            }

            return name + idx.ToString();
        }
    }
}
