﻿using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows;

using imageProcessor.viewModels;
using imageProcessor.models;

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
					var imageProcessingModel = new ImageProcessingModel();
					using(var processedBitmap = imageProcessingModel.SobolEdgeDetector(bmp))
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
