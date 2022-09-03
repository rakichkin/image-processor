using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace imageProcessor.services
{
	public static class RandomService
	{
		public static int GetRandomValue(int min, int max)
		{
			var rand = new Random();
			return rand.Next(min, max);
		}
	}
}
