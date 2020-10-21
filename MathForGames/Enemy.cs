using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;
using MathLibrary;

namespace MathForGames
{
    class Enemy : Actor
    {
        private Actor _target;

        public Actor Target
        {
            get{ return _target;}
            set{ _target = value;}
        }
        public Enemy(float x, float y, char icon = ' ', ConsoleColor color = ConsoleColor.White)
            : base(x, y, icon, color)
        {

        }

        public Enemy(float x, float y, Color raycolor, char icon = ' ', ConsoleColor color = ConsoleColor.White)
            : base(x, y, raycolor, icon, color)
        {

        }

        public bool GetTargetInSight()
        {
            if (Target == null)
                return false;
            Vector2 direction = (Position - Target.Position);

            if (Vector2.DotProduct(Forward, direction) == 1)
                return true;

            return false;
        }

        public override void Update(float deltaTime)
        {
            if(GetTargetInSight())
            {

            }
            base.Update(deltaTime);
        }
    }
}
