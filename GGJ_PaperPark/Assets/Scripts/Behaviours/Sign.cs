using UnityEngine;
using System.Collections;
using Assets.Scripts.General;
using System;
using System.Collections.Generic;
using Assets.Scripts.Constraints;
using Assets.Scripts.Constraints.Generators;

namespace Assets.Scripts.Constraints
{
    public class Sign : MonoBehaviour
    {
        public int level = 1;

        private Dictionary<Type, RangeConstraintManager> _rangeManagers;
        private Dictionary<Type, ConstraintManager> _managers;
        private ConstraintFileReader reader;
        //public SignGenerator generator; // Configure in Unity Editor an instance of sign generator

        void Awake()
        {
            reader = new ConstraintFileReader(Constants.XML_SCENE_DIR + level + ".xml");
            _rangeManagers = reader.GenerateSignRangeConstraints();
            _managers = reader.GenerateSignConstraints();
        }

        void Start()
        {
            // TESTING YAW! KEEP OUT KEEP AWAY FAGGOTS
            var result1 = getConstraintsToString();
            var result2 = validateUserInputByConstraints();
        }

        public bool validateUserInputByConstraints()
        {
            List<RangeConstraintManager> rangeManagers = new List <RangeConstraintManager>(_rangeManagers.Values);
            List<ConstraintManager> managers = new List<ConstraintManager>(_managers.Values);

            // Validate all constraints in existance
            for (int i = 0; i < rangeManagers.Count; i++)
            {
                if(!rangeManagers[i].validateUserInputByConstraints())
                {
                    return false;
                }
            }

            for (int i = 0; i < managers.Count; i++)
            {
                if (!managers[i].validateUserInputByConstraints())
                {
                    return false;
                }
            }

            return true;
        }

        public List<string> getConstraintsToString()
        {
            List<string> result = new List<string>();
            List<RangeConstraintManager> _managers = new List<RangeConstraintManager>(_rangeManagers.Values);
            for (int i = 0; i < _managers.Count; i++)
            {
                result.AddRange(_managers[i].getConstraintsToString());
            }

            return result;
        }
    }
}