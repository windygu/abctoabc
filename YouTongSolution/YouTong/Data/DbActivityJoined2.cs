using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySoft.Data;
using YouTong.Model;

namespace YouTong.Data
{
	public class DbActivityJoined2
	{
		/// <summary>
		/// ActivityJoined2 实例
		/// </summary>
		public static readonly ActivityJoined2 Instance = new ActivityJoined2();

		DbSession dbSession = new DbSession("ut");
		readonly WhereClip NotDeleted = ActivityJoined2._.IsDeleted == false;
		readonly WhereClip HasDeleted = ActivityJoined2._.IsDeleted == true;

		/// <summary>
		/// 添加活动
		/// </summary>
		/// <param name="ActivityJoined2">活动实体</param>
		/// <returns>返回影响行数</returns>
		public Int32 AddActivityJoined2(ActivityJoined2 activityJoined2)
		{
			activityJoined2.Detach();

			activityJoined2.AddTime = DateTime.Now;
			activityJoined2.UpdateTime = DateTime.Now;
			return dbSession.Save<ActivityJoined2>(activityJoined2);
		}

		/// <summary>
		/// 修改活动
		/// </summary>
		/// <param name="ActivityJoined2">活动实体</param>
		/// <returns>返回影响行数</returns>
		public Int32 UpdateActivityJoined2(ActivityJoined2 activityJoined2)
		{
			activityJoined2.Attach();
			activityJoined2.UpdateTime = DateTime.Now;
			return dbSession.Save<ActivityJoined2>(activityJoined2);
		}

		/// <summary>
		/// 删除活动
		/// </summary>
		/// <param name="id">活动编号</param>
		/// <returns>返回影响行数</returns>
		public Int32 DeleteActivityJoined2(Guid id)
		{
			return dbSession.Delete<ActivityJoined2>(id);
		}

		/// <summary>
		/// 删除活动
		/// </summary>
		/// <param name="ids">活动编号</param>
		/// <returns>返回影响行数</returns>
		public Int32 DeleteActivities(params Guid[] ids)
		{
			var where = ActivityJoined2._.ID.In(ids);

			return dbSession.Delete<ActivityJoined2>(where);
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
			var where = ActivityJoined2._.IsDeleted.In(ids) && ActivityJoined2._.IsDeleted != isDeleted;

			return dbSession.Update<ActivityJoined2>(
				new Field[] { ActivityJoined2._.IsDeleted, ActivityJoined2._.UpdateTime },
				new Object[] { isDeleted, DateTime.Now },
				where);
		}

		/// <summary>
		/// 获取活动
		/// </summary>
		/// <param name="id">活动编号</param>
		/// <returns>返回活动实体</returns>
		public ActivityJoined2 GetActivityJoined2(Guid id)
		{
			return dbSession.Single<ActivityJoined2>(id);
		}

		/// <summary>
		/// 获取活动参与信息
		/// </summary>
		/// <param name="activityId">活动编号</param>
		/// <param name="userId">用户编号</param>
		/// <returns></returns>
		public ActivityJoined2 GetActivityJoined2(Guid activityId, Guid userId)
		{
			return dbSession.Single<ActivityJoined2>(ActivityJoined2._.ActivityID == activityId && ActivityJoined2._.UserID == userId);
		}

		/// <summary>
		/// 获取所有活动列表
		/// </summary>
		/// <returns>返回活动实体列表</returns>
		public IList<ActivityJoined2> GetAllActivities()
		{
			var where = NotDeleted;
			return dbSession.From<ActivityJoined2>()
				.Where(where).OrderBy(ActivityJoined2._.AddTime.Asc)
				.ToList();
		}

		/// <summary>
		/// 获取活动列表
		/// </summary>
		/// <param name="pageIndex">当前索引页</param>
		/// <param name="pageSize">每页记录数</param>
		/// <returns>返回活动实体列表</returns>
		public IList<ActivityJoined2> GetActivities(int pageIndex, int pageSize)
		{
			WhereClip where = this.NotDeleted;

			return dbSession.From<ActivityJoined2>()
				.Where(where).OrderBy(ActivityJoined2._.AddTime.Desc)
				.GetPage(pageSize).ToList(pageIndex);
		}

		/// <summary>
		/// 获取已删除活动列表
		/// </summary>
		/// <param name="pageIndex">当前索引页</param>
		/// <param name="pageSize">每页记录数</param>
		/// <returns>返回已删除活动实体列表</returns>
		public IList<ActivityJoined2> GetDeletedActivities(int pageIndex, int pageSize)
		{
			WhereClip where = this.HasDeleted;

			return dbSession.From<ActivityJoined2>()
				.Where(where).OrderBy(ActivityJoined2._.AddTime.Desc)
				.GetPage(pageSize).ToList(pageIndex);
		}

		/// <summary>
		/// 获取活动记录条数
		/// </summary>
		/// <returns>返回活动记录条数</returns>
		public Int32 GetActivityJoined2Count()
		{
			WhereClip where = this.NotDeleted;

			return dbSession.From<ActivityJoined2>()
				.Where(where).Count();
		}

		/// <summary>
		/// 获取活动参与记录条数
		/// </summary>
		/// <param name="activityId">活动编号</param>
		/// <returns>返回活动参与记录条数</returns>
		public int GetActivityJoined2Count(Guid activityId)
		{
			WhereClip where = this.NotDeleted && ActivityJoined2._.ActivityID == activityId;

			return dbSession.From<ActivityJoined2>()
				.Where(where).Count();
		}

		/// <summary>
		/// 获取已删除活动记录条数
		/// </summary>
		/// <returns>返回已删除活动记录条数</returns>
		public Int32 GetDeletedActivityJoined2Count()
		{
			WhereClip where = this.HasDeleted;

			return dbSession.From<ActivityJoined2>()
				.Where(where).Count();
		}


		/// <summary>
		/// 获取已删除活动记录条数
		/// </summary>
		/// <param name="activityId">活动编号</param>
		/// <returns>返回已删除活动记录条数</returns>
		public int GetDeletedActivityJoined2Count(Guid activityId)
		{
			WhereClip where = this.HasDeleted && ActivityJoined2._.ActivityID == activityId;

			return dbSession.From<ActivityJoined2>()
				.Where(where).Count();
		}

		/// <summary>
		///	某一个活动当前最大活动序号
		/// </summary>
		/// <param name="activityId">活动编号</param>
		/// <returns></returns>
		public Int32 GetMaxNumber(Guid activityId)
		{
			var v = dbSession.Max<ActivityJoined2>(ActivityJoined2._.Number, ActivityJoined2._.ActivityID == activityId);

			return v == null ? 0 : (Int32)v;
		}
	}
}
