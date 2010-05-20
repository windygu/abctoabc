using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YouTong.WebSite.Codes
{
	/// <summary>
	/// 缩略图类型
	/// </summary>
	public enum ThumbnailType
	{
		/// <summary>
		/// 按指定高宽(会造成变形)
		/// </summary>
		AutoResize,
		/// <summary>
		/// 对图片进行裁剪
		/// </summary>
		AutoCut
	}

	/// <summary>
	/// 图片处理类
	/// </summary>
	public class ImageHelper
	{
		/// <summary>
		/// 生成缩略图
		/// </summary>
		/// <param name="originalImage">源图路径（物理路径）</param>
		/// <param name="thumbnailPath">缩略图路径（物理路径）</param>
		/// <param name="width">缩略图宽度</param>
		/// <param name="height">缩略图高度</param>
		/// <param name="mode">生成缩略图的方式</param>    
		public static void MakeThumbnail(System.Drawing.Image image, string thumbnailPath, int size, ThumbnailType type)
		{
			int towidth = size;
			int toheight = size;

			int x = 0;
			int y = 0;
			int ow = image.Width;
			int oh = image.Height;

			switch (type)
			{
				case ThumbnailType.AutoResize://按比例进行缩放
					if (ow > oh)
					{
						toheight = image.Height * size / image.Width;
					}
					else
					{
						towidth = image.Width * size / image.Height;
					}
					break;
				case ThumbnailType.AutoCut://指定高宽裁减（不变形）                
					if (((double)image.Width / (double)image.Height) > 1)
					{
						oh = image.Height;
						ow = image.Height;
						y = 0;
						x = (image.Width - ow) / 2;
					}
					else
					{
						ow = image.Width;
						oh = image.Width;
						x = 0;
						y = (image.Height - oh) / 2;
					}
					break;
				default:
					break;
			}

			//新建一个bmp图片
			System.Drawing.Image bitmap = new System.Drawing.Bitmap(towidth, toheight);

			//新建一个画板
			System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap);

			//设置高质量插值法
			g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;

			//设置高质量,低速度呈现平滑程度
			g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

			//清空画布并以透明背景色填充
			g.Clear(System.Drawing.Color.Transparent);

			//在指定位置并且按指定大小绘制原图片的指定部分
			g.DrawImage(image, new System.Drawing.Rectangle(0, 0, towidth, toheight),
				new System.Drawing.Rectangle(x, y, ow, oh),
				System.Drawing.GraphicsUnit.Pixel);

			try
			{
				//以jpg格式保存缩略图
				bitmap.Save(thumbnailPath, System.Drawing.Imaging.ImageFormat.Jpeg);
			}
			catch (System.Exception e)
			{
				throw e;
			}
			finally
			{
				image.Dispose();
				bitmap.Dispose();
				g.Dispose();
			}
		}
	}
}
