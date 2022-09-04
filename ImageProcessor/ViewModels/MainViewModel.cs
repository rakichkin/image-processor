namespace imageProcessor.viewModels
{
	public class MainViewModel : ViewModelBase
	{
		public ViewModelBase CurrentViewModel { get; }

		public MainViewModel()
		{
			CurrentViewModel = new ImageProcessingViewModel();
		}
	}
}
