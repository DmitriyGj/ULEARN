using System;
using System.Data;
using System.Drawing;
using System.Globalization;

namespace Fractals
{
	internal static class DragonFractalTask
	{
		public static void DrawDragonFractal(Pixels pixels, int iterationsCount, int seed)
		{
			var randomNumbers = new Random(seed);
			double x = 1.0;
			double y = 0.0;
			pixels.SetPixel(x, y);
			for (int i = 0; i != iterationsCount; i++)
			{
				double pastX = x;
				if (randomNumbers.Next(2) == 0)
					pixels.SetPixel(x = Transform1X(pastX, y), y = Transform1Y(pastX, y));
				else
					pixels.SetPixel(x= Transform2X(pastX, y), y = Transform2Y(pastX, y));
			}
		}
		
		static double Transform1X(double x, double y) => (x - y) / 2;
		static double Transform1Y(double x, double y) => (x + y) / 2;
		static double Transform2X(double x, double y) => ((-x - y) / 2) + 1;
		static double Transform2Y(double x, double y) => (x - y) / 2;
	}
}
