using System;
using System.Collections.Generic;
using System.Text;

namespace MathLibrary
{
    public class Vector4
    {
        private float _x;
        private float _y;
        private float _z;
        private float _t;

        public float X
        {
            get
            {
                return _x;
            }
            set
            {
                _x = value;
            }
        }

        public float Y
        {
            get
            {
                return _y;
            }
            set
            {
                _y = value;
            }
        }

        public float Z
        {
            get
            {
                return _z;
            }
            set
            {
                _z = value;
            }
        }

        public float T
        {
            get
            {
                return _t;
            }
            set
            {
                _t = value;
            }
        }

        public Vector4()
        {
            _x = 0;
            _y = 0;
            _z = 0;
            _t = 0;
        }

        public Vector4(float x, float y, float z, float t)
        {
            _x = x;
            _y = y;
            _z = z;
            _t = t;
        }

        public static Vector4 operator *(Matrix4 lhs, Vector4 rhs)
        {
            return new Vector4(
                   lhs.m11 * rhs.T + lhs.m12 * rhs.X + lhs.m13 * rhs.Y+ lhs.m14 * rhs.Z,
                   lhs.m21 * rhs.T + lhs.m22 * rhs.X + lhs.m23 * rhs.Y+ lhs.m24 * rhs.Z,
                   lhs.m31 * rhs.T + lhs.m32 * rhs.X + lhs.m33 * rhs.Y+ lhs.m34 * rhs.Z,
                   lhs.m41 * rhs.T + lhs.m42 * rhs.X + lhs.m43 * rhs.Y+ lhs.m44 * rhs.Z
                   );
        }
        public static float DotProduct(Vector4 lhs, Vector4 rhs)
        {
            return (lhs.X * rhs.X) + (lhs.Y * rhs.Y);
        }

        public float Magnitude
        {
            get
            {
                return (float)Math.Sqrt(X * X + Y * Y);
            }
        }
        public Vector4 Normalized
        {
            get
            {
                return Normalize(this);
            }
        }

        /// <summary>
        /// returns the normalized version of the vector passed in
        /// </summary>
        /// <param name="vector">The vector that will be normal </param>
        /// <returns></returns>
        public static Vector4 Normalize(Vector4 vector)
        {
            if (vector.Magnitude == 0)
                return new Vector4();

            return vector / vector.Magnitude;
        }

        public static Vector4 CrossProduct(Vector4 lhs, Vector4 rhs)
        {
            return new Vector4((lhs.Z * rhs.T - lhs.T * rhs.Z),
                (lhs.Y * rhs.Z - lhs.Z * rhs.Y) ,
                (lhs.Z * rhs.X - lhs.X * rhs.Z) ,
                (lhs.X * rhs.Y - lhs.Y * rhs.X));
        }

        public static Vector4 operator +(Vector4 lhs, Vector4 rhs)
        {
            return new Vector4(lhs.X + rhs.X, lhs.Y + rhs.Y, lhs.Z + rhs.Z, lhs.T + rhs.T);
        }

        public static Vector4 operator -(Vector4 lhs, Vector4 rhs)
        {
            return new Vector4(lhs.X - rhs.X, lhs.Y - rhs.Y, lhs.Z - rhs.Z, lhs.T - rhs.T);
        }
        public static Vector4 operator *(Vector4 lhs, float scalar)
        {
            return new Vector4(lhs.X * scalar, lhs.Y * scalar, lhs.Z * scalar, lhs.T * scalar);
        }
        public static Vector4 operator *( float scalar, Vector4 rhs)
        {
            return new Vector4( scalar * rhs.X , scalar *rhs.Y , scalar * rhs.Z, scalar * rhs.T);
        }
        public static Vector4 operator /(Vector4 lhs, float scalar)
        {
            return new Vector4(lhs.X / scalar, lhs.Y / scalar, lhs.Z / scalar, lhs.T / scalar);
        }
    }
}
