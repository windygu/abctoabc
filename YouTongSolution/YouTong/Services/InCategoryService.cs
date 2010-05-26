using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouTong.Common;
using YouTong.Model;

namespace YouTong
{
	public class InCategoryService : BusinessBase, IInCategoryService
	{
		public static readonly InCategoryService Instance = new InCategoryService();

		/// <summary>
		/// 添加分类关系
		/// </summary>
		/// <param name="InCategory">分类关系实体</param>
		/// <returns>返回影响行数</returns>
		public Int32 AddInCategory(InCategory inCategory)
		{
			var result = dbInCategory.AddInCategory(inCategory);
			CategoryService.Instance.ResetCount(inCategory.CategoryID);
			return result;
		}

		/// <summary>
		/// 修改分类关系
		/// </summary>
		/// <param name="InCategory">分类关系实体</param>
		/// <returns>返回影响行数</returns>
		public Int32 UpdateInCategory(InCategory inCategory)
		{
			return dbInCategory.UpdateInCategory(inCategory);
		}

		/// <summary>
		/// 删除分类关系
		/// </summary>
		/// <param name="id">分类关系编号</param>
		/// <returns>返回影响行数</returns>
		public Int32 DeleteInCategory(Guid id)
		{
			return dbInCategory.DeleteInCategory(id);
		}

		/// <summary>
		/// 删除分类关系
		/// </summary>
		/// <param name="ids">分类关系编号</param>
		/// <returns>返回影响行数</returns>
		public Int32 DeleteCategories(params Guid[] ids)
		{
			return dbInCategory.DeleteCategories(ids);
		}

		/// <summary>
		/// 更新删除标志。
		/// 如果删除标志值与需要设置的值相同，则不进行修改
		/// </summary>
		/// <param name="ids">分类关系编号，一个数组</param>
		/// <param name="isDeleted">删除标志值</param>
		/// <returns>返回影响行数</returns>
		public Int32 UpdateIsDeleted(Guid[] ids, Boolean isDeleted)
		{
			return dbInCategory.UpdateIsDeleted(ids, isDeleted);
		}

		/// <summary>
		/// 获取分类关系
		/// </summary>
		/// <param name="id">分类关系编号</param>
		/// <returns>返回分类关系实体</returns>
		public InCategory GetInCategory(Guid id)
		{
			return dbInCategory.GetInCategory(id);
		}

		/// <summary>
		/// 获取实体编号集
		/// </summary>
		/// <param name="categoryId">分类编号</param>
		/// <returns></returns>
		public IList<Guid> GetEntityIDs(Guid categoryId)
		{
			return dbInCategory.GetEntityIDs(categoryId);
		}

		/// <summary>
		/// 获取实体编号集
		/// </summary>
		/// <param name="categoryId">分类编号</param>
		/// <param name="pageIndex">页索引</param>
		/// <param name="pageSize">页大小</param>
		/// <returns></returns>
		public IList<Guid> GetEntityIDs(Guid categoryId, int pageIndex, int pageSize)
		{
			return dbInCategory.GetEntityIDs(categoryId, pageIndex, pageSize);
		}

		/// <summary>
		/// 获取实体数
		/// </summary>
		/// <param name="categoryId"></param>
		/// <returns></returns>
		public int GetEntityCount(Guid categoryId)
		{
			return dbInCategory.GetEntityCount(categoryId);
		}
	}
}
