using System;
using System.Collections.Generic;
using System.Linq;
using OOP_RPG.Characters;
using OOP_RPG.Equipment;
using OOP_RPG.Interfaces;
using OOP_RPG.Other_Classes;

namespace OOP_RPG.Actions
{
    public class Fight
    {
        List<Monster> Monsters { get; set; }//List called Monsters
        public Game Game { get; set; }
        public Hero Hero { get; set; }
        public Monster Monster { get; set; }//added this Monster property using type Monster of the List

        #region Old Code
        //public Fight(Hero hero, Game game) //Original code
        //public Fight(Monster monster, Hero hero, Game game) {//Fight method being called, need monster parameter?
        //    this.Monsters = new List<Monster>();//calling an instance of List Monsters
        //    this.Hero = hero;//setting hero property
        //    this.Game = game;//setting game property
        //    this.Monster = monster;//setting monster property
        //    this.AddMonster("Squid", 9, 8, 20, 20, 5, 10);
        //    this.AddMonster("Chimera", 11, 13, 24, 24, 7, 12);
        //    this.AddMonster("ROUS (Rodent Of Unusual Size)", 10, 9, 15, 15, 12, 14);
        //    this.AddMonster("Bunny Rabbit", 15, 14, 30, 30, 20, 16);
        //    //this.AddMonster("Dragon", 12, 9, 10, 10, 5, 17);
        //}
        #endregion

        public Fight(Hero hero, Game game)
        {
            //Fight method being called, need monster parameter?
            this.Monsters = new List<Monster>();//calling an instance of List Monsters
            this.Hero = hero;//setting hero property
            this.Game = game;//setting game property
            //this.Monster = monster;//setting monster property
            this.AddMonster("Squid", 9, 8, 9, 9, 5, 10);
            this.AddMonster("Chimera", 11, 13, 10, 10, 7, 12);
            this.AddMonster("ROUS (Rodent Of Unusual Size)", 10, 9, 12, 12, 12, 14);
            this.AddMonster("Bunny Rabbit", 15, 14, 11, 11, 20, 16);
            this.AddMonster("Dragon", 12, 9, 10, 10, 5, 17);
        }

        public void AddMonster(string name, int strength, int defense, int ohp, int chp, int gold, int speed) {//has to match overload var names below
            //Using overloaded Monster constructor to add new monsters to list Monster; lists properties in separate class so not all listed below
            var monster = new Monster(name, strength, defense, ohp, chp, gold, speed);//- needs same signatures as constructor, i.e. string, int, int, int, int... etc
            this.Monsters.Add(monster);//method that adds new Monster to List Monsters
        }

        public void Start() {

            #region Fighting Monsters exercises, not including Random
            ////First Monster
            //var enemy = this.Monsters[0];
            //Console.WriteLine("You've encountered a " + enemy.Name + "! " + enemy.Strength + " Strength/" +
            //enemy.Defense + " Defense/" + enemy.CurrentHP + " HP. What will you do?");
            //Console.WriteLine("1. Fight");
            //var input = Console.ReadLine();
            //if (input == "1")
            //{
            //    this.HeroTurn(enemy);
            //}
            //else
            //{
            //    this.game.Main();
            //}

            ////Last Monster
            //var enemy4 = this.Monsters[this.Monsters.Count - 1];//always gets last item in a list
            //Console.WriteLine("You've encountered a " + enemy4.Name + "! " + enemy4.Strength + " Strength/" + 
            //enemy4.Defense + " Defense/" + enemy4.CurrentHP + " HP. What will you do?");
            //Console.WriteLine("1. Fight");
            //var input4 = Console.ReadLine();
            //if (input4 == "1")
            //{
            //    this.HeroTurn(enemy4);
            //}
            //else
            //{
            //    this.game.Main();
            //}

            ////Second Monster
            //if(this.Monsters.Count >= 2) { //need because list must have two or program will break
            //    var enemy2 = this.Monsters[1];
            //    Console.WriteLine("You've encountered a " + enemy2.Name + "! " + enemy2.Strength + " Strength/" + 
            //    enemy2.Defense + " Defense/" + enemy2.CurrentHP + " HP. What will you do?");
            //    Console.WriteLine("1. Fight");
            //    var input2 = Console.ReadLine();
            //    if (input2 == "1")
            //    {
            //        this.HeroTurn(enemy2);
            //    }
            //    else
            //    {
            //        this.game.Main();
            //    }
            //}
            //else
            //{
            //    var enemy2 = this.Monsters[0]; //if it doesn't have two in list read this code
            //}

            ////First Monster minus 20 hp
            //var enemyMinusHp = this.Monsters.FirstOrDefault(m => m.CurrentHP < 20);//LINQ method to fight monster with current hp less than 20
            //                   //FirstOrDefault = lambda expression looks for items and uses first one or returns null (so program still works)
            //                                  //m = delegate that refers to object in that list; usually use first letter of structure querying
            //Console.WriteLine("You've encountered a " + enemyMinusHp.Name + "! " + enemyMinusHp.Strength + 
            //" Strength/" + enemyMinusHp.Defense + " Defense/" + enemyMinusHp.CurrentHP + " HP. What will you do?");
            //Console.WriteLine("1. Fight");
            //var inputMinusHp = Console.ReadLine();
            //if (inputMinusHp == "1")
            //{
            //    this.HeroTurn(enemyMinusHp);
            //}
            //else
            //{
            //    this.game.Main();
            //}

            ////First Monster with at least strength of 11
            //var enemyEleven = this.Monsters.FirstOrDefault(m => m.Strength >= 11);//LINQ method to fight monster with strength 11 or more
            //Console.WriteLine("You've encountered a " + enemyEleven.Name + "! " + enemyEleven.Strength + 
            //" Strength/" + enemyEleven.Defense + " Defense/" + enemyEleven.CurrentHP + " HP. What will you do?");
            //Console.WriteLine("1. Fight");
            //var inputEleven = Console.ReadLine();
            //if (inputEleven == "1")
            //{
            //    this.HeroTurn(enemyEleven);
            //}
            //else
            //{
            //    this.game.Main();
            //}
            #endregion

            //Random Monster
            Console.Clear();
            if (this.Monster == null || this.Monster.CurrentHP <= 0)
            {
                var random = new Random(); //new instance of Random class
                this.Monster = this.Monsters[random.Next(0, this.Monsters.Count)]; //Monster being passed into HeroTurn, etc below
                                                                                   //generate a random number of list
            }
            Console.WriteLine("You've encountered a " + this.Monster.Name + "!");
            Console.WriteLine("");
            Console.WriteLine("Strength: " + this.Monster.Strength);
            Console.WriteLine("Defense: " + this.Monster.Defense);
            Console.WriteLine("HP: " + this.Monster.CurrentHP);
            Console.WriteLine("Speed: " + this.Monster.Speed);
            Console.WriteLine("Gold: " + this.Monster.Gold);
            Console.WriteLine("");
            Console.WriteLine("What will you do?");
            Console.WriteLine("");
            Console.WriteLine("1. Fight");
            Console.WriteLine("");
            Console.WriteLine("2. Run");
            Console.WriteLine("");
            Console.WriteLine("3. Return to Game Menu");

            //Restrict user input
            string input;
            do
            {
                input = Console.ReadLine();
            } while (!Utilities.IsValidInput(input, 1, 3));

            if (input == "1")
            {
                this.HeroTurn();
            }
            else if (input == "2")
            {
                this.HeroRun();
            }
            else if (input == "3")
            {
                this.Game.Main();
            }   
        }
        
        public void HeroTurn(){
           //var enemy = Monster; no need for separate variable anymore because this.Monster exists above in randomly generated monster
           var compare = Hero.Strength - this.Monster.Defense;
           int damage;
           
           if(compare <= 0) {
               damage = 1;
               this.Monster.CurrentHP -= damage;
           }
           else{
               damage = compare;
                this.Monster.CurrentHP -= damage;
           }
           Console.WriteLine("You did " + damage + " damage!");
           
           if(this.Monster.CurrentHP <= 0){
               this.Win();
           }
           else
           {
               this.MonsterTurn();
           }
           
        }
        
        public void MonsterTurn(){
           //var enemy = Monster;
           int damage;
           var compare = this.Monster.Strength - Hero.Defense;
           if(compare <= 0) {
               damage = 1;
               Hero.CurrentHP -= damage;
           }
           else{
               damage = compare;
               Hero.CurrentHP -= damage;
           }
           Console.WriteLine(this.Monster.Name + " does " + damage + " damage!");
           if(Hero.CurrentHP <= 0){
               this.Lose();
           }
           else
           {
               this.Start();
           }
        }
        
        public void Win() {
            //var enemy = Monster;
            Hero.Gold += Monster.Gold;//adds monster's gold to hero's (I think)

            //Because I am in the Win method I must have killed the Monster I was fighting..
            this.Monsters.Remove(this.Monster);

            Console.Clear();
            Console.WriteLine(this.Monster.Name + " has been defeated! You win the battle!");
            Console.WriteLine(this.Monster.Gold + " gold pieces have been added to your money purse.");
            if (this.Monsters.Count == 0)
            {
                Console.WriteLine("");
                Console.WriteLine("You have defeated all the Monsters and WON THE GAME!!");
                Console.WriteLine("");
                Console.Write("Press any key and enter to play again. Press 0 to Exit.");
                var userChoice = Console.ReadLine();
                if (userChoice == "0")
                {
                    Environment.Exit(0);
                }
                else
                {
                    var game = new Game();
                    game.Start();
                }
            }
            else
            {
                Console.WriteLine("");
                Console.Write("Press any key to continue");
                Console.ReadKey();
                Game.Main();
            }
        }
        
        public void Lose() {
            Console.Clear();
            Console.WriteLine("You've been defeated! GAME OVER.");
            Console.WriteLine("");
            Console.WriteLine("Press 1 to play again and 0 to exit.");

            //Restrict user input
            string userChoice;
            do
            {
                userChoice = Console.ReadLine();
            } while (!Utilities.IsValidInput(userChoice, 0, 1));


            if (userChoice == "0")
            {
                Environment.Exit(0);
            }
            else
            {
                Game.Start();
            }
        }

        public void HeroRun()
        {
            if (Hero.Speed >= this.Monster.Speed)
            {
                Console.WriteLine("You got away! Press any key to return the main menu.");
                Console.ReadKey();
                this.Game.Main();
            }
            else
            {
                Console.WriteLine(this.Monster.Name + " caught you and you died a bloody death! GAME OVER.");
                Console.WriteLine("");
                Console.WriteLine("Press any key to return the main menu.");
                Console.ReadKey();
                this.Game.Main();
            }
        }

    }
    
}