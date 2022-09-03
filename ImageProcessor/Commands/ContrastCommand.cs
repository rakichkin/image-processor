using System.Drawing;
using System.Windows;

using imageProcessor.viewModels;
using imageProcessor.models;
using imageProcessor.services;
using System.ComponentModel;

namespace imageProcessor.commands
{
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

		public override bool CanExecute(object? parameter)
		{
			return _imageProcessingViewModel.IsImageLoaded && base.CanExecute(parameter);
		}
	}
}
