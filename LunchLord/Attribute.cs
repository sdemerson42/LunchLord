using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunchLord
{
    class Attribute
    {
        public Attribute(AttributeDef _definition)
        {
            definition = _definition;
            definition.AttribRemoveVal += onAttribRemoveVal;
        }
        private AttributeDef definition;
        public AttributeDef Definition
        {
            get { return definition; }
        }

        private string value;
        public string Value
        {
            get { return value; }
            set
            {
                if (definition.HasValueName(value) || value == "null")
                    this.value = value;
                else
                    Console.WriteLine("Warning: Attribute not set to invalid value.");
            }
        }

        void onAttribRemoveVal(object sender, AttribRemoveValEventArgs args)
        {
            if (value == args.ValName)
                value = "null";
        }

    }
}
