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
	/// 频道 数据操作
	/// </summary>
	public class DbChannel
	{
		/// <summary>
		/// DbChannel实例
		/// </summary>
		public static readonly DbChannel Instance = new DbChannel();

		DbSession dbSession = new DbSession("wbcms");
		readonly WhereClip NotDeleted = Channel._.IsDeleted == false;
		readonly WhereClip HasDeleted = Channel._.IsDeleted == true;

		/// <summary>
		/// 添加频道
		/// </summary>
		/// <param name="channel">频道实体</param>
		/// <returns>返回影响行数</returns>
		public Int32 AddChannel(Channel channel)
		{
			channel.Detach();

			if (channel.ID == Guid.Empty) channel.ID = Comb.NewComb2();
			channel.AddTime = DateTime.Now;
			channel.UpdateTime = DateTime.Now;
			return dbSession.Save<Channel>(channel);
		}

		/// <summary>
		/// 修改频道
		/// </summary>
		/// <param name="channel">频道实体</param>
		/// <returns>返回影响行数</returns>
		public Int32 UpdateChannel(Channel channel)
		{
			channel.Attach();
			channel.UpdateTime = DateTime.Now;
			return dbSession.Save<Channel>(channel);
		}

		/// <summary>
		/// 删除频道
		/// </summary>
		/// <param name="id">频道编号</param>
		/// <returns>返回影响行数</returns>
		public Int32 DeleteChannel(Guid id)
		{
			return dbSession.Delete<Channel>(id);
		}

		/// <summary>
		/// 删除频道
		/// </summary>
		/// <param name="ids">频道编号</param>
		/// <returns>返回影响行数</returns>
		public Int32 DeleteChannels(params Guid[] ids)
		{
			var where = Channel._.ID.In(ids);

			return dbSession.Delete<Channel>(where);
		}

		/// <summary>
		/// 更新删除标志。
		/// 如果删除标志值与需要设置的值相同，则不进行修改
		/// </summary>
		/// <param name="ids">频道编号，一个数组</param>
		/// <param name="isDeleted">删除标志值</param>
		/// <returns>返回影响行数</returns>
		public Int32 UpdateIsDeleted(Guid[] ids, Boolean isDeleted)
		{
			var where = Channel._.IsDeleted.In(ids) && Channel._.IsDeleted != isDeleted;

			return dbSession.Update<Channel>(
				new Field[] { Channel._.IsDeleted, Channel._.UpdateTime },
				new Object[] { isDeleted, DateTime.Now },
				where);
		}

		/// <summary>
		/// 获取频道
		/// </summary>
		/// <param name="id">频道编号</param>
		/// <returns>返回频道实体</returns>
		public Channel GetChannel(Guid id)
		{
			return dbSession.Single<Channel>(id);
		}

		/// <summary>
		/// 获取所有频道列表
		/// </summary>
		/// <returns>返回频道实体列表</returns>
		public IList<Channel> GetAllChannels()
		{
			var where = NotDeleted;
			return dbSession.From<Channel>()
				.Where(where).OrderBy(Channel._.AddTime.Asc)
				.ToList();
		}

		/// <summary>
		/// 获取根频道列表
		/// </summary>
		/// <returns>返回频道实体列表</returns>
		public IList<Channel> GetRootChannels()
		{
			var where = NotDeleted && Channel._.ParentID.IsNull();

			return dbSession.From<Channel>()
				.Where(where).OrderBy(Channel._.AddTime.Asc)
				.ToList();
		}

		/// <summary>
		/// 获取子频道列表
		/// </summary>
		/// <param name="channelId">频道编号</param>
		/// <returns>返回频道实体列表</returns>
		public IList<Channel> GetChildChannels(Guid id)
		{
			var where = NotDeleted && Channel._.ParentID == id;

			return dbSession.From<Channel>()
				.Where(where).OrderBy(Channel._.AddTime.Asc)
				.ToList();
		}

		/// <summary>
		/// 获取子频道列表
		/// </summary>
		/// <param name="id">频道编号</param>
		/// <param name="recursive">递归选项，如果true则递归子频道的的子频道，否则不递归获取</param>
		/// <returns>返回频道实体列表</returns>
		public IList<Channel> GetChildChannels(Guid id, bool recursive)
		{
			var where = NotDeleted && Channel._.Family.Like("%" + id.ToString() + "%");

			return dbSession.From<Channel>()
				.Where(where).OrderBy(Channel._.AddTime.Asc)
				.ToList();
		}

		/// <summary>
		/// 获取子频道编号
		/// </summary>
		/// <param name="id">频道编号</param>
		/// <param name="recursive">递归选项，如果true则递归子频道的的子频道，否则不递归获取</param>
		/// <returns>返回频道编号列表</returns>
		public IList<Guid> GetChildChannelIDs(Guid id, bool recursive)
		{
			IList<Channel> childChannels;

			if (recursive)
			{
				childChannels = this.GetChildChannels(id, recursive);
			}
			else
			{
				childChannels = this.GetChildChannels(id);
			}

			var ids = new List<Guid>();

			(childChannels as List<Channel>).ForEach(p => ids.Add(p.ID));

			return ids;
		}

		/// <summary>
		/// 获取频道
		/// </summary>
		/// <param name="ids">频道编号，一个数组</param>
		/// <returns>返回频道实体列表</returns>
		public IList<Channel> GetChannels(params Guid[] ids)
		{
			return dbSession.From<Channel>().Where(Channel._.ID.In(ids)).ToList();
		}
	}
}
