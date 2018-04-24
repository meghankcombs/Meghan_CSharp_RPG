using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP_RPG.Actions;
using OOP_RPG.Characters;
using OOP_RPG.Interfaces;
using OOP_RPG.Other_Classes;

namespace OOP_RPG.Equipment
{
    public class Potion : IItem
    {
        //Turn to page 394 (Lol, Harry Potter reference)

        //Properties
        public string Name { get; set; }
        public int HP { get; set; }
        public int Speed { get; set; }
        public int OriginalValue { get; set; }//from IItem
        public int ResellValue { get; set; }//from IItem

        //Constructors
        //Healing Potion
        public Potion(string name, int ov, int rv, int hp)//arguments passed into the constructor
        {
            this.Name = name;
            this.OriginalValue = ov;
            this.ResellValue = rv;
            this.HP = hp;
        }

        //Speed Potion
        public Potion(int speed, string name, int ov, int rv)//arguments passed into the constructor
        {
            this.Speed = speed;
            this.Name = name;
            this.OriginalValue = ov;
            this.ResellValue = rv;
        }
    }
}
