using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Constraints
{
    public abstract class RangeConstraintManager
    {
        public Type ConstraintType { get; private set; }
        protected List<IRangeConstraint> constraintsList { get; private set; }

        public RangeConstraintManager(Type constraintType)
        {
            constraintsList = new List<IRangeConstraint>();
            this.ConstraintType = constraintType;
        }

        public bool tryAddConstraint(IRangeConstraint constraint)
        {
            // Check if new constraint is of this manager's type and fits the other constraints
            if (constraint.GetType().Equals(ConstraintType) && validateAddition(constraint))
            {
                // Fits, add to the list and return true for success
                constraintsList.Add(constraint);
                return true;
            }

            // Wasn't added, return false
            return false;
        }

        private bool validateAddition(IRangeConstraint constraint)
        {
            bool result = true;

            // Check if any other constraint in the list collides with new constraint
            for (int i = 0; i < constraintsList.Count; i++)
            {
                if (constraint.collides(constraintsList[i]))
                {
                    // Collision found, return false and stop validating
                    result = false;
                    break;
                }
            }

            return result;
        }

        public abstract bool validateUserInputByConstraints();

        internal List<string> getConstraintsToString()
        {
            List<string> result = new List<string>();

            for (int i = 0; i < constraintsList.Count; i++)
            {
                result.Add(constraintsList[i].ToString());
            }

            return result;
        }
    }
}
