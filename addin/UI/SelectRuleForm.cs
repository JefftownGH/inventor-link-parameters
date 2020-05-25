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
using System.Windows.Forms;
using Autodesk.iLogic.Interfaces;
using Inventor;
using LinkParameters.Utilities;

namespace LinkParameters.UI
{
    public partial class SelectRuleForm : Form
    {
        private string _ruleName = string.Empty;

        public SelectRuleForm()
        {
            InitializeComponent();

            this.DialogResult = DialogResult.None;

            this.KeyPreview = true;

            _lbRules.Items.Clear();

            this.KeyDown += new KeyEventHandler(SelectRuleForm_KeyDown);

            Document doc = AdnInventorUtilities.InvApplication.ActiveDocument;

            System.Collections.IEnumerable rules = 
                iLogicUtilities.GetiLogicAutomation().get_Rules(doc);

            if (rules != null)
            {
                foreach (iLogicRule rule in rules)
                {
                    _lbRules.Items.Add(rule.Name);
                }
            }

            _lbRules.SelectedIndexChanged += new EventHandler(lbRules_SelectedIndexChanged);
            _lbRules.Click += new EventHandler(lbRules_Click);
        }

        void SelectRuleForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        public string RuleName
        {
            get 
            {
                return _ruleName;
            }
        }

        private void lbRules_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(_lbRules.SelectedItem != null)
            {
                _ruleName = (string)_lbRules.SelectedItem;
                DialogResult = DialogResult.OK;
            }

            Close();
        }

        private void lbRules_Click(object sender, EventArgs e)
        {
            if (_lbRules.SelectedItem != null)
            {
                _ruleName = (string)_lbRules.SelectedItem;
                DialogResult = DialogResult.OK;
            }

            Close();
        }
    }
}
