using Assets.Scripts.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Random = UnityEngine.Random;

namespace Assets.Scripts.Constraints
{
    public class SidewalkConstraintManager : ConstraintManager
    {
        public SidewalkConstraintManager()
            : base(typeof(SidewalkConstraint))
        {   
        }

        public override bool validateUserInputByConstraints()
        {
            return constraintsList.TrueForAll(x => x.isUserInputLegal());
        }
    }
}
