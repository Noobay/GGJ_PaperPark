﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Constraints
{
    public class HourConstraintManager : RangeConstraintManager
    {
        public HourConstraintManager()
            : base(typeof(HourConstraint))
        {

        }
        public override bool validateUserInputByConstraints()
        {
            throw new NotImplementedException();
        }
    }
}
