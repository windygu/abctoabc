using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;

namespace WebBasics.Utilities
{
	public class MD5Hasher
	{
		public static Byte[] GetMD5Hash(Byte[] buffer)
		{
			var md5 = MD5.Create();
			return md5.ComputeHash(buffer);
		}

		public static Byte[] GetMD5Hash(Object obj)
		{
			var buffer = GetBinary(obj);
			return GetMD5Hash(buffer);
		}

		public static Byte[] GetMD5Hash(String value)
		{
			var buffer = Encoding.UTF8.GetBytes(value);
			return GetMD5Hash(buffer);
		}

		public static String GetMD5HashString(Byte[] buffer)
		{
			var data = GetMD5Hash(buffer);
			return BytesToString(data);
		}

		public static String GetMD5HashString(Object obj)
		{
			var data = GetMD5Hash(obj);
			return BytesToString(data);
		}

		public static String GetMD5HashString(String value)
		{
			var data = GetMD5Hash(value);
			return BytesToString(data);
		}

		public static Byte[] GetBinary(Object obj)
		{
			var stream = new MemoryStream();
			BinaryFormatter bf = new BinaryFormatter();
			bf.Serialize(stream, obj);

			var buffer = stream.ToArray();
			stream.Close();

			return buffer;
		}

		public static String BytesToString(Byte[] bytes)
		{
			StringBuilder sBuilder = new StringBuilder();

			for (int i = 0; i < bytes.Length; i++)
			{
				sBuilder.Append(bytes[i].ToString("x2"));
			}

			return sBuilder.ToString();
		}
	}
}
