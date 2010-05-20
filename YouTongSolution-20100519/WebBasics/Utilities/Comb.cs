using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebBasics.Utilities
{
	public class Comb
	{
		public static Guid NewComb()
		{
			byte[] guidArray = Guid.NewGuid().ToByteArray();
			DateTime baseDate = new DateTime(1900, 1, 1);
			DateTime now = DateTime.Now;

			// Get the days and milliseconds which will be used to build the byte string
			TimeSpan days = new TimeSpan(now.Ticks - baseDate.Ticks);
			TimeSpan msecs = new TimeSpan(now.Ticks - (new DateTime(now.Year, now.Month, now.Day).Ticks));

			// Convert to a byte array
			// Note that SQL Server is accurate to 1/300th of a millisecond so we divide by 3.333333
			byte[] daysArray = BitConverter.GetBytes(days.Days);
			byte[] msecsArray = BitConverter.GetBytes((long)(msecs.TotalMilliseconds / 3.333333));

			// Reverse the bytes to match SQL Servers ordering
			Array.Reverse(daysArray);
			Array.Reverse(msecsArray);

			// Copy the bytes into the guid
			Array.Copy(daysArray, daysArray.Length - 2, guidArray, guidArray.Length - 6, 2);
			Array.Copy(msecsArray, msecsArray.Length - 4, guidArray, guidArray.Length - 4, 4);

			return new Guid(guidArray);
		}

		public static Guid NewComb2()
		{
			byte[] guidArray = Guid.NewGuid().ToByteArray();
			DateTime baseDate = new DateTime(1900, 1, 1);
			DateTime now = DateTime.Now;

			// Get the days and milliseconds which will be used to build the byte string
			TimeSpan days = new TimeSpan(now.Ticks - baseDate.Ticks);
			TimeSpan msecs = new TimeSpan(now.Ticks - (new DateTime(now.Year, now.Month, now.Day).Ticks));

			// Convert to a byte array
			// Note that SQL Server is accurate to 1/300th of a millisecond so we divide by 3.333333
			byte[] daysArray = BitConverter.GetBytes(days.Days);
			byte[] msecsArray = BitConverter.GetBytes((long)(msecs.TotalMilliseconds / 3.333333));

			// Reverse the bytes to match SQL Servers ordering
			Array.Reverse(daysArray);
			Array.Reverse(msecsArray);

			Byte[] newGuidArray = new Byte[16];

			// Copy the bytes into the guid
			Array.Copy(daysArray, daysArray.Length - 2, newGuidArray, 0, 2);
			Array.Copy(msecsArray, msecsArray.Length - 4, newGuidArray, 2, 4);
			Array.Copy(guidArray, 0, newGuidArray, 6, 10);

			return new Guid(newGuidArray);
		}
	}
}
