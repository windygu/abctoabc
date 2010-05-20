using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebBasics.Utilities;
using YouTong.Common;
using YouTong.Model;

namespace YouTong
{
	public class ChildService : BusinessBase, IChildService
	{
		/// <summary>
		/// ChildService实例
		/// </summary>
		public static readonly ChildService Instance = new ChildService();

		#region IChildService 成员

		public void AddChild(Child child)
		{
			child.ID = Comb.NewComb2();
			dbChild.AddChild(child);
		}

		public void UpdateChild(Child child)
		{
			dbChild.UpdateChild(child);
		}

		public void DeleteChild(Guid id)
		{
			dbChild.UpdateIsDeleted(new Guid[] { id }, true);
		}

		public void DeleteChilds(Guid[] ids)
		{
			dbChild.UpdateIsDeleted(ids, true);
		}

		public void ShiftDeleteChild(Guid id)
		{
			throw new NotImplementedException();
		}

		public void ShiftDeleteChilds(Guid[] ids)
		{
			throw new NotImplementedException();
		}

		public Child GetChild(Guid id)
		{
			return dbChild.GetChild(id);
		}

		public IList<Child> GetChilds(params Guid[] ids)
		{
			return dbChild.GetChilds(ids);
		}

		public IList<Child> GetChildsByParent(Guid parentId)
		{
			return dbChild.GetChildsByParent(parentId);
		}

		public IList<Child> GetChilds(int pageIndex, int pageSize)
		{
			return dbChild.GetChilds(pageIndex, pageSize);
		}

		public IList<Child> GetDeletedChilds(int pageIndex, int pageSize)
		{
			return dbChild.GetDeletedChilds(pageIndex, pageSize);
		}

		public int GetChildCountByParent(Guid parentId)
		{
			return dbChild.GetChildCountByParent(parentId);
		}

		public int GetChildCount()
		{
			return dbChild.GetChildCount();
		}

		public int GetDeletedChildCount()
		{
			return dbChild.GetDeletedChildCount();
		}

		public Child GetFirstChild(Guid parentId)
		{
			var childs = UtFactory.Instance.ChildService.GetChildsByParent(parentId);
			return childs.Count == 0 ? null : childs[0];
		}

		#endregion

	}
}
