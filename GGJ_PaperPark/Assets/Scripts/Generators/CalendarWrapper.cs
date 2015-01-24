using Assets.Scripts.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Random = UnityEngine.Random;

namespace Assets.Scripts.Generators
{
    public class CalendarWrapper
    {
        private const int NUM_OF_TRIES = 4;
        private static Dictionary<int, NameIntPair> _holidayDates;
        private static Dictionary<string, GameRangeAttribute> _holidayRanges;

        public static int daysInMonth { get; private set; }

        static CalendarWrapper()
        {
            daysInMonth = DateTime.DaysInMonth(MakeTime.gameDateTime.Year, MakeTime.gameDateTime.Month);
            GenerateDayPairs();
        }

        public static Dictionary<int, NameIntPair> GetHolidayDates()
        {
            return _holidayDates;
        }

        private static void GenerateDayPairs()
        {
            _holidayDates = new Dictionary<int, NameIntPair>();
            _holidayRanges = new Dictionary<string, GameRangeAttribute>();
            int holidaysInMonth = Random.Range(1, GameData.HolidayNameLengthPairs.Length - 1);

            // Populate holidays
            for (short i = 0; i < GameData.holidayNames.Length; i++)
            {
                int randomDate = Random.Range(0, daysInMonth - 1);
                int j = 0;
                for (; (_holidayDates.ContainsKey(randomDate)) && j < NUM_OF_TRIES; j++)
                {
                    randomDate = Random.Range(0, daysInMonth - 1);
                }
                if (j == NUM_OF_TRIES)
                {
                    break;
                }

                _holidayDates.Add(randomDate, GameData.HolidayNameLengthPairs[i]);
                GameRangeAttribute range = new GameRangeAttribute(randomDate, 
                    randomDate + GameData.HolidayNameLengthPairs[i].value);
                _holidayRanges.Add(GameData.HolidayNameLengthPairs[i].name, range);
            }
        }

        internal static bool IsHolidayNow(string holiday, int p)
        {
            return (p >= _holidayRanges[holiday].min) && (p <= _holidayRanges[holiday].max);
        }
    }
}
