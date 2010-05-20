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
	/// 频道服务
	/// </summary>
	public class ChannelService : BusinessBase, IChannelService
	{
		/// <summary>
		/// ChannelService实例
		/// </summary>
		public static readonly ChannelService Instance = new ChannelService();

		#region IChannelService 成员

		public void AddChannel(Channel channel)
		{
			channel.ID = Comb.NewComb2();
			this.ResetChannelFamily(channel, false);
			dbChannel.AddChannel(channel);
		}

		public void UpdateChannel(Channel channel)
		{
			this.ResetChannelFamily(channel, false);
			dbChannel.UpdateChannel(channel);
		}

		public void DeleteChannel(Guid id)
		{
			// 需要删除所有与该频道相关的信息

			// 删除该频道以及所有子频道（递归）
			var childIds = dbChannel.GetChildChannelIDs(id, true);
			var ids = new List<Guid>(childIds);
			ids.Add(id);
			dbChannel.UpdateIsDeleted(ids.ToArray(), true);

			// 删除所有被删除频道的文章
			dbArticle.UpdateIsDeletedByChannel(ids.ToArray(), true);
		}

		public void DeleteChannels(Guid[] ids)
		{
			foreach (var id in ids)
			{
				this.DeleteChannel(id);
			}
		}

		public void ShiftDeleteChannel(Guid id)
		{
			throw new NotImplementedException();
		}

		public void ShiftDeleteChannels(Guid[] ids)
		{
			throw new NotImplementedException();
		}

		public Channel GetChannel(Guid id)
		{
			return dbChannel.GetChannel(id);
		}

		public IList<Channel> GetAllChannels()
		{
			return dbChannel.GetAllChannels();
		}

		public IList<Channel> GetRootChannels()
		{
			return dbChannel.GetRootChannels();
		}

		public IList<Channel> GetChildChannels(Guid id)
		{
			return dbChannel.GetChildChannels(id);
		}

		public bool ExistsChannel(Guid id)
		{
			return dbCommon.Exists<Channel>(id);
		}

		public IList<Channel> GetChannels(params Guid[] ids)
		{
			return dbChannel.GetChannels(ids);
		}

		public void ResetChannelFamily(Channel channel, bool update)
		{
			if (channel.ParentID.HasValue)
			{
				var parentChannel = this.GetChannel(channel.ParentID.Value);
				if (parentChannel != null && !String.IsNullOrEmpty(parentChannel.Family))
				{
					channel.Family = parentChannel.Family + "," + channel.ID;
				}
				else
				{
					channel.Family = channel.ID.ToString();
				}
			}
			else
			{
				channel.Family = channel.ID.ToString();
			}

			if (update)
			{
				dbChannel.UpdateChannel(channel);
			}
		}

		#endregion
	}
}
