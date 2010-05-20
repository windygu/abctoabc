using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using Itfort.Web;
using Itfort.Web.Binder;
using WebBasics.Cms.Common;
using WebBasics.Cms.Model;
using WebBasics.Utilities;
using YouTong.WebSite.Codes;

namespace YouTong.WebSite._Handlers
{
	/// <summary>
	/// $codebehindclassname$ 的摘要说明
	/// </summary>
	[WebService(Namespace = "http://tempuri.org/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	public class CmsAnyFile_Upload : HttpHandlerBase
	{
		public override void ProcessRequest(HttpContext context)
		{
			base.ProcessRequest(context);
			var success = true;
			AnyFile anyFile = ConverterFactory.ConvertTo<AnyFile>(Request.Params, "File_");

			try
			{
				if (Request.Files.Count > 0)
				{
					HttpPostedFile file = Request.Files[0];

					var originalName = Path.GetFileName(file.FileName);
					anyFile.FileExtension = Path.GetExtension(file.FileName).ToLower();

					anyFile.FileSize = file.ContentLength / 1024;

					//生成文件名
					DateTime now = DateTime.Now;
					var newFileName = string.Format("{0}{1}", Comb.NewComb2().ToString(), anyFile.FileExtension);
					var tempDir = DateTime.Now.ToString("yyyyMMdd");

					if (anyFile.FileExtension == ".jpg" || anyFile.FileExtension == ".gif" || anyFile.FileExtension == ".png" || anyFile.FileExtension == ".bmp" || anyFile.FileExtension == ".jpeg")
					{	// 已知图片格式
						anyFile.FileUrl = Path.Combine("/uploads/cmspics/" + tempDir + "/", newFileName);
						anyFile.ThumbnailUrl = Path.Combine("/uploads/cmspics/" + tempDir + "/t/", newFileName);
						anyFile.FileType = (byte)AnyFileType.Photo;
					}
					else
					{
						anyFile.FileUrl = Path.Combine("/uploads/cmsfiles/" + tempDir + "/", newFileName);
						anyFile.ThumbnailUrl = "";
					}

					// 保存文件
					var filePath = Server.MapPath(anyFile.FileUrl);
					if (!Directory.Exists(Path.GetDirectoryName(filePath)))
					{
						Directory.CreateDirectory(Path.GetDirectoryName(filePath));
					}
					file.SaveAs(filePath);

					// 缩略图
					if (!String.IsNullOrEmpty(anyFile.ThumbnailUrl))
					{
						var thumbnailPath = Server.MapPath(anyFile.ThumbnailUrl);
						if (!Directory.Exists(Path.GetDirectoryName(thumbnailPath)))
						{
							Directory.CreateDirectory(Path.GetDirectoryName(thumbnailPath));
						}
						System.Drawing.Image originalImage = System.Drawing.Image.FromStream(file.InputStream);
						ImageHelper.MakeThumbnail(originalImage, thumbnailPath, 200, ThumbnailType.AutoCut);
					}
				}

				anyFile.UserID = UserSession.UserID;

				CmsFactory.Instance.AnyFileService.AddAnyFile(anyFile);
			}
			catch
			{
				success = false;
			}

			var format = RequestObject.ToString("format").ToLower();

			if (format == "json")
			{
				String json = "";
				if (success)
				{
					json = String.Format("{{ID:'{0}',FileUrl:'{1}',ThumbnailUrl:'{2}'}}", anyFile.ID, anyFile.FileUrl, anyFile.ThumbnailUrl);

				}
				else
				{
					json = String.Format("{{Error:'{0}'}}", "错误");
				}
				Response.Write(json);
			}
			else
			{
				var defaultSuccessCallBack = "uploadSuccess";
				var defaultFailureCallBack = "uploadFailure";

				var successCallBack = RequestObject.ToString("successCallback");
				var failureCallBack = RequestObject.ToString("failureCallback");

				if (String.IsNullOrEmpty(successCallBack))
				{
					successCallBack = defaultSuccessCallBack;
				}
				if (String.IsNullOrEmpty(failureCallBack))
				{
					failureCallBack = defaultFailureCallBack;
				}

				String js = "";
				if (success)
				{
					js = String.Format("window.parent.{0}('{1}','{2}','{3}')", successCallBack, anyFile.ID, anyFile.FileUrl, anyFile.ThumbnailUrl);

				}
				else
				{
					js = String.Format("window.parent.{0}('{1}')", failureCallBack, "错误");
				}
				JavaScript.Write(js);
			}
		}
	}
}
