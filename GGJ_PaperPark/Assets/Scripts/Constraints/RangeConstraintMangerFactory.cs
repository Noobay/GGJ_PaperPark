using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Constraints
{
    public class RangeConstraintMangerFactory
    {
        private static Dictionary<Type, Type> _ConstraintManagersDict;

        private RangeConstraintMangerFactory()
        {

        }

        static RangeConstraintMangerFactory()
        {
            _ConstraintManagersDict = new Dictionary<Type, Type>();

            // All available managers
            _ConstraintManagersDict.Add(typeof(DateConstraint), typeof(DateConstraintManager));
            _ConstraintManagersDict.Add(typeof(WeeklyConstraint), typeof(WeeklyConstraintManager));
            _ConstraintManagersDict.Add(typeof(HourConstraint), typeof(HourConstraintManager));
        }

        public static RangeConstraintManager getManager(Type constraintType)
        {
            return Activator.CreateInstance(_ConstraintManagersDict[constraintType]) as RangeConstraintManager;
        }
    }
}
