using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace WebBasics.Utilities
{
	public class WbUtility
	{
		public static Dictionary<TKey, TValue> ToDictinary<TKey, TValue>(String keyProperty, IList<TValue> list)
		{
			var dict = new Dictionary<TKey, TValue>();

			var keyPropertyInfo = Activator.CreateInstance<TValue>().GetType().GetProperty(keyProperty);

			foreach (var item in list)
			{
				var key = (TKey)keyPropertyInfo.GetValue(item, null);

				dict[key] = item;
			}

			return dict;
		}

		public static void CopyPropertiesTo<T1, T2>(T1 t1, T2 t2)
		{
			var t1Type = t1.GetType();
			var t2Type = t2.GetType();

			var t1PropertyInfos = t1Type.GetProperties();
			var t2PropertyInfos = t2Type.GetProperties();

			foreach (var t1P in t1PropertyInfos)
			{
				if (t1P.CanRead)
				{
					var t2P = t2Type.GetProperty(t1P.Name);
					if (t2P != null && t2P.CanWrite)
					{
						t2P.SetValue(t2, t1P.GetValue(t1, null), null);
					}
				}
			}
		}
	}
}
