using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySoft.Data;
using YouTong.Model;

namespace YouTong.Data
{
	/// <summary>
	/// 信息分类-数据层
	/// </summary>
	public class DbCategory : DbBase
	{
		public static readonly DbCategory Instance = new DbCategory();

		internal readonly WhereClip NotDeleted = Category._.IsDeleted == false;
		internal readonly WhereClip HasDeleted = Category._.IsDeleted == true;

		/// <summary>
		/// 添加分类
		/// </summary>
		/// <param name="Category">分类实体</param>
		/// <returns>返回影响行数</returns>
		public Int32 AddCategory(Category category)
		{
			category.Detach();
			category.AddTime = DateTime.Now;
			category.UpdateTime = DateTime.Now;
			return dbSession.Save<Category>(category);
		}

		/// <summary>
		/// 修改分类
		/// </summary>
		/// <param name="Category">分类实体</param>
		/// <returns>返回影响行数</returns>
		public Int32 UpdateCategory(Category category)
		{
			category.Attach();
			category.UpdateTime = DateTime.Now;
			return dbSession.Save<Category>(category);
		}

		/// <summary>
		/// 删除分类
		/// </summary>
		/// <param name="id">分类编号</param>
		/// <returns>返回影响行数</returns>
		public Int32 DeleteCategory(Guid id)
		{
			return dbSession.Delete<Category>(id);
		}

		/// <summary>
		/// 删除分类
		/// </summary>
		/// <param name="ids">分类编号</param>
		/// <returns>返回影响行数</returns>
		public Int32 DeleteCategories(params Guid[] ids)
		{
			var where = Category._.ID.In(ids);

			return dbSession.Delete<Category>(where);
		}

		/// <summary>
		/// 更新删除标志。
		/// 如果删除标志值与需要设置的值相同，则不进行修改
		/// </summary>
		/// <param name="ids">分类编号，一个数组</param>
		/// <param name="isDeleted">删除标志值</param>
		/// <returns>返回影响行数</returns>
		public Int32 UpdateIsDeleted(Guid[] ids, Boolean isDeleted)
		{
			var where = Category._.IsDeleted.In(ids) && Category._.IsDeleted != isDeleted;

			return dbSession.Update<Category>(
				new Field[] { Category._.IsDeleted, Category._.UpdateTime },
				new Object[] { isDeleted, DateTime.Now },
				where);
		}

		/// <summary>
		/// 获取分类
		/// </summary>
		/// <param name="id">分类编号</param>
		/// <returns>返回分类实体</returns>
		public Category GetCategory(Guid id)
		{
			return dbSession.Single<Category>(id);
		}

		/// <summary>
		/// 获取用户分类
		/// </summary>
		/// <param name="userId">用户编号</param>
		/// <returns></returns>
		public IList<Category> GetCategoriesByUser(Guid userId)
		{
			var where = NotDeleted && Category._.UserID == userId;
			return dbSession.From<Category>().Where(where).ToList();
		}
	}
}
