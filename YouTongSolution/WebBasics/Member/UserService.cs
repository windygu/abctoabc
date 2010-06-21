using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebBasics.Member.Common;
using WebBasics.Member.Model;
using WebBasics.Utilities;

namespace WebBasics.Member
{
	/// <summary>
	/// 用户服务
	/// </summary>
	public class UserService : BusinessBase, IUserService
	{
		/// <summary>
		/// UserService实例
		/// </summary>
		public static readonly UserService Instance = new UserService();

		#region IUserService 成员

		public void AddUser(User user)
		{
			if (this.ExistUserName(user.UserName))
			{
				throw new ArgumentException("存在相同的用户名");
			}

			user.ID = Comb.NewComb2();
			dbUser.AddUser(user);
		}

		public void UpdateUser(User user)
		{
			dbUser.UpdateUser(user);
		}

		public void DeleteUser(Guid id)
		{
			dbUser.UpdateIsDeleted(new Guid[] { id }, true);
		}

		public void DeleteUsers(Guid[] ids)
		{
			dbUser.UpdateIsDeleted(ids, true);
		}

		public void ShiftDeleteUser(Guid id)
		{
			throw new NotImplementedException();
		}

		public void ShiftDeleteUsers(Guid[] ids)
		{
			throw new NotImplementedException();
		}

		public User GetUser(Guid id)
		{
			return dbUser.GetUser(id);
		}

		public User GetUser(string username)
		{
			return dbUser.GetUser(username);
		}

		public IList<User> GetUsers(params Guid[] ids)
		{
			return dbUser.GetUsers(ids);
		}

		public IList<User> GetUsers(int pageIndex, int pageSize)
		{
			return dbUser.GetUsers(pageIndex, pageSize);
		}

		public IList<User> GetDeletedUsers(int pageIndex, int pageSize)
		{
			return dbUser.GetDeletedUsers(pageIndex, pageSize);
		}

		public int GetUserCount()
		{
			return dbUser.GetUserCount();
		}

		public int GetDeletedUserCount()
		{
			return dbUser.GetDeletedUserCount();
		}

		public bool ExistUserName(string username)
		{
			if (String.IsNullOrEmpty(username) || username.Trim() == "")
			{
				throw new ArgumentException("参数不能为空", "username");
			}

			return dbUser.ExistUserName(username);
		}

		public bool ExistEmail(string email)
		{
			if (String.IsNullOrEmpty(email) || email.Trim() == "")
			{
				throw new ArgumentException("参数不能为空", "email");
			}

			return dbUser.ExistEmail(email);
		}

		public bool ExistMobile(string mobile)
		{
			if (String.IsNullOrEmpty(mobile) || mobile.Trim() == "")
			{
				throw new ArgumentException("参数不能为空", "mobile");
			}

			return dbUser.ExistMobile(mobile);
		}

		public void ModifyPassword(string username, string password, string newPassword)
		{
			var user = dbUser.GetUser(username);
			if (user == null)
			{
				throw new Exception("用户不存在");
			}

            var md5Password = MD5Hasher.GetMD5HashString(password);
            if (user.PasswordHash.Length != 0 && md5Password != user.PasswordHash)
                throw new Exception("密码错误");
            else if (password != user.Password)
                throw new Exception("密码错误");

            user.Password = newPassword;
			user.PasswordHash = MD5Hasher.GetMD5HashString(newPassword);

			dbUser.UpdateUser(user);
		}

		#endregion
	}
}
