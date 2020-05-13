using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace House
{
    class RoomWithHidingPlace : Room, IHidingPlace
    {
        public RoomWithHidingPlace(string name, string decoration, string hidingPlace) : base(name, decoration)
        {
            this.HidingPlace = hidingPlace;
        }        
        public string HidingPlace { get; }
        public override string Description
        {
            get
            {
                return base.Description + "\nHere you see hiding place - " + HidingPlace + ".";
            }
        }
    }
}
