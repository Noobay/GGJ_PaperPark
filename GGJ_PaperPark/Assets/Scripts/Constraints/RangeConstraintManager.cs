﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Constraints
{
    public abstract class RangeConstraintManager
    {
        public Type ConstraintType { get; private set; }
        private List<IRangeConstraint> constraintsList { get; set; }

        public RangeConstraintManager(IRangeConstraint first)
        {
            ConstraintType = first.GetType();
            constraintsList = new List<IRangeConstraint>();

            // Add the first instance of constraint
            constraintsList.Add(first);
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
    }
}
