using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebBasics.Cms.Common;
using WebBasics.Cms.Data;
using WebBasics.Cms.Model;
using WebBasics.Utilities;

namespace WebBasics.Cms
{
	/// <summary>
	/// 文章服务
	/// </summary>
	public class ArticleService : BusinessBase, IArticleService
	{
		/// <summary>
		/// ArticleService实例
		/// </summary>
		public static readonly ArticleService Instance = new ArticleService();

		#region IArticleService 成员

		public void AddArticle(Article article)
		{
			article.ID = Comb.NewComb2();
			dbArticle.AddArticle(article);
		}

		public void UpdateArticle(Article article)
		{
			dbArticle.UpdateArticle(article);
		}

		public void DeleteArticle(Guid id)
		{
			dbArticle.UpdateIsDeleted(new Guid[] { id }, true);
		}

		public void DeleteArticles(params Guid[] ids)
		{
			dbArticle.UpdateIsDeleted(ids, true);
		}

		public void DeleteArticlesByChannel(Guid channelId)
		{
			dbArticle.UpdateIsDeletedByChannel(channelId, true);
		}

		public void DeleteArticlesByChannel(params Guid[] channelds)
		{
			dbArticle.UpdateIsDeletedByChannel(channelds, true);
		}

		public void ShiftDeleteArticle(Guid id)
		{
			throw new NotImplementedException();
		}

		public void ShiftDeleteArticles(Guid[] ids)
		{
			throw new NotImplementedException();
		}

		public Article GetArticle(Guid id)
		{
			return dbArticle.GetArticle(id);
		}

		/// <summary>
		/// 获取文章
		/// </summary>
		/// <param name="ids">文章编号</param>
		/// <returns>返回文章实体</returns>
		public IList<Article> GetArticles(Guid[] ids)
		{
			return dbArticle.GetArticles(ids);
		}

		public IList<Article> GetArticles(Guid channelId, bool recursive, int pageIndex, int pageSize)
		{
			return dbArticle.GetArticles(channelId, recursive, pageIndex, pageSize);
		}

		/// <summary>
		/// 获取文章列表
		/// </summary>
		/// <param name="channelId">频道编号</param>
		/// <param name="recursive">递归选项，如果true则包括所有子频道，否则只从当前频道获取</param>
		/// <param name="audits">审核状态</param>
		/// <param name="pageIndex">当前索引页</param>
		/// <param name="pageSize">每页记录数</param>
		/// <returns>返回文章实体列表</returns>
		public IList<Article> GetArticles(Guid channelId, bool recursive, byte[] audits, int pageIndex, int pageSize)
		{
			return dbArticle.GetArticles(channelId, recursive, audits, pageIndex, pageSize);
		}

		public IList<Article> GetArticles(Guid channelId, bool recursive, Guid userId, int pageIndex, int pageSize)
		{
			return dbArticle.GetArticles(channelId, recursive, userId, pageIndex, pageSize);
		}

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
		public IList<Article> GetArticles(Guid channelId, bool recursive, byte[] audits, Guid userId, int pageIndex, int pageSize)
		{
			return dbArticle.GetArticles(channelId, recursive, audits, userId, pageIndex, pageSize);
		}

		/// <summary>
		/// 获取推荐文章列表
		/// </summary>
		/// <param name="channelId">频道编号</param>
		/// <param name="recursive">递归选项，如果true则包括所有子频道，否则只从当前频道获取</param>
		/// <param name="pageIndex">当前索引页</param>
		/// <param name="pageSize">每页记录数</param>
		/// <returns>返回文章实体列表</returns>
		public IList<Article> GetRecommendArticles(Guid channelId, bool recursive, int pageIndex, int pageSize)
		{
			return dbArticle.GetRecommendArticles(channelId, recursive, pageIndex, pageSize);
		}

		public IList<Article> GetDeletedArticles(Guid channelId, bool recursive, int pageIndex, int pageSize)
		{
			return dbArticle.GetDeletedArticles(channelId, recursive, pageIndex, pageSize);
		}

		public int GetArticleCount(Guid channelId, bool recursive)
		{
			return dbArticle.GetArticleCount(channelId, recursive);
		}

		public int GetArticleCount(Guid channelId, bool recursive, Guid userId)
		{
			return this.dbArticle.GetArticleCount(channelId, recursive, userId);
		}

		public int GetArticleCount(Guid channelId, bool recursive, byte[] audits, Guid? userId)
		{
			return this.dbArticle.GetArticleCount(channelId, recursive, audits, userId);
		}

		public int GetDeletedArticleCount(Guid channelId, bool recursive)
		{
			return dbArticle.GetDeletedArticleCount(channelId, recursive);
		}

		public int AuditPass(Guid[] ids)
		{
			return dbArticle.UpdateAuditStatus(ids, 1);
		}

		public int AuditRefuse(Guid[] ids)
		{
			return dbArticle.UpdateAuditStatus(ids, 2);
		}
		#endregion
	}
}
