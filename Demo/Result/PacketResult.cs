using System;
using System.Runtime.CompilerServices;
using SourceLiveTimer.Util;

namespace SourceLiveTimer.Demo
{
	public class PacketResult
	{
		public Vector CurrentPosition
		{
			get;
			set;
		}

		public long Read
		{
			get;
			set;
		}

		public PacketResult()
		{
		}
	}
}