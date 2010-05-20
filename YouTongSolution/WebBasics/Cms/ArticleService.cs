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

		public IList<Article> GetArticles(Guid channelId, bool recursive, int pageIndex, int pageSize)
		{
			return dbArticle.GetArticles(channelId, recursive, pageIndex, pageSize);
		}

		public IList<Article> GetArticles(Guid channelId, bool recursive, Guid userId, int pageIndex, int pageSize)
		{
			return dbArticle.GetArticles(channelId, recursive, userId, pageIndex, pageSize);
		}

		public IList<Article> GetDeletedArticles(Guid channelId, bool recursive, int pageIndex, int pageSize)
		{
			return dbArticle.GetDeletedArticles(channelId, recursive, pageIndex, pageSize);
		}

		public int GetArticleCount(Guid channelId, bool recursive)
		{
			return dbArticle.GetArticleCount(channelId, recursive);
		}

		public int GetDeletedArticleCount(Guid channelId, bool recursive)
		{
			return dbArticle.GetDeletedArticleCount(channelId, recursive);
		}

		#endregion
	}
}
