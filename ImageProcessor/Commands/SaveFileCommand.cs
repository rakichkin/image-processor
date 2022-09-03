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
		}

		public override void Execute(object? parameter)
		{
			DefaultDialogService defaultDialogService = new DefaultDialogService(_imageProcessingViewModel);
			defaultDialogService.SaveFileDialog(); // реализовать canExecute
		}
	}
}