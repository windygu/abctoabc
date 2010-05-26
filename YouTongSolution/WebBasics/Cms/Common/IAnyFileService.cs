using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebBasics.Cms.Model;

namespace WebBasics.Cms.Common
{
	/// <summary>
	/// 文件服务 接口
	/// </summary>
	public interface IAnyFileService
	{
		/// <summary>
		/// 添加文件
		/// </summary>
		/// <param name="anyFile">文件实体</param>
		void AddAnyFile(AnyFile anyFile);

		/// <summary>
		/// 修改文件
		/// </summary>
		/// <param name="anyFile">文件实体</param>
		void UpdateAnyFile(AnyFile anyFile);

		/// <summary>
		/// 逻辑删除文件
		/// </summary>
		/// <param name="id">文件编号</param>
		void DeleteAnyFile(Guid id);

		/// <summary>
		/// 逻辑删除文件
		/// </summary>
		/// <param name="ids">文件编号，一个数组</param>
		void DeleteAnyFiles(params Guid[] ids);

		/// <summary>
		/// 逻辑删除指定频道下的所有文件
		/// </summary>
		/// <param name="channelId">频道编号</param>
		void DeleteAnyFilesByChannel(Guid channelId);

		/// <summary>
		/// 逻辑删除指定频道下的所有文件
		/// </summary>
		/// <param name="channelds">频道编号，一个数组</param>
		void DeleteAnyFilesByChannel(params Guid[] channelds);

		/// <summary>
		/// 彻底删除文件
		/// </summary>
		/// <param name="id">文件编号</param>
		void ShiftDeleteAnyFile(Guid id);

		/// <summary>
		/// 彻底删除文件
		/// </summary>
		/// <param name="ids">文件编号，一个数组</param>
		void ShiftDeleteAnyFiles(Guid[] ids);

		/// <summary>
		/// 获取文件
		/// </summary>
		/// <param name="id">文件编号</param>
		/// <returns>返回文件实体</returns>
		AnyFile GetAnyFile(Guid id);

		/// <summary>
		/// 获取文章
		/// </summary>
		/// <param name="ids">文章编号</param>
		/// <returns></returns>
		IList<AnyFile> GetAnyFiles(Guid[] ids);

		/// <summary>
		/// 获取文件列表
		/// </summary>
		/// <param name="channelId">频道编号</param>
		/// <param name="recursive">递归选项，如果true则包括所有子频道，否则只从当前频道获取</param>
		/// <param name="pageIndex">当前索引页</param>
		/// <param name="pageSize">每页记录数</param>
		/// <returns>返回文件实体列表</returns>
		IList<AnyFile> GetAnyFiles(Guid channelId, bool recursive, int pageIndex, int pageSize);

		/// <summary>
		/// 获取文件列表
		/// </summary>
		/// <param name="channelId">频道编号</param>
		/// <param name="recursive">递归选项，如果true则包括所有子频道，否则只从当前频道获取</param>
		/// <param name="userId">用户编号</param>
		/// <param name="pageIndex">当前索引页</param>
		/// <param name="pageSize">每页记录数</param>
		/// <returns>返回文件实体列表</returns>
		IList<AnyFile> GetAnyFiles(Guid channelId, bool recursive, Guid? userId, Int32? fileType, int pageIndex, int pageSize);

		/// <summary>
		/// 获取文章列表
		/// </summary>
		/// <param name="channelId">频道编号</param>
		/// <param name="recursive">递归选项，如果true则包括所有子频道，否则只从当前频道获取</param>
		/// <param name="userId">用户编号</param>
		/// <param name="fileType">文件类型</param>
		/// <param name="from">文件来源</param>
		/// <param name="pageIndex">当前索引页</param>
		/// <param name="pageSize">每页记录数</param>
		/// <returns>返回文章实体列表</returns>
		IList<AnyFile> GetAnyFiles(Guid channelId, Boolean recursive, Guid? userId, Int32? fileType, String from, Int32 pageIndex, Int32 pageSize);

		/// <summary>
		/// 获取已删除文件列表
		/// </summary>
		/// <param name="channelId">频道编号</param>
		/// <param name="recursive">递归选项，如果true则包括所有子频道，否则只从当前频道获取</param>
		/// <param name="pageIndex">当前索引页</param>
		/// <param name="pageSize">每页记录数</param>
		/// <returns>返回已删除文件实体列表</returns>
		IList<AnyFile> GetDeletedAnyFiles(Guid channelId, bool recursive, int pageIndex, int pageSize);

		/// <summary>
		/// 获取文件记录条数
		/// </summary>
		/// <param name="channelId">频道编号</param>
		/// <param name="recursive">递归选项，如果true则包括所有子频道，否则只从当前频道获取</param>
		/// <returns>返回文件记录条数</returns>
		int GetAnyFileCount(Guid channelId, bool recursive);

		/// <summary>
		/// 获取文件记录条数
		/// </summary>
		/// <param name="channelId">频道编号</param>
		/// <param name="recursive">递归选项，如果true则包括所有子频道，否则只从当前频道获取</param>
		/// <param name="userId">用户编号</param>
		/// <param name="fileType">文件类型</param>
		/// <param name="from">文件来源</param>
		/// <returns>返回文件记录条数</returns>
		Int32 GetAnyFileCount(Guid channelId, Boolean recursive, Guid? userId, Int32? fileType, String from);

		/// <summary>
		/// 获取已删除文件记录条数
		/// </summary>
		/// <param name="channelId">频道编号</param>
		/// <param name="recursive">递归选项，如果true则包括所有子频道，否则只从当前频道获取</param>
		/// <returns>返回已删除文件记录条数</returns>
		int GetDeletedAnyFileCount(Guid channelId, bool recursive);

	}
}
