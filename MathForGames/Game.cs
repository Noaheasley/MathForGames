using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using MathLibrary;
using System.Threading;
using Raylib_cs;
namespace MathForGames
{
    class Game
    {
        private static bool _gameOver = false;
        private static Scene[] _scenes;
        private static int _currentSceneIndex;

        public static ConsoleColor DefaultColor { get; set; } = ConsoleColor.White;
        //public static ConsoleKey GetNextKey()
        //{
        //    //if the user hasn't pressed the right key it will return zero
        //    if(!Console.KeyAvailable)
        //    {
        //        return 0;
        //    }
        //    //returns the key
        //    return Console.ReadKey(true).Key;
        //}

        public static Scene GetScenes(int index)
        {
            return _scenes[index];
        }

        //public static int GetNextKey()
        //{
        //    return Raylib.GetKeyPressed();
        //}

        public static bool GetKeyDown(int key)
        {
            bool testbool = true;
            int test = Convert.ToInt32(testbool);
            return Raylib.IsKeyDown((KeyboardKey)key);
        }
        public static bool GetKeyPressed(int key)
        {

            return Raylib.IsKeyPressed((KeyboardKey)key);
        }
        public static int AddScene(Scene scene)
        {
            Scene[] tempArray = new Scene[_scenes.Length + 1];

            for(int i = 0; i < _scenes.Length; i++)
            {
                tempArray[i] = _scenes[i];
            }

            int index = _scenes.Length;

            tempArray[index] = scene;
            _scenes = tempArray;

            return index;
        }

        public static bool RemoveScene(Scene scene)
        {
            if(scene == null)
            {
                return false;
            }

            bool removed = false;

            Scene[] tempArry = new Scene[_scenes.Length - 1];
            int j = 0;
            for(int i = 0; i < _scenes.Length; i++)
            {
                if(tempArry[i] != scene)
                {
                    tempArry[j] = _scenes[i];
                    j++;
                }
                else
                {
                    removed = true;
                }
            }
            if(removed)
                _scenes = tempArry;

            return removed;
        }

        public static void SetGameOver(bool value)
        {
            _gameOver = value;
        }

        public Game()
        {
            _scenes = new Scene[0];
        }

        public static void SetCurrentScene(int index)
        {
            if (index < 0 || index > _scenes.Length)
                return;
            if (_scenes[_currentSceneIndex].Started)
                _scenes[_currentSceneIndex].End();
            _currentSceneIndex = index;
        }
        //Called when the game begins. Use this for initialization.
        public void Start()
        {
            Raylib.InitWindow(1024, 760, "Math For Games");
            Raylib.SetTargetFPS(60);

            Scene scene1 = new Scene();
            Scene scene2 = new Scene();
            Actor actor = new Actor(0,0,Color.GREEN, 'o', ConsoleColor.Green);
            actor.Velocity.X = 1;
            Player player = new Player(10, 0, Color.RED, '@', ConsoleColor.Red);
            scene1.AddActor(actor);
            scene1.AddActor(player);

            scene2.AddActor(player);

            int startingSceneIndex = 0;
            
            startingSceneIndex = AddScene(scene1);
            AddScene(scene2);

            SetCurrentScene(startingSceneIndex);
        }


        //Called every frame.
        public void Update()
        {
            if (!_scenes[_currentSceneIndex].Started)
                _scenes[_currentSceneIndex].Start();
            _scenes[_currentSceneIndex].Update();
        }

        //Used to display objects and other info on the screen.
        public void Draw()
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.BLACK);
            Console.Clear();
            _scenes[_currentSceneIndex].Draw();
            Raylib.EndDrawing();
        }


        //Called when the game ends.
        public void End()
        {
            if(_scenes[_currentSceneIndex].Started)
                _scenes[_currentSceneIndex].End();

        }

        

        //Handles all of the main game logic including the main game loop.
        public void Run()
        {
            Start();

            while(!_gameOver || !Raylib.WindowShouldClose())
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
