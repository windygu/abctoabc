using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebBasics.Cms.Common;
using WebBasics.Cms.Model;
using YouTong.Model;

namespace YouTong
{
	public class FamilyMediaAction
	{
		public static readonly string EntityName = "亲子影像";

		/// <summary>
		/// 官方分类
		/// </summary>
		/// <returns></returns>
		public static IList<Channel> GetOfficialCategories()
		{
			return CmsFactory.Instance.ChannelService.GetChildChannels(UtConfig.FamilyMediaChannelID);
		}

		/// <summary>
		/// 用户自定义分类
		/// </summary>
		/// <param name="userId"></param>
		/// <returns></returns>
		public static IList<Category> GetUserCategories(Guid userId)
		{
			return CategoryService.Instance.GetCategoriesByUser(userId, EntityName);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="categoryId"></param>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		public static IList<AnyFile> GetFamilyMediasByUserCategory(Guid categoryId, int pageIndex, int pageSize)
		{
			return null;
		}
	}
}
