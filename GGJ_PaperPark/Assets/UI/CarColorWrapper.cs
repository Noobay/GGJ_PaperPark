using Assets.Scripts.General;
using System;
using System.Collections.Generic;
using System.Text;
using Random=UnityEngine.Random;

namespace Assets.UI
{
    public static class CarColorWrapper
    {
        static Constants.CarColor s_carColor;
        static bool s_generated = false;

        public static Constants.CarColor GetCarColor()
        {
            if(!s_generated)
            {
                s_carColor = (Constants.CarColor)Random.Range(0, Enum.GetValues(typeof(Constants.CarColor)).Length);
                s_generated = true;
            }

            return s_carColor;
        }
    }
}
