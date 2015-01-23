using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Constraints
{
    public class WeeklyConstraint : RangeConstraint<int>
    {
        public WeeklyConstraint(bool isConAllowed, RangeAttribute range)
            : base(isConAllowed, range)
        {

        }

        public override bool collides(IRangeConstraint other)
        {
            return range.max < other.range.min || range.min > other.range.max;
        }

        public override string ToString()
        {
            return (isConAllowed) ? ("May") : ("May not") + String.Format(" park between {0}:00 and {1}:00",
                                                            Enum.GetName(typeof(DayOfWeek), (int) range.min),
                                                            Enum.GetName(typeof(DayOfWeek), (int) range.max));
        }
    }
}
