using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Constraints
{
    public class DateConstraintManager : RangeConstraintManager
    {
        public DateConstraintManager()
            : base(typeof(DateConstraint))
        {

        }

        public override bool validateUserInputByConstraints()
        {
            return constraintsList.TrueForAll(x => x.isUserInputLegal(UserInput.GetUserTime()));
        }
    }
}
