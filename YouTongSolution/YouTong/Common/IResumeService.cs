using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouTong.Model;

namespace YouTong.Common
{
	public interface IResumeService
	{
		/// <summary>
		/// 添加孩子履历
		/// </summary>
		/// <param name="Resume">孩子履历实体</param>
		/// <returns>返回影响行数</returns>
		 Int32 AddResume(Resume resume);

		/// <summary>
		/// 修改孩子履历
		/// </summary>
		/// <param name="Resume">孩子履历实体</param>
		/// <returns>返回影响行数</returns>
		 Int32 UpdateResume(Resume resume);

		/// <summary>
		/// 删除孩子履历
		/// </summary>
		/// <param name="id">孩子履历编号</param>
		/// <returns>返回影响行数</returns>
		 Int32 DeleteResume(Guid id);

		/// <summary>
		/// 删除孩子履历
		/// </summary>
		/// <param name="ids">孩子履历编号</param>
		/// <returns>返回影响行数</returns>
		 Int32 DeleteResumes(Guid[] ids);

		/// <summary>
		/// 更新删除标志。
		/// 如果删除标志值与需要设置的值相同，则不进行修改
		/// </summary>
		/// <param name="ids">孩子履历编号，一个数组</param>
		/// <param name="isDeleted">删除标志值</param>
		/// <returns>返回影响行数</returns>
		 Int32 UpdateIsDeleted(Guid[] ids, Boolean isDeleted);

		/// <summary>
		/// 获取孩子履历
		/// </summary>
		/// <param name="id">孩子履历编号</param>
		/// <returns>返回孩子履历实体</returns>
		 Resume GetResume(Guid id);

		/// <summary>
		/// 获取孩子履历
		/// </summary>
		/// <param name="ids">孩子履历编号，一个数组</param>
		/// <returns>返回孩子履历实体列表</returns>
		 IList<Resume> GetResumes(params Guid[] ids);

		/// <summary>
		/// 获取孩子履历，根据指定孩子编号
		/// </summary>
		/// <param name="parentId">孩子编号</param>
		/// <returns>返回孩子履历实体列表</returns>
		 IList<Resume> GetResumesByChild(Guid childId);
	}
}
