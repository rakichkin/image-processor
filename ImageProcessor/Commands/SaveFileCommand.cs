using System.ComponentModel;

using imageProcessor.services;
using imageProcessor.viewModels;


namespace imageProcessor.commands
{
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