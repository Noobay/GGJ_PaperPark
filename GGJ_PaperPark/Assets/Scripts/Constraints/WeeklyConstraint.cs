using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Behaviours
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
    }
}
