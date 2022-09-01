using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using imageProcessor.services;

namespace imageProcessor.commands
{
	public class SaveFileCommand : CommandBase
	{
		public override void Execute(object? parameter)
		{
			DefaultDialogService defaultDialogService = new DefaultDialogService();
			defaultDialogService.SaveFileDialog(); // реализовать canExecute
		}
	}
}
