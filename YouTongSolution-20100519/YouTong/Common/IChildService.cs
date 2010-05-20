using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouTong.Model;

namespace YouTong.Common
{
	/// <summary>
	/// 孩子服务 接口
	/// </summary>
	public interface IChildService
	{
		/// <summary>
		/// 添加频道
		/// </summary>
		/// <param name="Child">频道实体</param>
		void AddChild(Child child);

		/// <summary>
		/// 修改频道
		/// </summary>
		/// <param name="Child">频道实体</param>
		void UpdateChild(Child child);

		/// <summary>
		/// 删除频道
		/// </summary>
		/// <param name="id">频道编号</param>
		void DeleteChild(Guid id);

		/// <summary>
		/// 删除频道
		/// </summary>
		/// <param name="ids">频道编号，一个数组</param>
		void DeleteChilds(Guid[] ids);

		/// <summary>
		/// 彻底删除频道
		/// </summary>
		/// <param name="id">频道编号</param>
		void ShiftDeleteChild(Guid id);

		/// <summary>
		/// 彻底删除频道
		/// </summary>
		/// <param name="ids">频道编号，一个数组</param>
		void ShiftDeleteChilds(Guid[] ids);

		/// <summary>
		/// 获取频道
		/// </summary>
		/// <param name="id">频道编号</param>
		/// <returns>返回频道实体</returns>
		Child GetChild(Guid id);

		/// <summary>
		/// 获取孩子
		/// </summary>
		/// <param name="ids">孩子编号，一个数组</param>
		/// <returns>返回孩子实体列表</returns>
		IList<Child> GetChilds(params Guid[] ids);

		/// <summary>
		/// 获取孩子，根据指定家长编号
		/// </summary>
		/// <param name="parentId">家长编号</param>
		/// <returns>返回孩子实体列表</returns>
		IList<Child> GetChildsByParent(Guid parentId);

		/// <summary>
		/// 获取孩子列表
		/// </summary>
		/// <param name="pageIndex">当前索引页</param>
		/// <param name="pageSize">每页记录数</param>
		/// <returns>返回孩子实体列表</returns>
		IList<Child> GetChilds(int pageIndex, int pageSize);

		/// <summary>
		/// 获取已删除孩子列表
		/// </summary>
		/// <param name="pageIndex">当前索引页</param>
		/// <param name="pageSize">每页记录数</param>
		/// <returns>返回已删除孩子实体列表</returns>
		IList<Child> GetDeletedChilds(int pageIndex, int pageSize);

		/// <summary>
		/// 获取孩子个数，根据指定家长编号
		/// </summary>
		/// <param name="parentId">家长编号</param>
		/// <returns>返回孩子个数</returns>
		Int32 GetChildCountByParent(Guid parentId);

		/// <summary>
		/// 获取孩子记录条数
		/// </summary>
		/// <returns>返回孩子记录条数</returns>
		Int32 GetChildCount();

		/// <summary>
		/// 获取已删除孩子记录条数
		/// </summary>
		/// <returns>返回已删除孩子记录条数</returns>
		Int32 GetDeletedChildCount();

		Child GetFirstChild(Guid parentId);
	}
}
