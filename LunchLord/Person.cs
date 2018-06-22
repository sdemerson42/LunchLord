using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunchLord
{
    internal class Person
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private List<Attribute> attribute = new List<Attribute>();

        public void AddAttribute(Attribute a)
        {
            // Never add attributes with redundant definitions
            foreach (var att in attribute)
            {
                if (att.Definition == a.Definition) return;
            }
            attribute.Add(a);
            a.Value = "null";
        }

        public void SetAttributeValue(string attrib, string val)
        {
            foreach (var a in attribute)
            {
                if (a.Definition.Name == attrib)
                {
                    a.Value = val;
                    return;
                }
            }
        }
        public string GetAttributeValue(string attrib)
        {
            foreach (var a in attribute)
            {
                if (a.Definition.Name == attrib)
                {
                    return a.Value;
                }
            }
            return "null";
        }

    }
}
