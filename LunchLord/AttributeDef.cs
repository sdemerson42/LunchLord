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
        public AttributeDef(string _name)
        {
            int i = 0;
            while (guidTracker.Contains(i))
                ++i;

            guid = i;
            guidTracker.Add(i);

            name = _name;
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
        private List<AttributeVal> val = new List<AttributeVal>();

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
            foreach (AttributeVal av in val)
            {
                if (av.value == value)
                {
                    val.Remove(av);
                    // Send Event

                    AttribRemoveValEventArgs args = new AttribRemoveValEventArgs();
                    args.ValName = value;
                    AttribRemoveVal(this, args);

                    return;
                }
            }
        }
        public List<AttributeVal> Values
        {
            get { return val; }
        }
        public bool HasValueName(string name)
        {
            foreach (var v in val)
            {
                if (v.value == name)
                    return true;
            }
            return false;
        }

        public event AttribRemoveValDelegate AttribRemoveVal;


    }
}
