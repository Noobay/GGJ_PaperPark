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

        public static int daysInMonth { get; private set; }

        static CalendarWrapper()
        {
            daysInMonth = DateTime.DaysInMonth(MakeTime.gameDateTime.Year, MakeTime.gameDateTime.Month);
        }

        public static Dictionary<int, NameIntPair> GenerateDayPairs()
        {
            Dictionary<int, NameIntPair> _dayList = new Dictionary<int, NameIntPair>();

            int holidaysInMonth = Random.Range(1, GameData.HolidayNameLengthPairs.Length - 1);

            // Populate holidays
            for (short i = 0; i < GameData.holidayNames.Length; i++)
            {
                int randomDate = Random.Range(0, daysInMonth - 1);
                int j = 0;
                for (; (_dayList.ContainsKey(randomDate)) && j < NUM_OF_TRIES; j++)
                {
                    randomDate = Random.Range(0, daysInMonth - 1);
                }
                if (j == NUM_OF_TRIES)
                {
                    break;
                }

                _dayList.Add(randomDate, GameData.HolidayNameLengthPairs[i]);
            }

            return _dayList;
        }
    }
}
