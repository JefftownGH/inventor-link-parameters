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
using System.Reflection;
using Inventor;
using LinkParameters.AddIn;
using LinkParameters.UI;
using LinkParameters.Utilities;

namespace LinkParameters.Commands
{
    //[Command("coolOrange.LinkParametersCmd")]
    class LinkParametersCommand : AdnButtonCommandBase
    {
        // Create a logger for use in this class
        private static log4net.ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public enum CommandState
        {
            Idle,
            SourceComponentSelection,
            TargetComponentSelection,
        };

        #region Fields

        private static LinkParametersForm _frm;

        private global::Inventor.ComponentOccurrence _sourceComponent;
        private global::Inventor.ComponentOccurrence _targetComponent;
        private CommandState _state;
        private AdnInteractionManager _InteractionManager;

        #endregion


        #region Events

        public LinkParametersCommand(Application application) : base(application)
        {
        }

        internal event EventHandler<EventArgs> SourceComponentSelected;
        internal event EventHandler<EventArgs> TargetComponentSelected;

        #endregion

        #region ButtonCommand Members

        public override string DisplayName
        {
            get { return "linkParameters"; }
        }

        public override string InternalName
        {
            get { return "coolOrange.linkParametersAddin.LinkParametersCmd"; }
        }

        public override CommandTypesEnum Classification
        {
            get { return CommandTypesEnum.kEditMaskCmdType; }
        }

        public override string Description
        {
            get { return "Links parameters between parts"; }
        }

        public override string ToolTipText
        {
            get { return "Link Parameters"; }
        }

        public override ButtonDisplayEnum ButtonDisplay
        {
            get { return ButtonDisplayEnum.kDisplayTextInLearningMode; }
        }

        public override string StandardIconName
        {
            get { return "LinkParameters.Resources.linkParameters.ico"; }
        }

        public override string LargeIconName
        {
            get { return "LinkParameters.Resources.linkParameters.ico"; }
        }

        protected override void OnExecute(global::Inventor.NameValueMap context)
        {
            log.Debug("Start command execution");
            StartCommand();
            Terminate();
        }

        protected override void OnHelp(global::Inventor.NameValueMap context)
        {
        }

        #endregion


        public CommandState State
        {
            get 
            { 
                return _state; 
            }
        }

        internal global::Inventor.ComponentOccurrence SourceComponent
        {
            get 
            { 
                return _sourceComponent; 
            }
            set
            {
                _sourceComponent = value;
            }
        }

        internal global::Inventor.ComponentOccurrence TargetComponent
        {
            get 
            { 
                return _targetComponent; 
            }
            set
            {
                _targetComponent = value;
            }
        }

        internal void SelectSourceComponent()
        {
            _state = CommandState.SourceComponentSelection;

            _InteractionManager.Stop();

            _InteractionManager.Reset();

            _InteractionManager.SelectEvents.SingleSelectEnabled = true;

            _InteractionManager.SelectEvents.AddSelectionFilter(
                Inventor.SelectionFilterEnum.kAssemblyLeafOccurrenceFilter);

           _InteractionManager.Start("Select source component");
        }

        internal void SelectTargetComponent()
        {
            _state = CommandState.TargetComponentSelection;

            _InteractionManager.Stop();

            _InteractionManager.Reset();

            _InteractionManager.SelectEvents.SingleSelectEnabled = true;

            _InteractionManager.SelectEvents.AddSelectionFilter(
                Inventor.SelectionFilterEnum.kAssemblyLeafOccurrenceFilter);

            _InteractionManager.Start("Select target component");
        }

        private void StartCommand()
        {
            if (_frm != null)
            {
                if (!_frm.Visible)
                {
                    _frm.Dispose();
                }

                _frm.Focus();
                return;
            }

            RuleNameForm ruleNameForm = new RuleNameForm();

            System.Windows.Forms.DialogResult res = 
                ruleNameForm.ShowModal();

            if (res != System.Windows.Forms.DialogResult.OK)
                return;

            ruleNameForm.Dispose();

            _frm = new LinkParametersForm(ruleNameForm.RuleName);
            _frm.Command = this;
            _frm.FormClosed += new System.Windows.Forms.FormClosedEventHandler(Handle_Form_FormClosed);

            _frm.Show(new WinUtilities((IntPtr)AdnInventorUtilities.InvApplication.MainFrameHWND));
            
            if (_frm.TopMost == false)
            {
                _frm.BringToFront();
                _frm.Activate();
            }

            _InteractionManager = new AdnInteractionManager(AdnInventorUtilities.InvApplication);

            _InteractionManager.Initialize();

            _InteractionManager.SelectEvents.OnSelect += 
                new Inventor.SelectEventsSink_OnSelectEventHandler(SelectEvents_OnSelect);
        }

        public void StopSelection()
        {
            _InteractionManager.Stop();

            //System.Windows.Forms.Application.DoEvents();
        }
    
        private void TerminateCommand()
        {
            _InteractionManager.Terminate();

            if (_frm != null)
            {
                _frm.Dispose();
                _frm = null;
            }
        }

        private void Handle_Form_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            TerminateCommand();
        }

        void SelectEvents_OnSelect(
            Inventor.ObjectsEnumerator JustSelectedEntities, 
            Inventor.SelectionDeviceEnum SelectionDevice, 
            Inventor.Point ModelPosition, 
            Inventor.Point2d ViewPosition, 
            Inventor.View View)
        {
            if (_state == CommandState.Idle)
                return;

            if (JustSelectedEntities.Count != 1)
                return;

            if (!(JustSelectedEntities[1] is ComponentOccurrence))
                return;

            ComponentOccurrence selectedOccurrence = JustSelectedEntities[1] as ComponentOccurrence;

            switch (_state)
            { 
                case CommandState.SourceComponentSelection:

                    if (_targetComponent != null)
                    {
                        if (selectedOccurrence.Definition == _targetComponent.Definition)
                        {
                            System.Windows.Forms.MessageBox.Show("Source and Target components cannot be the same, or refer to the same document...",
                                "Error selecting component",
                                System.Windows.Forms.MessageBoxButtons.OK,
                                System.Windows.Forms.MessageBoxIcon.Exclamation);

                            break;
                        }
                    }

                    _state = CommandState.Idle;

                    _sourceComponent = selectedOccurrence;

                    SourceComponentSelected(this, new EventArgs());

                    break;

                case CommandState.TargetComponentSelection:

                    if (_sourceComponent != null)
                    {
                        if (selectedOccurrence.Definition == _sourceComponent.Definition)
                        {
                            System.Windows.Forms.MessageBox.Show("Source and Target components cannot be the same, or refer to the same document...",
                                "Error selecting component",
                                System.Windows.Forms.MessageBoxButtons.OK,
                                System.Windows.Forms.MessageBoxIcon.Exclamation);

                            break;
                        }
                    }

                    _state = CommandState.Idle;

                    _targetComponent = selectedOccurrence;

                    TargetComponentSelected(this, new EventArgs());

                    break;

                default:
                    _state = CommandState.Idle;
                    break;
            }  
        }

        public override string ClientId
        {
            get
            {
                Type t = typeof(AddInServer);
                return t.GUID.ToString("B");
            }
        }
    }
}
