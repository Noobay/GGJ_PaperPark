using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Constraints
{
    public class WeeklyConstraintManager : RangeConstraintManager
    {
        public WeeklyConstraintManager()
            : base(typeof(WeeklyConstraint))
        {

        }

        public override bool validateUserInputByConstraints()
        {
            return constraintsList.TrueForAll(x => x.isUserInputLegal(UserInput.GetUserDayOfWeek()));
        }
    }
}
