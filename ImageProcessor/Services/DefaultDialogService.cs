using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace imageProcessor.services
{
	public class DefaultDialogService : IDialogService
	{
		public string FilePath { get; set; }

		public bool OpenFileDialog()
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Filter = "png files (*.png)|*.png|jpeg files (*.jpeg)|*.jpeg|jpg files (*.jpg)|*.jpg";
			if(openFileDialog.ShowDialog() == true)
			{
				FilePath = openFileDialog.FileName;
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
