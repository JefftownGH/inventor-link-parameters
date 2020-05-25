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
using System.Runtime.InteropServices;
using Inventor;
using LinkParameters.Utilities;

namespace LinkParameters
{
    /////////////////////////////////////////////////////////////////
    // A wrapper class to handle Interaction Events
    //
    /////////////////////////////////////////////////////////////////
    class InteractionManager
    {
        /////////////////////////////////////////////////////////////
        // Members
        //
        /////////////////////////////////////////////////////////////
        private Inventor.Application _Application;

        private InteractionEvents _InteractionEvents;
        private SelectEvents _SelectEvents;

        private bool _AllowCleanup;

        private List<System.Object> _SelectedEntities;

        private List<ObjectTypeEnum> _PreSelectFilters;

        /////////////////////////////////////////////////////////////
        // Constructor
        //
        /////////////////////////////////////////////////////////////
        public InteractionManager(Inventor.Application Application)
        {
            _Application = Application;

            _InteractionEvents = null;

            _SelectedEntities = new List<System.Object>();

            _PreSelectFilters = new List<ObjectTypeEnum>();
        }

        /////////////////////////////////////////////////////////////
        // Use: Returns list of currently selected entities
        //
        /////////////////////////////////////////////////////////////
        public List<System.Object> SelectedEntities
        {
            get
            {
                return _SelectedEntities;
            }
        }

        /////////////////////////////////////////////////////////////
        // Use: 
        //
        /////////////////////////////////////////////////////////////
        public InteractionEvents InteractionEvents
        {
            get
            {
                return _InteractionEvents;
            }
        }

        /////////////////////////////////////////////////////////////
        // Use: 
        //
        /////////////////////////////////////////////////////////////
        public SelectEvents SelectEvents
        {
            get
            {
                return _SelectEvents;
            }
        }

        /////////////////////////////////////////////////////////////
        // use: Initializes event handlers
        //
        /////////////////////////////////////////////////////////////
        public void Initialize()
        {
            _InteractionEvents = 
               _Application.CommandManager.CreateInteractionEvents();

            _SelectEvents = _InteractionEvents.SelectEvents;

            _SelectEvents.Enabled = true;
            _SelectEvents.SingleSelectEnabled = false;

            _SelectEvents.OnPreSelect += 
                new SelectEventsSink_OnPreSelectEventHandler(
                    SelectEvents_OnPreSelect);

            _InteractionEvents.OnTerminate +=
                new InteractionEventsSink_OnTerminateEventHandler(
                    InteractionEvents_OnTerminate);
        }

        /////////////////////////////////////////////////////////////
        // Use: Add selection filter.
        //
        /////////////////////////////////////////////////////////////
        public void AddSelectionFilter(SelectionFilterEnum filter)
        {
            if (_SelectEvents != null)
            {
                _SelectEvents.AddSelectionFilter(filter);
            }
        }

        /////////////////////////////////////////////////////////////
        // Use: Add pre-selection filter.
        //
        /////////////////////////////////////////////////////////////
        public void AddPreSelectionFilter(
            ObjectTypeEnum filter)
        {
            _PreSelectFilters.Add(filter);
        }

        /////////////////////////////////////////////////////////////
        // Use: Starts selection.
        //
        /////////////////////////////////////////////////////////////
        public void DoSelect(string statusbartxt)
        {
            _AllowCleanup = false;

            //_InteractionEvents.Stop();

            System.Windows.Forms.Application.DoEvents();

            _SelectedEntities.Clear();

            _InteractionEvents.Start();

            _InteractionEvents.StatusBarText = statusbartxt;

            //_AllowCleanup = true;
        }

        /////////////////////////////////////////////////////////////
        // Use: Stops selection.
        //
        /////////////////////////////////////////////////////////////
        public void StopSelect()
        {
            _AllowCleanup = false;

            _InteractionEvents.Stop();

            //System.Windows.Forms.Application.DoEvents();
        }

        /////////////////////////////////////////////////////////////
        // Use: 
        //
        /////////////////////////////////////////////////////////////
        public void Reset()
        {
            _SelectEvents.ResetSelections();
            _SelectEvents.ClearSelectionFilter();
        }

        /////////////////////////////////////////////////////////////
        // Use: OnPreSelect Handler.
        //
        /////////////////////////////////////////////////////////////
        private void SelectEvents_OnPreSelect(
            ref object PreSelectEntity, 
            out bool DoHighlight, 
            ref ObjectCollection MorePreSelectEntities, 
            SelectionDeviceEnum SelectionDevice, 
            Point ModelPosition, 
            Point2d ViewPosition, 
            View View)
        {
            if (_PreSelectFilters.Count != 0 && 
                !_PreSelectFilters.Contains(
                    AdnInventorUtilities.GetInventorType(PreSelectEntity)))
            {
                DoHighlight = false;
                return;
            }

            DoHighlight = true;
        }

        /////////////////////////////////////////////////////////////
        // Use: Performs interaction cleanup.
        //
        /////////////////////////////////////////////////////////////
        private void CleanUp()
        {
            if (_InteractionEvents != null)
            {
                _SelectedEntities.Clear();

                _PreSelectFilters.Clear();

                _SelectEvents.OnPreSelect -=
                   new SelectEventsSink_OnPreSelectEventHandler(
                       SelectEvents_OnPreSelect);

                _InteractionEvents.OnTerminate -=
                    new InteractionEventsSink_OnTerminateEventHandler(
                        InteractionEvents_OnTerminate);

                Marshal.ReleaseComObject(_SelectEvents);
                _SelectEvents = null;

                Marshal.ReleaseComObject(_InteractionEvents);
                _InteractionEvents = null;
            }
        }

        /////////////////////////////////////////////////////////////
        // Use: Terminates Interaction event.
        //
        /////////////////////////////////////////////////////////////
        public void Terminate()
        {
            if (_InteractionEvents != null)
            {
                _AllowCleanup = true;

                _InteractionEvents.Stop();
            }
        }

        /////////////////////////////////////////////////////////////
        // Use: OnTerminate handler.
        //
        /////////////////////////////////////////////////////////////
        private void InteractionEvents_OnTerminate()
        {
            if (_AllowCleanup)
            {
                CleanUp();
            }

            OnTerminate(new OnTerminateEventArgs());
        }

        /////////////////////////////////////////////////////////////
        // Use: Exposes OnTerminate Event for InteractionManager.
        //
        /////////////////////////////////////////////////////////////
        public class OnTerminateEventArgs : EventArgs
        {
            public OnTerminateEventArgs()
            {

            }
        }

        private void OnTerminate(OnTerminateEventArgs e)
        {
            if (OnTerminateEvent != null)
                OnTerminateEvent(this, e);
        }

        public delegate void OnTerminateHandler(object o, 
            OnTerminateEventArgs e);

        public event OnTerminateHandler OnTerminateEvent = null;
    }
}
