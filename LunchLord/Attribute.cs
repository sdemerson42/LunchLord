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
        }
        private AttributeDef definition;
        private string value;
    }
}
