using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebBasics.Cms.Model
{
	/// <summary>
	/// 审核状态
	/// </summary>
	public enum CmsAuditStatus : byte
	{
		/// <summary>
		/// 常态
		/// </summary>
		Normal = 0,
		/// <summary>
		/// 通过
		/// </summary>
		Pass = 1,
		/// <summary>
		/// 拒绝
		/// </summary>
		Refuse = 2
	}
}
