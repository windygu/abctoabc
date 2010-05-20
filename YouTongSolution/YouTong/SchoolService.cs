using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouTong.Common;
using YouTong.Model;

namespace YouTong
{
	public class SchoolService : BusinessBase, ISchoolService
	{
		/// <summary>
		/// SchoolService实例
		/// </summary>
		public static readonly ChildService Instance = new ChildService();

		#region ISchoolService 成员

		public void AddSchool(School School)
		{
			dbSchool.AddSchool(School);
		}

		public void UpdateSchool(School School)
		{
			dbSchool.UpdateSchool(School);
		}

		public void DeleteSchool(int id)
		{
			dbSchool.UpdateIsDeleted(new Int32[] { id }, true);
		}

		public void DeleteSchools(params int[] ids)
		{
			dbSchool.UpdateIsDeleted(ids, true);
		}

		public void ShiftDeleteChild(int id)
		{
			throw new NotImplementedException();
		}

		public void ShiftDeleteChilds(int[] ids)
		{
			throw new NotImplementedException();
		}

		public School GetSchool(int id)
		{
			return dbSchool.GetSchool(id);
		}

		public IList<School> GetAllSchools()
		{
			return dbSchool.GetAllSchools();
		}

		public IList<School> GetSchools(int pageIndex, int pageSize)
		{
			return dbSchool.GetSchools(pageIndex, pageSize);
		}

		public IList<School> GetDeletedSchools(int pageIndex, int pageSize)
		{
			return dbSchool.GetDeletedSchools(pageIndex, pageSize);
		}

		public int GetSchoolCount()
		{
			return dbSchool.GetSchoolCount();
		}

		public int GetDeletedSchoolCount()
		{
			return dbSchool.GetDeletedSchoolCount();
		}

		#endregion
	}
}
