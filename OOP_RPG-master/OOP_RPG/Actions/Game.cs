using System;
using System.Collections.Generic;
using OOP_RPG.Characters;
using OOP_RPG.Equipment;
using OOP_RPG.Interfaces;
using OOP_RPG.Other_Classes;

namespace OOP_RPG.Actions
{
    public class Game
    {
        public Hero hero { get; set; }//property from Fight class       
        public Shop Shop { get; set; }
        public Fight GameFight { get; set; }

        public Game() { //calling Game method
            this.hero = new Hero(this); //hero property in this Game class is calling a new instance of Hero class
            this.Shop = new Shop(this);
            this.GameFight = new Fight(this.hero, this);

        }
            
        public void Start() {
            Console.Clear();
            Console.WriteLine("Welcome hero!");
            Console.WriteLine("");
            Console.WriteLine("Please enter your name:");
            this.hero.Name = Console.ReadLine();
            this.Main();
        }
        
        public void Main() {
            Console.Clear();
            Console.WriteLine("Hello " + hero.Name + "!");
            Console.WriteLine("");
            Console.WriteLine("Please choose an option by entering a number.");
            Console.WriteLine("");
            Console.WriteLine("1. View Your Stats");
            Console.WriteLine("2. View Your Equipment");
            Console.WriteLine("3. Visit The Shop");
            Console.WriteLine("4. Equip Yourself");
            Console.WriteLine("5. Fight A Monster");
            Console.WriteLine("6. Exit");

            //Restrict user
            string input;
            do
            {
                input = Console.ReadLine();
            } while (!Utilities.IsValidInput(input, 1, 6));

            if (input == "1") {
                this.Stats();
            }
            else if (input == "2") {
                this.Inventory();
            }
            else if (input == "3")
            {
                this.Shop.Menu();//referring to Menu inside shop class
            }
            else if (input == "4")
            {
                this.Equip();
            }
            else if (input == "5") {
                this.Fight();
            }
            else if (input == "6") {
                Environment.Exit(0);
            }
            
        }
        
        public void Stats() {
            Console.Clear();
            hero.ShowStats();
            Console.WriteLine("");
            Console.WriteLine("Press any key to return to main menu.");
            Console.ReadKey();
            this.Main();
        }
        
        public void Inventory(){
            Console.Clear();
            hero.ShowInventory();
            Console.WriteLine("");
            Console.WriteLine("Press any key to return to main menu.");
            Console.ReadKey();
            this.Main();
        }

        public void Equip()
        {
            Console.Clear();
            Console.WriteLine("What would you like to equip yourself with?");
            Console.WriteLine("");
            Console.WriteLine("1. Armor");
            Console.WriteLine("2. Weapons");
            Console.WriteLine("3. Potions");
            Console.WriteLine("4. Return to main menu");

            //Restrict user
            string input;
            do
            {
                input = Console.ReadLine();
            } while (!Utilities.IsValidInput(input, 1, 4));

            switch (input)
            {
                case "1":
                    hero.EquipArmor();
                    break;
                case "2":
                    hero.EquipWeapon();
                    break;
                case "3":
                    hero.EquipPotion();
                    break;
                case "4":
                    this.Main();
                    break;
            }
        }
        
        public void Fight(){
            Console.Clear();     
            GameFight.Start();
        }
        

    }
}