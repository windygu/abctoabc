using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySoft.Data;
using YouTong.Model;

namespace YouTong.Data
{
	/// <summary>
	/// 信息分类关系-数据层
	/// </summary>
	public class DbInCategory : DbBase
	{
		public static readonly DbInCategory Instance = new DbInCategory();

		internal readonly WhereClip NotDeleted = InCategory._.IsDeleted == false;
		internal readonly WhereClip HasDeleted = InCategory._.IsDeleted == true;

		/// <summary>
		/// 添加分类关系
		/// </summary>
		/// <param name="InCategory">分类关系实体</param>
		/// <returns>返回影响行数</returns>
		public Int32 AddInCategory(InCategory inCategory)
		{
			inCategory.Detach();
			inCategory.AddTime = DateTime.Now;
			inCategory.UpdateTime = DateTime.Now;
			return dbSession.Save<InCategory>(inCategory);
		}

		/// <summary>
		/// 修改分类关系
		/// </summary>
		/// <param name="InCategory">分类关系实体</param>
		/// <returns>返回影响行数</returns>
		public Int32 UpdateInCategory(InCategory inCategory)
		{
			inCategory.Attach();
			inCategory.UpdateTime = DateTime.Now;
			return dbSession.Save<InCategory>(inCategory);
		}

		/// <summary>
		/// 删除分类关系
		/// </summary>
		/// <param name="id">分类关系编号</param>
		/// <returns>返回影响行数</returns>
		public Int32 DeleteInCategory(Guid id)
		{
			return dbSession.Delete<InCategory>(id);
		}

		/// <summary>
		/// 删除分类关系
		/// </summary>
		/// <param name="ids">分类关系编号</param>
		/// <returns>返回影响行数</returns>
		public Int32 DeleteCategories(params Guid[] ids)
		{
			var where = InCategory._.ID.In(ids);

			return dbSession.Delete<InCategory>(where);
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
			var where = InCategory._.IsDeleted.In(ids) && InCategory._.IsDeleted != isDeleted;

			return dbSession.Update<InCategory>(
				new Field[] { InCategory._.IsDeleted, InCategory._.UpdateTime },
				new Object[] { isDeleted, DateTime.Now },
				where);
		}

		/// <summary>
		/// 获取分类关系
		/// </summary>
		/// <param name="id">分类关系编号</param>
		/// <returns>返回分类关系实体</returns>
		public InCategory GetInCategory(Guid id)
		{
			return dbSession.Single<InCategory>(id);
		}

		/// <summary>
		/// 获取实体编号集
		/// </summary>
		/// <param name="categoryId">分类编号</param>
		/// <returns></returns>
		public IList<Guid> GetEntityIDs(Guid categoryId)
		{
			var where = NotDeleted && InCategory._.CategoryID == categoryId;
			return dbSession.From<InCategory>().Select(InCategory._.EntityID)
				.Where(where).OrderBy(InCategory._.EntityTime.Desc)
				.ToListResult<Guid>();
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
			var where = NotDeleted && InCategory._.CategoryID == categoryId;
			return dbSession.From<InCategory>().Select(InCategory._.EntityID)
				.Where(where).OrderBy(InCategory._.EntityTime.Desc)
				.GetPage(pageSize)
				.ToListResult<Guid>(pageIndex);
		}

		/// <summary>
		/// 获取实体数
		/// </summary>
		/// <param name="categoryId"></param>
		/// <returns></returns>
		public int GetEntityCount(Guid categoryId)
		{
			var where = NotDeleted && InCategory._.CategoryID == categoryId;
			return dbSession.Count<InCategory>(where);
		}

        /// <summary>
        /// 得到亲子影像属于的相册
        /// </summary>
        /// <param name="ID">文件id</param>
        /// <returns></returns>
        public InCategory GetCatatoryIDByAnyFileID(Guid ID)
        {
            return dbSession.Single<InCategory>(InCategory._.EntityID == ID);
        }
	}
}
