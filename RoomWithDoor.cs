using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace House
{
    class RoomWithDoor : RoomWithHidingPlace, IHasExteriorDoor
    {
        public RoomWithDoor(string name, string decoration, string hidingPlace, string doorDescription) : base(name, decoration, hidingPlace)
        {
            this.DoorDescription = doorDescription;
        }
        public string DoorDescription {get; }
        public Location DoorLocation { get; set; }
        public override string Description
        {
            get
            {
                return base.Description + "\nThere is " + DoorDescription + ".";
            }
        }
    }
}
