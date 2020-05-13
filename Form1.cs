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
            opponent = new Opponent(frontYard);
            ResetGame(false);
        }

        Opponent opponent;
        
        Location currentLocation;

        RoomWithHidingPlace diningRoom;
        RoomWithDoor livingRoom;
        RoomWithDoor kitchen;
        Room stairs;
        RoomWithHidingPlace corridor;
        RoomWithHidingPlace masterBedRoom;
        RoomWithHidingPlace secondBedRoom;
        RoomWithHidingPlace bathRoom;
        OutsideWithHidingPlace garden;
        OutsideWithDoor frontYard;
        OutsideWithDoor backYard;
        OutsideWithHidingPlace driveway;

        private int Move;

        private void CreateObjects()
        {
            diningRoom = new RoomWithHidingPlace("diningRoom", "chrystal chandelier", "tall cupboard");
            livingRoom = new RoomWithDoor("livingRoom", "antique carpet", "wardrobe", "oak door");
            kitchen = new RoomWithDoor("kitchen", "stainless steal stove", "chest", "gate");
            stairs = new Room("stairs", "wooden railing");
            corridor = new RoomWithHidingPlace("corridor", "painting with a dog", "cupboard");
            masterBedRoom = new RoomWithHidingPlace("master bedroom", "large bed", "bed");
            secondBedRoom = new RoomWithHidingPlace("second bedroom", "small bed", "bed");
            bathRoom = new RoomWithHidingPlace("bathroom", "sink and toilet", "shawer");
            garden = new OutsideWithHidingPlace("garden", false, "barn");
            frontYard = new OutsideWithDoor("frontYard", false, "oak door");
            backYard = new OutsideWithDoor("backYard", true, "gate");
            driveway = new OutsideWithHidingPlace("driveway", true, "garage");

            diningRoom.Exits = new Location[] { livingRoom, kitchen };
            livingRoom.Exits = new Location[] { diningRoom, stairs };
            kitchen.Exits = new Location[] { diningRoom };
            stairs.Exits = new Location[] { livingRoom, corridor };
            corridor.Exits = new Location[] { stairs, masterBedRoom, secondBedRoom, bathRoom };
            masterBedRoom.Exits = new Location[] { corridor };
            secondBedRoom.Exits = new Location[] { corridor };
            bathRoom.Exits = new Location[] { corridor };
            garden.Exits = new Location[] { frontYard, backYard };
            frontYard.Exits = new Location[] { garden, backYard, driveway };
            backYard.Exits = new Location[] { garden, frontYard, driveway };
            driveway.Exits = new Location[] { frontYard, backYard };

            livingRoom.DoorLocation = frontYard;
            frontYard.DoorLocation = livingRoom;
            kitchen.DoorLocation = backYard;
            backYard.DoorLocation = kitchen;
        }

        private void MoveToANewLocation(Location location)
        {
            Move++;
            currentLocation = location;
            RedrowFrom();
        }

        private void goHere_Click(object sender, EventArgs e)
        {
            MoveToANewLocation(currentLocation.Exits[exits.SelectedIndex]);
        }

        private void goThroughTheDoor_Click(object sender, EventArgs e)
        {
                IHasExteriorDoor newLocation = currentLocation as IHasExteriorDoor;
                MoveToANewLocation(newLocation.DoorLocation);
        }

        private void RedrowFrom()
        {            
            hide.Visible = false;
            goHere.Visible = true;
            exits.Visible = true;
            exits.Items.Clear();
            for (int i = 0; i < currentLocation.Exits.Length; i++)
            {
                exits.Items.Add(currentLocation.Exits[i].name);
            }
            exits.SelectedIndex = 0;
            if (currentLocation is IHasExteriorDoor)
            {
                goThroughTheDoor.Visible = true;
            }
            else
            {
                goThroughTheDoor.Visible = false;
            }
            if (currentLocation is IHidingPlace)
            {
                check.Visible = true;
                IHidingPlace hidingPlace = currentLocation as IHidingPlace;
                check.Text = "Check " + hidingPlace.HidingPlace;
            }
            else
            {
                check.Visible = false;
            }            
            description.Text = currentLocation.Description + "\r\nMoves: " + Move;
        }

        private void ResetGame(bool message)
        {
            if (message)
            {
                IHidingPlace hidingPlace = currentLocation as IHidingPlace;
                description.Text = "You found opponent in " + hidingPlace.HidingPlace + " in " + Move + " moves";
            }
            Move = 0;            
            goHere.Visible = false;
            exits.Visible = false;
            goThroughTheDoor.Visible = false;
            check.Visible = false;
            hide.Visible = true;            
        }

        private void check_Click(object sender, EventArgs e)
        {
            if (opponent.Check(currentLocation))
            {
                ResetGame(true);
            }
            else
            {
                Move++;
                description.Text = currentLocation.Description + "\r\nMoves: " + Move + "\r\nNobody here";
            }
        }

        private void hide_Click(object sender, EventArgs e)
        {
            hide.Visible = false;
            for (int i = 1; i <= 10; i++)
            {
                opponent.Move();
                description.Text ="" + i;
                Application.DoEvents();
                System.Threading.Thread.Sleep(200);
            }
            description.Text = "I'm going to search!"/* + opponent.myLocation.name*/; //для ответа в классе Opponent изменить Location на public
            Application.DoEvents();
            System.Threading.Thread.Sleep(1000);
            MoveToANewLocation(frontYard);
            Move = 0;
        }
    }
}
