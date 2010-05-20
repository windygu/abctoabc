using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebBasics.Member.Model;

namespace WebBasics.Member.Common
{
	public interface IUserService
	{
		/// <summary>
		/// 添加频道
		/// </summary>
		/// <param name="User">频道实体</param>
		void AddUser(User user);

		/// <summary>
		/// 修改频道
		/// </summary>
		/// <param name="User">频道实体</param>
		void UpdateUser(User user);

		/// <summary>
		/// 删除频道
		/// </summary>
		/// <param name="id">频道编号</param>
		void DeleteUser(Guid id);

		/// <summary>
		/// 删除频道
		/// </summary>
		/// <param name="ids">频道编号，一个数组</param>
		void DeleteUsers(Guid[] ids);

		/// <summary>
		/// 彻底删除频道
		/// </summary>
		/// <param name="id">频道编号</param>
		void ShiftDeleteUser(Guid id);

		/// <summary>
		/// 彻底删除频道
		/// </summary>
		/// <param name="ids">频道编号，一个数组</param>
		void ShiftDeleteUsers(Guid[] ids);

		/// <summary>
		/// 获取频道
		/// </summary>
		/// <param name="id">频道编号</param>
		/// <returns>返回频道实体</returns>
		User GetUser(Guid id);

		/// <summary>
		/// 获取用户，根据用户名
		/// </summary>
		/// <param name="username">用户名</param>
		/// <returns>返回用户实体</returns>
		User GetUser(String username);

		/// <summary>
		/// 获取用户
		/// </summary>
		/// <param name="ids">用户编号，一个数组</param>
		/// <returns>返回用户实体列表</returns>
		IList<User> GetUsers(params Guid[] ids);

		/// <summary>
		/// 获取用户列表
		/// </summary>
		/// <param name="pageIndex">当前索引页</param>
		/// <param name="pageSize">每页记录数</param>
		/// <returns>返回用户实体列表</returns>
		IList<User> GetUsers(int pageIndex, int pageSize);

		/// <summary>
		/// 获取已删除用户列表
		/// </summary>
		/// <param name="pageIndex">当前索引页</param>
		/// <param name="pageSize">每页记录数</param>
		/// <returns>返回已删除用户实体列表</returns>
		IList<User> GetDeletedUsers(int pageIndex, int pageSize);

		/// <summary>
		/// 获取用户记录条数
		/// </summary>
		/// <returns>返回用户记录条数</returns>
		Int32 GetUserCount();

		/// <summary>
		/// 获取已删除用户记录条数
		/// </summary>
		/// <returns>返回已删除用户记录条数</returns>
		Int32 GetDeletedUserCount();

		/// <summary>
		/// 用户名是否存在
		/// </summary>
		/// <param name="username">用户名</param>
		/// <returns>如果存在，返回true；否则返回false</returns>
		Boolean ExistUserName(string username);

		/// <summary>
		/// 邮箱是否存在
		/// </summary>
		/// <param name="email">邮箱</param>
		/// <returns>如果存在，返回true；否则返回false</returns>
		Boolean ExistEmail(string email);

		/// <summary>
		/// 手机是否存在
		/// </summary>
		/// <param name="mobile">手机</param>
		/// <returns>如果存在，返回true；否则返回false</returns>
		Boolean ExistMobile(string mobile);

		/// <summary>
		/// 修改密码
		/// </summary>
		/// <param name="username">用户名</param>
		/// <param name="password">密码</param>
		/// <param name="newPassword">新你妈</param>
		/// <returns></returns>
		void ModifyPassword(String username, String password, String newPassword);
	}
}
