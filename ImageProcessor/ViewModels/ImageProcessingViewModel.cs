using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using imageProcessor.commands;

namespace imageProcessor.viewModels
{
	public class ImageProcessingViewModel : ViewModelBase
	{
		private BitmapImage _imageSrc;
		public BitmapImage ImageSrc
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

		private int _sliderValue;
		public int SliderValue
		{
			get
			{
				return _sliderValue;
			}
			set
			{
				_sliderValue = value;
				OnPropertyChanged(nameof(SliderValue));
			}
		}

		public ICommand OpenFileCommand { get; }
		public ICommand SaveFileCommand { get; }
		public ICommand SobolEdgeDetectionCommand { get; }
		public ICommand ContrastCommand { get; }

		public ImageProcessingViewModel()
		{
			OpenFileCommand = new OpenFileCommand(this);
			SaveFileCommand = new SaveFileCommand(this);
			SobolEdgeDetectionCommand = new SobolEdgeDetectionCommand(this);
			ContrastCommand = new ContrastCommand(this);
		}
	}
}
