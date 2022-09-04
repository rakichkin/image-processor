using System;
using System.Windows.Input;

namespace ImageProcessor.Commands
{
	/// <summary>Основа для построения команд</summary>
	public abstract class CommandBase : ICommand
	{
		public event EventHandler? CanExecuteChanged;

		public virtual bool CanExecute(object? parameter)
		{
			return true;
		}

		public abstract void Execute(object? parameter);

		public void OnCanExecuteChanged()
		{
			CanExecuteChanged?.Invoke(this, new EventArgs());
		}
	}
}
