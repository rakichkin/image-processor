using System.Drawing;
using System.Windows;

using imageProcessor.viewModels;
using imageProcessor.models;
using imageProcessor.services;

namespace imageProcessor.commands
{
	public class ContrastCommand : CommandBase
	{
		private readonly ImageProcessingViewModel _imageProcessingViewModel;

		public ContrastCommand(ImageProcessingViewModel imageProcessingViewModel)
		{
			_imageProcessingViewModel = imageProcessingViewModel;
		}

		public override void Execute(object? parameter)
		{
			if(_imageProcessingViewModel.ImageSrc == null) return;

			using(var bmp = new Bitmap(BitmapConverter.BitmapImage2Bitmap(_imageProcessingViewModel.ImageSrc)))
			{
				var imageProcessingModel = new ImageProcessingModel();
				using(var processedBitmap = imageProcessingModel.AdjustContrast(bmp, _imageProcessingViewModel.SliderValue))
				{
					try
					{
						_imageProcessingViewModel.ImageSrc = BitmapConverter.Bitmap2BitmapImage(processedBitmap);
					}
					catch(System.Runtime.InteropServices.ExternalException ex)
					{
						MessageBox.Show("Исправь!!!!!",
							"Сообщение",
							MessageBoxButton.OK,
							MessageBoxImage.Information);
					}
				}
			}
		}
	}
}
