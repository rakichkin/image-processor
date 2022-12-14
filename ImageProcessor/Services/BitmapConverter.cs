using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Media.Imaging;

namespace ImageProcessor.Services
{
	/// <summary>Вспомогательный класс для конвертации типов Bitmap и BitmapImage</summary>
	public static class BitmapConverter
	{
		/// <summary>Конвертирует тип BitmapImage в тип Bitmap</summary>
		public static Bitmap BitmapImage2Bitmap(BitmapImage bitmapImage)
		{
			// BitmapImage bitmapImage = new BitmapImage(new Uri("../Images/test.png", UriKind.Relative));

			using(MemoryStream outStream = new MemoryStream())
			{
				BitmapEncoder enc = new BmpBitmapEncoder();
				enc.Frames.Add(BitmapFrame.Create(bitmapImage));
				enc.Save(outStream);
				Bitmap bitmap = new Bitmap(outStream);

				return new Bitmap(bitmap);
			}
		}

		[System.Runtime.InteropServices.DllImport("gdi32.dll")]
		private static extern bool DeleteObject(IntPtr hObject);

		/// <summary>Конвертирует тип Bitmap в тип BitmapImage</summary>
		public static BitmapImage Bitmap2BitmapImage(Bitmap bitmap)
		{
			using(var memory = new MemoryStream())
			{
				bitmap.Save(memory, ImageFormat.Png);
				memory.Position = 0;

				var bitmapImage = new BitmapImage();
				bitmapImage.BeginInit();
				bitmapImage.StreamSource = memory;
				bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
				bitmapImage.EndInit();
				bitmapImage.Freeze();

				return bitmapImage;
			}
		}
	}
}
