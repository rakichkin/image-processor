using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using imageProcessor.commands;

namespace imageProcessor.ViewModels
{
	public class ImageProcessingViewModel : ViewModelBase
	{
		private string _imageSrc;
		public string ImageSrc
		{
			get
			{
				return _imageSrc;
			}
			set
			{
				_imageSrc = value;
				OnPropertyChanged(nameof(ImageSrc));
			}
		}

		public ICommand OpenFileCommand { get; }
		public ICommand SobolEdgeDetectionCommand { get; }
		public ICommand MakeNegativeEffectCommand { get; }

		public ImageProcessingViewModel()
		{
			OpenFileCommand = new OpenFileCommand(this);
			SobolEdgeDetectionCommand = new SobolEdgeDetectionCommand(this);
			MakeNegativeEffectCommand = new MakeNegativeEffectCommand(this);
		}
	}
}
