using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySoft.Data;
using WebBasics.Utilities;
using YouTong.Model;

namespace YouTong.Data
{
	public class DbResume : DbBase
	{
		public static readonly DbResume Instance = new DbResume();

		readonly WhereClip NotDeleted = Resume._.IsDeleted == false;
		readonly WhereClip HasDeleted = Resume._.IsDeleted == true;

		/// <summary>
		/// 添加孩子履历
		/// </summary>
		/// <param name="Resume">孩子履历实体</param>
		/// <returns>返回影响行数</returns>
		public Int32 AddResume(Resume resume)
		{
			resume.Detach();

			if (resume.ID == Guid.Empty) resume.ID = Comb.NewComb2();
			resume.AddTime = DateTime.Now;
			resume.UpdateTime = DateTime.Now;
			return dbSession.Save<Resume>(resume);
		}

		/// <summary>
		/// 修改孩子履历
		/// </summary>
		/// <param name="Resume">孩子履历实体</param>
		/// <returns>返回影响行数</returns>
		public Int32 UpdateResume(Resume resume)
		{
			resume.Attach();
			resume.UpdateTime = DateTime.Now;
			return dbSession.Save<Resume>(resume);
		}

		/// <summary>
		/// 删除孩子履历
		/// </summary>
		/// <param name="id">孩子履历编号</param>
		/// <returns>返回影响行数</returns>
		public Int32 DeleteResume(Guid id)
		{
			return dbSession.Delete<Resume>(id);
		}

		/// <summary>
		/// 删除孩子履历
		/// </summary>
		/// <param name="ids">孩子履历编号</param>
		/// <returns>返回影响行数</returns>
		public Int32 DeleteResumes(params Guid[] ids)
		{
			var where = Resume._.ID.In(ids);

			return dbSession.Delete<Resume>(where);
		}

		/// <summary>
		/// 更新删除标志。
		/// 如果删除标志值与需要设置的值相同，则不进行修改
		/// </summary>
		/// <param name="ids">孩子履历编号，一个数组</param>
		/// <param name="isDeleted">删除标志值</param>
		/// <returns>返回影响行数</returns>
		public Int32 UpdateIsDeleted(Guid[] ids, Boolean isDeleted)
		{
			var where = Resume._.IsDeleted.In(ids) && Resume._.IsDeleted != isDeleted;

			return dbSession.Update<Resume>(
				new Field[] { Resume._.IsDeleted, Resume._.UpdateTime },
				new Object[] { isDeleted, DateTime.Now },
				where);
		}

		/// <summary>
		/// 获取孩子履历
		/// </summary>
		/// <param name="id">孩子履历编号</param>
		/// <returns>返回孩子履历实体</returns>
		public Resume GetResume(Guid id)
		{
			return dbSession.Single<Resume>(id);
		}

		/// <summary>
		/// 获取孩子履历
		/// </summary>
		/// <param name="ids">孩子履历编号，一个数组</param>
		/// <returns>返回孩子履历实体列表</returns>
		public IList<Resume> GetResumes(params Guid[] ids)
		{
			return dbSession.From<Resume>().Where(Resume._.ID.In(ids)).ToList();
		}

		/// <summary>
		/// 获取孩子履历，根据指定孩子编号
		/// </summary>
		/// <param name="parentId">孩子编号</param>
		/// <returns>返回孩子履历实体列表</returns>
		public IList<Resume> GetResumesByChild(Guid childId)
		{
			var where = this.NotDeleted && Resume._.ChildID == childId;

			return dbSession.From<Resume>().Where(where).ToList();
		}
	}
}
