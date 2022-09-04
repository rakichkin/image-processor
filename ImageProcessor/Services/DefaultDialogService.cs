using System;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;
using Microsoft.Win32;

using ImageProcessor.ViewModels;

namespace ImageProcessor.Services
{
	/// <summary>Класс, инкапсулирующий работу с диалоговыми окнами открытия и сохранения файлов</summary>
	public class DefaultDialogService
	{
		private readonly ImageProcessingViewModel _imageProcessingViewModel;

		public DefaultDialogService(ImageProcessingViewModel imageProcessingViewModel)
		{
			_imageProcessingViewModel = imageProcessingViewModel;
		}

		/// <summary>Открытие файла</summary>
		/// <returns>True, если файл успешно открылся; false в противном случае</returns>
		public bool OpenFileDialog()
		{
			var openFileDialog = new OpenFileDialog();
			openFileDialog.Filter = "Image files(*.BMP;*.JPG;*.JPEG;*.PNG)|*.BMP;*.JPG;*.JPEG;*.PNG";

			if(openFileDialog.ShowDialog() == true)
			{
				_imageProcessingViewModel.ImageSrc = new BitmapImage(new Uri(openFileDialog.FileName));
				return true;
			}
			return false;
		}

		/// <summary>Сохранение файла</summary>
		/// <returns>True, если файл успешно сохранился; false в противном случае</returns>
		public bool SaveFileDialog()
		{
			var saveFileDialog = new SaveFileDialog();
			saveFileDialog.FileName = "Processed image";
			saveFileDialog.DefaultExt = ".png";
			saveFileDialog.Filter = "Png files (*.png)|*.png|Jpeg files (*.jpeg)|*.jpeg|Jpg files (*.jpg)|*.jpg|Bmp files(*.bmp)|*.bmp";

			if(saveFileDialog.ShowDialog() == true)
			{
				var encoder = new PngBitmapEncoder();
				try
				{
					encoder.Frames.Add(BitmapFrame.Create(_imageProcessingViewModel.ImageSrc));
					using(FileStream stream = new FileStream(saveFileDialog.FileName, FileMode.Create))
					{
						encoder.Save(stream);
					}
				}
				catch(IOException IOEx)
				{
					MessageBox.Show("Обработайте изображение, прежде чем сохранять его.",
									"Ошибка",
									MessageBoxButton.OK,
									MessageBoxImage.Error);
				}
				catch(Exception ex)
				{
					MessageBox.Show("Что-то пошло не так. Ошибка:" + ex.Message,
									"Ошибка",
									MessageBoxButton.OK,
									MessageBoxImage.Error);
				}
				return true;
			}
			return false;
		}
	}
}
