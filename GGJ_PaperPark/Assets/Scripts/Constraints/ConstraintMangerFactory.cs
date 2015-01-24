using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Constraints
{
    public class ConstraintMangerFactory
    {
        private static Dictionary<Type, Type> _RangeConstraintManagersDict;
        private static Dictionary<Type, Type> _ConstraintManagersDict;

        private ConstraintMangerFactory()
        {

        }

        static ConstraintMangerFactory()
        {
            _RangeConstraintManagersDict = new Dictionary<Type, Type>();
            _ConstraintManagersDict = new Dictionary<Type, Type>();

            // All available range managers
            _RangeConstraintManagersDict.Add(typeof(DateConstraint), typeof(DateConstraintManager));
            _RangeConstraintManagersDict.Add(typeof(WeeklyConstraint), typeof(WeeklyConstraintManager));
            _RangeConstraintManagersDict.Add(typeof(HourConstraint), typeof(HourConstraintManager));

            // Available managers
            _ConstraintManagersDict.Add(typeof(HolidayConstraint), typeof(HolidayConstraintManager));
            _ConstraintManagersDict.Add(typeof(ColorConstraint), typeof(SidewalkConstraintManager));
        }

        public static RangeConstraintManager getRangeManager(Type constraintType)
        {
            RangeConstraintManager result = null;

            // Make sure the key is in the manager
            if (_RangeConstraintManagersDict.ContainsKey(constraintType))
                result = Activator.CreateInstance(_RangeConstraintManagersDict[constraintType]) as RangeConstraintManager;

            return result;
        }

        public static ConstraintManager getManager(Type constraintType)
        {
            ConstraintManager result = null;

            // Make sure the key is in the manager
            if (_ConstraintManagersDict.ContainsKey(constraintType))
                result = Activator.CreateInstance(_ConstraintManagersDict[constraintType]) as ConstraintManager;

            return result;
        }
    }
}
