using System;
using System.Drawing;
using System.Windows;
using System.ComponentModel;

using ImageProcessor.ViewModels;
using ImageProcessor.Models;
using ImageProcessor.Services;


namespace ImageProcessor.Commands
{
	/// <summary>Класс, реализующий команду для фильтра Собеля</summary>
	public class SobolEdgeDetectionCommand : CommandBase
	{
		private readonly ImageProcessingViewModel _imageProcessingViewModel;

		public SobolEdgeDetectionCommand(ImageProcessingViewModel imageProcessingViewModel)
		{
			_imageProcessingViewModel = imageProcessingViewModel;

			_imageProcessingViewModel.PropertyChanged += OnViewModelPropertyChanged;
		}

		private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
		{
			if(e.PropertyName == nameof(_imageProcessingViewModel.IsImageLoaded))
			{
				OnCanExecuteChanged();
			}
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
						ErrorMessage.ShowDefaultMessage(ex);
					}
				}

			}
		}

		public override bool CanExecute(object? parameter)
		{
			return _imageProcessingViewModel.IsImageLoaded && base.CanExecute(parameter);
		}
	}
}
