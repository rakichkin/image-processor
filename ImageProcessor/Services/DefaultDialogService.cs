using System;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;
using Microsoft.Win32;

using imageProcessor.viewModels;

namespace imageProcessor.services
{
	public class DefaultDialogService
	{
		private readonly ImageProcessingViewModel _imageProcessingViewModel;

		public DefaultDialogService(ImageProcessingViewModel imageProcessingViewModel)
		{
			_imageProcessingViewModel = imageProcessingViewModel;
		}

		public bool OpenFileDialog()
		{
			var openFileDialog = new OpenFileDialog();
			openFileDialog.Filter = "png files (*.png)|*.png|jpeg files (*.jpeg)|*.jpeg|jpg files (*.jpg)|*.jpg";
			if(openFileDialog.ShowDialog() == true)
			{
				_imageProcessingViewModel.ImageSrc = new BitmapImage(new Uri(openFileDialog.FileName));
				return true;
			}
			return false;
		}

		public bool SaveFileDialog()
		{
			var saveFileDialog = new SaveFileDialog();
			saveFileDialog.FileName = "processedImage";
			saveFileDialog.DefaultExt = ".png";
			saveFileDialog.Filter = "png files (*.png)|*.png|jpeg files (*.jpeg)|*.jpeg|jpg files (*.jpg)|*.jpg";

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
