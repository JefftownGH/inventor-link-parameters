////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// Copyright (c) Autodesk, Inc. All rights reserved 
// Written by Jan Liska & Philippe Leefsma 2011 - ADN/Developer Technical Services
//
// This software is provided as is, without any warranty that it will work. You choose to use this tool at your own risk.
// Neither Autodesk nor the authors can be taken as responsible for any damage this tool can cause to 
// your data. Please always make a back up of your data prior to use this tool.
//
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System.ComponentModel;
using System.Xml;

namespace LinkParameters
{
    public class XmlUtilities
    {
        public static T? GetAttributeValueAsNullable<T>(XmlNode node, string attributeName) where T : struct
        {
            XmlAttribute attr = node.Attributes.GetNamedItem(attributeName) as XmlAttribute;

            if (attr != null)
            {
                TypeConverter converter = TypeDescriptor.GetConverter(typeof(T));

                return (T)converter.ConvertFrom(attr.Value);
            }
            return null;
        }

        public static T GetAttributeValue<T>(XmlNode node, string attributeName) where T : class
        {
            XmlAttribute attr = node.Attributes.GetNamedItem(attributeName) as XmlAttribute;

            if (attr != null)
            {
                TypeConverter converter = TypeDescriptor.GetConverter(typeof(T));

                return (T)converter.ConvertFrom(attr.Value);
            }
            return null;
        }
    }
}
