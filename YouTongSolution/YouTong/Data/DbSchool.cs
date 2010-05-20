using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySoft.Data;
using YouTong.Model;

namespace YouTong.Data
{
	public class DbSchool
	{
		/// <summary>
		/// DbSchool实例
		/// </summary>
		public static readonly DbSchool Instance = new DbSchool();

		DbSession dbSession = new DbSession("ut");
		readonly WhereClip NotDeleted = School._.IsDeleted == false;
		readonly WhereClip HasDeleted = School._.IsDeleted == true;

		/// <summary>
		/// 添加学校
		/// </summary>
		/// <param name="School">学校实体</param>
		/// <returns>返回影响行数</returns>
		public Int32 AddSchool(School school)
		{
			school.Detach();

			school.AddTime = DateTime.Now;
			school.UpdateTime = DateTime.Now;
			return dbSession.Save<School>(school);
		}

		/// <summary>
		/// 修改学校
		/// </summary>
		/// <param name="School">学校实体</param>
		/// <returns>返回影响行数</returns>
		public Int32 UpdateSchool(School school)
		{
			school.Attach();
			school.UpdateTime = DateTime.Now;
			return dbSession.Save<School>(school);
		}

		/// <summary>
		/// 删除学校
		/// </summary>
		/// <param name="id">学校编号</param>
		/// <returns>返回影响行数</returns>
		public Int32 DeleteSchool(Int32 id)
		{
			return dbSession.Delete<School>(id);
		}

		/// <summary>
		/// 删除学校
		/// </summary>
		/// <param name="ids">学校编号</param>
		/// <returns>返回影响行数</returns>
		public Int32 DeleteSchools(params Int32[] ids)
		{
			var where = School._.ID.In(ids);

			return dbSession.Delete<School>(where);
		}

		/// <summary>
		/// 更新删除标志。
		/// 如果删除标志值与需要设置的值相同，则不进行修改
		/// </summary>
		/// <param name="ids">学校编号，一个数组</param>
		/// <param name="isDeleted">删除标志值</param>
		/// <returns>返回影响行数</returns>
		public Int32 UpdateIsDeleted(Int32[] ids, Boolean isDeleted)
		{
			var where = School._.IsDeleted.In(ids) && School._.IsDeleted != isDeleted;

			return dbSession.Update<School>(
				new Field[] { School._.IsDeleted, School._.UpdateTime },
				new Object[] { isDeleted, DateTime.Now },
				where);
		}

		/// <summary>
		/// 获取学校
		/// </summary>
		/// <param name="id">学校编号</param>
		/// <returns>返回学校实体</returns>
		public School GetSchool(Int32 id)
		{
			return dbSession.Single<School>(id);
		}

		/// <summary>
		/// 获取所有学校列表
		/// </summary>
		/// <returns>返回学校实体列表</returns>
		public IList<School> GetAllSchools()
		{
			var where = NotDeleted;
			return dbSession.From<School>()
				.Where(where).OrderBy(School._.AddTime.Asc)
				.ToList();
		}

		public IList<School> GetSchoolsByRegion(Int32 region)
		{
			var where = NotDeleted && School._.Region == region;

			return dbSession.From<School>().Where(where).ToList();
		}

		public IList<School> GetSchoolsByRegion(Int32 region, Int32 level)
		{
			var where = NotDeleted && School._.Region == region && School._.Level == level;

			return dbSession.From<School>().Where(where).ToList();
		}

		/// <summary>
		/// 获取学校列表
		/// </summary>
		/// <param name="pageIndex">当前索引页</param>
		/// <param name="pageSize">每页记录数</param>
		/// <returns>返回学校实体列表</returns>
		public IList<School> GetSchools(int pageIndex, int pageSize)
		{
			WhereClip where = this.NotDeleted;

			return dbSession.From<School>()
				.Where(where).OrderBy(School._.AddTime.Desc)
				.GetPage(pageSize).ToList(pageIndex);
		}

		/// <summary>
		/// 获取已删除学校列表
		/// </summary>
		/// <param name="pageIndex">当前索引页</param>
		/// <param name="pageSize">每页记录数</param>
		/// <returns>返回已删除学校实体列表</returns>
		public IList<School> GetDeletedSchools(int pageIndex, int pageSize)
		{
			WhereClip where = this.HasDeleted;

			return dbSession.From<School>()
				.Where(where).OrderBy(School._.AddTime.Desc)
				.GetPage(pageSize).ToList(pageIndex);
		}

		/// <summary>
		/// 获取学校记录条数
		/// </summary>
		/// <returns>返回学校记录条数</returns>
		public Int32 GetSchoolCount()
		{
			WhereClip where = this.NotDeleted;

			return dbSession.From<School>()
				.Where(where).Count();
		}

		/// <summary>
		/// 获取已删除学校记录条数
		/// </summary>
		/// <returns>返回已删除学校记录条数</returns>
		public Int32 GetDeletedSchoolCount()
		{
			WhereClip where = this.HasDeleted;

			return dbSession.From<School>()
				.Where(where).Count();
		}
	}
}
