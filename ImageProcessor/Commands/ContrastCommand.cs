using System;
using System.Drawing;
using System.Windows;
using System.ComponentModel;

using ImageProcessor.ViewModels;
using ImageProcessor.Models;
using ImageProcessor.Services;


namespace ImageProcessor.Commands
{
	/// <summary>Класс, реализующий команду для выполнения контрастирования</summary>
	public class ContrastCommand : CommandBase
	{
		private readonly ImageProcessingViewModel _imageProcessingViewModel;

		public ContrastCommand(ImageProcessingViewModel imageProcessingViewModel)
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
				using(var processedBitmap = imageProcessingModel.AdjustContrast(bmp, _imageProcessingViewModel.SliderValue))
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

		public override bool CanExecute(object? parameter)
		{
			return _imageProcessingViewModel.IsImageLoaded && base.CanExecute(parameter);
		}
	}
}
