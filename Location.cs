using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace House
{
    abstract class Location
    {
        public Location (string name)
        {
            this.name = name;
        }
        public Location[] Exits;
        public string name { get; }
        public virtual string Description
        {
            get
            {
                string description = "You are in " + name + ". You see the doors leading to: ";
                for (int i = 0; i < Exits.Length; i++)
                {
                    description += " " + Exits[i].name;
                    if (i != Exits.Length - 1)
                    {
                        description += ",";
                    }
                }
                description += ".";
                return description;
            }
        }
    }
}
