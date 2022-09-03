using System;
using System.Drawing;
using System.Windows;

using imageProcessor.viewModels;
using imageProcessor.models;
using imageProcessor.services;


namespace imageProcessor.commands
{
	public class SobolEdgeDetectionCommand : CommandBase
	{
		private readonly ImageProcessingViewModel _imageProcessingViewModel;

		public SobolEdgeDetectionCommand(ImageProcessingViewModel imageProcessingViewModel)
		{
			_imageProcessingViewModel = imageProcessingViewModel;
		}

		public override void Execute(object? parameter)
		{
			if(_imageProcessingViewModel.ImageSrc == null) return;

			using(var bmp = new Bitmap(BitmapConverter.BitmapImage2Bitmap(_imageProcessingViewModel.ImageSrc)))
			{
				var imageProcessingModel = new ImageProcessingModel();
				using(var processedBitmap = imageProcessingModel.SobolEdgeDetector(bmp))
				{
					try
					{
						_imageProcessingViewModel.ImageSrc = BitmapConverter.Bitmap2BitmapImage(processedBitmap);
					}
					catch(Exception ex)
					{
						MessageBox.Show("Что-то пошло не так. Ошибка:" + ex.Message,
							"Ошибка",
							MessageBoxButton.OK,
							MessageBoxImage.Error);
					}
				}

			}
		}
	}
}
