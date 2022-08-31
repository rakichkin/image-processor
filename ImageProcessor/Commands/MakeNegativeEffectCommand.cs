using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Drawing;

using ImageProcessor.ViewModels;

namespace ImageProcessor.Commands
{
	public class MakeNegativeEffectCommand : CommandBase
	{
		private readonly ImageProcessingViewModel _imageProcessingViewModel;

		public MakeNegativeEffectCommand(ImageProcessingViewModel imageProcessingViewModel)
		{
			_imageProcessingViewModel = imageProcessingViewModel;
		}

		// HARCODEEEEE		 TODO: FIX THIS 
		public override void Execute(object? parameter)
		{
			//bitmap
			//BitmapImage bitmap = new BitmapImage(new Uri(_imageProcessingViewModel.ImageSrc));
			//SobelEdgeDetector sobelEdgeDetector = new SobelEdgeDetector();
			//sobelEdgeDetector.ApplyInPlace(bitmap);
			
		}
	}
}
