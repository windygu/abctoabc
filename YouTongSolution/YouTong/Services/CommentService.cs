using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouTong.Common;
using YouTong.Model;

namespace YouTong
{
	public class CommentService : BusinessBase
	{
		/// <summary>
		/// 添加评论
		/// </summary>
		/// <param name="Comment">评论实体</param>
		/// <returns>返回影响行数</returns>
		public int AddComment(Comment comment)
		{
			return dbComment.AddComment(comment);
		}

		/// <summary>
		/// 修改评论
		/// </summary>
		/// <param name="Comment">评论实体</param>
		/// <returns>返回影响行数</returns>
		public int UpdateComment(Comment comment)
		{
			return dbComment.UpdateComment(comment);
		}

		/// <summary>
		/// 删除评论
		/// </summary>
		/// <param name="id">评论编号</param>
		/// <returns>返回影响行数</returns>
		public int DeleteComment(Guid id)
		{
			return dbComment.DeleteComment(id);
		}

		/// <summary>
		/// 删除评论
		/// </summary>
		/// <param name="ids">评论编号</param>
		/// <returns>返回影响行数</returns>
		public int DeleteComments(params Guid[] ids)
		{
			return dbComment.DeleteComments(ids);
		}

		/// <summary>
		/// 获取评论
		/// </summary>
		/// <param name="id">评论编号</param>
		/// <returns>返回评论实体</returns>
		public Comment GetComment(Guid id)
		{
			return dbComment.GetComment(id);
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
			return dbComment.GetComments(entity, entityId, pageIndex, pageSize);
		}
	}
}
