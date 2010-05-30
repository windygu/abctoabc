using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebBasics.Cms.Model;

namespace WebBasics.Cms.Common
{
	/// <summary>
	/// 文章服务 接口
	/// </summary>
	public interface IArticleService
	{
		/// <summary>
		/// 添加文章
		/// </summary>
		/// <param name="article">文章实体</param>
		void AddArticle(Article article);

		/// <summary>
		/// 修改文章
		/// </summary>
		/// <param name="article">文章实体</param>
		void UpdateArticle(Article article);

		/// <summary>
		/// 逻辑删除文章
		/// </summary>
		/// <param name="id">文章编号</param>
		void DeleteArticle(Guid id);

		/// <summary>
		/// 逻辑删除文章
		/// </summary>
		/// <param name="ids">文章编号，一个数组</param>
		void DeleteArticles(params Guid[] ids);

		/// <summary>
		/// 逻辑删除指定频道下的所有文章
		/// </summary>
		/// <param name="channelId">频道编号</param>
		void DeleteArticlesByChannel(Guid channelId);

		/// <summary>
		/// 逻辑删除指定频道下的所有文章
		/// </summary>
		/// <param name="channelds">频道编号，一个数组</param>
		void DeleteArticlesByChannel(params Guid[] channelds);

		/// <summary>
		/// 彻底删除文章
		/// </summary>
		/// <param name="id">文章编号</param>
		void ShiftDeleteArticle(Guid id);

		/// <summary>
		/// 彻底删除文章
		/// </summary>
		/// <param name="ids">文章编号，一个数组</param>
		void ShiftDeleteArticles(Guid[] ids);

		/// <summary>
		/// 获取文章
		/// </summary>
		/// <param name="id">文章编号</param>
		/// <returns>返回文章实体</returns>
		Article GetArticle(Guid id);

		/// <summary>
		/// 获取文章列表
		/// </summary>
		/// <param name="channelId">频道编号</param>
		/// <param name="recursive">递归选项，如果true则包括所有子频道，否则只从当前频道获取</param>
		/// <param name="pageIndex">当前索引页</param>
		/// <param name="pageSize">每页记录数</param>
		/// <returns>返回文章实体列表</returns>
		IList<Article> GetArticles(Guid channelId, bool recursive, int pageIndex, int pageSize);

		/// <summary>
		/// 获取文章列表
		/// </summary>
		/// <param name="channelId">频道编号</param>
		/// <param name="recursive">递归选项，如果true则包括所有子频道，否则只从当前频道获取</param>
		/// <param name="audits">审核状态</param>
		/// <param name="pageIndex">当前索引页</param>
		/// <param name="pageSize">每页记录数</param>
		/// <returns>返回文章实体列表</returns>
		IList<Article> GetArticles(Guid channelId, bool recursive, byte[] audits, int pageIndex, int pageSize);

		/// <summary>
		/// 获取文章列表
		/// </summary>
		/// <param name="channelId">频道编号</param>
		/// <param name="recursive">递归选项，如果true则包括所有子频道，否则只从当前频道获取</param>
		/// <param name="userId">用户编号</param>
		/// <param name="pageIndex">当前索引页</param>
		/// <param name="pageSize">每页记录数</param>
		/// <returns>返回文章实体列表</returns>
		IList<Article> GetArticles(Guid channelId, bool recursive, Guid userId, int pageIndex, int pageSize);

		/// <summary>
		/// 获取文章列表
		/// </summary>
		/// <param name="channelId">频道编号</param>
		/// <param name="recursive">递归选项，如果true则包括所有子频道，否则只从当前频道获取</param>
		/// <param name="audits">审核状态</param>
		/// <param name="userId">用户编号</param>
		/// <param name="pageIndex">当前索引页</param>
		/// <param name="pageSize">每页记录数</param>
		/// <returns>返回文章实体列表</returns>
		IList<Article> GetArticles(Guid channelId, bool recursive, byte[] audits, Guid userId, int pageIndex, int pageSize);

		/// <summary>
		/// 获取已删除文章列表
		/// </summary>
		/// <param name="channelId">频道编号</param>
		/// <param name="recursive">递归选项，如果true则包括所有子频道，否则只从当前频道获取</param>
		/// <param name="pageIndex">当前索引页</param>
		/// <param name="pageSize">每页记录数</param>
		/// <returns>返回已删除文章实体列表</returns>
		IList<Article> GetDeletedArticles(Guid channelId, bool recursive, int pageIndex, int pageSize);

		/// <summary>
		/// 获取文章记录条数
		/// </summary>
		/// <param name="channelId">频道编号</param>
		/// <param name="recursive">递归选项，如果true则包括所有子频道，否则只从当前频道获取</param>
		/// <returns>返回文章记录条数</returns>
		int GetArticleCount(Guid channelId, bool recursive);

		/// <summary>
		/// 获取文章记录条数
		/// </summary>
		/// <param name="channelId">频道编号</param>
		/// <param name="recursive">递归选项，如果true则包括所有子频道，否则只从当前频道获取</param>
		/// <param name="userId">用户编号</param>
		/// <returns>返回文章记录条数</returns>
		int GetArticleCount(Guid channelId, bool recursive, Guid userId);

		/// <summary>
		/// 获取文章记录条数
		/// </summary>
		/// <param name="channelId">频道编号</param>
		/// <param name="recursive">递归选项，如果true则包括所有子频道，否则只从当前频道获取</param>
		/// <param name="audits">审核状态</param>
		/// <param name="userId">用户编号</param>
		/// <returns>返回文章记录条数</returns>
		int GetArticleCount(Guid channelId, bool recursive, byte[] audits, Guid? userId);

		/// <summary>
		/// 获取已删除文章记录条数
		/// </summary>
		/// <param name="channelId">频道编号</param>
		/// <param name="recursive">递归选项，如果true则包括所有子频道，否则只从当前频道获取</param>
		/// <returns>返回已删除文章记录条数</returns>
		int GetDeletedArticleCount(Guid channelId, bool recursive);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ids"></param>
		/// <returns></returns>
		int AuditPass(Guid[] ids);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ids"></param>
		/// <returns></returns>
		int AuditRefuse(Guid[] ids);

	}
}
