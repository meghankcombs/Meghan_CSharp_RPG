using System;
using OOP_RPG.Actions;
using OOP_RPG.Characters;
using OOP_RPG.Equipment;
using OOP_RPG.Interfaces;
using OOP_RPG.Other_Classes;

namespace OOP_RPG
{
    class RPG
    {
        static void Main() 
        {
            // A new object named "game" is being instantiated from our Game Class. game is an instance of the Game Class. 
            // game is also a variable that is pointing to the instance of that Class
            var game = new Game();
            game.Start();
        }
    }
}