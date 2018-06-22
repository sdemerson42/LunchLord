using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunchLord
{
    public class AttribRemoveValEventArgs : EventArgs
    {
        private string valName;
        public string ValName
        {
            get { return valName; }
            set { valName = value; }
        }
    };
}
