using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using YouTong.Data;
using YouTong.WebSite.Codes;
using Itfort.Web;

namespace YouTong.WebSite._Handlers
{
	/// <summary>
	/// $codebehindclassname$ 的摘要说明
	/// </summary>
	[WebService(Namespace = "http://tempuri.org/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	public class GetSchools : HttpHandlerBase
	{
		public override void ProcessRequest(HttpContext context)
		{
			base.ProcessRequest(context);

			var region = RequestObject.ToInt32("region");
			var level = RequestObject.ToInt32("level");

			var schools = DbSchool.Instance.GetSchoolsByRegion(region, level);

			var json = JsonConvert.SerializeObject(schools, Formatting.None,
				new JsonSerializerSettings { ContractResolver = new SchoolContractResolver() });

			Response.Write(json);
		}
	}

	public class SchoolContractResolver : DefaultContractResolver
	{
		protected override IList<JsonProperty> CreateProperties(JsonObjectContract contract)
		{
			var properties = base.CreateProperties(contract);

			return properties
				.Where(p => p.PropertyName == "ID" || p.PropertyName == "Name" || p.PropertyName == "Region")
				.ToList();
		}
	}
}
