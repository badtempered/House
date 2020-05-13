using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace House
{
    class OutsideWithHidingPlace : Outside, IHidingPlace
    {
        public OutsideWithHidingPlace (string name, bool hot, string hidingPlace) : base(name, hot)
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
