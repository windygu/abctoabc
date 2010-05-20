using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace YouTong.WebSite
{
	public class UtException : Exception
	{
		public UtException() { }
		public UtException(string message) : base(message) { }
		public UtException(string message, Exception inner) : base(message, inner) { }
		protected UtException(SerializationInfo info, StreamingContext context)
			: base(info, context) { }
	}
}
