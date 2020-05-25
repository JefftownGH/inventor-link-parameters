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

namespace LinkParameters.UI
{
    public partial class RuleOptionsForm : Form
    {
        private bool _bFireDep;
        private bool _bDontRunAuto;
        private bool _bUpdateWhenDone;
           
        public RuleOptionsForm()
        {
            InitializeComponent();

            this.Load += new EventHandler(RuleOptionsForm_Load);

            _bFireDep = false;
            _bDontRunAuto = false;
            _bUpdateWhenDone = true;
        }

        void RuleOptionsForm_Load(object sender, EventArgs e)
        {
            cbFireDep.Checked = _bFireDep;
            cbRunAuto.Checked = _bDontRunAuto;
            cbUpdateWhenDone.Checked = _bUpdateWhenDone;
        }

        public bool FireDep
        {
            get
            {
                return _bFireDep;
            }
            set
            {
                _bFireDep = value;
            }
        }

        public bool DontRunAuto
        {
            get
            {
                return _bDontRunAuto;
            }
            set
            {
                _bDontRunAuto = value;
            }
        }

        public bool UpdateWhenDone
        {
            get
            {
                return _bUpdateWhenDone;
            }
            set
            {
                _bUpdateWhenDone = value;
            }
        }

        private void bOk_Click(object sender, EventArgs e)
        {
            _bFireDep = cbFireDep.Checked;
            _bDontRunAuto = cbRunAuto.Checked;
            _bUpdateWhenDone = cbUpdateWhenDone.Checked;

            this.DialogResult = DialogResult.OK;

            Close();
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
