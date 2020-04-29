using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace House
{
    class RoomWithDoor : Room, IHasExteriorDoor
    {
        public RoomWithDoor(string name, string decoration, string doorDescription) : base(name, decoration)
        {
            this.DoorDescription = doorDescription;
        }
        public string DoorDescription {get; }
        public Location DoorLocation { get; set; }
        public override string Description
        {
            get
            {
                return base.Description + " There is " + DoorDescription + ".";
            }
        }
    }
}
