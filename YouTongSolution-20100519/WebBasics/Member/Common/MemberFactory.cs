using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebBasics.Member.Common
{
	public class MemberFactory
	{
		public static readonly MemberFactory Instance = new MemberFactory();

		public IUserService UserService = new UserService();
	}
}
