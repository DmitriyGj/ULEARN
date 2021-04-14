using System;

namespace Names
{
    internal static class HeatmapTask
    {
        public static HeatmapData GetBirthsPerDateHeatmap(NameData[] names)
        {
            string[] months = new string[12];
            string[] days = new string[30];
            for (int i = 0; i != days.Length; i++)
                days[i] = (i + 2).ToString();
            for(int i = 0; i != months.Length; i++)
                months[i] = (i+1).ToString();

            double[,] values = new double[30,12];
            foreach (var name in names)
                if(name.BirthDate.Day >1)
                    values[name.BirthDate.Day -2, name.BirthDate.Month - 1]++;
            return new HeatmapData(
                "Пример карты интенсивностей",
                values, 
                days,
                months);
        }
    }
}
