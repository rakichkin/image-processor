using imageProcessor.services;
using imageProcessor.viewModels;

namespace imageProcessor.commands
{
	public class OpenFileCommand : CommandBase
	{
		private readonly ImageProcessingViewModel _imageProcessingViewModel;

		public OpenFileCommand(ImageProcessingViewModel imageProcessingViewModel)
		{
			_imageProcessingViewModel = imageProcessingViewModel;
		}

		public override void Execute(object? parameter)
		{
			DefaultDialogService defaultDialogService = new DefaultDialogService(_imageProcessingViewModel);

			if(defaultDialogService.OpenFileDialog() == true)
			{
				_imageProcessingViewModel.IsImageLoaded = true;
			}
		}
	}
}
