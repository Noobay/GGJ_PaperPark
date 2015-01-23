using Assets.Scripts.Behaviours;
using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Random = UnityEngine.Random;

namespace Assets.Scripts.Behaviours.Generators
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
        private List<String> rangeConstraintTypes;

        void Start()
        {
            rangeConstraintTypes = new List<String>();

            // TODO Make generic
            rangeConstraintTypes.Add("WeeklyConstraint");
        }

        public List<RangeConstraintManager> GenerateSignConstraints()
        {
            // Define number of managers
            List<RangeConstraintManager> managers = new List<RangeConstraintManager>(Random.Range(minConstraintTypes, maxConstraintTypes));

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
                       new RangeAttribute((float)Convert.ChangeType(DayOfWeek.Tuesday, DayOfWeek.Tuesday.GetTypeCode()),
                                          (float)Convert.ChangeType(DayOfWeek.Thursday, DayOfWeek.Thursday.GetTypeCode())));
        }

        private bool AddNewConstraint(List<RangeConstraintManager> managers, IRangeConstraint constraint)
        {
            bool result = false;

            // First, check if a mananger exists for this type of constraint. If not, create a new one
            if (!isManagerTypeExisting(managers, constraint.GetType()))
            {
                managers.Add(new RangeConstraintManager(constraint));
            }

            // Try adding constraints in all managers
            for (int i = 0; i < managers.Capacity; i++)
            {
                // Once success, break and stop
                if (managers[i].tryAddConstraint(constraint))
                {
                    result = true;
                    break;
                }
            }

            // Return success or failure of adding constraint
            return result;
        }

        private bool isManagerTypeExisting(List<RangeConstraintManager> managers, Type constraintType)
        {
            bool result = true;

            for (int i = 0; i < managers.Count; i++)
            {
                if (managers[i].ConstraintType == constraintType)
                {
                    result = false;
                    break;
                }
            }

            return result;
        }
    }
}
