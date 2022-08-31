using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace imageProcessor.services
{
	public interface IDialogService
	{
		string FilePath { get; set; }

		void ShowMessage(string message);
		bool OpenFileDialog();
	}
}
