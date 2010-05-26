using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouTong.Common;
using YouTong.Model;

namespace YouTong
{
	/// <summary>
	/// 信息分类-业务层
	/// </summary>
	public class CategoryService : BusinessBase, ICategoryService
	{
		public static readonly CategoryService Instance = new CategoryService();

		/// <summary>
		/// 添加分类
		/// </summary>
		/// <param name="Category">分类实体</param>
		/// <returns>返回影响行数</returns>
		public Int32 AddCategory(Category category)
		{
			return dbCategory.AddCategory(category);
		}

		/// <summary>
		/// 修改分类
		/// </summary>
		/// <param name="Category">分类实体</param>
		/// <returns>返回影响行数</returns>
		public Int32 UpdateCategory(Category category)
		{
			return dbCategory.UpdateCategory(category);
		}

		/// <summary>
		/// 删除分类
		/// </summary>
		/// <param name="id">分类编号</param>
		/// <returns>返回影响行数</returns>
		public Int32 DeleteCategory(Guid id)
		{
			return this.DeleteCategories(id);
		}

		/// <summary>
		/// 删除分类
		/// </summary>
		/// <param name="ids">分类编号</param>
		/// <returns>返回影响行数</returns>
		public Int32 DeleteCategories(params Guid[] ids)
		{
			return dbCategory.UpdateIsDeleted(ids, true);
		}

		/// <summary>
		/// 获取分类
		/// </summary>
		/// <param name="id">分类编号</param>
		/// <returns>返回分类实体</returns>
		public Category GetCategory(Guid id)
		{
			return dbCategory.GetCategory(id);
		}

		/// <summary>
		/// 获取用户分类
		/// </summary>
		/// <param name="userId">用户编号</param>
		/// <returns></returns>
		public IList<Category> GetCategoriesByUser(Guid userId)
		{
			return dbCategory.GetCategoriesByUser(userId);
		}

		/// <summary>
		/// 获取用户分类
		/// </summary>
		/// <param name="userId">用户编号</param>
		/// <param name="entity">实体</param>
		/// <returns></returns>
		public IList<Category> GetCategoriesByUser(Guid userId, string entity)
		{
			return dbCategory.GetCategoriesByUser(userId, entity);
		}
	}
}
