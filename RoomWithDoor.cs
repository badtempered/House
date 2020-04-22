using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace House
{
    class RoomWithDoor : Room, IHasExteriorDoor
    {
        public RoomWithDoor(string name, string decoration, string doorDescription, Location doorLocation) : base (name, decoration) 
        {
            DoorDescription = doorDescription;
            DoorLocation = doorLocation;
        }
        public string DoorDescription { get; }
        public Location DoorLocation { get; }
    }
}
