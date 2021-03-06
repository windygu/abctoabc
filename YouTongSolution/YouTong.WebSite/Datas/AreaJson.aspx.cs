﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using YouTong.Data;

namespace YouTong.WebSite.Datas
{
	public partial class AreaJson : System.Web.UI.Page
	{
		public String json;

		protected void Page_Load(object sender, EventArgs e)
		{
			var areas = DbArea.Instance.GetAllAreas();

			json = JsonConvert.SerializeObject(areas, Formatting.None,
				new JsonSerializerSettings { ContractResolver = new AreaContractResolver() });
		}
	}

	public class AreaContractResolver : DefaultContractResolver
	{
		protected override IList<JsonProperty> CreateProperties(JsonObjectContract contract)
		{
			var properties = base.CreateProperties(contract);

			return properties
				.Where(p => p.PropertyName == "ID" || p.PropertyName == "Name" || p.PropertyName == "ParentID")
				.ToList();
		}
	}
}
