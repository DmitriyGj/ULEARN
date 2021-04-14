namespace Pluralize
{
	public static class PluralizeTask
	{
		public static string PluralizeRubles(int count)
		{
			string s = "рублей";
			if (count % 10 == 1)
				s= "рубль";
			if (count % 10 >= 2 && count % 10 <= 4)
				s= "рубля";
			if (count == 0 || (count % 100 >= 5 && count % 100 <= 20))
				s= "рублей";
			return s;
		}
	}
}
