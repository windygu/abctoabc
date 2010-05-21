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
	/// 活动参与 服务
	/// </summary>
	public class ActivityJoined2Service : BusinessBase, IActivityJoined2Service
	{
		#region IActivityJoined2Service 成员

		public void AddActivityJoined2(ActivityJoined2 activityJoined2)
		{
			activityJoined2.ID = Comb.NewComb2();
			activityJoined2.Number = dbActivityJoined2.GetMaxNumber(activityJoined2.ActivityID) + 1;
			dbActivityJoined2.AddActivityJoined2(activityJoined2);
		}

		public void UpdateActivityJoined2(ActivityJoined2 activityJoined2)
		{
			dbActivityJoined2.UpdateActivityJoined2(activityJoined2);
		}

		public void DeleteActivityJoined2(Guid id)
		{
			dbActivityJoined2.UpdateIsDeleted(new Guid[] { id }, true);
		}

		public void DeleteActivities(params Guid[] ids)
		{
			dbActivityJoined2.UpdateIsDeleted(ids, true);
		}

		public void ShiftDeleteChild(Guid id)
		{
			throw new NotImplementedException();
		}

		public void ShiftDeleteChilds(Guid[] ids)
		{
			throw new NotImplementedException();
		}

		public ActivityJoined2 GetActivityJoined2(Guid id)
		{
			return dbActivityJoined2.GetActivityJoined2(id);
		}

		public ActivityJoined2 GetActivityJoined2(Guid activityId, Guid userId)
		{
			return dbActivityJoined2.GetActivityJoined2(activityId, userId);
		}

		public IList<ActivityJoined2> GetAllActivityJoined2s()
		{
			return dbActivityJoined2.GetAllActivities();
		}

		public IList<ActivityJoined2> GetActivityJoined2s(Guid activityId, int pageIndex, int pageSize)
		{
			return dbActivityJoined2.GetActivities(pageIndex, pageSize);
		}

		public IList<ActivityJoined2> GetDeletedActivities(Guid activityId, int pageIndex, int pageSize)
		{
			return dbActivityJoined2.GetDeletedActivities(pageIndex, pageSize);
		}

		public int GetActivityJoined2Count()
		{
			return dbActivityJoined2.GetActivityJoined2Count();
		}

		public int GetActivityJoined2Count(Guid activityId)
		{
			return dbActivityJoined2.GetActivityJoined2Count(activityId);
		}

		public int GetDeletedActivityJoined2Count()
		{
			return dbActivityJoined2.GetDeletedActivityJoined2Count();
		}

		public int GetDeletedActivityJoined2Count(Guid activityId)
		{
			return dbActivityJoined2.GetDeletedActivityJoined2Count(activityId);
		}

		public int GetMaxNumber(Guid activityId)
		{
			return dbActivityJoined2.GetMaxNumber(activityId);
		}

		#endregion
	}
}
