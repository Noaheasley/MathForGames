using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;
using Raylib_cs;

namespace MathForGames
{
    class Player: Actor
    {
        public Player(float x, float y, char icon = ' ', ConsoleColor color = ConsoleColor.White)
            : base(x,y,icon,color)
        {

        }

        public Player(float x, float y, Color raycolor, char icon = ' ', ConsoleColor color = ConsoleColor.White)
            : base(x,y,raycolor, icon, color)
        {

        }
        public override void Update()
        {
            int xVelocity = -Convert.ToInt32(Game.GetKeyDown((int)KeyboardKey.KEY_A))
                + Convert.ToInt32(Game.GetKeyDown((int)KeyboardKey.KEY_D));
            int yVelocity = -Convert.ToInt32(Game.GetKeyDown((int)KeyboardKey.KEY_W))
                + Convert.ToInt32(Game.GetKeyDown((int)KeyboardKey.KEY_S));

            Velocity = new Vector2(xVelocity, yVelocity);
            if (GetMagnitude() != 0)
            {
                Velocity.X /= Velocity.GetMagnitude();
                Velocity.Y /= Velocity.GetMagnitude();
            }
            //ConsoleKey keyPressed = Game.GetNextKey();

            //switch (keyPressed)
            //{
            //    case ConsoleKey.D:
            //        _velocity.X = 1;
            //        break;
            //    case ConsoleKey.A:
            //        _velocity.X = -1;
            //        break;
            //    case ConsoleKey.W:
            //        _velocity.Y = -1;
            //        break;
            //    case ConsoleKey.S:
            //        _velocity.Y = 1;
            //        break;
            //    default:
            //        _velocity.X = 0;
            //        _velocity.Y = 0;
            //        break;
            //}
            base.Update();
        }
    }
}
