using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouTong.Model;

namespace YouTong.Common
{
	public interface ICommentService
	{
		/// <summary>
		/// 添加评论
		/// </summary>
		/// <param name="Comment">评论实体</param>
		/// <returns>返回影响行数</returns>
		int AddComment(Comment comment);

		/// <summary>
		/// 修改评论
		/// </summary>
		/// <param name="Comment">评论实体</param>
		/// <returns>返回影响行数</returns>
		int UpdateComment(Comment comment);

		/// <summary>
		/// 删除评论
		/// </summary>
		/// <param name="id">评论编号</param>
		/// <returns>返回影响行数</returns>
		int DeleteComment(Guid id);

		/// <summary>
		/// 删除评论
		/// </summary>
		/// <param name="ids">评论编号</param>
		/// <returns>返回影响行数</returns>
		int DeleteComments(params Guid[] ids);

		/// <summary>
		/// 获取评论
		/// </summary>
		/// <param name="id">评论编号</param>
		/// <returns>返回评论实体</returns>
		Comment GetComment(Guid id);

		/// <summary>
		/// 获取用户评论
		/// </summary>
		/// <param name="userId">用户编号</param>
		/// <param name="entity">实体</param>
		/// <param name="entityId">实体编号</param>
		/// <param name="pageIndex">页索引</param>
		/// <param name="pageSize">页大小</param>
		/// <returns></returns>
		IList<Comment> GetComments(string entity, Guid entityId, int pageIndex, int pageSize);

		/// <summary>
		/// 获取用户评论
		/// </summary>
		/// <param name="userId">用户编号</param>
		/// <param name="entity">实体</param>
		/// <param name="pageIndex">页索引</param>
		/// <param name="pageSize">页大小</param>
		/// <returns></returns>
		IList<Comment> GetComments(string entity, int pageIndex, int pageSize);

		/// <summary>
		/// 获取评论记录条数
		/// </summary>
		/// <param name="entity">实体</param>
		/// <param name="entityId">实体编号</param>
		/// <returns></returns>
		int GetCommentCount(string entity, Guid entityId);

		/// <summary>
		/// 获取评论记录条数
		/// </summary>
		/// <param name="entity">实体</param>
		/// <returns></returns>
		int GetCommentCount(string entity);
	}
}
