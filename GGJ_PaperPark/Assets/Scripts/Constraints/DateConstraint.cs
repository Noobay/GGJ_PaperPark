using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Constraints
{
    public class DateConstraint : RangeConstraint<DateTime>
    {
        public DateConstraint(bool isConAllowed, RangeAttribute range)
            : base(isConAllowed, range)
        {

        }

        public override bool collides(IRangeConstraint other)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return (isConAllowed) ? ("May") : ("May not") + String.Format(" park between {0} and {1}", 
                                                            new DateTime((long)range.min),
                                                            new DateTime((long)range.max));
        }
    }
}
