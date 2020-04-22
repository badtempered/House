using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace House
{
    class OutsideWithDoor : Outside, IHasExteriorDoor
    {
        public OutsideWithDoor(string name, bool hot, string doorDescription, Location doorLocation) : base(name, hot)
        {
            DoorDescription = doorDescription;
            DoorLocation = doorLocation;
        }
        public string DoorDescription { get; }
        public Location DoorLocation { get; }
        public override string Description
        {
            get
            {
                return base.Description + "You see " + DoorDescription + ".";
            }
        }
    }
}
