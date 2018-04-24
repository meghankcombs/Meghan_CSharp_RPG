using System;
using OOP_RPG.Actions;
using OOP_RPG.Characters;
using OOP_RPG.Interfaces;
using OOP_RPG.Other_Classes;

namespace OOP_RPG.Equipment
{
    public class Weapon : IItem
    {
        //Properties
        public string Name { get; set; }
        public int Strength { get; set; }
        public int OriginalValue { get; set; }//from IItem
        public int ResellValue { get; set; }//from IItem

        //Constructor
        public Weapon(string name, int ov, int rv, int strength) {
            this.Name = name;
            this.OriginalValue = ov;
            this.ResellValue = rv;
            this.Strength = strength;
        }
    }
}