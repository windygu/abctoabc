using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySoft.Data;
using YouTong.Model;

namespace YouTong.Data
{
	public class DbArea
	{
		/// <summary>
		/// DbArea实例
		/// </summary>
		public static readonly DbArea Instance = new DbArea();

		DbSession dbSession = new DbSession("ut");
		readonly WhereClip NotDeleted = Area._.IsDeleted == false;
		readonly WhereClip HasDeleted = Area._.IsDeleted == true;

		/// <summary>
		/// 添加学校
		/// </summary>
		/// <param name="Area">学校实体</param>
		/// <returns>返回影响行数</returns>
		public Int32 AddArea(Area Area)
		{
			Area.Detach();

			Area.AddTime = DateTime.Now;
			Area.UpdateTime = DateTime.Now;
			return dbSession.Save<Area>(Area);
		}

		/// <summary>
		/// 修改学校
		/// </summary>
		/// <param name="Area">学校实体</param>
		/// <returns>返回影响行数</returns>
		public Int32 UpdateArea(Area Area)
		{
			Area.Attach();
			Area.UpdateTime = DateTime.Now;
			return dbSession.Save<Area>(Area);
		}

		/// <summary>
		/// 删除学校
		/// </summary>
		/// <param name="id">学校编号</param>
		/// <returns>返回影响行数</returns>
		public Int32 DeleteArea(Guid id)
		{
			return dbSession.Delete<Area>(id);
		}

		/// <summary>
		/// 删除学校
		/// </summary>
		/// <param name="ids">学校编号</param>
		/// <returns>返回影响行数</returns>
		public Int32 DeleteAreas(params Int32[] ids)
		{
			var where = Area._.ID.In(ids);

			return dbSession.Delete<Area>(where);
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
			var where = Area._.IsDeleted.In(ids) && Area._.IsDeleted != isDeleted;

			return dbSession.Update<Area>(
				new Field[] { Area._.IsDeleted, Area._.UpdateTime },
				new Object[] { isDeleted, DateTime.Now },
				where);
		}

		/// <summary>
		/// 获取学校
		/// </summary>
		/// <param name="id">学校编号</param>
		/// <returns>返回学校实体</returns>
		public Area GetArea(Guid id)
		{
			return dbSession.Single<Area>(id);
		}

        /// <summary>
        /// 获取学校
        /// </summary>
        /// <param name="id">学校编号</param>
        /// <returns>返回学校实体</returns>
        public Area GetArea(int id)
        {
            return dbSession.Single<Area>(id);
        }

		/// <summary>
		/// 获取所有学校列表
		/// </summary>
		/// <returns>返回学校实体列表</returns>
		public IList<Area> GetAllAreas()
		{
			var where = NotDeleted;
			return dbSession.From<Area>()
				.Where(where).OrderBy(Area._.AddTime.Asc)
				.ToList();
		}

		/// <summary>
		/// 获取学校列表
		/// </summary>
		/// <param name="pageIndex">当前索引页</param>
		/// <param name="pageSize">每页记录数</param>
		/// <returns>返回学校实体列表</returns>
		public IList<Area> GetAreas(int pageIndex, int pageSize)
		{
			WhereClip where = this.NotDeleted;

			return dbSession.From<Area>()
				.Where(where).OrderBy(Area._.AddTime.Desc)
				.GetPage(pageSize).ToList(pageIndex);
		}

		/// <summary>
		/// 获取已删除学校列表
		/// </summary>
		/// <param name="pageIndex">当前索引页</param>
		/// <param name="pageSize">每页记录数</param>
		/// <returns>返回已删除学校实体列表</returns>
		public IList<Area> GetDeletedAreas(int pageIndex, int pageSize)
		{
			WhereClip where = this.HasDeleted;

			return dbSession.From<Area>()
				.Where(where).OrderBy(Area._.AddTime.Desc)
				.GetPage(pageSize).ToList(pageIndex);
		}

		/// <summary>
		/// 获取学校记录条数
		/// </summary>
		/// <returns>返回学校记录条数</returns>
		public Int32 GetAreaCount()
		{
			WhereClip where = this.NotDeleted;

			return dbSession.From<Area>()
				.Where(where).Count();
		}

		/// <summary>
		/// 获取已删除学校记录条数
		/// </summary>
		/// <returns>返回已删除学校记录条数</returns>
		public Int32 GetDeletedAreaCount()
		{
			WhereClip where = this.HasDeleted;

			return dbSession.From<Area>()
				.Where(where).Count();
		}
	}
}
