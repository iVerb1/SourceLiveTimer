using System;
using System.Runtime.CompilerServices;

namespace SourceLiveTimer.Util
{
	public class Vector
	{
		public float X
		{
			get;
			set;
		}

		public float Y
		{
			get;
			set;
		}

		public float Z
		{
			get;
			set;
		}

		public Vector(float x, float y, float z)
		{
			this.X = x;
			this.Y = y;
			this.Z = z;
		}

		public override bool Equals(object obj)
		{
			Vector vector = obj as Vector;
			if (vector == null)
			{
				return false;
			}
			if (vector.X == this.X && vector.Y == this.Y && vector.Z == this.Z)
			{
				return true;
			}
			return false;
		}

		public override int GetHashCode()
		{
			return (int)this.X ^ (int)this.Y ^ (int)this.Z;
		}

		public override string ToString()
		{
			return string.Format("{0:0.000000} {1:0.000000} {2:.000000}", this.X, this.Y, this.Z);
		}
	}
}