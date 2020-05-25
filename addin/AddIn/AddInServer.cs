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
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using LinkParameters.Commands;
using LinkParameters.Utilities;

namespace LinkParameters.AddIn
{
    [Guid(Globals.AddInGUID)]
    [ComVisible(true)]
    public class AddInServer : Inventor.ApplicationAddInServer
    {

        // Create a logger for use in this class
        private static log4net.ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public AddInServer()
        {
            Assembly thisAssembly = Assembly.GetExecutingAssembly();
            FileInfo fi = new FileInfo(thisAssembly.Location + ".log4net");
            log4net.GlobalContext.Properties["LogFileName"] = fi.DirectoryName + "\\Log\\linkParameters";
            log4net.Config.XmlConfigurator.Configure(fi);
            log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        }
        #region Fields

        private static AddInServer _instance;

        private global::Inventor.Application _application;

        #endregion

        #region ApplicationAddInServer Members

        public object Automation
        {
            get { return null; }
        }

        public void Activate(global::Inventor.ApplicationAddInSite site, bool firstTime)
        {
            log.Info("Attempting to load linkParameters..");
            _instance = this;
            _application = site.Application;

            Type addinType = this.GetType();
            AdnInventorUtilities.Initialize(_application, addinType);

            AdnCommand.AddCommand(new LinkParametersCommand(_application));
            AdnCommand.AddCommand(new AboutCommand(_application));
            AdnCommand.AddCommand(new HelpControlCommand(_application));

            AdnRibbonBuilder.CreateRibbon(_application, addinType, "LinkParameters.Resources.AddInUI.xml");

            //Prevent user from unloading the add-in (except at Inventor shutdown).
            //This workarounds an issue concerning unloading/reloading an addin that
            //creates controls in a native Inventor Panel.
            site.Parent.UserUnloadable = false;
            
            AssemblyResolver.Paths.Add(AdnInventorUtilities.iLogicPath);
            AssemblyResolver.Start();
            log.Info("linkParameters loaded successfully.");
        }

        public void Deactivate()
        {
            _instance = null;
            Marshal.ReleaseComObject(_application);
            _application = null;
            AssemblyResolver.Stop();
        }

        public void ExecuteCommand(int commandId)
        {
        }

        #endregion

        #region COM Registration

        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
        [ComRegisterFunction]
        private static void Register(Type t)
        {
            try
            {
                AddInRegistration.RegisterAddIn(t);
            }
            catch
            {
            }
        }

        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
        [ComUnregisterFunction]
        private static void Unregister(Type t)
        {
            try
            {
                AddInRegistration.UnregisterAddIn(t);
            }
            catch
            {
            }
        }

        #endregion

        public static AddInServer Instance
        {
            get { return _instance; }
        }

        public global::Inventor.Application Application
        {
            get { return _application; }
        }
    }
}
