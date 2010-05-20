using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySoft.Data;
using WebBasics.Member.Model;
using WebBasics.Utilities;

namespace WebBasics.Member.Data
{
	/// <summary>
	/// 用户 数据操作
	/// </summary>
	public class DbUser
	{
		/// <summary>
		/// DbUser实例
		/// </summary>
		public static readonly DbUser Instance = new DbUser();

		DbSession dbSession = new DbSession("wb");
		readonly WhereClip NotDeleted = User._.IsDeleted == false;
		readonly WhereClip HasDeleted = User._.IsDeleted == true;

		/// <summary>
		/// 添加用户
		/// </summary>
		/// <param name="User">用户实体</param>
		/// <returns>返回影响行数</returns>
		public Int32 AddUser(User user)
		{
			user.Detach();

			if (user.ID == Guid.Empty) user.ID = Comb.NewComb2();
			if (user.AddTime == DateTime.MinValue) user.AddTime = DateTime.Now;
			if (user.UpdateTime == DateTime.MinValue) user.UpdateTime = DateTime.Now;
			if (user.LastLoginTime == DateTime.MinValue) user.LastLoginTime = DateTime.Parse("1899-1-1");
			return dbSession.Save<User>(user);
		}

		/// <summary>
		/// 修改用户
		/// </summary>
		/// <param name="User">用户实体</param>
		/// <returns>返回影响行数</returns>
		public Int32 UpdateUser(User user)
		{
			user.Attach();
			user.UpdateTime = DateTime.Now;
			return dbSession.Save<User>(user);
		}

		/// <summary>
		/// 删除用户
		/// </summary>
		/// <param name="id">用户编号</param>
		/// <returns>返回影响行数</returns>
		public Int32 DeleteUser(Guid id)
		{
			return dbSession.Delete<User>(id);
		}

		/// <summary>
		/// 删除用户
		/// </summary>
		/// <param name="ids">用户编号</param>
		/// <returns>返回影响行数</returns>
		public Int32 DeleteUsers(params Guid[] ids)
		{
			var where = User._.ID.In(ids);

			return dbSession.Delete<User>(where);
		}

		/// <summary>
		/// 更新删除标志。
		/// 如果删除标志值与需要设置的值相同，则不进行修改
		/// </summary>
		/// <param name="ids">用户编号，一个数组</param>
		/// <param name="isDeleted">删除标志值</param>
		/// <returns>返回影响行数</returns>
		public Int32 UpdateIsDeleted(Guid[] ids, Boolean isDeleted)
		{
			var where = User._.IsDeleted.In(ids) && User._.IsDeleted != isDeleted;

			return dbSession.Update<User>(
				new Field[] { User._.IsDeleted, User._.UpdateTime },
				new Object[] { isDeleted, DateTime.Now },
				where);
		}

		/// <summary>
		/// 获取用户
		/// </summary>
		/// <param name="id">用户编号</param>
		/// <returns>返回用户实体</returns>
		public User GetUser(Guid id)
		{
			return dbSession.Single<User>(id);
		}

		/// <summary>
		/// 获取用户，根据用户名
		/// </summary>
		/// <param name="username">用户名</param>
		/// <returns>返回用户实体</returns>
		public User GetUser(String username)
		{
			var where = User._.UserName == username;
			return dbSession.Single<User>(where);
		}

		/// <summary>
		/// 获取所有用户列表
		/// </summary>
		/// <returns>返回用户实体列表</returns>
		public IList<User> GetAllUsers()
		{
			var where = NotDeleted;
			return dbSession.From<User>()
				.Where(where).OrderBy(User._.AddTime.Asc)
				.ToList();
		}

		/// <summary>
		/// 获取用户
		/// </summary>
		/// <param name="ids">用户编号，一个数组</param>
		/// <returns>返回用户实体列表</returns>
		public IList<User> GetUsers(params Guid[] ids)
		{
			return dbSession.From<User>().Where(User._.ID.In(ids)).ToList();
		}

		/// <summary>
		/// 获取用户列表
		/// </summary>
		/// <param name="pageIndex">当前索引页</param>
		/// <param name="pageSize">每页记录数</param>
		/// <returns>返回用户实体列表</returns>
		public IList<User> GetUsers(int pageIndex, int pageSize)
		{
			WhereClip where = this.NotDeleted;

			return dbSession.From<User>()
				.Where(where).OrderBy(User._.AddTime.Desc)
				.GetPage(pageSize).ToList(pageIndex);
		}

		/// <summary>
		/// 获取已删除用户列表
		/// </summary>
		/// <param name="pageIndex">当前索引页</param>
		/// <param name="pageSize">每页记录数</param>
		/// <returns>返回已删除用户实体列表</returns>
		public IList<User> GetDeletedUsers(int pageIndex, int pageSize)
		{
			WhereClip where = this.HasDeleted;

			return dbSession.From<User>()
				.Where(where).OrderBy(User._.AddTime.Desc)
				.GetPage(pageSize).ToList(pageIndex);
		}

		/// <summary>
		/// 获取用户记录条数
		/// </summary>
		/// <returns>返回用户记录条数</returns>
		public Int32 GetUserCount()
		{
			WhereClip where = this.NotDeleted;

			return dbSession.From<User>()
				.Where(where).Count();
		}

		/// <summary>
		/// 获取已删除用户记录条数
		/// </summary>
		/// <returns>返回已删除用户记录条数</returns>
		public Int32 GetDeletedUserCount()
		{
			WhereClip where = this.HasDeleted;

			return dbSession.From<User>()
				.Where(where).Count();
		}

		/// <summary>
		/// 用户名是否存在
		/// </summary>
		/// <param name="username">用户名</param>
		/// <returns>如果存在，返回true；否则返回false</returns>
		public Boolean ExistUserName(string username)
		{
			return dbSession.Exists<User>(User._.UserName == username);
		}

		/// <summary>
		/// 邮箱是否存在
		/// </summary>
		/// <param name="email">邮箱</param>
		/// <returns>如果存在，返回true；否则返回false</returns>
		public Boolean ExistEmail(string email)
		{
			return dbSession.Exists<User>(User._.Email == email);
		}

		/// <summary>
		/// 手机是否存在
		/// </summary>
		/// <param name="mobile">手机</param>
		/// <returns>如果存在，返回true；否则返回false</returns>
		public Boolean ExistMobile(string mobile)
		{
			return dbSession.Exists<User>(User._.Mobile == mobile);
		}
	}
}
