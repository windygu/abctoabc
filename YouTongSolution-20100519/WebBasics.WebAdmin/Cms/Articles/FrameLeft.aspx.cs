﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebBasics.Cms.Model;
using WebBasics.WebAdmin.Cms.Codes;

namespace WebBasics.WebAdmin.Cms.Articles
{
	public partial class FrameLeft : PageAuth
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!this.IsPostBack)
			{
				this.LoadTree();
			}
		}

		protected void LoadTree()
		{
			this.TreeViewChannel.Nodes.Clear();

			var allChannels = xChannelService.GetAllChannels();

			TreeNode node = new TreeNode("文章管理", "");
			node.NavigateUrl = "Index.aspx";
			node.Target = "mainFrame";
			this.TreeViewChannel.Nodes.Add(node);

			foreach (var channel in allChannels)
			{
				if (channel.ParentID == null)
				{
					node.ChildNodes.Add(this.LoadTreeNode(channel, allChannels));
				}
			}
		}

		private TreeNode LoadTreeNode(Channel channel, IList<Channel> channels)
		{
			TreeNode node = new TreeNode(channel.DisplayName, channel.ID.ToString());
			node.NavigateUrl = "ArticleList.aspx?ChannelID=" + channel.ID;
			node.Target = "mainFrame";

			var childChannels = channels
				.Where(p => p.ParentID == channel.ID)
				.ToList();

			foreach (var childChannel in childChannels)
			{
				node.ChildNodes.Add(this.LoadTreeNode(childChannel, channels));
			}

			return node;
		}
	}
}
