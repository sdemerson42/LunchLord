using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunchLord
{
    internal class AttributeDef
    {
        static AttributeDef()
        {
            guidTracker = new List<int>();
        }
        public AttributeDef()
        {
            int i = 0;
            while (guidTracker.Contains(i))
                ++i;

            guid = i;
            guidTracker.Add(i);
        }
        ~AttributeDef()
        {
            guidTracker.Remove(guid);
        }

        private static List<int> guidTracker;
        private int guid;
        private String name;

        public struct AttributeVal
        {
            public string value;
            public int weight;
        };
        private List<AttributeVal> val;

        // Properties and public methods

        public int ID
        {
            get { return guid; }
        }
        public string Name
        {
            set { name = value; }
            get { return name; }
        }
        public bool AddVal(string value, int weight = 0)
        {
            foreach (AttributeVal av in val)
            {
                if (av.value == value)
                {
                    // AttributeValue already exists
                    return false;
                }
            }
            AttributeVal nav = new AttributeVal();
            nav.value = value;
            nav.weight = weight;
            val.Add(nav);
            return true;
        }
        public void RemoveVal(string value)
        {
            AttributeVal lav = new AttributeVal();
            lav.value = value;
            foreach (AttributeVal av in val)
            {
                if (av.value == lav.value)
                {
                    val.Remove(av);
                    return;
                }
            }

            // Send Event

            AttribRemoveValEventArgs args = new AttribRemoveValEventArgs();
            args.ValName = value;
            AttribRemoveVal(this, args);

        }
        public List<AttributeVal> Values
        {
            get { return val; }
        } 

        public event AttribRemoveValDelegate AttribRemoveVal;


    }
}
