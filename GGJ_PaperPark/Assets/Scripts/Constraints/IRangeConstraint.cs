using Assets.Scripts.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Constraints
{
    public interface IRangeConstraint
    {
        GameRangeAttribute range { get; }
        bool isConAllowed { get; }

        bool collides(IRangeConstraint other);
        bool isUserInputLegal(params object[] inputs);
    }
}
