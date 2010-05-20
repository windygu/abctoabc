using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
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
	public class Photo_Upload : HttpHandlerBase
	{
		protected string _SuccessCallBack = "imageUploadSuccess";
		protected string _FailureCallBack = "imageUploadCompleted";

		public override void ProcessRequest(HttpContext context)
		{
			base.ProcessRequest(context);
			Response.ContentType = "text/html";

			// JS回调函数
			this._SuccessCallBack = Itfort.Web.RequestObject.ToString("successCallback");
			this._FailureCallBack = Itfort.Web.RequestObject.ToString("failureCallback");

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

				//生成文件名
				DateTime now = DateTime.Now;
				var fileName = string.Format("{0}{1}", Comb.NewComb2().ToString(), fileExtension);
				var fileUrl = Path.Combine(DateTime.Now.ToString("yyyyMMdd") + "/", fileName);
				var thumbnailUrl = Path.Combine(now.ToString("yyyyMMdd") + "/t/", fileName);

				if (fileExtension != ".jpg" && fileExtension != ".gif" && fileExtension != ".png" && fileExtension != ".bmp" && fileExtension != ".jpeg")
				{
					throw new UtException("图片文件格式不符合要求");
				}

				// 设置目录
				fileUrl = Path.Combine("/uploads/pics/", fileUrl);
				thumbnailUrl = Path.Combine("/uploads/pics/", thumbnailUrl);

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
				ImageHelper.MakeThumbnail(originalImage, thumbnailPath, 200, ThumbnailType.AutoResize);

				AnyFile image = ConverterFactory.ConvertTo<AnyFile>(Request.Params, "Works_");

				image.FileName = fileName;
				image.FileExtension = fileExtension;
				image.FileUrl = fileUrl;
				image.ThumbnailUrl = thumbnailUrl;
				image.FileSize = fileSize;
				image.FileType = 1;		// 图片

				image.UserID = UserSession.UserID;

				CmsFactory.Instance.AnyFileService.AddAnyFile(image);

				if (!String.IsNullOrEmpty(this._SuccessCallBack))
				{
					JavaScript.Write("parent." + this._SuccessCallBack + "('" + image.ID + "');");
				}

				Response.End();
			}
			catch (UtException ex)
			{
				if (!String.IsNullOrEmpty(this._FailureCallBack))
				{
					JavaScript.Write("parent." + this._FailureCallBack + "('" + ex.Message + "');");
				}
				Response.End();
			}
			catch (Exception ex)
			{
				Response.Write(ex.ToString());
				Response.End();
			}
		}
	}
}
