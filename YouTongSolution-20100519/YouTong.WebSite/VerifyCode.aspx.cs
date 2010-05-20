using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Itfort.Web;

namespace YouTong.WebSite
{
	public partial class VerifyCode : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			String action = Request.QueryString["action"];
			// 默认为登录
			if (String.IsNullOrEmpty(action))
			{
				action = VerifyCodeAction.LoginKey;
			}
			else
			{
				action = action.ToLower();
			}

			String verifyCode = RandomString();
			VerifyCodeAction.SetVerifyCode(action, verifyCode);

			Int32 imageWidth = 50;
			Int32 imageHeight = 20;
			Bitmap bmp = new Bitmap(imageWidth, imageHeight);
			Graphics g = Graphics.FromImage(bmp);
			Font font = new Font(FontFamily.GenericSansSerif, 12);
			g.DrawString(verifyCode, font, Brushes.White, 1, 1);

			bmp.Save(Response.OutputStream, ImageFormat.Gif);
		}

		private String RandomString()
		{
			Random r = new Random();

			return r.Next(1000, 10000).ToString();
		}
	}
}
