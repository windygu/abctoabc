using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySoft.Data;
using YouTong.Model;

namespace YouTong.Data
{
	public class DbActivity
	{
		/// <summary>
		/// DbActivity实例
		/// </summary>
		public static readonly DbActivity Instance = new DbActivity();

		DbSession dbSession = new DbSession("ut");
		readonly WhereClip NotDeleted = Activity._.IsDeleted == false;
		readonly WhereClip HasDeleted = Activity._.IsDeleted == true;

		/// <summary>
		/// 添加学校
		/// </summary>
		/// <param name="Activity">学校实体</param>
		/// <returns>返回影响行数</returns>
		public Int32 AddActivity(Activity activity)
		{
			activity.Detach();

			activity.AddTime = DateTime.Now;
			activity.UpdateTime = DateTime.Now;
			return dbSession.Save<Activity>(activity);
		}

		/// <summary>
		/// 修改学校
		/// </summary>
		/// <param name="Activity">学校实体</param>
		/// <returns>返回影响行数</returns>
		public Int32 UpdateActivity(Activity activity)
		{
			activity.Attach();
			activity.UpdateTime = DateTime.Now;
			return dbSession.Save<Activity>(activity);
		}

		/// <summary>
		/// 删除学校
		/// </summary>
		/// <param name="id">学校编号</param>
		/// <returns>返回影响行数</returns>
		public Int32 DeleteActivity(Guid id)
		{
			return dbSession.Delete<Activity>(id);
		}

		/// <summary>
		/// 删除学校
		/// </summary>
		/// <param name="ids">学校编号</param>
		/// <returns>返回影响行数</returns>
		public Int32 DeleteActivities(params Guid[] ids)
		{
			var where = Activity._.ID.In(ids);

			return dbSession.Delete<Activity>(where);
		}

		/// <summary>
		/// 更新删除标志。
		/// 如果删除标志值与需要设置的值相同，则不进行修改
		/// </summary>
		/// <param name="ids">学校编号，一个数组</param>
		/// <param name="isDeleted">删除标志值</param>
		/// <returns>返回影响行数</returns>
		public Int32 UpdateIsDeleted(Guid[] ids, Boolean isDeleted)
		{
			var where = Activity._.IsDeleted.In(ids) && Activity._.IsDeleted != isDeleted;

			return dbSession.Update<Activity>(
				new Field[] { Activity._.IsDeleted, Activity._.UpdateTime },
				new Object[] { isDeleted, DateTime.Now },
				where);
		}

		/// <summary>
		/// 获取学校
		/// </summary>
		/// <param name="id">学校编号</param>
		/// <returns>返回学校实体</returns>
		public Activity GetActivity(Guid id)
		{
			return dbSession.Single<Activity>(id);
		}

		/// <summary>
		/// 获取所有学校列表
		/// </summary>
		/// <returns>返回学校实体列表</returns>
		public IList<Activity> GetAllActivities()
		{
			var where = NotDeleted;
			return dbSession.From<Activity>()
				.Where(where).OrderBy(Activity._.AddTime.Asc)
				.ToList();
		}

		/// <summary>
		/// 获取学校列表
		/// </summary>
		/// <param name="pageIndex">当前索引页</param>
		/// <param name="pageSize">每页记录数</param>
		/// <returns>返回学校实体列表</returns>
		public IList<Activity> GetActivities(int pageIndex, int pageSize)
		{
			WhereClip where = this.NotDeleted;

			return dbSession.From<Activity>()
				.Where(where).OrderBy(Activity._.AddTime.Desc)
				.GetPage(pageSize).ToList(pageIndex);
		}

		/// <summary>
		/// 获取已删除学校列表
		/// </summary>
		/// <param name="pageIndex">当前索引页</param>
		/// <param name="pageSize">每页记录数</param>
		/// <returns>返回已删除学校实体列表</returns>
		public IList<Activity> GetDeletedActivities(int pageIndex, int pageSize)
		{
			WhereClip where = this.HasDeleted;

			return dbSession.From<Activity>()
				.Where(where).OrderBy(Activity._.AddTime.Desc)
				.GetPage(pageSize).ToList(pageIndex);
		}

		/// <summary>
		/// 获取学校记录条数
		/// </summary>
		/// <returns>返回学校记录条数</returns>
		public Int32 GetActivityCount()
		{
			WhereClip where = this.NotDeleted;

			return dbSession.From<Activity>()
				.Where(where).Count();
		}

		/// <summary>
		/// 获取已删除学校记录条数
		/// </summary>
		/// <returns>返回已删除学校记录条数</returns>
		public Int32 GetDeletedActivityCount()
		{
			WhereClip where = this.HasDeleted;

			return dbSession.From<Activity>()
				.Where(where).Count();
		}
	}
}
