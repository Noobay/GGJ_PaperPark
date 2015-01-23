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
        private Dictionary<Type, RangeConstraintManager> managers;
        public SignGenerator generator; // Configure in Unity Editor an instance of sign generator

        // Use this for initialization
        void Start()
        {
            managers = generator.GenerateSignConstraints();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public bool validateUserInputByConstraints()
        {
            bool result = true;

            // TODO Check all managers
            for (int i = 0; i < managers.Count; i++)
            {
                //managers
            }

            return result;
        }
    }
}