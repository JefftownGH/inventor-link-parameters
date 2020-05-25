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
using System.IO;
using System.Reflection;

namespace LinkParameters
{
    class AssemblyResolver
    {
        static AssemblyResolver()
        {
            Paths = new List<string>();
        }

        public static List<string> Paths 
        { 
            get; 
            private set; 
        }

        public static void Start()
        {
            AppDomain.CurrentDomain.AssemblyResolve += 
                new ResolveEventHandler(Handle_CurrentDomain_AssemblyResolve);
        }

        public static void Stop()
        {
            AppDomain.CurrentDomain.AssemblyResolve -= 
                new ResolveEventHandler(Handle_CurrentDomain_AssemblyResolve);
        }

        private static Assembly Handle_CurrentDomain_AssemblyResolve(
            object sender, 
            ResolveEventArgs e)
        {
            AssemblyName name = new AssemblyName(e.Name);

            foreach (string path in Paths)
            {
                string fileName = string.Format(@"{0}\{1}.dll", path, name.Name);

                if (File.Exists(fileName))
                {
                    return Assembly.LoadFrom(fileName);
                }
            }

            return null;
        }

    }
}
