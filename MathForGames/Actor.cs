﻿using MathLibrary;
using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;

namespace MathForGames
{
    class Actor
    {
        protected char _icon = 'a';
        protected Vector2 _velocity;
        protected Sprite _sprite;
        protected Matrix3 _transform;
        protected ConsoleColor _color;
        protected Color _rayColor;

        public bool Started { get; private set; }

        public Vector2 Forward
        { 
            get { return new Vector2(_transform.m11, _transform.m21); }
            set
            {
                _transform.m11 = value.X;
                _transform.m21 = value.Y;
            }
        }
        

        public Vector2 Position
        {
            get
            {
                return new Vector2(_transform.m13, _transform.m23);
            }
            set
            {
                _transform.m13 = value.X;
                _transform.m23 = value.Y;
            }
        }
        public Vector2 Velocity
        {
            get
            {
                return _velocity;
            }
            set
            {
                _velocity = value;
            }
        }

        protected void Scale(float lhs, float rhs)
        {
            _transform.m12 = lhs;
            _transform.m21 = rhs;
        }
        public Actor( float x, float y, char icon = ' ', ConsoleColor color = ConsoleColor.White) 
        {
            _rayColor = Color.WHITE;
            _icon = icon;
            _transform = new Matrix3();
            Position = new Vector2(x, y);
            _velocity = new Vector2();
            _color = color;
        }
        public Actor(float x, float y, Color raycolor, char icon = ' ', ConsoleColor color = ConsoleColor.White)
        {
            _rayColor = raycolor;
            _icon = icon;
            _transform = new Matrix3();
            Position = new Vector2(x, y);
            _velocity = new Vector2();
            _color = color;
            Forward = new Vector2(1, 0);
            _sprite = new Sprite("Images");
        }


        
        private void UpdateFacing()
        {
            if (_velocity.Magnitude <= 0)
                return;

            Forward = Velocity.Normalized;
        }

        public virtual void Start()
        {
            Started = true;
        }

        public virtual void Update(float deltaTime)
        {
            UpdateFacing();
            
            Position += _velocity * deltaTime;
            Position.X = Math.Clamp(Position.X, 0, Console.WindowWidth-1);
            Position.Y = Math.Clamp(Position.Y, 0, Console.WindowHeight-1);
        }

        public virtual void Draw()
        {
            Scale(4, 10);
            Raylib.DrawText(_icon.ToString(), (int)(Position.X * 32), (int)(Position.Y * 32), 20, _rayColor);
            Raylib.DrawLine(
                (int)(Position.X * 32), 
                (int)(Position.Y * 32),
                (int)((Position.X + Forward.X) * 32),
                (int)((Position.Y + Forward.Y) * 32),
                _rayColor);

            
            Console.ForegroundColor = _color;
            Console.SetCursorPosition((int)Position.X, (int)Position.Y);
            Console.Write(_icon);
            Console.ForegroundColor = Game.DefaultColor;
        }

        public virtual void End()
        {
            Started = false;
        }
    }
}
