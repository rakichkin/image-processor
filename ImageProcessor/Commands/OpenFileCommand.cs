using ImageProcessor.Services;
using ImageProcessor.ViewModels;

namespace ImageProcessor.Commands
{
	/// <summary>Класс, реализующий команду для загрузки изображения</summary>
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
