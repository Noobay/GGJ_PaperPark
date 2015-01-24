using Assets.Scripts.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using UnityEngine;

namespace Assets.Scripts.Constraints
{
    [XmlRoot(Constants.CONSTRAINT_XML)]
    public class WeeklyConstraint : RangeConstraint<int>
    {
        public WeeklyConstraint(bool isConAllowed, GameRangeAttribute range)
            : base(isConAllowed, range)
        {

        }

        public WeeklyConstraint()
        {
           
        }
        public override GameRangeAttribute range
        {
            protected set
            {
                base.range = value;
                base.range.max += (int)Convert.ChangeType(UserInput.GetUserDayOfWeek(), UserInput.GetUserDayOfWeek().GetTypeCode()) % 7;
                base.range.min += (int)Convert.ChangeType(UserInput.GetUserDayOfWeek(), UserInput.GetUserDayOfWeek().GetTypeCode()) % 7;
            }
        }
        public override bool collides(IRangeConstraint other)
        {
            return IsIntersecting((long)range.min, (long)range.max, (long)other.range.min, (long)other.range.max);
        }

        public override string ToString()
        {
            return ((isConAllowed) ? ("May") : ("May not")) + String.Format(" park between {0} and {1}",
                                                            Enum.GetName(typeof(DayOfWeek), (int) range.min),
                                                            Enum.GetName(typeof(DayOfWeek), (int) range.max));
        }

        public override bool isUserInputLegal(params object[] inputs)
        {
            if (inputs == null || !(inputs[0] is DayOfWeek))
            {
                return false;
            }

            DayOfWeek day = (DayOfWeek)inputs[0];

            int userDay = (int)Convert.ChangeType(day, day.GetTypeCode()) % 7;

            // If day in range, return allowed flag
            if ((userDay >= range.min && userDay <= range.max) || (userDay <= range.min && userDay >= range.max))
            {
                return isConAllowed;
            }
            else
            {
                // Not in range, return not allowed flag
                return !isConAllowed;
            }
        }
    }
}
