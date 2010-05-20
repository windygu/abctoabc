using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouTong.Model
{
	public partial class Child
	{
		public Int32 Age
		{
			get
			{
				var ts = DateTime.Now - this.Birthday;
				return ts.Days / 365;
			}
		}
	}
}
