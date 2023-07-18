using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;

namespace Fcl.Utility
{
    public class XmlConverter : IXmlConverter
    {
        public IEnumerable<T> ToObjects<T>(string nodeName, string xml) where T : class, new()
        {
            var results = XDocument.Parse(xml).Elements(nodeName).GetEnumerator();
            while (results.MoveNext())
            {
                var element = results.Current;
                T tEntity = new T();
                foreach (PropertyInfo property in typeof(T).GetProperties())
                {
                    var elementCount = element.Elements(property.Name).Count();
                    if (elementCount > 1)
                    {
                        break;
                    }
                    string tValue = string.Empty;
                    if (element.Element(property.Name) != null)
                    {
                        tValue = element.Element(property.Name).Value;
                    }
                    if (property.PropertyType.Name == "String")
                    {
                        property.SetValue(tEntity, tValue);
                    }
                }
                yield return tEntity;
            }
        }

        public string ToXml<T>(string nodeName, IEnumerable<T> objs) where T : class
        {
            XDocument newXDoc = new XDocument();
            newXDoc.Add(objs.Select(item => new XElement(
                                item.GetType().Name,
                                item.GetType().GetProperties().Select(p => new XElement(p.Name, p.GetValue(item)))
                            )));
            return newXDoc.ToString();
        }
    }
}
