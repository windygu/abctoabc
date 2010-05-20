using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebBasics.Cms.Model;

namespace WebBasics.Cms.Common
{
	/// <summary>
	/// 频道服务 接口
	/// </summary>
	public interface IChannelService
	{
		/// <summary>
		/// 添加频道
		/// </summary>
		/// <param name="channel">频道实体</param>
		void AddChannel(Channel channel);

		/// <summary>
		/// 修改频道
		/// </summary>
		/// <param name="channel">频道实体</param>
		void UpdateChannel(Channel channel);

		/// <summary>
		/// 删除频道
		/// </summary>
		/// <param name="id">频道编号</param>
		void DeleteChannel(Guid id);

		/// <summary>
		/// 删除频道
		/// </summary>
		/// <param name="ids">频道编号，一个数组</param>
		void DeleteChannels(Guid[] ids);

		/// <summary>
		/// 彻底删除频道
		/// </summary>
		/// <param name="id">频道编号</param>
		void ShiftDeleteChannel(Guid id);

		/// <summary>
		/// 彻底删除频道
		/// </summary>
		/// <param name="ids">频道编号，一个数组</param>
		void ShiftDeleteChannels(Guid[] ids);

		/// <summary>
		/// 获取频道
		/// </summary>
		/// <param name="id">频道编号</param>
		/// <returns>返回频道实体</returns>
		Channel GetChannel(Guid id);

		/// <summary>
		/// 获取所有频道列表。
		/// </summary>
		/// <returns>返回频道实体列表</returns>
		IList<Channel> GetAllChannels();

		/// <summary>
		/// 获取根频道列表
		/// </summary>
		/// <returns>返回频道实体列表</returns>
		IList<Channel> GetRootChannels();

		/// <summary>
		/// 获取子频道列表
		/// </summary>
		/// <param name="channelId">频道编号</param>
		/// <returns>返回频道实体列表</returns>
		IList<Channel> GetChildChannels(Guid id);

		/// <summary>
		/// 指定编号的频道是否存在
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Boolean ExistsChannel(Guid id);

		/// <summary>
		/// 获取频道
		/// </summary>
		/// <param name="ids">频道编号，一个数组</param>
		/// <returns>返回频道实体列表</returns>
		IList<Channel> GetChannels(params Guid[] ids);

		/// <summary>
		/// 重置Family字段
		/// </summary>
		/// <param name="channel">频道</param>
		/// <param name="update">是否更新到数据库</param>
		void ResetChannelFamily(Channel channel, Boolean update);
	}
}
