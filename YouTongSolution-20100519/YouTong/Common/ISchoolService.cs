using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouTong.Model;

namespace YouTong.Common
{
	/// <summary>
	/// 学校服务 接口
	/// </summary>
	public interface ISchoolService
	{
		/// <summary>
		/// 添加学校
		/// </summary>
		/// <param name="School">学校实体</param>
		/// <returns>返回影响行数</returns>
		void AddSchool(School School);

		/// <summary>
		/// 修改学校
		/// </summary>
		/// <param name="School">学校实体</param>
		/// <returns>返回影响行数</returns>
		void UpdateSchool(School School);

		/// <summary>
		/// 删除学校
		/// </summary>
		/// <param name="id">学校编号</param>
		/// <returns>返回影响行数</returns>
		void DeleteSchool(Int32 id);

		/// <summary>
		/// 删除学校
		/// </summary>
		/// <param name="ids">学校编号</param>
		/// <returns>返回影响行数</returns>
		void DeleteSchools(params Int32[] ids);

		/// <summary>
		/// 彻底删除频道
		/// </summary>
		/// <param name="id">频道编号</param>
		void ShiftDeleteChild(Int32 id);

		/// <summary>
		/// 彻底删除频道
		/// </summary>
		/// <param name="ids">频道编号，一个数组</param>
		void ShiftDeleteChilds(Int32[] ids);

		/// <summary>
		/// 获取学校
		/// </summary>
		/// <param name="id">学校编号</param>
		/// <returns>返回学校实体</returns>
		School GetSchool(Int32 id);

		/// <summary>
		/// 获取所有学校列表
		/// </summary>
		/// <returns>返回学校实体列表</returns>
		IList<School> GetAllSchools();

		/// <summary>
		/// 获取学校列表
		/// </summary>
		/// <param name="pageIndex">当前索引页</param>
		/// <param name="pageSize">每页记录数</param>
		/// <returns>返回学校实体列表</returns>
		IList<School> GetSchools(Int32 pageIndex, Int32 pageSize);

		/// <summary>
		/// 获取已删除学校列表
		/// </summary>
		/// <param name="pageIndex">当前索引页</param>
		/// <param name="pageSize">每页记录数</param>
		/// <returns>返回已删除学校实体列表</returns>
		IList<School> GetDeletedSchools(Int32 pageIndex, Int32 pageSize);

		/// <summary>
		/// 获取学校记录条数
		/// </summary>
		/// <returns>返回学校记录条数</returns>
		Int32 GetSchoolCount();

		/// <summary>
		/// 获取已删除学校记录条数
		/// </summary>
		/// <returns>返回已删除学校记录条数</returns>
		Int32 GetDeletedSchoolCount();
	}
}
