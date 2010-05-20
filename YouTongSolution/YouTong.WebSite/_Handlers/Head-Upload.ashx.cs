using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using WebBasics.Utilities;
using YouTong.WebSite.Codes;

namespace YouTong.WebSite._Handlers
{
	/// <summary>
	/// $codebehindclassname$ 的摘要说明
	/// </summary>
	[WebService(Namespace = "http://tempuri.org/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	public class Head_Upload : HttpHandlerBase
	{
		public override void ProcessRequest(HttpContext context)
		{
			base.ProcessRequest(context);

			String result = "";

			try
			{
				if (Request.Files.Count == 0)
				{
					throw new UtException("没有上传文件");
				}

				HttpPostedFile file = Request.Files[0];

				var originalName = Path.GetFileName(file.FileName);
				var fileExtension = Path.GetExtension(file.FileName).ToLower();
				float fileSize = file.ContentLength / 1024;

				if (fileSize == 0)
				{
					throw new UtException("没有选择文件");
				}

				// 生成文件名
				DateTime now = DateTime.Now;
				var fileName = string.Format("{0}{1}", Comb.NewComb2().ToString(), fileExtension);
				var fileUrl = Path.Combine(DateTime.Now.ToString("yyyyMMdd") + "/", fileName);
				var thumbnailUrl = Path.Combine(now.ToString("yyyyMMdd") + "/t/", fileName);

				if (fileExtension != ".jpg" && fileExtension != ".gif" && fileExtension != ".png" && fileExtension != ".bmp" && fileExtension != ".jpeg")
				{
					throw new UtException("图片文件格式不符合要求");
				}

				// 设置目录
				fileUrl = Path.Combine("/uploads/heads/", fileUrl);
				thumbnailUrl = Path.Combine("/uploads/heads/", thumbnailUrl);

				string filePath = Server.MapPath(fileUrl);
				if (!Directory.Exists(Path.GetDirectoryName(filePath)))
				{
					Directory.CreateDirectory(Path.GetDirectoryName(filePath));
				}

				file.SaveAs(filePath);

				string thumbnailPath = Server.MapPath(thumbnailUrl);
				if (!Directory.Exists(Path.GetDirectoryName(thumbnailPath)))
				{
					Directory.CreateDirectory(Path.GetDirectoryName(thumbnailPath));
				}

				System.Drawing.Image originalImage = System.Drawing.Image.FromStream(file.InputStream);
				ImageHelper.MakeThumbnail(originalImage, thumbnailPath, 120, ThumbnailType.AutoCut);

				result = String.Format("{{BigUrl:'{0}', SmallUrl:'{1}'}}", fileUrl, thumbnailUrl);
			}
			catch (UtException ex)
			{
				result = String.Format("{{Error:'{0}'}}", ex.Message);
			}
			catch
			{
				result = String.Format("{{Error:'{0}'}}", "未知错误");
			}

			var callback = Request["callback"];
			if (String.IsNullOrEmpty(callback))
			{
				Response.Write(result);
			}
			else
			{
				Response.ContentType = "text/html";
				JavaScript.Write(String.Format("parent.{0}({1})", callback, result));
			}
		}

		public bool IsReusable
		{
			get
			{
				return false;
			}
		}
	}
}
