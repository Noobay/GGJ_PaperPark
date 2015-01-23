using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Behaviours
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
    }
}
