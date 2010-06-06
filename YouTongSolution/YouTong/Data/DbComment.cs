using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySoft.Data;
using YouTong.Model;

namespace YouTong.Data
{
	/// <summary>
	/// 评论-数据层
	/// </summary>
	public class DbComment : DbBase
	{
		public static readonly DbComment Instance = new DbComment();

		internal readonly WhereClip NotDeleted = Comment._.IsDeleted == false;
		internal readonly WhereClip HasDeleted = Comment._.IsDeleted == true;

		/// <summary>
		/// 添加评论
		/// </summary>
		/// <param name="Comment">评论实体</param>
		/// <returns>返回影响行数</returns>
		public int AddComment(Comment comment)
		{
			comment.Detach();
			comment.AddTime = DateTime.Now;
			comment.UpdateTime = DateTime.Now;
			return dbSession.Save<Comment>(comment);
		}

		/// <summary>
		/// 修改评论
		/// </summary>
		/// <param name="Comment">评论实体</param>
		/// <returns>返回影响行数</returns>
		public int UpdateComment(Comment comment)
		{
			comment.Attach();
			comment.UpdateTime = DateTime.Now;
			return dbSession.Save<Comment>(comment);
		}

		/// <summary>
		/// 删除评论
		/// </summary>
		/// <param name="id">评论编号</param>
		/// <returns>返回影响行数</returns>
		public int DeleteComment(Guid id)
		{
			return dbSession.Delete<Comment>(id);
		}

		/// <summary>
		/// 删除评论
		/// </summary>
		/// <param name="ids">评论编号</param>
		/// <returns>返回影响行数</returns>
		public int DeleteComments(params Guid[] ids)
		{
			var where = Comment._.ID.In(ids);

			return dbSession.Delete<Comment>(where);
		}

		/// <summary>
		/// 更新删除标志。
		/// 如果删除标志值与需要设置的值相同，则不进行修改
		/// </summary>
		/// <param name="ids">评论编号，一个数组</param>
		/// <param name="isDeleted">删除标志值</param>
		/// <returns>返回影响行数</returns>
		public int UpdateIsDeleted(Guid[] ids, Boolean isDeleted)
		{
			var where = Comment._.IsDeleted.In(ids) && Comment._.IsDeleted != isDeleted;

			return dbSession.Update<Comment>(
				new Field[] { Comment._.IsDeleted, Comment._.UpdateTime },
				new Object[] { isDeleted, DateTime.Now },
				where);
		}

		/// <summary>
		/// 获取评论
		/// </summary>
		/// <param name="id">评论编号</param>
		/// <returns>返回评论实体</returns>
		public Comment GetComment(Guid id)
		{
			return dbSession.Single<Comment>(id);
		}

		/// <summary>
		/// 获取用户评论
		/// </summary>
		/// <param name="userId">用户编号</param>
		/// <param name="entity">实体</param>
		/// <param name="entityId">实体编号</param>
		/// <param name="pageIndex">页索引</param>
		/// <param name="pageSize">页大小</param>
		/// <returns></returns>
		public IList<Comment> GetComments(string entity, Guid entityId, int pageIndex, int pageSize)
		{
			var where = NotDeleted && Comment._.Entity == entity && Comment._.EntityID == entityId;
			return dbSession.From<Comment>().Where(where).OrderBy(Comment._.AddTime.Desc)
				.GetPage(pageSize)
				.ToList(pageIndex);
		}

		/// <summary>
		/// 获取用户评论
		/// </summary>
		/// <param name="userId">用户编号</param>
		/// <param name="entity">实体</param>
		/// <param name="pageIndex">页索引</param>
		/// <param name="pageSize">页大小</param>
		/// <returns></returns>
		public IList<Comment> GetComments(string entity, int pageIndex, int pageSize)
		{
			var where = NotDeleted && Comment._.Entity == entity;
			return dbSession.From<Comment>().Where(where).OrderBy(Comment._.AddTime.Desc)
				.GetPage(pageSize)
				.ToList(pageIndex);
		}

		/// <summary>
		/// 获取评论记录条数
		/// </summary>
		/// <param name="entity">实体</param>
		/// <param name="entityId">实体编号</param>
		/// <returns></returns>
		public int GetCommentCount(string entity, Guid entityId)
		{
			var where = NotDeleted && Comment._.Entity == entity && Comment._.EntityID == entityId;
			return dbSession.Count<Comment>(where);
		}

		/// <summary>
		/// 获取评论记录条数
		/// </summary>
		/// <param name="entity">实体</param>
		/// <returns></returns>
		public int GetCommentCount(string entity)
		{
			var where = NotDeleted && Comment._.Entity == entity;
			return dbSession.Count<Comment>(where);
		}
	}
}
