using System;
using System.Collections.Generic;
using System.Linq;
using OOP_RPG.Actions;
using OOP_RPG.Equipment;
using OOP_RPG.Interfaces;
using OOP_RPG.Other_Classes;


namespace OOP_RPG.Characters
{
    public class Hero
    {
        //Properties
        public string Name { get; set; }
        public int Strength { get; set; }
        public int Defense { get; set; }
        public int OriginalHP { get; set; }
        public int CurrentHP { get; set; }
        public int Gold { get; set; }//added gold property
        public int Speed { get; set; }
        public Armor EquippedArmor { get; set; }
        public Weapon EquippedWeapon { get; set; }
        public Potion EquippedPotion { get; set; }

        public List<Armor> ArmorsBag { get; set; }
        public List<Weapon> WeaponsBag { get; set; }
        public List<Potion> PotionsBag { get; set; }

        public Game Game { get; set; }

        public Hero(Game game) {
            this.ArmorsBag = new List<Armor>();
            this.WeaponsBag = new List<Weapon>();
            this.PotionsBag = new List<Potion>();
            this.Strength = 10;
            this.Defense = 10;
            this.OriginalHP = 500;
            this.CurrentHP = 500;
            this.Gold = 5;//initial gold property amount
            this.Speed = 15;
            this.Game = game;
        }
       
        //Methods
        public void ShowStats() {
            Console.Clear();
            Console.WriteLine("***** " + this.Name + " *****");
            Console.WriteLine("");
            Console.WriteLine("Strength: " + this.Strength);
            Console.WriteLine("Defense: " + this.Defense);
            Console.WriteLine("Hitpoints: " + this.CurrentHP + "/" + this.OriginalHP);
            Console.WriteLine("Money Purse: " + this.Gold + " Gold Pieces");
            Console.WriteLine("Speed: " + this.Speed);
        }
        
        public void ShowInventory() {
            Console.Clear();
            Console.WriteLine("***** EQUIPMENT *****");
            Console.WriteLine("");
            Console.WriteLine("Armor:");
            Console.WriteLine("");
            foreach (var a in this.ArmorsBag)
            {
                Console.WriteLine(a.Name + ", Defense: " + a.Defense);
            }
            Console.WriteLine("");
            Console.WriteLine("Weapons:");
            Console.WriteLine("");
            foreach (var w in this.WeaponsBag){
                Console.WriteLine(w.Name + ", Strength: " + w.Strength);
            }
            Console.WriteLine("");
            Console.WriteLine("Potions:");
            Console.WriteLine("");
            foreach (var p in this.PotionsBag)
            {
                if (p.Name.Contains("Healing"))
                {
                    Console.WriteLine(p.Name + ", HP: " + p.HP);
                }
                else
                {
                    Console.WriteLine(p.Name + ", Speed: " + p.Speed);
                }
            }
        }

        public void EquipArmor()
        {
            Console.Clear();
            Console.WriteLine("Which Armor would you like to don (Press 0 to return to Equip Menu)?");
            Console.WriteLine("");
            //Shows armor in ArmorsBag
            if (this.ArmorsBag.Count() > 0)
            {
                var armBagDict = new Dictionary<string, Armor>();
                var index = 1;
                foreach (var armor in this.ArmorsBag)
                {
                    armBagDict.Add(index.ToString(), armor);
                    Console.WriteLine(index + ". " + armor.Name + ", Defense: " + armor.Defense);
                    index++;
                }

                //Hero chooses item from bag to put on
                Console.WriteLine("");
                string userChoiceArmor;
                //Restrict user input
                do
                {
                    Console.Write("Choose the armor's number: ");
                    userChoiceArmor = Console.ReadLine();
                } while (!Utilities.IsValidInput(userChoiceArmor, 0, index - 1));

                if (userChoiceArmor == "0")
                {
                    Game.Equip();
                }
                else
                 {
                    if (this.EquippedArmor != null)
                    {
                        //Put the armor back into the  ArmorBag
                        this.ArmorsBag.Add(this.EquippedArmor);
                        //Subtract the Armor.>Defense from  Hero.defense
                        this.Defense -= this.EquippedArmor.Defense;
                        //Make this.EquippedArmor = null
                        this.EquippedArmor = null;
                    }

                    var item = armBagDict[userChoiceArmor];
                    //Remove the armor from the Hero's ArmorBag
                    this.ArmorsBag.Remove(item);
                    Console.WriteLine(string.Format("You just donned {0}.", item.Name));

                    //Add to equipped property?
                    this.EquippedArmor = item;

                    //increase and decrease stats accordingly
                    this.Defense += item.Defense;
                    Console.WriteLine("Your current defense is now: " + this.Defense);
                }
            }
            else
            {
                Console.WriteLine("You do not have any armor to don.");
            }
                Console.WriteLine("");
                Console.Write("Press any key to proceed to the Euip Menu");
                Console.ReadKey();
                //Go back to the Equip Menu
                Game.Equip();
        }

        public void EquipWeapon()
        {
            Console.Clear();
            Console.WriteLine("Which Weapon would you like to wield (Press 0 to return to the Equip Menu)?");
            Console.WriteLine("");
            //Shows weapon in WeaponsBag
            if (this.WeaponsBag.Count() > 0)
            {
                var weapBagDict = new Dictionary<string, Weapon>();
                var index = 1;
                foreach (var weapon in this.WeaponsBag)
                {
                    weapBagDict.Add(index.ToString(), weapon);
                    Console.WriteLine(index + ". " + weapon.Name + ", Strength: " + weapon.Strength);
                    index++;
                }

                //Hero chooses item from bag to put on
                Console.WriteLine("");
                string userChoiceWeapon;
                //Restrict user input
                do
                {
                    Console.Write("Choose the weapon's number: ");
                    userChoiceWeapon = Console.ReadLine();
                } while (!Utilities.IsValidInput(userChoiceWeapon, 0, index - 1));

                if (userChoiceWeapon == "0")
                {
                    Game.Equip();
                }
                else
                {
                    if (this.EquippedWeapon != null)
                    {
                        //Put the weapon back into the  WeaponBag
                        this.WeaponsBag.Add(this.EquippedWeapon);
                        //Subtract the Weapon.Strength from  Hero.Strength
                        this.Strength -= this.EquippedWeapon.Strength;
                        //Make this.EquippedWeapon = null
                        this.EquippedWeapon = null;
                    }

                    var item = weapBagDict[userChoiceWeapon];
                    //Remove the weapon from the Hero's WeaponBag
                    this.WeaponsBag.Remove(item);
                    Console.WriteLine(string.Format("You are now wielding a(n) {0}.", item.Name));

                    //Add to equipped property
                    this.EquippedWeapon = item;

                    //increase and decrease stats accordingly
                    this.Strength += item.Strength;
                    Console.WriteLine("Your current strength is now: " + this.Strength);
                }
            }
            else
            {
                Console.WriteLine("You do not have any weapons to wield.");
            }

            Console.WriteLine("");
            Console.Write("Press any key to proceed to the Euip Menu");
            Console.ReadKey();
            //Go back to the Equip Menu
            Game.Equip();
        }

        public void EquipPotion()
        {
            Console.Clear();
            Console.WriteLine("Which Potion would you like to drink (Press 0 to return to the Equip Menu)?");
            Console.WriteLine("");
            //Shows potions in PotionsBag
            if (this.PotionsBag.Count() > 0)
            {
                var potBagDict = new Dictionary<string, Potion>();
                var index = 1;
                foreach (var potion in this.PotionsBag)
                {
                    potBagDict.Add(index.ToString(), potion);
                    if (potion.Name.Contains("Healing"))
                    {
                        Console.WriteLine(index + ". " + potion.Name + ", HP: " + potion.HP);
                    }
                    else
                    {
                        Console.WriteLine(index + ". " + potion.Name + ", Speed: " + potion.Speed);
                    }
                    index++;
                }

                //Hero chooses item from bag to put on
                Console.WriteLine("");
                string userChoicePotion;
                //Restrict user input
                do
                {
                    Console.Write("Choose the potion's number: ");
                    userChoicePotion = Console.ReadLine();
                } while (!Utilities.IsValidInput(userChoicePotion, 0, index - 1));

                if (userChoicePotion == "0")
                {
                    Game.Equip();
                }
                else
                {
                    var item = potBagDict[userChoicePotion];
                    this.PotionsBag.Remove(item);
                    Console.WriteLine(string.Format("You have drunk a {0}.", item.Name));

                    //Add to equipped property
                    this.EquippedPotion = item;

                    //increase and decrease stats accordingly
                    if (item.Name.Contains("Healing"))
                    {
                        this.CurrentHP += item.HP;
                        Console.WriteLine("Your current HP is now: " + this.CurrentHP);
                    }
                    else
                    {
                        this.Speed += item.Speed;
                        Console.WriteLine("Your current speed is now: " + this.Speed);
                    }
                }
            }
            else
            {
                Console.WriteLine("You do not have any potions to drink.");
            }

            Console.WriteLine("");
            Console.Write("Press any key to proceed to the Euip Menu");
            Console.ReadKey();
            //Go back to the Equip Menu
            Game.Equip();
        }
    }
}