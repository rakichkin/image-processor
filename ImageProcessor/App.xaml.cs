using System.Windows;

using imageProcessor.viewModels;

namespace imageProcessor
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		protected override void OnStartup(StartupEventArgs e)
		{
			MainWindow = new MainWindow()
			{
				DataContext = new MainViewModel()
			};
			MainWindow.Show();

			base.OnStartup(e);
		}
	}
}
