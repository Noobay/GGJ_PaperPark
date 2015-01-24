using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

namespace Assets.Scripts.Constraints
{
    public class UserInput : MonoBehaviour
    {
        static List<IConstraint> sidewalkConstraints;

        void Awake()
        {
            sidewalkConstraints = new List<IConstraint>();
            sidewalkConstraints.Add(new ColorConstraint(true, General.Constants.CarColor.BLUE));
            sidewalkConstraints.Add(new ColorConstraint(true, General.Constants.CarColor.RED));
            sidewalkConstraints.Add(new ColorConstraint(true, General.Constants.CarColor.GREEN));
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

        internal static Assets.Scripts.General.Constants.CarColor GetCarColor()
        {
            return Assets.Scripts.General.Constants.CarColor.BLUE;
        }

        internal static IConstraint GetSidewalkConstraint(int index)
        {
            return sidewalkConstraints[index % sidewalkConstraints.Count];
        }

        internal static bool IsHolidayNow(string p)
        {
            return false;
        }
    }
}