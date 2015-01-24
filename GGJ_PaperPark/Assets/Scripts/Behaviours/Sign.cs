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
        // TODO: Debug!!!
        static int level = 1;

        private Dictionary<Type, RangeConstraintManager> managers;
        private ConstraintFileReader reader;
        //public SignGenerator generator; // Configure in Unity Editor an instance of sign generator

        void Awake()
        {
            reader = new ConstraintFileReader(Constants.XML_SCENE_DIR + level + ".xml");
            //managers = generator.GenerateSignConstraints();
            managers = reader.GenerateSignConstraints();
        }

        // Use this for initialization
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {

        }

        public bool validateUserInputByConstraints()
        {
            List<RangeConstraintManager> _managers = new List < RangeConstraintManager > (managers.Values);
            for (int i = 0; i < _managers.Count; i++)
            {
                if(!_managers[i].validateUserInputByConstraints())
                {
                    return false;
                }
            }

            return true;
        }

        public List<string> getConstraintsToString()
        {
            List<string> result = new List<string>();
            List<RangeConstraintManager> _managers = new List<RangeConstraintManager>(managers.Values);
            for (int i = 0; i < _managers.Count; i++)
            {
                result.AddRange(_managers[i].getConstraintsToString());
            }

            return result;
        }
    }
}