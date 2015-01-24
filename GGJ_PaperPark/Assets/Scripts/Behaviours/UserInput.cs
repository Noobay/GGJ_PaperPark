using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using Assets.Scripts.General;
using Assets.UI;
using Assets.Scripts.Generators;

namespace Assets.Scripts.Constraints
{
    public class UserInput : MonoBehaviour
    {
        public MakeTime userTime;

        private static MakeTime s_makeTime;

        void Awake()
        {
            s_makeTime = userTime;
        }

        public static long GetUserTime()
        {
            return MakeTime.gameDateTime.Ticks;
        }

        public static DayOfWeek GetUserDayOfWeek()
        {
            return MakeTime.gameDateTime.DayOfWeek;
        }

        public static int GetUserHour()
        {
            return MakeTime.gameDateTime.Hour;
        }

        internal static Constants.CarColor GetCarColor()
        {
            return CarColorWrapper.GetCarColor();
        }

        internal static bool IsHolidayNow(string holiday)
        {
            return CalendarWrapper.IsHolidayNow(holiday, MakeTime.gameDateTime.Day);
        }
    }
}