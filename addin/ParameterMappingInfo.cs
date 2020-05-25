////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// Copyright (c) Autodesk, Inc. All rights reserved 
// Written by Jan Liska & Philippe Leefsma 2011 - ADN/Developer Technical Services
//
// This software is provided as is, without any warranty that it will work. You choose to use this tool at your own risk.
// Neither Autodesk nor the authors can be taken as responsible for any damage this tool can cause to 
// your data. Please always make a back up of your data prior to use this tool.
//
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System.Collections.Generic;
using Autodesk.iLogic.Interfaces;
using Inventor;
using LinkParameters.Utilities;

namespace LinkParameters
{
    class ParameterMappingInfo
    {
        public ParameterMappingInfo()
        {

        }

        public string SourceComponentName { get; set; }
        public string SourceParameterName { get; set; }
        public string TargetComponentName { get; set; }
        public string TargetParameterName { get; set; }

        public string SourceName
        {
            get
            {
                string format = (SourceComponentName != string.Empty ? "{0}.{1}" : "{1}");
                return string.Format(format, SourceComponentName, SourceParameterName);
            }
        }

        public string TargetName
        {
            get
            {
                string format = (TargetComponentName != string.Empty ? "{0}.{1}" : "{1}");
                return string.Format(format, TargetComponentName, TargetParameterName);
            }
        }

        public static List<ParameterMappingInfo> GetMappings(Document document, string ruleName)
        {
            IiLogicAutomation ruleApi = iLogicUtilities.GetiLogicAutomation();

            System.Collections.IEnumerable rules =
               iLogicUtilities.GetiLogicAutomation().get_Rules(document);

            iLogicRule rule = ruleApi.GetRule(document, ruleName);

            if (rule != null)
            {
                return ParameterMappingInfo.GetMappingsFromRule(rule);
            }

            return new List<ParameterMappingInfo>();
        }

        public static List<ParameterMappingInfo> GetMappingsFromRule(iLogicRule rule)
        {
            List<ParameterMappingInfo> result = new List<ParameterMappingInfo>();

            string[] lines = rule.Text.Split('\n');

            bool bIsLinkParametersSection = false;

            foreach (string line in lines)
            {
                //Not in a section, look for section start
                if(!bIsLinkParametersSection)
                {
                    if(line.Contains("<LinkParameters:Section:Start>"))
                    {
                        bIsLinkParametersSection = true;
                    }

                    continue;
                }

                //we are in a section, look for section end
                if(line.Contains("<LinkParameters:Section:End>"))
                {
                    bIsLinkParametersSection = false;
                    continue;
                }

                //Now process section...

                int pos = line.IndexOf('=');

                if (pos < 0)
                {
                    continue;
                }

                string leftSide = line.Substring(0, pos).Trim();
                string rightSide = line.Substring(pos + 1).Trim();

                string targetComponent, targetParameter, 
                    sourceComponent, sourceParameter;

                ParseParameterExpression(leftSide, out targetComponent, out targetParameter);
                ParseParameterExpression(rightSide, out sourceComponent, out sourceParameter);

                ParameterMappingInfo mapping = new ParameterMappingInfo()
                {
                    SourceComponentName = sourceComponent,
                    SourceParameterName = sourceParameter,
                    TargetComponentName = targetComponent,
                    TargetParameterName = targetParameter,
                };

                result.Add(mapping);
            }
            return result;
        }

        private static void ParseParameterExpression(
            string expr, 
            out string componentName, 
            out string parameterName)
        {
            componentName = string.Empty;
            parameterName = string.Empty;

            if (expr.StartsWith("Parameter(") == false)
            {
                return;
            }

            string args = expr.Substring(10);

            if (args.EndsWith(")"))
            {
                args = args.Substring(0, args.Length - 1);
            }

            string[] tokens = args.Split(',');

            //Means top-level assembly as source
            if (tokens.Length == 1)
            {
                parameterName = ParseName(tokens[0].Trim());
                return;
            }
            else if (tokens.Length == 2)
            {
                componentName = ParseName(tokens[0].Trim());
                parameterName = ParseName(tokens[1].Trim());
            }
        }

        private static string ParseName(string input)
        {
            string result = input;

            if (result.StartsWith("\""))
            {
                result = result.Substring(1);
            }
            if (result.EndsWith("\""))
            {
                result = result.Substring(0, result.Length - 1);
            }
            return result;
        }
    }
}
