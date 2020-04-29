using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace House
{
    class Room : Location
    {
        public Room(string name, string decoration) : base(name)
        {
            this.decoration = decoration;
        }
        string decoration;
        public override string Description
        {
            get
            {
                return base.Description + " Here you see " + decoration + ".";
            }
        }
    }
}
