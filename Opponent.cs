using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace House
{
    class Opponent
    {
        public Opponent(Location myLocation)
        {
            this.myLocation = myLocation;
            random = new Random();
        }
        private Location myLocation;
        private Random random;

        public void Move()
        {
            bool hide = false;
            while (hide == false)
            {
                if (myLocation is IHasExteriorDoor)
                {
                    if (random.Next(2) == 1)
                    {
                        IHasExteriorDoor newLocation = myLocation as IHasExteriorDoor;
                        myLocation = newLocation.DoorLocation;
                    }
                }
                int rand = random.Next(myLocation.Exits.Length);
                myLocation = myLocation.Exits[rand];
                if (myLocation is IHidingPlace)
                {
                    hide = true;
                }
            }
        }

        public bool Check(Location location)
        {
            if (location == myLocation)
            {
                return true;
            }
            return false;
        }
    }
}
