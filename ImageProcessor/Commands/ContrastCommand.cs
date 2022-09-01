using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Drawing;

using imageProcessor.viewModels;
using imageProcessor.models;
using System.IO;
using System.Windows;

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
			if(string.IsNullOrEmpty(_imageProcessingViewModel.ImageSrc)) return;

			using(var bmp = new Bitmap(_imageProcessingViewModel.ImageSrc))
			{
				if(bmp != null)
				{
					var imageProcessingModel = new ImageProcessingModel();
					using(var processedBitmap = imageProcessingModel.AdjustContrast(bmp, _imageProcessingViewModel.SliderValue))
					{
						string processedImageSrc = Directory.GetCurrentDirectory() + "\\processedImage.png";

						try
						{
							processedBitmap.Save(processedImageSrc);
							_imageProcessingViewModel.ImageSrc = processedImageSrc;
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
