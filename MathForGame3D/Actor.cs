using MathLibrary;
using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.CompilerServices;

namespace MathForGame3D
{
    class Actor
    {
        protected char _icon = 'a';
        protected Vector3 _velocity;
        protected Matrix4 _globalTransform = new Matrix4();
        protected Matrix4 _localTransform = new Matrix4();
        protected Matrix4 _translation = new Matrix4();
        protected Matrix4 _rotation = new Matrix4();
        protected Matrix4 _scale = new Matrix4();
        protected ConsoleColor _color;
        protected Color _rayColor;
        protected Actor _parent;
        protected Actor[] _children = new Actor[0];

        public bool Started { get; private set; }

        public Vector3 Forward
        {
            get { return new Vector3(_localTransform.m11, _localTransform.m21, _localTransform.m31); }
            //set
            //{
            //    _transform.m11 = value.X;
            //    _transform.m21 = value.Y;
            //}
        }

        public Vector3 WorldPosition
        {
            get
            {
                return new Vector3(_globalTransform.m13, _globalTransform.m23,_globalTransform.m33);
            }
            set
            {
                _translation.m13 = value.X;
                _translation.m23 = value.Y;
            }
        }
        public Vector3 LocalPosition
        {
            get
            {
                return new Vector3(_localTransform.m13, _localTransform.m23, _localTransform.m33);
            }
            set
            {
                _translation.m13 = value.X;
                _translation.m23 = value.Y;
            }
        }
        public Vector3 Velocity
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
        public void SetRotationX(float radians)
        {

        }
        public void SetRotationY(float radians)
        {

        }
        public void SetRotationZ(float radians)
        {

        }
    }
}
