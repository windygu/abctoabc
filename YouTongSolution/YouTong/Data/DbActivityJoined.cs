using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySoft.Data;
using YouTong.Model;

namespace YouTong.Data
{
	public class DbActivityJoined
	{
		/// <summary>
		/// DbActivityJoined实例
		/// </summary>
		public static readonly DbActivityJoined Instance = new DbActivityJoined();

		DbSession dbSession = new DbSession("ut");
		readonly WhereClip NotDeleted = ActivityJoined._.IsDeleted == false;
		readonly WhereClip HasDeleted = ActivityJoined._.IsDeleted == true;

		/// <summary>
		/// 添加活动
		/// </summary>
		/// <param name="ActivityJoined">活动实体</param>
		/// <returns>返回影响行数</returns>
		public Int32 AddActivityJoined(ActivityJoined activityJoined)
		{
			activityJoined.Detach();

			activityJoined.AddTime = DateTime.Now;
			activityJoined.UpdateTime = DateTime.Now;
			return dbSession.Save<ActivityJoined>(activityJoined);
		}

		/// <summary>
		/// 修改活动
		/// </summary>
		/// <param name="ActivityJoined">活动实体</param>
		/// <returns>返回影响行数</returns>
		public Int32 UpdateActivityJoined(ActivityJoined activityJoined)
		{
			activityJoined.Attach();
			activityJoined.UpdateTime = DateTime.Now;
			return dbSession.Save<ActivityJoined>(activityJoined);
		}

		/// <summary>
		/// 删除活动
		/// </summary>
		/// <param name="id">活动编号</param>
		/// <returns>返回影响行数</returns>
		public Int32 DeleteActivityJoined(Guid id)
		{
			return dbSession.Delete<ActivityJoined>(id);
		}

		/// <summary>
		/// 删除活动
		/// </summary>
		/// <param name="ids">活动编号</param>
		/// <returns>返回影响行数</returns>
		public Int32 DeleteActivities(params Guid[] ids)
		{
			var where = ActivityJoined._.ID.In(ids);

			return dbSession.Delete<ActivityJoined>(where);
		}

		/// <summary>
		/// 更新删除标志。
		/// 如果删除标志值与需要设置的值相同，则不进行修改
		/// </summary>
		/// <param name="ids">活动编号，一个数组</param>
		/// <param name="isDeleted">删除标志值</param>
		/// <returns>返回影响行数</returns>
		public Int32 UpdateIsDeleted(Guid[] ids, Boolean isDeleted)
		{
			var where = ActivityJoined._.IsDeleted.In(ids) && ActivityJoined._.IsDeleted != isDeleted;

			return dbSession.Update<ActivityJoined>(
				new Field[] { ActivityJoined._.IsDeleted, ActivityJoined._.UpdateTime },
				new Object[] { isDeleted, DateTime.Now },
				where);
		}

		/// <summary>
		/// 获取活动
		/// </summary>
		/// <param name="id">活动编号</param>
		/// <returns>返回活动实体</returns>
		public ActivityJoined GetActivityJoined(Guid id)
		{
			return dbSession.Single<ActivityJoined>(id);
		}

		/// <summary>
		/// 获取活动参与信息
		/// </summary>
		/// <param name="activityId">活动编号</param>
		/// <param name="userId">用户编号</param>
		/// <returns></returns>
		public ActivityJoined GetActivityJoined(Guid activityId, Guid userId)
		{
			return dbSession.Single<ActivityJoined>(ActivityJoined._.ActivityID == activityId && ActivityJoined._.UserID == userId);
		}

		/// <summary>
		/// 获取所有活动列表
		/// </summary>
		/// <returns>返回活动实体列表</returns>
		public IList<ActivityJoined> GetAllActivities()
		{
			var where = NotDeleted;
			return dbSession.From<ActivityJoined>()
				.Where(where).OrderBy(ActivityJoined._.AddTime.Asc)
				.ToList();
		}

		/// <summary>
		/// 获取活动列表
		/// </summary>
		/// <param name="pageIndex">当前索引页</param>
		/// <param name="pageSize">每页记录数</param>
		/// <returns>返回活动实体列表</returns>
		public IList<ActivityJoined> GetActivities(int pageIndex, int pageSize)
		{
			WhereClip where = this.NotDeleted;

			return dbSession.From<ActivityJoined>()
				.Where(where).OrderBy(ActivityJoined._.AddTime.Desc)
				.GetPage(pageSize).ToList(pageIndex);
		}

		/// <summary>
		/// 获取已删除活动列表
		/// </summary>
		/// <param name="pageIndex">当前索引页</param>
		/// <param name="pageSize">每页记录数</param>
		/// <returns>返回已删除活动实体列表</returns>
		public IList<ActivityJoined> GetDeletedActivities(int pageIndex, int pageSize)
		{
			WhereClip where = this.HasDeleted;

			return dbSession.From<ActivityJoined>()
				.Where(where).OrderBy(ActivityJoined._.AddTime.Desc)
				.GetPage(pageSize).ToList(pageIndex);
		}

		/// <summary>
		/// 获取活动记录条数
		/// </summary>
		/// <returns>返回活动记录条数</returns>
		public Int32 GetActivityJoinedCount()
		{
			WhereClip where = this.NotDeleted;

			return dbSession.From<ActivityJoined>()
				.Where(where).Count();
		}

		/// <summary>
		/// 获取活动参与记录条数
		/// </summary>
		/// <param name="activityId">活动编号</param>
		/// <returns>返回活动参与记录条数</returns>
		public int GetActivityJoinedCount(Guid activityId)
		{
			WhereClip where = this.NotDeleted && ActivityJoined._.ActivityID == activityId;

			return dbSession.From<ActivityJoined>()
				.Where(where).Count();
		}

		/// <summary>
		/// 获取已删除活动记录条数
		/// </summary>
		/// <returns>返回已删除活动记录条数</returns>
		public Int32 GetDeletedActivityJoinedCount()
		{
			WhereClip where = this.HasDeleted;

			return dbSession.From<ActivityJoined>()
				.Where(where).Count();
		}


		/// <summary>
		/// 获取已删除活动记录条数
		/// </summary>
		/// <param name="activityId">活动编号</param>
		/// <returns>返回已删除活动记录条数</returns>
		public int GetDeletedActivityJoinedCount(Guid activityId)
		{
			WhereClip where = this.HasDeleted && ActivityJoined._.ActivityID == activityId;

			return dbSession.From<ActivityJoined>()
				.Where(where).Count();
		}

		/// <summary>
		///	某一个活动当前最大活动序号
		/// </summary>
		/// <param name="activityId">活动编号</param>
		/// <returns></returns>
		public Int32 GetMaxNumber(Guid activityId)
		{
			var v = dbSession.Max<ActivityJoined>(ActivityJoined._.Number, ActivityJoined._.ActivityID == activityId);

			return v == null ? 0 : (Int32)v;
		}
	}
}
