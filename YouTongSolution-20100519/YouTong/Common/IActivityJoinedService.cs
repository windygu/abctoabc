using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouTong.Model;

namespace YouTong.Common
{
	/// <summary>
	/// 活动参与 接口
	/// </summary>
	public interface IActivityJoinedService
	{
		/// <summary>
		/// 添加活动参与
		/// </summary>
		/// <param name="ActivityJoined">活动参与实体</param>
		/// <returns>返回影响行数</returns>
		void AddActivityJoined(ActivityJoined activityJoined);

		/// <summary>
		/// 修改活动参与
		/// </summary>
		/// <param name="ActivityJoined">活动参与实体</param>
		/// <returns>返回影响行数</returns>
		void UpdateActivityJoined(ActivityJoined activityJoined);

		/// <summary>
		/// 删除活动参与
		/// </summary>
		/// <param name="id">活动参与编号</param>
		/// <returns>返回影响行数</returns>
		void DeleteActivityJoined(Guid id);

		/// <summary>
		/// 删除活动参与
		/// </summary>
		/// <param name="ids">活动参与编号</param>
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
		/// 获取活动参与
		/// </summary>
		/// <param name="id">活动参与编号</param>
		/// <returns>返回活动参与实体</returns>
		ActivityJoined GetActivityJoined(Guid id);

		/// <summary>
		/// 获取活动参与信息
		/// </summary>
		/// <param name="activityId">活动编号</param>
		/// <param name="userId">用户编号</param>
		/// <returns></returns>
		ActivityJoined GetActivityJoined(Guid activityId, Guid userId);

		/// <summary>
		/// 获取所有活动参与列表
		/// </summary>
		/// <returns>返回活动参与实体列表</returns>
		IList<ActivityJoined> GetAllActivityJoineds();

		/// <summary>
		/// 获取活动参与列表
		/// </summary>
		/// <param name="pageIndex">当前索引页</param>
		/// <param name="pageSize">每页记录数</param>
		/// <returns>返回活动参与实体列表</returns>
		IList<ActivityJoined> GetActivityJoineds(Int32 pageIndex, Int32 pageSize);

		/// <summary>
		/// 获取已删除活动参与列表
		/// </summary>
		/// <param name="pageIndex">当前索引页</param>
		/// <param name="pageSize">每页记录数</param>
		/// <returns>返回已删除活动参与实体列表</returns>
		IList<ActivityJoined> GetDeletedActivities(Int32 pageIndex, Int32 pageSize);

		/// <summary>
		/// 获取活动参与记录条数
		/// </summary>
		/// <returns>返回活动参与记录条数</returns>
		Int32 GetActivityJoinedCount();

		/// <summary>
		/// 获取活动参与记录条数
		/// </summary>
		/// <param name="activityId">活动编号</param>
		/// <returns>返回活动参与记录条数</returns>
		Int32 GetActivityJoinedCount(Guid activityId);

		/// <summary>
		/// 获取已删除活动参与记录条数
		/// </summary>
		/// <returns>返回已删除活动参与记录条数</returns>
		Int32 GetDeletedActivityJoinedCount();

		/// <summary>
		/// 获取已删除活动参与记录条数
		/// </summary>
		/// <param name="activityId">活动编号</param>
		/// <returns>返回已删除活动参与记录条数</returns>
		Int32 GetDeletedActivityJoinedCount(Guid activityId);

		/// <summary>
		///	某一个活动当前最大活动序号
		/// </summary>
		/// <param name="activityId">活动编号</param>
		/// <returns></returns>
		Int32 GetMaxNumber(Guid activityId);
	}
}
