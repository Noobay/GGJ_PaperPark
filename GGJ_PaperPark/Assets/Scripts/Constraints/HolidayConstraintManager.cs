using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Constraints
{
    public class HolidayConstraintManager : ConstraintManager
    {
        public HolidayConstraintManager()
            : base(typeof(HolidayConstraint))
        {

        }

        public override bool validateUserInputByConstraints()
        {
			return constraintsList.TrueForAll(x => x.isUserInputLegal());
        }
    }
}
