using System.ComponentModel;

using ImageProcessor.Services;
using ImageProcessor.ViewModels;


namespace ImageProcessor.Commands
{
	/// <summary>Класс, реализующий команду для сохранения изображения</summary>
	public class SaveFileCommand : CommandBase
	{
		private readonly ImageProcessingViewModel _imageProcessingViewModel;

		public SaveFileCommand(ImageProcessingViewModel imageProcessingViewModel)
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
			DefaultDialogService defaultDialogService = new DefaultDialogService(_imageProcessingViewModel);
			defaultDialogService.SaveFileDialog();
		}

		public override bool CanExecute(object? parameter)
		{
			return _imageProcessingViewModel.IsImageLoaded && base.CanExecute(parameter);
		}
	}
}