using System.ComponentModel;


namespace ImageProcessor.ViewModels
{
	/// <summary>Основа для построения ViewModel</summary>
	public class ViewModelBase : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler? PropertyChanged;

		protected void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
