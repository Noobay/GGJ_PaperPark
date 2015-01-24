using System;
using System.Collections.Generic;
using System.Text;
using Random = UnityEngine.Random;

namespace Assets.Scripts.General
{
    public class Utility
    {
        public static bool GetRandomBoolean()
        {
            return Random.Range(0, 100) % 2 == 0;
        }
    }
}
