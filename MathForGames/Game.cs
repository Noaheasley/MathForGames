using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using MathLibrary;
using System.Threading;
namespace MathForGames
{
    class Game
    {
        private static bool _gameOver = false;
        private Scene _scene;
        private Actor _actor;

        public static ConsoleColor DefaultColor { get; set; } = ConsoleColor.White;
        public static ConsoleKey GetNextKey()
        {
            //if the user hasn't pressed the right key it will return zero
            if(!Console.KeyAvailable)
            {
                return 0;
            }
            //returns the key
            return Console.ReadKey(true).Key;
        }


        public static void SetGameOver(bool value)
        {
            _gameOver = value;
        }
        //Called when the game begins. Use this for initialization.
        public void Start()
        {
            
            _scene = new Scene();
            Actor actor = new Actor(0,0,'o', ConsoleColor.Green);
            actor.Velocity.X = 1;
            Player player = new Player(10, 0, '@', ConsoleColor.Red);
            _scene.AddActor(actor);
            _scene.AddActor(player);
        }


        //Called every frame.
        public void Update()
        {
            _scene.Update();
        }

        //Used to display objects and other info on the screen.
        public void Draw()
        {
            Console.Clear();
            _scene.Draw();
        }


        //Called when the game ends.
        public void End()
        {

        }

        

        //Handles all of the main game logic including the main game loop.
        public void Run()
        {
            Start();

            while(!_gameOver)
            {
                Update();
                Draw();
                while (Console.KeyAvailable) Console.ReadKey(true);
                Thread.Sleep(100);
            }

            End();
        }
    }
}
