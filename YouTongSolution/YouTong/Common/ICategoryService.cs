using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouTong.Model;

namespace YouTong.Common
{
	public interface ICategoryService
	{
		/// <summary>
		/// 添加分类
		/// </summary>
		/// <param name="Category">分类实体</param>
		/// <returns>返回影响行数</returns>
		Int32 AddCategory(Category category);

		/// <summary>
		/// 修改分类
		/// </summary>
		/// <param name="Category">分类实体</param>
		/// <returns>返回影响行数</returns>
		Int32 UpdateCategory(Category category);

		/// <summary>
		/// 删除分类
		/// </summary>
		/// <param name="id">分类编号</param>
		/// <returns>返回影响行数</returns>
		Int32 DeleteCategory(Guid id);

		/// <summary>
		/// 删除分类
		/// </summary>
		/// <param name="ids">分类编号</param>
		/// <returns>返回影响行数</returns>
		Int32 DeleteCategories(params Guid[] ids);

		/// <summary>
		/// 获取分类
		/// </summary>
		/// <param name="id">分类编号</param>
		/// <returns>返回分类实体</returns>
		Category GetCategory(Guid id);

		/// <summary>
		/// 获取用户分类
		/// </summary>
		/// <param name="userId">用户编号</param>
		/// <returns></returns>
		IList<Category> GetCategoriesByUser(Guid userId);

		/// <summary>
		/// 获取用户分类
		/// </summary>
		/// <param name="userId">用户编号</param>
		/// <param name="entity">实体</param>
		/// <returns></returns>
		IList<Category> GetCategoriesByUser(Guid userId, string entity);
	}
}
