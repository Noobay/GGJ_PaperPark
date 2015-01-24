using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Constraints
{
    public abstract class ConstraintManager
    {
        public Type ConstraintType { get; private set; }
        protected List<IConstraint> constraintsList { get; private set; }

        public ConstraintManager(Type constraintType)
        {
            constraintsList = new List<IConstraint>();
            this.ConstraintType = constraintType;
        }

        public bool tryAddConstraint(IConstraint constraint)
        {
            // Check if new constraint is of this manager's type and fits the other constraints
            if (constraint.GetType().Equals(ConstraintType))
            {
                // Fits, add to the list and return true for success
                constraintsList.Add(constraint);
                return true;
            }

            // Wasn't added, return false
            return false;
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
