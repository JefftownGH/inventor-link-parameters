////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// Copyright (c) Autodesk, Inc. All rights reserved 
// Written by Jan Liska & Philippe Leefsma 2011 - ADN/Developer Technical Services
//
// This software is provided as is, without any warranty that it will work. You choose to use this tool at your own risk.
// Neither Autodesk nor the authors can be taken as responsible for any damage this tool can cause to 
// your data. Please always make a back up of your data prior to use this tool.
//
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System.Globalization;

namespace LinkParameters
{
    static class Globals
    {
        //2011
        //Installer ProductCode: {63FFDA30-E479-4731-907C-44F9E265C075}
        //Installer UpgradeCode: {08BAEA70-1B23-4339-8EDA-B52C198E88AD}
        //public const string AddInGUID = "D0E0B767-E553-4C75-AAA1-A2822686A4D9";
        
        //2012
        //Installer ProductCode: {B75AE9C1-2771-46F1-B4C9-B36345934DEA}
        //Installer UpgradeCode: {9C5D0A7E-D053-4827-B647-A0082A953F56}
        public const string AddInGUID = "6BCB4DC2-A2CE-4135-9818-B28A0863EB5B";

        public static string AddInGUIDRegString
        {
            get 
            { 
                return string.Format(CultureInfo.InvariantCulture, "{{{0}}}", AddInGUID); 
            }
        }
    }
}
