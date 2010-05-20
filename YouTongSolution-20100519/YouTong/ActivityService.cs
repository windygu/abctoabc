using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebBasics.Utilities;
using YouTong.Common;
using YouTong.Model;

namespace YouTong
{
	/// <summary>
	/// 活动 服务
	/// </summary>
	public class ActivityService : BusinessBase, IActivityService
	{
		#region IActivityService 成员

		public void AddActivity(Activity activity)
		{
			activity.ID = Comb.NewComb2();
			dbActivity.AddActivity(activity);
		}

		public void UpdateActivity(Activity activity)
		{
			dbActivity.UpdateActivity(activity);
		}

		public void DeleteActivity(Guid id)
		{
			dbActivity.UpdateIsDeleted(new Guid[] { id }, true);
		}

		public void DeleteActivities(params Guid[] ids)
		{
			dbActivity.UpdateIsDeleted(ids, true);
		}

		public void ShiftDeleteChild(Guid id)
		{
			throw new NotImplementedException();
		}

		public void ShiftDeleteChilds(Guid[] ids)
		{
			throw new NotImplementedException();
		}

		public Activity GetActivity(Guid id)
		{
			return dbActivity.GetActivity(id);
		}

		public IList<Activity> GetAllActivities()
		{
			return dbActivity.GetAllActivities();
		}

		public IList<Activity> GetActivities(int pageIndex, int pageSize)
		{
			return dbActivity.GetActivities(pageIndex, pageSize);
		}

		public IList<Activity> GetDeletedActivities(int pageIndex, int pageSize)
		{
			return dbActivity.GetDeletedActivities(pageIndex, pageSize);
		}

		public int GetActivityCount()
		{
			return dbActivity.GetActivityCount();
		}

		public int GetDeletedActivityCount()
		{
			return dbActivity.GetDeletedActivityCount();
		}

		#endregion
	}
}
