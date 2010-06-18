<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ChildNews.ascx.cs" Inherits="YouTong.WebSite.Includes.ChildNews" %>
<div class="redianxinxi">
	<div class="duanblock1">
		<div class="kong">
			<a class="title" href="#">优童新闻</a>
			<a href="/news/news-list.aspx?id=7601789d-109d-9c32-f10f-eba23944a4cd" class="more">&gt;&gt;更多</a>
		</div>
	</div>
	<div class="duanblock2">
		<asp:Repeater ID="rp_ChildNews" runat="server">
			<HeaderTemplate>
				<ul class="zuixin">
			</HeaderTemplate>
			<ItemTemplate>
				<li>
					<a href="/news/news-detail.aspx?id=<%# Eval("ID") %>" class="choose">
						<%# Eval("Title") %></a></li>
			</ItemTemplate>
			<FooterTemplate>
				</ul>
			</FooterTemplate>
		</asp:Repeater>
	</div>
	<div class="duanblock3">
	</div>
</div>