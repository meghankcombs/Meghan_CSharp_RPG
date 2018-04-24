using System;
using System.Collections.Generic;
using OOP_RPG.Actions;
using OOP_RPG.Equipment;
using OOP_RPG.Interfaces;
using OOP_RPG.Other_Classes;

namespace OOP_RPG.Characters
{
    public class Monster
    {
        //Monster class Properties
        public string Name { get; set; }
        public int Strength { get; set; }
        public int Defense { get; set; }
        public int OriginalHP { get; set; }
        public int CurrentHP { get; set; }
        public int Gold { get; set; }//added gold property
        public int Speed { get; set; }//added speed property

        //Constructor for adding Monsters: notice it's the same name as the class it's in
        public Monster(string name, int strength, int defense, int originalHP, int currentHP, int gold, int speed)
        {
            this.Name = name;
            this.Strength = strength;
            this.Defense = defense;
            this.OriginalHP = originalHP;
            this.CurrentHP = currentHP;
            this.Gold = gold;//set gold property to monster's individual gold amount every time instance of Monster created; don't have to add it as an argument
            this.Speed = speed;
        }
    }
}