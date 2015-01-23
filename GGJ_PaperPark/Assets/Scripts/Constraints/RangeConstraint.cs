using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Behaviours
{
    public abstract class RangeConstraint<T> : IRangeConstraint
    {
        public RangeConstraint(bool isConAllowed, RangeAttribute range)
        {
            this.isConAllowed = isConAllowed;
            this.range = range;
        }

        public RangeAttribute range {get; private set; }

        public bool isConAllowed { get; private set; }

        public abstract bool collides(IRangeConstraint other);
    }
}