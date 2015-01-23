using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Constraints
{
    public class HourConstraint : RangeConstraint<int>
    {
        public HourConstraint(bool isConAllowed, RangeAttribute range)
            : base(isConAllowed, range)
        {

        }

        public override bool collides(IRangeConstraint other)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return (isConAllowed) ? ("May") : ("May not") + String.Format(" park between {0}:00 and {1}:00",
                                                            range.min,
                                                            range.max);
        }
    }
}
