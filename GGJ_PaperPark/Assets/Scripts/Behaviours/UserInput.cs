using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using Assets.Scripts.General;

namespace Assets.Scripts.Constraints
{
    public class UserInput : MonoBehaviour
    {
        

        void Awake()
        {

        }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public static long GetUserTime()
        {
            return 0;
        }

        public static DayOfWeek GetUserDayOfWeek()
        {
            return DayOfWeek.Saturday;
        }

        public static int GetUserHour()
        {
            return 0;
        }

        internal static Constants.CarColor GetCarColor()
        {
            return Constants.CarColor.BLUE;
        }

        internal static bool IsHolidayNow(string p)
        {
            return false;
        }
    }
}