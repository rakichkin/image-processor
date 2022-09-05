using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ImageProcessor.Services
{
	/// <summary>Вспомогательный класс для вывода ошибок на экран</summary>
	public static class ErrorMessage
	{
		public static void ShowDefaultMessage(Exception exception)
		{
			MessageBox.Show("Что-то пошло не так. Ошибка:" + exception.Message,
									"Ошибка",
									MessageBoxButton.OK,
									MessageBoxImage.Error);
		}
	}
}
