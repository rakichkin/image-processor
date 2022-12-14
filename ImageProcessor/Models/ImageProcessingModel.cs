using System;
using System.Drawing;
using System.Drawing.Imaging;


namespace ImageProcessor.Models
{
	public class ImageProcessingModel
	{
		/// <summary>Применяет фильтр Собеля к изображению</summary>
		/// <param name="image">Исходное изображение</param>
		/// <returns>Обработанное изображение</returns>
		public Bitmap SobolEdgeDetector(Bitmap image)
		{
			using(var bitmap = (Bitmap)image.Clone())
			{
				using(var processedBitmap = (Bitmap)image.Clone())
				{
					for(var i = 0; i < bitmap.Width; i++)
						for(var j = 0; j < bitmap.Height; j++)
						{
							var valueZero = bitmap.GetPixel(i, j);
							var averageValueZero = ((int)valueZero.R + (int)valueZero.G + (int)valueZero.B) / 3;
							if((i - 1 >= 0) && (i <= bitmap.Width - 2) && (j - 1 >= 0) && (j <= bitmap.Height - 2))
							{
								var p1 = bitmap.GetPixel(i - 1, j - 1);
								var p2 = bitmap.GetPixel(i, j - 1);
								var p3 = bitmap.GetPixel(i + 1, j - 1);
								var p4 = bitmap.GetPixel(i + 1, j);
								var p5 = bitmap.GetPixel(i + 1, j + 1);
								var p6 = bitmap.GetPixel(i, j + 1);
								var p7 = bitmap.GetPixel(i - 1, j + 1);
								var p8 = bitmap.GetPixel(i - 1, j);

								var averageValueP1 = ((int)p1.R + (int)p1.G + (int)p1.B) / 3; 
								var averageValueP2 = ((int)p2.R + (int)p2.G + (int)p2.B) / 3; 
								var averageValueP3 = ((int)p3.R + (int)p3.G + (int)p3.B) / 3; 
								var averageValueP4 = ((int)p4.R + (int)p4.G + (int)p4.B) / 3; 
								var averageValueP5 = ((int)p5.R + (int)p5.G + (int)p5.B) / 3;
								var averageValueP6 = ((int)p6.R + (int)p6.G + (int)p6.B) / 3;
								var averageValueP7 = ((int)p7.R + (int)p7.G + (int)p7.B) / 3;
								var averageValueP8 = ((int)p8.R + (int)p8.G + (int)p8.B) / 3;

								var averageValueX = Math.Abs(averageValueP7 + 2 * averageValueP6 + averageValueP5 - averageValueP1 - 2 * averageValueP2 - averageValueP3);
								var averageValueY = Math.Abs(averageValueP3 + 2 * averageValueP4 + averageValueP5 - averageValueP1 - 2 * averageValueP8 - averageValueP7);
								var averageValue = (int)Math.Sqrt(Math.Pow(averageValueX, 2) + Math.Pow(averageValueY, 2));

								if(averageValue > 255) averageValue = 255;

								// |G| = |P1 + 2P2 + P3 - P7 - 2P6 - P5| + |P3 + 2P4 + P5 - P1 - 2P8 - P7| 
								processedBitmap.SetPixel(i, j, Color.FromArgb(Math.Abs(averageValue), Math.Abs(averageValue), Math.Abs(averageValue)));
							}
							else
							{
								processedBitmap.SetPixel(i, j, Color.FromArgb(averageValueZero, averageValueZero, averageValueZero));
							}
						}
					return (Bitmap)processedBitmap.Clone();
				}
			}
		}

		/// <summary>Изменяет контраст изображения</summary>
		/// <param name="bitmap">Исходное изображение</param>
		/// <returns>Обработанное изображение</returns>
		public Bitmap AdjustContrast(Bitmap bitmap, float value)
		{
			value = (100.0f + value) / 100.0f;
			value *= value;
			Bitmap newBitmap = (Bitmap)bitmap.Clone();
			BitmapData data = newBitmap.LockBits(new Rectangle(0, 0, newBitmap.Width, newBitmap.Height),
												 ImageLockMode.ReadWrite,
												 newBitmap.PixelFormat);
			int height = newBitmap.Height;
			int width = newBitmap.Width;

			unsafe
			{
				for(int y = 0; y < height; ++y)
				{
					byte* row = (byte*)data.Scan0 + (y * data.Stride);
					int columnOffset = 0;
					for(int x = 0; x < width; ++x)
					{
						byte b = row[columnOffset];
						byte g = row[columnOffset + 1];
						byte r = row[columnOffset + 2];

						float red = r / 255.0f;
						float green = g / 255.0f;
						float blue = b / 255.0f;
						red = (((red - 0.5f) * value) + 0.5f) * 255.0f;
						green = (((green - 0.5f) * value) + 0.5f) * 255.0f;
						blue = (((blue - 0.5f) * value) + 0.5f) * 255.0f;

						int iR = (int)red;
						iR = iR > 255 ? 255 : iR;
						iR = iR < 0 ? 0 : iR;
						int iG = (int)green;
						iG = iG > 255 ? 255 : iG;
						iG = iG < 0 ? 0 : iG;
						int iB = (int)blue;
						iB = iB > 255 ? 255 : iB;
						iB = iB < 0 ? 0 : iB;

						row[columnOffset] = (byte)iB;
						row[columnOffset + 1] = (byte)iG;
						row[columnOffset + 2] = (byte)iR;

						columnOffset += 4;
					}
				}
			}

			newBitmap.UnlockBits(data);

			return newBitmap;
		}
	}
}
