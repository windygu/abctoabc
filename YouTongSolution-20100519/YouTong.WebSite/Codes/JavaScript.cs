using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YouTong.WebSite.Codes
{
	public class JavaScript
	{
		public static void Write(String js)
		{
			string scriptBlock = Wrap(js);

			HttpContext.Current.Response.Write(scriptBlock);
		}

		public static void Alert(String msg)
		{
			Write("alert('" + msg + "');");
		}

		public static String Wrap(String js)
		{
			return "<script type='text/javascript'>" + js + "</script>";
		}
	}
}
