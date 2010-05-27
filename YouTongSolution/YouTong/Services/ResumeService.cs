using System;
using System.Collections.Generic;
using YouTong.Common;
using YouTong.Model;

namespace YouTong
{
	public class ResumeService : BusinessBase, IResumeService
	{
		/// <summary>
		/// 添加孩子履历
		/// </summary>
		/// <param name="Resume">孩子履历实体</param>
		/// <returns>返回影响行数</returns>
		public Int32 AddResume(Resume resume)
		{
			return dbResume.AddResume(resume);
		}

		/// <summary>
		/// 修改孩子履历
		/// </summary>
		/// <param name="Resume">孩子履历实体</param>
		/// <returns>返回影响行数</returns>
		public Int32 UpdateResume(Resume resume)
		{
			return dbResume.UpdateResume(resume);
		}

		/// <summary>
		/// 删除孩子履历
		/// </summary>
		/// <param name="id">孩子履历编号</param>
		/// <returns>返回影响行数</returns>
		public Int32 DeleteResume(Guid id)
		{
			return dbResume.DeleteResume(id);
		}

		/// <summary>
		/// 删除孩子履历
		/// </summary>
		/// <param name="ids">孩子履历编号</param>
		/// <returns>返回影响行数</returns>
		public Int32 DeleteResumes(Guid[] ids)
		{
			return dbResume.DeleteResumes(ids);
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
			return dbResume.UpdateIsDeleted(ids, isDeleted);
		}

		/// <summary>
		/// 获取孩子履历
		/// </summary>
		/// <param name="id">孩子履历编号</param>
		/// <returns>返回孩子履历实体</returns>
		public Resume GetResume(Guid id)
		{
			return dbResume.GetResume(id);
		}

		/// <summary>
		/// 获取孩子履历
		/// </summary>
		/// <param name="ids">孩子履历编号，一个数组</param>
		/// <returns>返回孩子履历实体列表</returns>
		public IList<Resume> GetResumes(params Guid[] ids)
		{
			return dbResume.GetResumes(ids);
		}

		/// <summary>
		/// 获取孩子履历，根据指定孩子编号
		/// </summary>
		/// <param name="parentId">孩子编号</param>
		/// <returns>返回孩子履历实体列表</returns>
		public IList<Resume> GetResumesByChild(Guid childId)
		{
			return dbResume.GetResumesByChild(childId);
		}
	}
}
