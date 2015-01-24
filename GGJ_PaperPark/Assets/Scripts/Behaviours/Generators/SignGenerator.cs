using Assets.Scripts.Constraints;
using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Random = UnityEngine.Random;
using Assets.Scripts.General;

namespace Assets.Scripts.Constraints.Generators
{
    public class SignGenerator : MonoBehaviour
    {
        // Fields accessed through the Unity editor
        //public int minConstraintsPerManager;
        //public int maxConstraintsPerManager;
        public int minConstraints;
        public int maxConstraints;
        public int minConstraintTypes;
        public int maxConstraintTypes;

        void Start()
        {
        }

        public Dictionary<Type, RangeConstraintManager> GenerateSignConstraints()
        {
            // Define number of managers
            var managers = new Dictionary<Type, RangeConstraintManager>(Random.Range(minConstraintTypes, maxConstraintTypes));

            // TODO Create a parser that reads and generates a sign from file data.
            // Get their type by reflection maybe?
            int numOfConstraints = Random.Range(minConstraints, maxConstraints);
            int constraintsMade = 0;

            // Create a random number of constraints
            while (numOfConstraints > constraintsMade)
            {
                if (AddNewConstraint(managers, GenerateConstraint()))
                {
                    constraintsMade++;
                }
            }

            return managers;
        }

        private IRangeConstraint GenerateConstraint()
        {
            //Type.GetType(rangeConstraintTypes.OrderBy(x => Guid.NewGuid()).FirstOrDefault());

            // TODO Static shit. Change in the future
            return new WeeklyConstraint(false,
                       new GameRangeAttribute((int)Convert.ChangeType(DayOfWeek.Tuesday, DayOfWeek.Tuesday.GetTypeCode()),
                                              (int)Convert.ChangeType(DayOfWeek.Thursday, DayOfWeek.Thursday.GetTypeCode())));
        }

        private bool AddNewConstraint(Dictionary<Type, RangeConstraintManager> managers, IRangeConstraint constraint)
        {
            // First, check if a mananger exists for this type of constraint. If not, create a new one
            if (!managers.ContainsKey(constraint.GetType()))
            {
                managers.Add(constraint.GetType(), RangeConstraintMangerFactory.getManager(constraint.GetType()));
            }

            // Add new constraint
            return managers[constraint.GetType()].tryAddConstraint(constraint);
        }
    }
}
