using System.Drawing;

using imageProcessor.ViewModels;
using imageProcessor.models;
using System.IO;
using System.Reflection;
using System.Windows;

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
			if(string.IsNullOrEmpty(_imageProcessingViewModel.ImageSrc)) return;


			using(var bmp = new Bitmap(_imageProcessingViewModel.ImageSrc))
			{
				if(bmp != null)
				{
					using(var processedBitmap = ImageProcessingModel.SobolEdgeDetector(bmp))
					{
						string newImageSrc = Directory.GetCurrentDirectory() + "\\processedImage.png";

						try
						{
							processedBitmap.Save(newImageSrc);
							_imageProcessingViewModel.ImageSrc = newImageSrc;
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
}
