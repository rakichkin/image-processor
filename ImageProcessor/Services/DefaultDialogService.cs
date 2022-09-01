using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace imageProcessor.services
{
	public class DefaultDialogService : IDialogService
	{
		public string FilePath { get; set; }

		public bool OpenFileDialog()
		{
			var openFileDialog = new OpenFileDialog();
			openFileDialog.Filter = "png files (*.png)|*.png|jpeg files (*.jpeg)|*.jpeg|jpg files (*.jpg)|*.jpg";
			if(openFileDialog.ShowDialog() == true)
			{
				FilePath = openFileDialog.FileName;
				return true;
			}
			return false;
		}

		public bool SaveFileDialog()
		{
			var saveFileDialog = new SaveFileDialog();
			saveFileDialog.FileName = "processedImage";
			saveFileDialog.DefaultExt = ".png";
			saveFileDialog.Filter = "png files (*.png)|*.png|jpeg files (*.jpeg)|*.jpeg|jpg files (*.jpg)|*.jpg";

			if(saveFileDialog.ShowDialog() == true)
			{
				var encoder = new PngBitmapEncoder();
				try
				{
					encoder.Frames.Add(BitmapFrame.Create(new Uri("processedImage.png", UriKind.Relative)));
					using(FileStream stream = new FileStream(saveFileDialog.FileName, FileMode.Create))
					{
						encoder.Save(stream);
					}
				}
				catch(System.IO.FileNotFoundException ex)
				{
					ShowMessage("Error");
				}

				return true;
			}
			return false;
		}

		public void ShowMessage(string message)
		{
			MessageBox.Show(message);
		}
	}
}
