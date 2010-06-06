using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySoft.Data;
using WebBasics.Cms.Model;
using WebBasics.Utilities;

namespace WebBasics.Cms.Data
{
	/// <summary>
	/// 文章 数据操作
	/// </summary>
	public class DbArticle
	{
		/// <summary>
		/// DbArticle实例
		/// </summary>
		public static readonly DbArticle Instance = new DbArticle();

		DbSession dbSession = new DbSession("wbcms");
		readonly WhereClip NotDeleted = Article._.IsDeleted == false;
		readonly WhereClip HasDeleted = Article._.IsDeleted == true;

		/// <summary>
		/// 添加文章
		/// </summary>
		/// <param name="article">文章实体</param>
		/// <returns>返回影响行数</returns>
		public Int32 AddArticle(Article article)
		{
			article.Detach();
			if (article.ID == Guid.Empty) article.ID = Comb.NewComb2();
			if (article.OccurTime == DateTime.MinValue) article.OccurTime = DateTime.Now;
			article.AddTime = DateTime.Now;
			article.UpdateTime = DateTime.Now;
			return dbSession.Save<Article>(article);
		}

		/// <summary>
		/// 修改文章
		/// </summary>
		/// <param name="article">文章实体</param>
		/// <returns>返回影响行数</returns>
		public Int32 UpdateArticle(Article article)
		{
			article.Attach();
			article.UpdateTime = DateTime.Now;
			return dbSession.Save<Article>(article);
		}

		/// <summary>
		/// 删除文章
		/// </summary>
		/// <param name="id">文章编号</param>
		/// <returns>返回影响行数</returns>
		public Int32 DeleteArticle(Guid id)
		{
			return dbSession.Delete<Article>(id);
		}

		/// <summary>
		/// 删除文章
		/// </summary>
		/// <param name="ids">文章编号</param>
		/// <returns>返回影响行数</returns>
		public Int32 DeleteArticles(params Guid[] ids)
		{
			var where = Article._.ID.In(ids);

			return dbSession.Delete<Article>(where);
		}

		/// <summary>
		/// 更新删除标志。
		/// 如果删除标志值与需要设置的值相同，则不进行修改
		/// </summary>
		/// <param name="ids">文章编号，一个数组</param>
		/// <param name="isDeleted">删除标志值</param>
		/// <returns>返回影响行数</returns>
		public Int32 UpdateIsDeleted(Guid[] ids, Boolean isDeleted)
		{
			var where = Article._.ID.In(ids) && Article._.IsDeleted != isDeleted;

			return dbSession.Update<Article>(
				new Field[] { Article._.IsDeleted, Article._.UpdateTime },
				new Object[] { isDeleted, DateTime.Now },
				where);
		}

		/// <summary>
		/// 更新指定频道下的所有文章删除标志。
		/// 如果删除标志值与需要设置的值相同，则不进行修改
		/// </summary>
		/// <param name="channelId">频道编号</param>
		public Int32 UpdateIsDeletedByChannel(Guid channelId, Boolean isDeleted)
		{
			var where = Article._.ChannelID == channelId && Article._.IsDeleted != isDeleted;

			return dbSession.Update<Article>(
				new Field[] { Article._.IsDeleted, Article._.UpdateTime },
				new Object[] { isDeleted, DateTime.Now },
				where);
		}

		/// <summary>
		/// 更新指定频道下的所有文章删除标志。
		/// 如果删除标志值与需要设置的值相同，则不进行修改
		/// </summary>
		/// <param name="channelds">频道编号，一个数组</param>
		public Int32 UpdateIsDeletedByChannel(Guid[] channelds, Boolean isDeleted)
		{
			var where = Article._.ChannelID.In(channelds) && Article._.IsDeleted != isDeleted;

			return dbSession.Update<Article>(
				new Field[] { Article._.IsDeleted, Article._.UpdateTime },
				new Object[] { isDeleted, DateTime.Now },
				where);
		}

		/// <summary>
		/// 更新审核状态
		/// </summary>
		/// <param name="ids">文章编号，一个数组</param>
		/// <param name="auditStatus">审核状态</param>
		/// <returns>返回影响行数</returns>
		public int UpdateAuditStatus(Guid[] ids, byte auditStatus)
		{
			var where = Article._.ID.In(ids) && Article._.AuditStatus != auditStatus;

			return dbSession.Update<Article>(
				new Field[] { Article._.AuditStatus, Article._.UpdateTime },
				new Object[] { auditStatus, DateTime.Now },
				where);
		}

		/// <summary>
		/// 获取文章
		/// </summary>
		/// <param name="id">文章编号</param>
		/// <returns>返回文章实体</returns>
		public Article GetArticle(Guid id)
		{
			return dbSession.Single<Article>(id);
		}

		/// <summary>
		/// 获取文章
		/// </summary>
		/// <param name="ids">文章编号</param>
		/// <returns>返回文章实体</returns>
		public IList<Article> GetArticles(Guid[] ids)
		{
			var where = Article._.ID.In(ids);
			return dbSession.From<Article>().Where(where).ToList();
		}

		/// <summary>
		/// 获取文章列表
		/// </summary>
		/// <param name="channelId">频道编号</param>
		/// <param name="recursive">递归选项，如果true则包括所有子频道，否则只从当前频道获取</param>
		/// <param name="pageIndex">当前索引页</param>
		/// <param name="pageSize">每页记录数</param>
		/// <returns>返回文章实体列表</returns>
		public IList<Article> GetArticles(Guid channelId, bool recursive, int pageIndex, int pageSize)
		{
			return this.GetArticles(channelId, recursive, new byte[] { 0, 1 }, pageIndex, pageSize);
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
			var where = this.GetWhereClip(channelId, recursive, audits, null);
			return this.GetArticles(where, pageIndex, pageSize);
		}

		/// <summary>
		/// 获取文章列表
		/// </summary>
		/// <param name="channelId">频道编号</param>
		/// <param name="recursive">递归选项，如果true则包括所有子频道，否则只从当前频道获取</param>
		/// <param name="userId">用户编号</param>
		/// <param name="pageIndex">当前索引页</param>
		/// <param name="pageSize">每页记录数</param>
		/// <returns>返回文章实体列表</returns>
		public IList<Article> GetArticles(Guid channelId, bool recursive, Guid userId, int pageIndex, int pageSize)
		{
			return this.GetArticles(channelId, recursive, new byte[] { 0, 1 }, userId, pageIndex, pageSize);
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
			var where = this.GetWhereClip(channelId, recursive, audits, userId);
			return this.GetArticles(where, pageIndex, pageSize);
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
			var where = this.GetWhereClip(channelId, recursive, new byte[] { 0, 1 }, null);
			where = where && Article._.Recommend > 0;
			return this.GetArticles(where, pageIndex, pageSize);
		}

		/// <summary>
		/// 获取已删除文章列表
		/// </summary>
		/// <param name="channelId">频道编号</param>
		/// <param name="recursive">递归选项，如果true则包括所有子频道，否则只从当前频道获取</param>
		/// <param name="pageIndex">当前索引页</param>
		/// <param name="pageSize">每页记录数</param>
		/// <returns>返回已删除文章实体列表</returns>
		public IList<Article> GetDeletedArticles(Guid channelId, bool recursive, int pageIndex, int pageSize)
		{
			WhereClip where = this.HasDeleted;

			if (recursive)
			{
				var ids = DbChannel.Instance.GetChildChannelIDs(channelId, true);
				ids.Add(channelId);
				where = where && Article._.ChannelID.In(ids.ToArray());
			}
			else
			{
				where = where && Article._.ChannelID == channelId;
			}

			return dbSession.From<Article>()
				.Where(where).OrderBy(Article._.AddTime.Desc)
				.GetPage(pageSize).ToList(pageIndex);
		}

		/// <summary>
		/// 获取文章记录条数
		/// </summary>
		/// <param name="channelId">频道编号</param>
		/// <param name="recursive">递归选项，如果true则包括所有子频道，否则只从当前频道获取</param>
		/// <returns>返回文章记录条数</returns>
		public int GetArticleCount(Guid channelId, bool recursive)
		{
			WhereClip where = this.NotDeleted;

			if (recursive)
			{
				var ids = DbChannel.Instance.GetChildChannelIDs(channelId, true);
				ids.Add(channelId);
				where = where && Article._.ChannelID.In(ids.ToArray());
			}
			else
			{
				where = where && Article._.ChannelID == channelId;
			}

			return dbSession.From<Article>()
				.Where(where).Count();
		}

		/// <summary>
		/// 获取文章记录条数
		/// </summary>
		/// <param name="channelId">频道编号</param>
		/// <param name="recursive">递归选项，如果true则包括所有子频道，否则只从当前频道获取</param>
		/// <param name="userId">用户编号</param>
		/// <returns>返回文章记录条数</returns>
		public int GetArticleCount(Guid channelId, bool recursive, Guid userId)
		{
			return this.GetArticleCount(channelId, recursive, new byte[] { 0, 1 }, userId);
		}

		/// <summary>
		/// 获取文章记录条数
		/// </summary>
		/// <param name="channelId">频道编号</param>
		/// <param name="recursive">递归选项，如果true则包括所有子频道，否则只从当前频道获取</param>
		/// <param name="audits">审核状态</param>
		/// <param name="userId">用户编号</param>
		/// <returns>返回文章记录条数</returns>
		public int GetArticleCount(Guid channelId, bool recursive, byte[] audits, Guid? userId)
		{
			var where = this.GetWhereClip(channelId, recursive, audits, userId);

			return dbSession.From<Article>()
				.Where(where).Count();
		}

		/// <summary>
		/// 获取已删除文章记录条数
		/// </summary>
		/// <param name="channelId">频道编号</param>
		/// <param name="recursive">递归选项，如果true则包括所有子频道，否则只从当前频道获取</param>
		/// <returns>返回已删除文章记录条数</returns>
		public int GetDeletedArticleCount(Guid channelId, bool recursive)
		{
			WhereClip where = this.HasDeleted;

			if (recursive)
			{
				var ids = DbChannel.Instance.GetChildChannelIDs(channelId, true);
				ids.Add(channelId);
				where = where && Article._.ChannelID.In(ids.ToArray());
			}
			else
			{
				where = where && Article._.ChannelID == channelId;
			}

			return dbSession.From<Article>()
				.Where(where).Count();
		}

		private IList<Article> GetArticles(WhereClip where, int pageIndex, int pageSize)
		{
			return dbSession.From<Article>()
				.Where(where).OrderBy(Article._.AddTime.Desc)
				.GetPage(pageSize).ToList(pageIndex);
		}

		private WhereClip GetWhereClip(Guid channelId, bool recursive, byte[] audits, Guid? userId)
		{
			WhereClip where = this.NotDeleted;

			if (recursive)
			{
				var ids = DbChannel.Instance.GetChildChannelIDs(channelId, true);
				ids.Add(channelId);
				where = where && Article._.ChannelID.In(ids.ToArray());
			}
			else
			{
				where = where && Article._.ChannelID == channelId;
			}

			if (audits != null)
			{
				where = where && Article._.AuditStatus.In(audits);
			}

			if (userId != null)
			{
				where = where && Article._.UserID == userId.Value;
			}

			return where;
		}
	}
}
