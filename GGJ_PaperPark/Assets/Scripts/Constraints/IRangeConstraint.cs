using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Constraints
{
    public interface IRangeConstraint
    {
        bool collides(IRangeConstraint other);
        //bool validateUserInput()
        RangeAttribute range { get; }
        bool isConAllowed { get; }
    }
}
