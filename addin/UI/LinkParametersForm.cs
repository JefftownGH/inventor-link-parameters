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
using System.Linq;
using System.Windows.Forms;
using Autodesk.iLogic.Interfaces;
using Inventor;
using LinkParameters.Commands;
using LinkParameters.Utilities;

namespace LinkParameters.UI
{
    partial class LinkParametersForm : Form
    {
        Document _document;

        string _ruleName = string.Empty;

        RuleOptionsForm _ruleOptionsForm = null;

        Dictionary<Parameter, ListViewItem> _sourceParameterDict;
        Dictionary<Parameter, ListViewItem> _targetParameterDict;

        List<ParameterMappingInfo> _mappings;
        List<ParameterMappingInfo> _newMappings;
        List<ParameterMappingInfo> _erasedMappings;

        ParamFilterEnum _currentParamFilter;

        public LinkParametersCommand Command { get; set; }

        public LinkParametersForm(string ruleName)
        {
            InitializeComponent();

            _deleteMappingMenuItem.Enabled = false;

            _deleteMappingMenuItem.Click += 
                new System.EventHandler(Handle_DeleteMappingMenuItem_Click);

            _deleteAllMappingsMenuItem.Click += 
                new System.EventHandler(Handle_DeleteAllMappingsMenuItem_Click);

            _autoMapParamsMenuItem.Click +=
                new System.EventHandler(Handle_AutoMapParamsMenuItem_Click);

            _targetParametersMenu.Opening += 
                new System.ComponentModel.CancelEventHandler(Handle_TargetParametersMenu_Opening);

            _ruleName = ruleName;
        }

        void LinkParametersForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if(Command.State != LinkParametersCommand.CommandState.Idle)
                    Command.StopSelection();
            }
        }

        private void RefreshSourceParameters()
        {
            _sourceParameterList.Items.Clear();
            _sourceParameterDict.Clear();

            ComponentDefinition definition = null;
           
            if (_cbRootAsmAsSrc.Checked)
            {
                AssemblyDocument asm = _document as AssemblyDocument;
                definition = asm.ComponentDefinition as ComponentDefinition;

                _labelSourceComponent.Text = "Driving Parameters (Top Assembly)";
            }
            else
            {
                if (Command.SourceComponent == null)
                    return;
                
                _labelSourceComponent.Text = string.Format("Driving Parameters ({0})",
                    Command.SourceComponent.Name);
                
                definition = Command.SourceComponent.Definition;
            }

            Parameters Parameters = AdnInventorUtilities.GetProperty(
               definition,
               "Parameters") as Parameters;

            foreach (Parameter parameter in Parameters)
            {
                ListViewItem newItem = new ListViewItem();

                string value = AdnInventorUtilities.GetStringFromValue(parameter);

                newItem.Text = parameter.Name;
                newItem.SubItems.Add(value);
                newItem.ToolTipText = parameter.Name + " = " + value;

                newItem.Tag = new ParameterInfo()
                {
                    ComponentName = (Command.SourceComponent != null ? Command.SourceComponent.Name : string.Empty),
                    ParameterName = parameter.Name,
                    ParamType = parameter.Value.GetType(),
                };

                _sourceParameterList.Items.Add(newItem);
                _sourceParameterDict.Add(parameter, newItem);
            }

            ApplyParametersFilter(_sourceParameterDict, _sourceParameterList, _currentParamFilter);
        }

        private void RefreshTargetParameters()
        {
            _targetParameterList.Items.Clear();
            _targetParameterDict.Clear();

            if (Command.TargetComponent == null)
                return;

            _newMappings = new List<ParameterMappingInfo>();
            _erasedMappings = new List<ParameterMappingInfo>();

            ComponentDefinition definition = Command.TargetComponent.Definition;

            Parameters Parameters = AdnInventorUtilities.GetProperty(
                definition,
                "Parameters") as Parameters;

            foreach (Parameter parameter in Parameters)
            {
                ListViewItem newItem = new ListViewItem();

                string value = AdnInventorUtilities.GetStringFromValue(parameter);

                newItem.Text = parameter.Name;
                newItem.SubItems.Add(value);
                newItem.SubItems.Add(string.Empty);
                newItem.ToolTipText = parameter.Name + " = " + value;

                ParameterMappingInfo mapping =
                    _mappings.FirstOrDefault(m => m.TargetComponentName == Command.TargetComponent.Name &&
                        m.TargetParameterName == parameter.Name);

                if (mapping != null)
                {
                    newItem.SubItems[2].Text = mapping.SourceName;
                    newItem.Tag = mapping;
                }

                _targetParameterList.Items.Add(newItem);
                _targetParameterDict.Add(parameter, newItem);
            }

            ApplyParametersFilter(_targetParameterDict, _targetParameterList, _currentParamFilter);
        }

        private void Handle_Form_Load(object sender, EventArgs e)
        {
            _document = AdnInventorUtilities.InvApplication.ActiveDocument;

            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(LinkParametersForm_KeyDown);

            this.Text = "Link Parameters  [Rule: " + _ruleName + "]";

            _ruleOptionsForm = new RuleOptionsForm();

            //Retrieve rule properties if rule exists
            IiLogicAutomation ruleApi = iLogicUtilities.GetiLogicAutomation();

            iLogicRule rule = ruleApi.GetRule(_document, _ruleName);

            if (rule != null)
            {
                _ruleOptionsForm.FireDep = rule.FireDependentImmediately;
                _ruleOptionsForm.DontRunAuto = !rule.AutomaticOnParamChange;
                //_ruleOptionsForm.UpdateWhenDone = 
            }

            _sourceParameterDict = new Dictionary<Parameter, ListViewItem>();
            _targetParameterDict = new Dictionary<Parameter, ListViewItem>();

            _currentParamFilter = ParamFilterEnum.kAll;

            Command.SourceComponent = null;
            Command.TargetComponent = null;

            _mappings = ParameterMappingInfo.GetMappings(_document, _ruleName);
        }

        private int GetMappingCount()
        {
            int count = _newMappings.Count + _erasedMappings.Count;

            return count;
        }

        private void ValidateButtons()
        {     
            bool enabled = (Command.TargetComponent != null);

            enabled = enabled && (GetMappingCount() != 0);

            _btnApply.Enabled = enabled;
        }

        private void Handle_SourceParameterList_ItemDrag(object sender, ItemDragEventArgs e)
        {
            ListViewItem item = e.Item as ListViewItem;

            if (item != null)
            {
                DoDragDrop(item.Tag, DragDropEffects.Link);
            }
        }

        private void Handle_TargetParameterList_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(ParameterInfo)) == false)
            {
                e.Effect = DragDropEffects.None;
                return;
            }
        }

        private void Handle_TargetParameterList_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(ParameterInfo)))
            {
                e.Effect = DragDropEffects.Link;
                return;
            }
        }

        private void Handle_TargetParameterList_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(ParameterInfo)) == false)
            {
                return;
            }

            ParameterInfo parameterInfo = e.Data.GetData(typeof(ParameterInfo)) as ParameterInfo;

            if (parameterInfo == null)
                return;

            System.Drawing.Point pt = _targetParameterList.PointToClient(
                new System.Drawing.Point(e.X, e.Y));

            ListViewItem targetItem = _targetParameterList.GetItemAt(pt.X, pt.Y);

            if (targetItem == null)
                return;

            //Check parameter types
            Parameters TargetParams = AdnInventorUtilities.GetProperty(
                Command.TargetComponent.Definition,
                "Parameters") as Parameters;

            if (TargetParams[targetItem.Text].Value.GetType() != parameterInfo.ParamType)
            {
                System.Windows.Forms.MessageBox.Show("Parameters must have same type in order to be mapped!",
                    "Invalid Parameter types", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Exclamation);

                return;
            }
            
            ParameterMappingInfo mapping = new ParameterMappingInfo()
            {
                SourceComponentName = parameterInfo.ComponentName,
                SourceParameterName = parameterInfo.ParameterName,
                TargetComponentName = Command.TargetComponent.Name,
                TargetParameterName = targetItem.Text,
            };

            _newMappings.Add(mapping);

            //Delete existing mapping if any
            DeleteMapping(targetItem.Tag as ParameterMappingInfo);

            targetItem.SubItems[2].Text = mapping.SourceName;
            targetItem.Tag = mapping;

            ValidateButtons();
        }

        private void Handle_BtnSelectSource_Click(object sender, EventArgs e)
        {
            Command.SourceComponentSelected += new EventHandler<EventArgs>(Handle_SourceComponentSelected);

            Command.SelectSourceComponent();
        }

        private void Handle_BtnSelectTarget_Click(object sender, EventArgs e)
        {
            Command.TargetComponentSelected += new EventHandler<EventArgs>(Handle_TargetComponentSelected);

            Command.SelectTargetComponent();
        }

        private void Handle_SourceComponentSelected(object sender, EventArgs e)
        {
            RefreshSourceParameters();

            ValidateButtons();

            Command.SourceComponentSelected -= new EventHandler<EventArgs>(Handle_SourceComponentSelected);

            Command.StopSelection();
        }

        private void Handle_TargetComponentSelected(object sender, EventArgs e)
        {
            if (Command.TargetComponent != null)
            {
                _labelTargetComponent.Text = 
                    string.Format("Driven Parameters ({0})", 
                        Command.TargetComponent.Name);
            }
            else
            {
                _labelTargetComponent.Text = "Driven Parameters";
            }

            RefreshTargetParameters();

            ValidateButtons();

            Command.TargetComponentSelected -= new EventHandler<EventArgs>(Handle_TargetComponentSelected);

            Command.StopSelection();
        }

        private void ApplyMappings()
        {
            ParameterMapping.UpdateMappings(
                _document, 
                Command.TargetComponent, 
                _erasedMappings,
                _newMappings,
                _ruleName,
                _ruleOptionsForm.FireDep,
                _ruleOptionsForm.DontRunAuto,
                _ruleOptionsForm.UpdateWhenDone);
        }

        private void Handle_BtnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;

            if (Command.TargetComponent != null)
            {
                ApplyMappings();
            }

            Close();
        }

        private void Handle_BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void Handle_BtnApply_Click(object sender, EventArgs e)
        {
            ApplyMappings();

            _mappings = ParameterMappingInfo.GetMappings(_document, _ruleName);

            RefreshTargetParameters();

            ValidateButtons();
        }

        private void Handle_TargetParametersMenu_Opening(
            object sender, 
            System.ComponentModel.CancelEventArgs e)
        {
            _deleteMappingMenuItem.Enabled = true;
            _autoMapParamsMenuItem.Enabled = true;

            if (_targetParameterList.SelectedIndices.Count != 1)
                _deleteMappingMenuItem.Enabled = false;
            else
            {
                ListViewItem selectedItem = _targetParameterList.SelectedItems[0];

                if (!(selectedItem.Tag is ParameterMappingInfo))
                    _deleteMappingMenuItem.Enabled = false;
            }

            if (_targetParameterList.Items.Count == 0 || _sourceParameterList.Items.Count == 0)
                _autoMapParamsMenuItem.Enabled = false;
        }

        private void DeleteMapping(ParameterMappingInfo mapping)
        {
            if (mapping == null)
                return;

            if (_newMappings.Contains(mapping))
                _newMappings.Remove(mapping);
            else
                _erasedMappings.Add(mapping);
        }

        private void Handle_DeleteMappingMenuItem_Click(object sender, EventArgs e)
        {
            if (_targetParameterList.SelectedItems.Count != 1)
                return;

            ListViewItem selectedItem = _targetParameterList.SelectedItems[0];

            DeleteMapping(selectedItem.Tag as ParameterMappingInfo); 

            selectedItem.Tag = null;
            selectedItem.SubItems[2].Text = string.Empty;

            ValidateButtons();
        }

        private void Handle_DeleteAllMappingsMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in _targetParameterList.Items)
            {
                DeleteMapping(item.Tag as ParameterMappingInfo); 

                item.Tag = null;
                item.SubItems[2].Text = string.Empty;
            }

            ValidateButtons();
        }

        private void AutoMapMatchingParams()
        {
            Parameters TargetParams = AdnInventorUtilities.GetProperty(
                    Command.TargetComponent.Definition,
                    "Parameters") as Parameters;

            foreach (ListViewItem sourceItem in _sourceParameterList.Items)
            {
                foreach (ListViewItem targetItem in _targetParameterList.Items)
                {
                    if (sourceItem.Text != targetItem.Text)
                        continue;

                    ParameterInfo parameterInfo = sourceItem.Tag as ParameterInfo;

                    if (TargetParams[targetItem.Text].Value.GetType() != parameterInfo.ParamType)
                        continue;

                    ParameterMappingInfo mapping = new ParameterMappingInfo()
                    {
                        SourceComponentName = parameterInfo.ComponentName,
                        SourceParameterName = parameterInfo.ParameterName,
                        TargetComponentName = Command.TargetComponent.Name,
                        TargetParameterName = targetItem.Text,
                    };

                    _newMappings.Add(mapping);

                    //Delete existing mapping if any
                    DeleteMapping(targetItem.Tag as ParameterMappingInfo);

                    targetItem.SubItems[2].Text = mapping.SourceName;
                    targetItem.Tag = mapping;
                }
            }

            ValidateButtons();
        }

        private void Handle_AutoMapParamsMenuItem_Click(object sender, EventArgs e)
        {
            AutoMapMatchingParams();
        }

        private void _bAutoMap_Click(object sender, EventArgs e)
        {
            if (_targetParameterList.Items.Count == 0 || _sourceParameterList.Items.Count == 0)
                return;

            AutoMapMatchingParams();
        }

        private System.Windows.Forms.ContextMenu _ctxMenuParamFilter = null;

        enum ParamFilterEnum
        { 
            kAll,
            kKey,
            kNonKey,
            kRenamed
        }

        private void bFilters_Click(object sender, EventArgs e)
        {
            if (_ctxMenuParamFilter == null)
            {
                _ctxMenuParamFilter = new ContextMenu();
                _ctxMenuParamFilter.MenuItems.Add("All").Click += new EventHandler(ParamFilterAll_Click);
                _ctxMenuParamFilter.MenuItems.Add("-");
                _ctxMenuParamFilter.MenuItems.Add("Key").Click += new EventHandler(ParamFilterKey_Click);
                _ctxMenuParamFilter.MenuItems.Add("Non-Key").Click += new EventHandler(ParamFilterNonKey_Click);
                _ctxMenuParamFilter.MenuItems.Add("Renamed").Click += new EventHandler(ParamFilterRenamed_Click);

                _ctxMenuParamFilter.MenuItems[0].Checked = true;
            }

            System.Drawing.Point menuPos = new System.Drawing.Point(
                _bFilters.Location.X, 
                _bFilters.Location.Y + _bFilters.Height);

            _ctxMenuParamFilter.Show(this, menuPos);
        }

        void ApplyParametersFilter(
            Dictionary<Parameter, ListViewItem> paramDict,
            ListView listView,
            ParamFilterEnum filter)
        {
            foreach (Parameter parameter in paramDict.Keys)
            {
                switch (filter)
                {
                    case ParamFilterEnum.kAll:
                        break;

                    case ParamFilterEnum.kKey:
                        if (!parameter.IsKey)
                        {
                            if (paramDict[parameter].ListView != null)
                                paramDict[parameter].Remove();
                            continue;
                        }
                        break;

                    case ParamFilterEnum.kNonKey:
                        if (parameter.IsKey)
                        {
                            if (paramDict[parameter].ListView != null)
                                paramDict[parameter].Remove();
                            continue;
                        }
                        break;

                    case ParamFilterEnum.kRenamed:
                        if(parameter.Type != ObjectTypeEnum.kModelParameterObject)
                        {
                            if (paramDict[parameter].ListView != null)
                                paramDict[parameter].Remove();
                            continue;
                        }

                        ModelParameter mparameter = parameter as ModelParameter;

                        if (!mparameter.Renamed)
                        {
                            if (paramDict[parameter].ListView != null)
                                paramDict[parameter].Remove();
                            continue;
                        }
                        break;

                    default:
                        break;
                }

                if (paramDict[parameter].ListView == null)
                {
                    ListViewItem item = paramDict[parameter];
                    listView.Items.Add(item);
                }
            }
        }

        void ParamFilterAll_Click(object sender, EventArgs e)
        {
            _currentParamFilter = ParamFilterEnum.kAll;

            _ctxMenuParamFilter.MenuItems[0].Checked = true;
            _ctxMenuParamFilter.MenuItems[2].Checked = false;
            _ctxMenuParamFilter.MenuItems[3].Checked = false;
            _ctxMenuParamFilter.MenuItems[4].Checked = false;

            ApplyParametersFilter(_sourceParameterDict, _sourceParameterList, _currentParamFilter);
            ApplyParametersFilter(_targetParameterDict, _targetParameterList, _currentParamFilter);

            _bFilters.BackgroundImage = Properties.Resources.Filter_Off;
        }

        void ParamFilterKey_Click(object sender, EventArgs e)
        {
            _currentParamFilter = ParamFilterEnum.kKey;

            _ctxMenuParamFilter.MenuItems[0].Checked = false;
            _ctxMenuParamFilter.MenuItems[2].Checked = true;
            _ctxMenuParamFilter.MenuItems[3].Checked = false;
            _ctxMenuParamFilter.MenuItems[4].Checked = false;

            ApplyParametersFilter(_sourceParameterDict, _sourceParameterList, _currentParamFilter);
            ApplyParametersFilter(_targetParameterDict, _targetParameterList, _currentParamFilter);

            _bFilters.BackgroundImage = Properties.Resources.Filter_On;
        }

        void ParamFilterNonKey_Click(object sender, EventArgs e)
        {
            _currentParamFilter = ParamFilterEnum.kNonKey;

            _ctxMenuParamFilter.MenuItems[0].Checked = false;
            _ctxMenuParamFilter.MenuItems[2].Checked = false;
            _ctxMenuParamFilter.MenuItems[3].Checked = true;
            _ctxMenuParamFilter.MenuItems[4].Checked = false;

            ApplyParametersFilter(_sourceParameterDict, _sourceParameterList, _currentParamFilter);
            ApplyParametersFilter(_targetParameterDict, _targetParameterList, _currentParamFilter);

            _bFilters.BackgroundImage = Properties.Resources.Filter_On;
        }

        void ParamFilterRenamed_Click(object sender, EventArgs e)
        {
            _currentParamFilter = ParamFilterEnum.kRenamed;

            _ctxMenuParamFilter.MenuItems[0].Checked = false;
            _ctxMenuParamFilter.MenuItems[2].Checked = false;
            _ctxMenuParamFilter.MenuItems[3].Checked = false;
            _ctxMenuParamFilter.MenuItems[4].Checked = true;

            ApplyParametersFilter(_sourceParameterDict, _sourceParameterList, _currentParamFilter);
            ApplyParametersFilter(_targetParameterDict, _targetParameterList, _currentParamFilter);

            _bFilters.BackgroundImage = Properties.Resources.Filter_On;
        }

        private void bOptions_Click(object sender, EventArgs e)
        {
            DialogResult res = 
                _ruleOptionsForm.ShowDialog(new WinUtilities(this.Handle));
        }

        private void cbRootAsmAsSrc_CheckedChanged(object sender, EventArgs e)
        {
            _btnSelectSource.Enabled = !_cbRootAsmAsSrc.Checked;

            _sourceParameterList.Items.Clear();
            _sourceParameterDict.Clear();

            if (Command.State == LinkParametersCommand.CommandState.SourceComponentSelection)
                Command.StopSelection();

            RefreshSourceParameters();
        }
    }

    class ParameterInfo
    {
        public string ComponentName 
        { get; set; }

        public string ParameterName 
        { get; set; }

        public Type ParamType 
        { get; set; }
    }
}
