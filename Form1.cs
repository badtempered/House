using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace House
{
    public partial class Form1 : Form
    {       
        public Form1()
        {
            InitializeComponent();
            CreateObjects();
            MoveToANewLocation(livingRoom);
        }
        
        Location currentLocation;
        Room diningRoom;
        RoomWithDoor livingRoom;
        RoomWithDoor kitchen;
        Outside garden;
        OutsideWithDoor frontYard;
        OutsideWithDoor backYard;

        private void CreateObjects()
        {
            diningRoom = new Room("diningRoom", "chrystal chandelier");
            livingRoom = new RoomWithDoor("livingRoom", "antique carpet", "oak door");
            kitchen = new RoomWithDoor("kitchen", "stainless steal stove", "gate");
            garden = new Outside("garden", false);
            frontYard = new OutsideWithDoor("frontYard", false, "oak door");
            backYard = new OutsideWithDoor("backYard", true, "gate");

            diningRoom.Exits = new Location[] { livingRoom, kitchen };
            livingRoom.Exits = new Location[] { diningRoom };
            kitchen.Exits = new Location[] { diningRoom };
            garden.Exits = new Location[] { frontYard, backYard };
            frontYard.Exits = new Location[] { garden, backYard };
            backYard.Exits = new Location[] { garden, frontYard };

            livingRoom.DoorLocation = frontYard;
            frontYard.DoorLocation = livingRoom;
            kitchen.DoorLocation = backYard;
            backYard.DoorLocation = kitchen;
        }

        private void MoveToANewLocation(Location location)
        {
            currentLocation = location;
            exits.Items.Clear();
            for (int i = 0; i < currentLocation.Exits.Length; i++)
            {
                exits.Items.Add(currentLocation.Exits[i].name);
            }
            exits.SelectedIndex = 0;
            description.Text = currentLocation.Description;
            if (currentLocation is IHasExteriorDoor)
            {
                goThroughTheDoor.Visible = true;
            }
            else
            {
                goThroughTheDoor.Visible = false;
            }
        }

        private void goHere_Click(object sender, EventArgs e)
        {
            MoveToANewLocation(currentLocation.Exits[exits.SelectedIndex]);
        }

        private void goThroughTheDoor_Click(object sender, EventArgs e)
        {
            if (currentLocation is IHasExteriorDoor)
            {
                IHasExteriorDoor newLocation = currentLocation as IHasExteriorDoor;
                MoveToANewLocation(newLocation.DoorLocation);
            }
        }
    }
}
