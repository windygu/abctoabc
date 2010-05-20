﻿using System;
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
	public class DbAnyFile
	{
		/// <summary>
		/// DbAnyFile实例
		/// </summary>
		public static readonly DbAnyFile Instance = new DbAnyFile();

		DbSession dbSession = new DbSession("wbcms");
		readonly WhereClip NotDeleted = AnyFile._.IsDeleted == false;
		readonly WhereClip HasDeleted = AnyFile._.IsDeleted == true;

		/// <summary>
		/// 添加文章
		/// </summary>
		/// <param name="AnyFile">文章实体</param>
		/// <returns>返回影响行数</returns>
		public Int32 AddAnyFile(AnyFile file)
		{
			file.Detach();
			if (file.ID == Guid.Empty) file.ID = Comb.NewComb2();
			if (file.OccurTime == DateTime.MinValue) file.OccurTime = DateTime.Now;
			file.AddTime = DateTime.Now;
			file.UpdateTime = DateTime.Now;
			return dbSession.Save<AnyFile>(file);
		}

		/// <summary>
		/// 修改文章
		/// </summary>
		/// <param name="AnyFile">文章实体</param>
		/// <returns>返回影响行数</returns>
		public Int32 UpdateAnyFile(AnyFile file)
		{
			file.Attach();
			file.UpdateTime = DateTime.Now;
			return dbSession.Save<AnyFile>(file);
		}

		/// <summary>
		/// 删除文章
		/// </summary>
		/// <param name="id">文章编号</param>
		/// <returns>返回影响行数</returns>
		public Int32 DeleteAnyFile(Guid id)
		{
			return dbSession.Delete<AnyFile>(id);
		}

		/// <summary>
		/// 删除文章
		/// </summary>
		/// <param name="ids">文章编号</param>
		/// <returns>返回影响行数</returns>
		public Int32 DeleteAnyFiles(params Guid[] ids)
		{
			var where = AnyFile._.ID.In(ids);

			return dbSession.Delete<AnyFile>(where);
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
			var where = AnyFile._.ID.In(ids) && AnyFile._.IsDeleted != isDeleted;

			return dbSession.Update<AnyFile>(
				new Field[] { AnyFile._.IsDeleted, AnyFile._.UpdateTime },
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
			var where = AnyFile._.ChannelID == channelId && AnyFile._.IsDeleted != isDeleted;

			return dbSession.Update<AnyFile>(
				new Field[] { AnyFile._.IsDeleted, AnyFile._.UpdateTime },
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
			var where = AnyFile._.ChannelID.In(channelds) && AnyFile._.IsDeleted != isDeleted;

			return dbSession.Update<AnyFile>(
				new Field[] { AnyFile._.IsDeleted, AnyFile._.UpdateTime },
				new Object[] { isDeleted, DateTime.Now },
				where);
		}

		/// <summary>
		/// 获取文章
		/// </summary>
		/// <param name="id">文章编号</param>
		/// <returns>返回文章实体</returns>
		public AnyFile GetAnyFile(Guid id)
		{
			return dbSession.Single<AnyFile>(id);
		}

		/// <summary>
		/// 获取文章列表
		/// </summary>
		/// <param name="channelId">频道编号</param>
		/// <param name="recursive">递归选项，如果true则包括所有子频道，否则只从当前频道获取</param>
		/// <param name="pageIndex">当前索引页</param>
		/// <param name="pageSize">每页记录数</param>
		/// <returns>返回文章实体列表</returns>
		public IList<AnyFile> GetAnyFiles(Guid channelId, bool recursive, int pageIndex, int pageSize)
		{
			WhereClip where = this.NotDeleted;

			if (recursive)
			{
				var ids = DbChannel.Instance.GetChildChannelIDs(channelId, true);
				ids.Add(channelId);
				where = where && AnyFile._.ChannelID.In(ids.ToArray());
			}
			else
			{
				where = where && AnyFile._.ChannelID == channelId;
			}

			return dbSession.From<AnyFile>()
				.Where(where).OrderBy(AnyFile._.AddTime.Desc)
				.GetPage(pageSize).ToList(pageIndex);
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
		public IList<AnyFile> GetAnyFiles(Guid channelId, bool recursive, Guid? userId, Int32? fileType, int pageIndex, int pageSize)
		{
			WhereClip where = this.NotDeleted;
			if (userId.HasValue)
			{
				where = where && AnyFile._.UserID == userId;

			}
			if (fileType.HasValue)
			{
				where = where && AnyFile._.FileType == fileType.Value;
			}

			if (recursive)
			{
				var ids = DbChannel.Instance.GetChildChannelIDs(channelId, true);
				ids.Add(channelId);
				where = where && AnyFile._.ChannelID.In(ids.ToArray());
			}
			else
			{
				where = where && AnyFile._.ChannelID == channelId;
			}

			return dbSession.From<AnyFile>()
				.Where(where).OrderBy(AnyFile._.AddTime.Desc)
				.GetPage(pageSize).ToList(pageIndex);
		}

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
		public IList<AnyFile> GetAnyFiles(Guid channelId, Boolean recursive, Guid? userId, Int32? fileType, String from, Int32 pageIndex, Int32 pageSize)
		{
			WhereClip where = this.GetWhere(channelId, recursive, userId, fileType, from);

			return dbSession.From<AnyFile>()
				.Where(where).OrderBy(AnyFile._.AddTime.Desc)
				.GetPage(pageSize).ToList(pageIndex);
		}

		/// <summary>
		/// 获取已删除文章列表
		/// </summary>
		/// <param name="channelId">频道编号</param>
		/// <param name="recursive">递归选项，如果true则包括所有子频道，否则只从当前频道获取</param>
		/// <param name="pageIndex">当前索引页</param>
		/// <param name="pageSize">每页记录数</param>
		/// <returns>返回已删除文章实体列表</returns>
		public IList<AnyFile> GetDeletedAnyFiles(Guid channelId, bool recursive, int pageIndex, int pageSize)
		{
			WhereClip where = this.HasDeleted;

			if (recursive)
			{
				var ids = DbChannel.Instance.GetChildChannelIDs(channelId, true);
				ids.Add(channelId);
				where = where && AnyFile._.ChannelID.In(ids.ToArray());
			}
			else
			{
				where = where && AnyFile._.ChannelID == channelId;
			}

			return dbSession.From<AnyFile>()
				.Where(where).OrderBy(AnyFile._.AddTime.Desc)
				.GetPage(pageSize).ToList(pageIndex);
		}

		/// <summary>
		/// 获取文章记录条数
		/// </summary>
		/// <param name="channelId">频道编号</param>
		/// <param name="recursive">递归选项，如果true则包括所有子频道，否则只从当前频道获取</param>
		/// <returns>返回文章记录条数</returns>
		public int GetAnyFileCount(Guid channelId, bool recursive)
		{
			var where = this.GetWhere(channelId, recursive, null, null, null);

			return dbSession.From<AnyFile>()
				.Where(where).Count();
		}

		public int GetAnyFileCount(Guid channelId, bool recursive, Guid? userId, int? fileType, string from)
		{
			var where = this.GetWhere(channelId, recursive, userId, fileType, from);

			return dbSession.From<AnyFile>()
				.Where(where).Count();
		}

		/// <summary>
		/// 获取已删除文章记录条数
		/// </summary>
		/// <param name="channelId">频道编号</param>
		/// <param name="recursive">递归选项，如果true则包括所有子频道，否则只从当前频道获取</param>
		/// <returns>返回已删除文章记录条数</returns>
		public int GetDeletedAnyFileCount(Guid channelId, bool recursive)
		{
			WhereClip where = this.HasDeleted;

			if (recursive)
			{
				var ids = DbChannel.Instance.GetChildChannelIDs(channelId, true);
				ids.Add(channelId);
				where = where && AnyFile._.ChannelID.In(ids.ToArray());
			}
			else
			{
				where = where && AnyFile._.ChannelID == channelId;
			}

			return dbSession.From<AnyFile>()
				.Where(where).Count();
		}

		public IList<AnyFile> GetAnyFiles(WhereClip where, OrderByClip orderBy, int pageIndex, int pageSize)
		{
			return dbSession.From<AnyFile>()
				.Where(where).OrderBy(orderBy)
				.GetPage(pageSize).ToList(pageIndex);
		}

		public WhereClip GetWhere(Guid channelId, Boolean recursive, Guid? userId, Int32? fileType, String from)
		{
			WhereClip where = this.NotDeleted;
			if (userId.HasValue)
			{
				where = where && AnyFile._.UserID == userId;
			}
			if (fileType.HasValue)
			{
				where = where && AnyFile._.FileType == fileType.Value;
			}
			if (from != null)
			{
				where = where && AnyFile._.From == from;
			}

			if (recursive)
			{
				var ids = DbChannel.Instance.GetChildChannelIDs(channelId, true);
				ids.Add(channelId);
				where = where && AnyFile._.ChannelID.In(ids.ToArray());
			}
			else
			{
				where = where && AnyFile._.ChannelID == channelId;
			}
			return where;
		}

	}
}
