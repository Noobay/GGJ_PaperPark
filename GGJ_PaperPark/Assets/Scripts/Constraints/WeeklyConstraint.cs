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

        public override bool collides(IRangeConstraint other)
        {
            return IsIntersecting((long)range.min, (long)range.max, (long)other.range.min, (long)other.range.max);
        }

        public override string ToString()
        {
            return "A car " + ((isConAllowed) ? ("May") : ("May not")) + String.Format(" park between {0} and {1}",
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

        protected override void calculateOffset()
        {
            int offset = (int)Convert.ChangeType(UserInput.GetUserDayOfWeek(), UserInput.GetUserDayOfWeek().GetTypeCode());
            // TODO: Days of the week
            int cycle = 7;
            this.range.max = (this.range.max + offset) % cycle;
            this.range.min = (this.range.min + offset) % cycle;
        }
    }
}
