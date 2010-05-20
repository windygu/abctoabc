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
	public class ActivityJoinedService : BusinessBase, IActivityJoinedService
	{
		#region IActivityJoinedService 成员

		public void AddActivityJoined(ActivityJoined activityJoined)
		{
			activityJoined.ID = Comb.NewComb2();
			activityJoined.Number = dbActivityJoined.GetMaxNumber(activityJoined.ActivityID) + 1;
			dbActivityJoined.AddActivityJoined(activityJoined);
		}

		public void UpdateActivityJoined(ActivityJoined activityJoined)
		{
			dbActivityJoined.UpdateActivityJoined(activityJoined);
		}

		public void DeleteActivityJoined(Guid id)
		{
			dbActivityJoined.UpdateIsDeleted(new Guid[] { id }, true);
		}

		public void DeleteActivities(params Guid[] ids)
		{
			dbActivityJoined.UpdateIsDeleted(ids, true);
		}

		public void ShiftDeleteChild(Guid id)
		{
			throw new NotImplementedException();
		}

		public void ShiftDeleteChilds(Guid[] ids)
		{
			throw new NotImplementedException();
		}

		public ActivityJoined GetActivityJoined(Guid id)
		{
			return dbActivityJoined.GetActivityJoined(id);
		}

		public ActivityJoined GetActivityJoined(Guid activityId, Guid userId)
		{
			return dbActivityJoined.GetActivityJoined(activityId, userId);
		}

		public IList<ActivityJoined> GetAllActivityJoineds()
		{
			return dbActivityJoined.GetAllActivities();
		}

		public IList<ActivityJoined> GetActivityJoineds(int pageIndex, int pageSize)
		{
			return dbActivityJoined.GetActivities(pageIndex, pageSize);
		}

		public IList<ActivityJoined> GetDeletedActivities(int pageIndex, int pageSize)
		{
			return dbActivityJoined.GetDeletedActivities(pageIndex, pageSize);
		}

		public int GetActivityJoinedCount()
		{
			return dbActivityJoined.GetActivityJoinedCount();
		}

		public int GetActivityJoinedCount(Guid activityId)
		{
			return dbActivityJoined.GetActivityJoinedCount(activityId);
		}

		public int GetDeletedActivityJoinedCount()
		{
			return dbActivityJoined.GetDeletedActivityJoinedCount();
		}

		public int GetDeletedActivityJoinedCount(Guid activityId)
		{
			return dbActivityJoined.GetDeletedActivityJoinedCount(activityId);
		}

		public int GetMaxNumber(Guid activityId)
		{
			return dbActivityJoined.GetMaxNumber(activityId);
		}

		#endregion
	}
}
