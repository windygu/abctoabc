using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouTong.Model;

namespace YouTong.Common
{
	/// <summary>
	/// 活动 接口
	/// </summary>
	public interface IActivityService
	{
		/// <summary>
		/// 添加活动
		/// </summary>
		/// <param name="Activity">活动实体</param>
		/// <returns>返回影响行数</returns>
		void AddActivity(Activity activity);

		/// <summary>
		/// 修改活动
		/// </summary>
		/// <param name="Activity">活动实体</param>
		/// <returns>返回影响行数</returns>
		void UpdateActivity(Activity activity);

		/// <summary>
		/// 删除活动
		/// </summary>
		/// <param name="id">活动编号</param>
		/// <returns>返回影响行数</returns>
		void DeleteActivity(Guid id);

		/// <summary>
		/// 删除活动
		/// </summary>
		/// <param name="ids">活动编号</param>
		/// <returns>返回影响行数</returns>
		void DeleteActivities(params Guid[] ids);

		/// <summary>
		/// 彻底删除频道
		/// </summary>
		/// <param name="id">频道编号</param>
		void ShiftDeleteChild(Guid id);

		/// <summary>
		/// 彻底删除频道
		/// </summary>
		/// <param name="ids">频道编号，一个数组</param>
		void ShiftDeleteChilds(Guid[] ids);

		/// <summary>
		/// 获取活动
		/// </summary>
		/// <param name="id">活动编号</param>
		/// <returns>返回活动实体</returns>
		Activity GetActivity(Guid id);

		/// <summary>
		/// 获取所有活动列表
		/// </summary>
		/// <returns>返回活动实体列表</returns>
		IList<Activity> GetAllActivities();

		/// <summary>
		/// 获取活动列表
		/// </summary>
		/// <param name="pageIndex">当前索引页</param>
		/// <param name="pageSize">每页记录数</param>
		/// <returns>返回活动实体列表</returns>
		IList<Activity> GetActivities(Int32 pageIndex, Int32 pageSize);

		/// <summary>
		/// 获取已删除活动列表
		/// </summary>
		/// <param name="pageIndex">当前索引页</param>
		/// <param name="pageSize">每页记录数</param>
		/// <returns>返回已删除活动实体列表</returns>
		IList<Activity> GetDeletedActivities(Int32 pageIndex, Int32 pageSize);

		/// <summary>
		/// 获取活动记录条数
		/// </summary>
		/// <returns>返回活动记录条数</returns>
		Int32 GetActivityCount();

		/// <summary>
		/// 获取已删除活动记录条数
		/// </summary>
		/// <returns>返回已删除活动记录条数</returns>
		Int32 GetDeletedActivityCount();
	}
}
