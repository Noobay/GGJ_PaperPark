using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Constraints
{
    public class ColorConstraintManager : ConstraintManager
    {
        public override bool validateUserInputByConstraints()
        {
            return constraintsList.TrueForAll(x => x.isUserInputLegal(UserInput.GetCarColor()));
        }

        public ColorConstraintManager()
            : base(typeof(ColorConstraint))
        {

        }
    }
}
