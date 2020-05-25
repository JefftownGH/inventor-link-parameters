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
using Microsoft.Win32;

namespace LinkParameters.AddIn
{
    class AddInRegistration
    {
        private class RegInfo
        {
            #region Fields

            private string _addinGuid;
            private string _description;
            private string _title;

            #endregion


            public RegInfo(Type t)
            {
                _addinGuid = t.GUID.ToString("B");
                object[] attrs = t.Assembly.GetCustomAttributes(false);

                _title = string.Empty;
                _description = string.Empty;

                foreach (object attr in attrs)
                {
                    AssemblyTitleAttribute titleAttr = attr as AssemblyTitleAttribute;

                    if (null != titleAttr)
                    {
                        _title = titleAttr.Title;
                    }
                    AssemblyDescriptionAttribute descriptionAttr = attr as AssemblyDescriptionAttribute;

                    if (null != descriptionAttr)
                    {
                        _description = descriptionAttr.Description;
                    }
                }
            }

            public string AddInGuid
            {
                get { return _addinGuid; }
            }

            public string Description
            {
                get { return _description; }
            }

            public string Title
            {
                get { return _title; }
            }
        }

        public static void RegisterAddIn(Type t)
        {
            RegInfo info = new RegInfo(t);

            using (RegistryKey keyClsid = Registry.ClassesRoot.CreateSubKey(@"CLSID\" + info.AddInGuid))
            {
                keyClsid.SetValue(null, info.Title);
                keyClsid.CreateSubKey(@"Implemented Categories\{39AD2B5C-7A29-11D6-8E0A-0010B541CAA8}");
                using (RegistryKey keySettings = keyClsid.CreateSubKey("Settings"))
                {
                    //SupportedSoftwareVersionLessThan
                    //SupportedSoftwareVersionGreaterThan
                    //SupportedSoftwareVersionEqualTo
                    //SupportedSoftwareVersionNotEqualTo

                    keySettings.SetValue("AddInType", "Standard");
                    keySettings.SetValue("LoadOnStartup", "1");

                    keySettings.SetValue("SupportedSoftwareVersionEqualTo", "15..");
                    //keySettings.SetValue("SupportedSoftwareVersionGreaterThan", "15..");

                    keySettings.SetValue("Version", "1");
                }
                using (RegistryKey keyDescription = keyClsid.CreateSubKey("Description"))
                {
                    keyDescription.SetValue(null, info.Description);
                }
            }
        }

        public static void UnregisterAddIn(Type t)
        {
            RegInfo info = new RegInfo(t);

            using (RegistryKey keyClsid = Registry.ClassesRoot.OpenSubKey(@"CLSID\" + info.AddInGuid, true))
            {
                keyClsid.DeleteSubKey(@"Implemented Categories\{39AD2B5C-7A29-11D6-8E0A-0010B541CAA8}");
                keyClsid.DeleteSubKey("Settings");
                keyClsid.DeleteSubKey("Description");
            }
        }

    }
}
