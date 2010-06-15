﻿using System;
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
	/// 文件服务
	/// </summary>
	public class AnyFileService : BusinessBase, IAnyFileService
	{
		/// <summary>
		/// AnyFileService实例
		/// </summary>
		public static readonly AnyFileService Instance = new AnyFileService();

		#region IAnyFileService 成员

		public void AddAnyFile(AnyFile anyFile)
		{
			anyFile.ID = Comb.NewComb2();
			var article = new Article();

			WbUtility.CopyPropertiesTo<AnyFile, Article>(anyFile, article);

			article.RelationalModel = 1;	// AnyFile=1

			dbArticle.AddArticle(article);
			dbAnyFile.AddAnyFile(anyFile);
		}

		public void UpdateAnyFile(AnyFile anyFile)
		{
			var article = dbArticle.GetArticle(anyFile.ID);
			article.ChannelID = anyFile.ChannelID;

			article.Title = anyFile.Title;
			article.Summary = anyFile.Summary;
			article.Body = anyFile.Body;
			article.Author = anyFile.Author;
			article.UserID = anyFile.UserID;
			article.AdminID = anyFile.AdminID;

			dbArticle.UpdateArticle(article);
			dbAnyFile.UpdateAnyFile(anyFile);
		}

		public void DeleteAnyFile(Guid id)
		{
			var ids = new Guid[] { id };
			dbArticle.UpdateIsDeleted(ids, true);
			dbAnyFile.UpdateIsDeleted(ids, true);
		}

		public void DeleteAnyFiles(params Guid[] ids)
		{
			dbArticle.UpdateIsDeleted(ids, true);
			dbAnyFile.UpdateIsDeleted(ids, true);
		}

		public void DeleteAnyFilesByChannel(Guid channelId)
		{
			dbArticle.UpdateIsDeletedByChannel(channelId, true);
			dbAnyFile.UpdateIsDeletedByChannel(channelId, true);
		}

		public void DeleteAnyFilesByChannel(params Guid[] channelds)
		{
			dbArticle.UpdateIsDeletedByChannel(channelds, true);
			dbAnyFile.UpdateIsDeletedByChannel(channelds, true);
		}

		public void ShiftDeleteAnyFile(Guid id)
		{
			throw new NotImplementedException();
		}

		public void ShiftDeleteAnyFiles(Guid[] ids)
		{
			throw new NotImplementedException();
		}

		public AnyFile GetAnyFile(Guid id)
		{
			return dbAnyFile.GetAnyFile(id);
		}

		public IList<AnyFile> GetAnyFiles(Guid[] ids)
		{
			return dbAnyFile.GetAnyFiles(ids);
		}

		public IList<AnyFile> GetAnyFiles(Guid channelId, bool recursive, int pageIndex, int pageSize)
		{
			return dbAnyFile.GetAnyFiles(channelId, recursive, pageIndex, pageSize);
		}

        public IList<AnyFile> GetAnyFiles(Guid channelId, string text, int pageIndex, int pageSize, out int rowTotal)
        {
            return dbAnyFile.GetAnyFiles(channelId, text, pageIndex, pageSize, out rowTotal);
        }

		public IList<AnyFile> GetAnyFiles(Guid channelId, bool recursive, Guid? userId, int? fileType, int pageIndex, int pageSize)
		{
			return dbAnyFile.GetAnyFiles(channelId, recursive, userId, fileType, pageIndex, pageSize);
		}

		public IList<AnyFile> GetAnyFiles(Guid channelId, bool recursive, Guid? userId, int? fileType, string from, int pageIndex, int pageSize)
		{
			return dbAnyFile.GetAnyFiles(channelId, true, userId, fileType, from, pageIndex, pageSize);
		}

		/// <summary>
		/// 获取推荐文件列表
		/// </summary>
		/// <param name="channelId">频道编号</param>
		/// <param name="recursive">递归选项，如果true则包括所有子频道，否则只从当前频道获取</param>
		/// <param name="pageIndex">当前索引页</param>
		/// <param name="pageSize">每页记录数</param>
		/// <returns>返回文件实体列表</returns>
		public IList<AnyFile> GetRecommendAnyFiles(Guid channelId, bool recursive, int pageIndex, int pageSize)
		{
			return dbAnyFile.GetRecommendAnyFiles(channelId, recursive, pageIndex, pageSize);
		}

		public IList<AnyFile> GetDeletedAnyFiles(Guid channelId, bool recursive, int pageIndex, int pageSize)
		{
			return dbAnyFile.GetDeletedAnyFiles(channelId, recursive, pageIndex, pageSize);
		}

		public int GetAnyFileCount(Guid channelId, bool recursive)
		{
			return dbAnyFile.GetAnyFileCount(channelId, recursive);
		}

		public int GetAnyFileCount(Guid channelId, bool recursive, Guid? userId, int? fileType, string from)
		{
			return dbAnyFile.GetAnyFileCount(channelId, recursive, userId, fileType, from);
		}

		public int GetDeletedAnyFileCount(Guid channelId, bool recursive)
		{
			return dbAnyFile.GetDeletedAnyFileCount(channelId, recursive);
		}

		public int AuditPass(Guid[] ids)
		{
			return dbAnyFile.UpdateAuditStatus(ids, 1);
		}

		public int AuditRefuse(Guid[] ids)
		{
			return dbAnyFile.UpdateAuditStatus(ids, 2);
		}

		public int Recommend(Guid[] ids, byte recommend)
		{
			return dbAnyFile.UpdateRecommend(ids, recommend);
		}

		#endregion

	}
}
