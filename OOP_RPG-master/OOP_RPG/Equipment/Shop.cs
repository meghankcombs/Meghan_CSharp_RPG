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
    public class Shop
    {
        //New property of type Hero so that we can reference the Hero from Shop
        public Game Game { get; set; }
        

        //Lists - Properties
        public List<Armor> ArmorInventory { get; set; }
        public List<Weapon> WeaponsInventory { get; set; }
        public List<Potion> PotionsInventory { get; set; }

        //Constructor - loads up the Properties (gets and sets the data)
        public Shop(Game game)
        {
            //Initialize each of the three Lists
            this.ArmorInventory = new List<Armor>();
            this.WeaponsInventory = new List<Weapon>();
            this.PotionsInventory = new List<Potion>();
            this.Game = game;
          
            //New Armor
            this.ArmorInventory.Add(new Armor("Wooden Armor", 10, 2, 3));
            this.ArmorInventory.Add(new Armor("Wooden Armor", 10, 2, 3));
            this.ArmorInventory.Add(new Armor("Wooden Armor", 10, 2, 3));
            this.ArmorInventory.Add(new Armor("Metal Armor", 20, 5, 7));
            this.ArmorInventory.Add(new Armor("Metal Armor", 20, 5, 7));

            //New Weapons
            this.WeaponsInventory.Add(new Weapon("Sword", 10, 2, 3));
            this.WeaponsInventory.Add(new Weapon("Sword", 10, 2, 3));
            this.WeaponsInventory.Add(new Weapon("Axe", 12, 3, 4));
            this.WeaponsInventory.Add(new Weapon("Axe", 12, 3, 4));
            this.WeaponsInventory.Add(new Weapon("Longsword", 20, 5, 7));
            this.WeaponsInventory.Add(new Weapon("Longsword", 20, 5, 7));

            //New Potions
            this.PotionsInventory.Add(new Potion("Healing Potion", 7, 1, 5));
            this.PotionsInventory.Add(new Potion("Healing Potion", 7, 1, 5));
            this.PotionsInventory.Add(new Potion("Healing Potion", 7, 1, 5));
            this.PotionsInventory.Add(new Potion(3, "Speed Potion", 7, 1));
            this.PotionsInventory.Add(new Potion(3, "Speed Potion", 7, 1));
        }

        public void Menu()
        {
            Console.Clear();
            var menuText = new StringBuilder();
            menuText.AppendLine("Welcome to the Shop! What would you like to do?");
            menuText.AppendLine("");
            menuText.AppendLine("1. Show Inventory For Sale");
            menuText.AppendLine("2. Sell Item");
            menuText.AppendLine("3. Return to Game Menu");
            Console.WriteLine(menuText);
            string input;

            //Restrict user input
            do
            {
                input = Console.ReadLine();
            } while (!Utilities.IsValidInput(input, 1, 3));

            
            if (input == "1")
            {
                this.ShowInventory();
            }
            else if (input == "2")
            {
                this.BuyFromUser(Game.hero);
            }
            else if (input == "3")
            {
                Game.Main();
            }
            
        }

        //Show inventory for hero to buy
        public void ShowInventory()
        {
            Console.Clear();
            //Display Armor with correlating number
            int index = 1;
            if (this.ArmorInventory.Count() > 0)
            {
                Console.WriteLine("***** Armor Inventory *****");
                Console.WriteLine("");
                var count = 0;
                //Use  LINQ to Group by the Armor Name and then Select the first occurence of each Name
                var uniqueArmorInventory = this.ArmorInventory.GroupBy(x => x.Name).Select(x => x.FirstOrDefault());
                foreach (var armor in uniqueArmorInventory)
                { 
                    count = this.ArmorInventory.Count(x => x.Name == armor.Name);

                    Console.WriteLine(index + ". " + armor.Name + ", Cost: " + armor.OriginalValue + " Gold Pieces - " + count + " in stock");
                    index++;
                }
            }
            else
            {
                Console.WriteLine("The Shop has no armor for sale.");
            }

            //Display Weapons with correlating number
            index = 1;
            if (this.WeaponsInventory.Count() > 0)
            {
                Console.WriteLine("");
                Console.WriteLine("***** Weapons Inventory *****");
                Console.WriteLine("");
                var count = 0;
                //Use  LINQ to Group by the Armor Name and then Select the first occurence of each Name
                var uniqueWeaponInventory = this.WeaponsInventory.GroupBy(y => y.Name).Select(y => y.FirstOrDefault());
                foreach (var weapon in uniqueWeaponInventory)
                {
                    count = this.WeaponsInventory.Count(x => x.Name == weapon.Name);

                    Console.WriteLine(index + ". " + weapon.Name + ", Cost: " + weapon.OriginalValue + " Gold Pieces - " + count + " in stock");
                    index++;
                }
            }
            else
            {
                Console.WriteLine("The Shop has no weapons for sale.");
            }

            //Display Potions with correlating number
            index = 1;
            if (this.PotionsInventory.Count() > 0)
            {
                Console.WriteLine("");
                Console.WriteLine("***** Potions Inventory *****");
                Console.WriteLine("");
                var count = 0;
                //Use  LINQ to Group by the Armor Name and then Select the first occurence of each Name
                var uniquePotionInventory = this.PotionsInventory.GroupBy(x => x.Name).Select(x => x.FirstOrDefault());
                foreach (var potion in uniquePotionInventory)
                {
                    count = this.PotionsInventory.Count(x => x.Name == potion.Name);

                    Console.WriteLine(index + ". " + potion.Name + ", Cost: " + potion.OriginalValue + " Gold Pieces - " + count + " in stock");
                    index++;
                }
            }
            else
            {
                Console.WriteLine("The Shop has no potions for sale.");
            }
            #region Buy Menu
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("*** READY TO BUY? ***");
            Console.WriteLine("Please choose one of the following:");
            Console.WriteLine("1. Buy Armor");
            Console.WriteLine("2. Buy Weapons");
            Console.WriteLine("3. Buy Potions");
            Console.WriteLine("4. Return to Shop Menu");
            string userChoice;
            #endregion
            //Restrict user choice
            do
            {
                userChoice = Console.ReadLine();
            } while (!Utilities.IsValidInput(userChoice, 1, 4));

            switch (userChoice)
                {
                    case "1":
                        Buy(this.ArmorInventory);
                        break;
                    case "2":
                        Buy(this.WeaponsInventory);
                        break;
                    case "3":
                        Buy(this.PotionsInventory);
                        break;
                    case "4":
                        this.Menu();
                        break;
                }
            
        }

        //User buys equipment
        public void Buy(List<Armor> armors)
        {
            Console.Clear();
            Console.WriteLine("Which Armor would you like to buy (Press 0 to return to the Inventory Menu)?");
            Console.WriteLine("");
            var index = 1;
            var armDict = new Dictionary<string, Armor>();
            
            foreach (var armor in armors)
            {
                Console.WriteLine(string.Format("{0}. {1}", index, armor.Name ));
                armDict.Add(index.ToString(), armor);
                index++;
            }

            //Get and restrict user's choice
            string userChoiceArmor;
            do
            {
                Console.Write("Choose the armor's number: ");
                userChoiceArmor = Console.ReadLine();
            } while (!Utilities.IsValidInput(userChoiceArmor, 0, index - 1));
            
            //What to do with user's choice
            if (userChoiceArmor == "0")
            {
                this.ShowInventory();
            }
            else
            {
                Console.WriteLine("");
                if (Game.hero.Gold >= armDict[userChoiceArmor].OriginalValue)//WILLIAM: Remember, use Hero.Gold, not what I have
                {
                    //Add the armor to the Hero's ArmorBag
                    Game.hero.ArmorsBag.Add(armDict[userChoiceArmor]);

                    Console.WriteLine(string.Format("Congratulations, you just purchased a new set of {0}.", armDict[userChoiceArmor].Name));
                    Console.WriteLine(armDict[userChoiceArmor].OriginalValue + " gold pieces have been subtracted from your money purse and the armor was added to your Armor Bag.");

                    //Subtract the amount of gold from the Hero
                    Game.hero.Gold -= armDict[userChoiceArmor].OriginalValue;

                    //Remove item from list
                    this.ArmorInventory.Remove(armDict[userChoiceArmor]);
                }
                else
                {
                    Console.WriteLine("You do not have enough gold to purchase this armor. Consider fighting a monster and returning to the Shop.");
                }

                Console.WriteLine("");
                Console.Write("Press any key to proceed to the Inventory Menu");
                Console.ReadKey();
                //Go back to the Shop Menu
                this.ShowInventory();
            }
        }

        public void Buy(List<Weapon> weapons)
        {
            Console.Clear();
            Console.WriteLine("Which Weapon would you like to buy (Press 0 to return to the Inventory Menu)?");
            Console.WriteLine("");
            var index = 1;
            var weapDict = new Dictionary<string, Weapon>();

            foreach (var weapon in weapons)
            {
                Console.WriteLine(string.Format("{0}. {1}", index, weapon.Name));
                weapDict.Add(index.ToString(), weapon);
                index++;
            }

            //Get and restrict user input
            string userChoiceWeapon;
            do
            {
                Console.Write("Choose the weapon's number: ");
                userChoiceWeapon = Console.ReadLine();
            } while (!Utilities.IsValidInput(userChoiceWeapon, 0, index - 1));

            //What to do with user's choice
            if (userChoiceWeapon == "0")
            {
                this.ShowInventory();
            }
            else
            {
                Console.WriteLine("");
                if (Game.hero.Gold >= weapDict[userChoiceWeapon].OriginalValue)
                {
                    //Add the armor to the Hero's ArmorBag
                    Game.hero.WeaponsBag.Add(weapDict[userChoiceWeapon]);

                    Console.WriteLine(string.Format("Congratulations, you just purchased a new {0}.", weapDict[userChoiceWeapon].Name));
                    Console.WriteLine(weapDict[userChoiceWeapon].OriginalValue + " gold pieces have been subtracted from your money purse and the weapon was added to your Weapons Bag.");

                    //Subtract the amount of gold from the Hero
                    Game.hero.Gold -= weapDict[userChoiceWeapon].OriginalValue;

                    //Remove item from list
                    this.WeaponsInventory.Remove(weapDict[userChoiceWeapon]);
                }
                else
                {
                    Console.WriteLine("You do not have enough gold to purchase this weapon. Consider fighting a monster and returning to the Shop.");
                }

                Console.WriteLine("");
                Console.Write("Press any key to proceed to the Inventory Menu");
                Console.ReadKey();
                //Go back to the Shop Menu
                this.ShowInventory();
            }

        }

        public void Buy(List<Potion> potions)
        {
            Console.Clear();
            Console.WriteLine("Which Potion would you like to buy (Press 0 to return to the Inventory Menu)?");
            Console.WriteLine("");
            var index = 1;
            var potDict = new Dictionary<string, Potion>();

            foreach (var potion in potions)
            {
                Console.WriteLine(string.Format("{0}. {1}", index, potion.Name));
                potDict.Add(index.ToString(), potion);
                index++;
            }

            //Get and restrict user input
            string userChoicePotion;
            do
            {
                Console.Write("Choose the potion's number: ");
                userChoicePotion = Console.ReadLine();
            } while (!Utilities.IsValidInput(userChoicePotion, 0, index - 1));

            //What to do with user's choice
            if (userChoicePotion == "0")
            {
                this.ShowInventory();
            }
            else
            {
                Console.WriteLine("");
                if (Game.hero.Gold >= potDict[userChoicePotion].OriginalValue)
                {
                    //Add the armor to the Hero's ArmorBag
                    Game.hero.PotionsBag.Add(potDict[userChoicePotion]);

                    Console.WriteLine(string.Format("Congratulations, you just purchased a new {0}.", potDict[userChoicePotion].Name));
                    Console.WriteLine(potDict[userChoicePotion].OriginalValue + " gold pieces have been subtracted from your money purse and the potion was added to your Potions Bag.");

                    //Subtract the amount of gold from the Hero
                    Game.hero.Gold -= potDict[userChoicePotion].OriginalValue;

                    //Remove item from list
                    this.PotionsInventory.Remove(potDict[userChoicePotion]);
                }
                else
                {
                    Console.WriteLine("You do not have enough gold to purchase this potion. Consider fighting a monster and returning to the Shop.");
                }

                Console.WriteLine("");
                Console.Write("Press any key to proceed to the Inventory Menu");
                Console.ReadKey();
                //Go back to the Shop Menu
                this.ShowInventory();
            }

        }

        //Equipment to sell menu
        public void BuyFromUser(Hero hero)
        {
            #region Old Code for showing hero's equipment bags
            //if (hero.ArmorsBag.Count() > 0)
            //{
            //    var myArmor = new Dictionary<int, Armor>();
            //    var index = 1;
            //    foreach (var armor in hero.ArmorsBag)
            //    {
            //        myArmor.Add(index, armor);
            //        index++;

            //        Console.WriteLine(index + ". " + armor.Name + "Re-sell Value: " + armor.ResellValue);
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("You have no armor.");
            //}

            //if (hero.WeaponsBag.Count() > 0)
            //{
            //    var myWeapon = new Dictionary<int, Weapon>();
            //    var index = 1;
            //    foreach (var weapon in hero.WeaponsBag)
            //    {
            //        myWeapon.Add(index, weapon);
            //        index++;

            //        Console.WriteLine(index + ". " + weapon.Name + "Re-sell Value: " + weapon.ResellValue);
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("You have no weapons.");
            //}

            //if (hero.PotionsBag.Count() > 0)
            //{
            //    var myPotion = new Dictionary<int, Potion>();
            //    var index = 1;
            //    foreach (var potion in hero.PotionsBag)
            //    {
            //        myPotion.Add(index, potion);
            //        index++;

            //        Console.WriteLine(index + ". " + potion.Name + "Re-sell Value: " + potion.ResellValue);
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("You have no potions.");
            //}
            #endregion

            Console.Clear();
            Console.WriteLine("*** READY TO SELL? ***");
            Console.WriteLine("");
            Console.WriteLine("Please choose one of the following:");
            Console.WriteLine("1. Sell Armor");
            Console.WriteLine("2. Sell Weapons");
            Console.WriteLine("3. Sell Potions");
            Console.WriteLine("4. Return to Shop Menu");
            string userChoice;

            //Restrict user choice
            do
            {
                userChoice = Console.ReadLine();
            } while (!Utilities.IsValidInput(userChoice, 1, 4));

            switch (userChoice)
            {
                case "1":
                    Sell(Game.hero.ArmorsBag);//ArmorsBag calling a new instance of the Armor List, so... (see below Sell method)
                    break;
                case "2":
                    Sell(Game.hero.WeaponsBag);
                    break;
                case "3":
                    Sell(Game.hero.PotionsBag);
                    break;
                case "4":
                    this.Menu();
                    break;
            }
        }

        //User sells equipment to shop
        public void Sell(List<Armor> armors)//...has to be put as an argument in the Sell method
        {
            Console.Clear();
            Console.WriteLine("Which Armor would you like to sell (Press 0 to return to the Sell Menu)?");
            Console.WriteLine("");
            //Shows armor in ArmorsBag
            if (Game.hero.ArmorsBag.Count() > 0)
            {
                var armBagDict = new Dictionary<string, Armor>();
                var index = 1;
                foreach (var armor in Game.hero.ArmorsBag)
                {
                    Console.WriteLine(index + ". " + armor.Name + ", Resell Value: " + armor.ResellValue);
                    armBagDict.Add(index.ToString(), armor);
                    index++;
                }

                //Hero chooses item from bag to sell
                //Get and restrict user input
                string userChoiceArmor;
                do
                {
                    Console.Write("Choose the armor's number: ");
                    userChoiceArmor = Console.ReadLine();
                } while (!Utilities.IsValidInput(userChoiceArmor, 0, index - 1));

                //What to do with user's choice
                if (userChoiceArmor == "0")
                {
                    this.BuyFromUser(Game.hero);
                }
                else
                {

                    Console.WriteLine("");
                    var item = armBagDict[userChoiceArmor];
                    //Remove the armor from the Hero's ArmorBag
                    Game.hero.ArmorsBag.Remove(armBagDict[userChoiceArmor]);

                    Console.WriteLine(string.Format("Congratulations, you just sold a set of {0}.", armBagDict[userChoiceArmor].Name));
                    Console.WriteLine(armBagDict[userChoiceArmor].ResellValue + " gold pieces have been added to your money purse and the armor was removed from your Armor Bag.");

                    //Add the Resell Value of gold to the Hero
                    Game.hero.Gold += armBagDict[userChoiceArmor].ResellValue;

                    //Add item to list
                    this.ArmorInventory.Add(armBagDict[userChoiceArmor]);
                }
            }
            else
            {
                Console.WriteLine("You do not have any armor to sell.");
            }

            Console.WriteLine("");
            Console.Write("Press any key to proceed to the Sell Menu");
            Console.ReadKey();
            //Go back to the Shop Menu
            this.BuyFromUser(Game.hero);
            #region Old code for showing armor
            //var index = 1;
            //var armBagDict = new Dictionary<string, Armor>();

            //foreach (var armor in armors)
            //{
            //    Console.WriteLine(string.Format("{0}. {1}", index, armor.Name));
            //    armBagDict.Add(index.ToString(), armor);
            //    index++;
            //}
            #endregion
        }

        public void Sell(List<Weapon> weapons)
        {
            Console.Clear();
            Console.WriteLine("Which Weapon would you like to sell (Press 0 to return to the Sell Menu)?");
            Console.WriteLine("");
            if (Game.hero.WeaponsBag.Count() > 0)
            {
                var weapBagDict = new Dictionary<string, Weapon>();
                var index = 1;
                foreach (var weapon in Game.hero.WeaponsBag)
                {
                    Console.WriteLine(index + ". " + weapon.Name + ", Resell Value: " + weapon.ResellValue);
                    weapBagDict.Add(index.ToString(), weapon);
                    index++;
                }

                //Get and restrict user input
                string userChoiceWeapon;
                do
                {
                    Console.Write("Choose the weapon's number: ");
                    userChoiceWeapon = Console.ReadLine();
                } while (!Utilities.IsValidInput(userChoiceWeapon, 0, index - 1));

                //What to do with user's choice
                if (userChoiceWeapon == "0")
                {
                    this.BuyFromUser(Game.hero);
                }
                else
                {
                    Console.WriteLine("");
                    //userChoiceWeapon = Console.ReadLine();
                    var item = weapBagDict[userChoiceWeapon];

                    if (Game.hero.WeaponsBag.Contains(item))
                    {
                        //Remove the armor from the Hero's ArmorBag
                        Game.hero.WeaponsBag.Remove(weapBagDict[userChoiceWeapon]);

                        Console.WriteLine(string.Format("Congratulations, you just sold a {0}.", weapBagDict[userChoiceWeapon].Name));
                        Console.WriteLine(weapBagDict[userChoiceWeapon].ResellValue + " gold pieces have been added to your money purse and the weapon was removed from your Weapons Bag.");

                        //Add the Resell Value of gold to the Hero
                        Game.hero.Gold += weapBagDict[userChoiceWeapon].ResellValue;

                        //Add item to list
                        this.WeaponsInventory.Add(weapBagDict[userChoiceWeapon]);
                    }
                }
            }
            else
            {
                Console.WriteLine("You do not have any weapons to sell.");
            }

            Console.WriteLine("");
            Console.Write("Press any key to proceed to the Sell Menu");
            Console.ReadKey();
            //Go back to the Shop Menu
            this.BuyFromUser(Game.hero);
        }

        public void Sell(List<Potion> potions)
        {
            Console.Clear();
            Console.WriteLine("Which Potion would you like to sell (Press 0 to return to the Sell Menu)?");
            Console.WriteLine("");
            if (Game.hero.PotionsBag.Count() > 0)
            {
                var potBagDict = new Dictionary<string, Potion>();
                var index = 1;
                foreach (var potion in Game.hero.PotionsBag)
                {
                    Console.WriteLine(index + ". " + potion.Name + ", Resell Value: " + potion.ResellValue);
                    potBagDict.Add(index.ToString(), potion);
                    index++;
                }

                //Get and restrict user input
                string userChoicePotion;
                do
                {
                    Console.Write("Choose the potion's number: ");
                    userChoicePotion = Console.ReadLine();
                } while (!Utilities.IsValidInput(userChoicePotion, 0, index - 1));

                //What to do with user's choice
                if (userChoicePotion == "0")
                {
                    this.BuyFromUser(Game.hero);
                }
                else
                {
                    Console.WriteLine("");
                    var item = potBagDict[userChoicePotion];

                    //Remove the armor from the Hero's ArmorBag
                    Game.hero.PotionsBag.Remove(potBagDict[userChoicePotion]);

                    Console.WriteLine(string.Format("Congratulations, you just sold a {0}.", potBagDict[userChoicePotion].Name));
                    Console.WriteLine(potBagDict[userChoicePotion].ResellValue + " gold pieces have been added to your money purse and the potion was removed from your Potions Bag.");

                    //Add the Resell Value of gold to the Hero
                    Game.hero.Gold += potBagDict[userChoicePotion].ResellValue;

                    //Add item to list
                    this.PotionsInventory.Add(potBagDict[userChoicePotion]);
                }
            }
            else
            {
                Console.WriteLine("You do not have any potions to sell.");
            }

            Console.WriteLine("");
            Console.Write("Press any key to proceed to the Sell Menu");
            Console.ReadKey();
            //Go back to the Shop Menu
            this.BuyFromUser(Game.hero);
        }
    }
}

