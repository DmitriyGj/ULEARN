using System;

namespace AngryBirds
{
	public static class AngryBirdsTask
	{
		public static double FindSightAngle(double v, double distance)
		{
			double sin2Value = (distance * 9.8) /(v*v) ;
			if (sin2Value < 0 || sin2Value > 1)
				return double.NaN;
			else
				return Math.Asin(sin2Value)/2;
		}
	}
}

