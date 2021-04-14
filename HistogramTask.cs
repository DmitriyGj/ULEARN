using System;
using System.Linq;

namespace Names
{
    internal static class HistogramTask
    {
        public static HistogramData GetBirthsPerDayHistogram(NameData[] names, string name)
        {
            string[] days = new string[31];
            double[] count = new double[31];
            for(int i = 0; i != days.Length; i++)
                days[i] = Convert.ToString(i + 1);

            foreach (var nameOfNames in names)
                if (nameOfNames.Name == name && nameOfNames.BirthDate.Day > 1)
                    count[nameOfNames.BirthDate.Day - 1]++;

            return new HistogramData( string.Format("Рождаемость людей с именем '{0}'", name), days, count);
        }
    }
}
