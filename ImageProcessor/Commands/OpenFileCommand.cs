using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using imageProcessor.services;
using imageProcessor.ViewModels;

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
			DefaultDialogService defaultDialogService = new DefaultDialogService();
			if(defaultDialogService.OpenFileDialog())
			{
				_imageProcessingViewModel.ImageSrc = defaultDialogService.FilePath;
			}
		}
	}
}
