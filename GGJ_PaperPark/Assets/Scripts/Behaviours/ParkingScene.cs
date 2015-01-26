using UnityEngine;
using System.Collections;
using Assets.Scripts.General;
using System;
using System.Collections.Generic;
using Assets.Scripts.Constraints;
using Assets.Scripts.Constraints.Generators;

namespace Assets.Scripts.Constraints
{
    public class ParkingScene : MonoBehaviour
    {
        public static int level = 1;

        private Dictionary<Type, RangeConstraintManager> _rangeManagers;
        private Dictionary<Type, ConstraintManager> _managers;
        private ConstraintFileReader reader;
        //public SignGenerator generator; // Configure in Unity Editor an instance of sign generator

        public ParkingScene()
        {
            loadSceneData();
        }

        void Start()
        {
		}
		
		private void loadSceneData()
        {	
            reader = new ConstraintFileReader(System.IO.Path.Combine (Constants.XML_SCENE_DIR, level + ".xml"));
            _rangeManagers = reader.GenerateSignRangeConstraints();
            _managers = reader.GenerateSignConstraints();
        }

        public void requestNewSceneData()
        {
            // Increase level counter and load new level
            level++;
            loadSceneData();
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
            List<RangeConstraintManager> rangeManagers = new List<RangeConstraintManager>(_rangeManagers.Values);
            List<ConstraintManager> managers = new List<ConstraintManager>(_managers.Values);

            // Get all strings from all constraints
            for (int i = 0; i < rangeManagers.Count; i++)
            {
                result.AddRange(rangeManagers[i].getConstraintsToString());
            }

            for (int i = 0; i < managers.Count; i++)
            {
                result.AddRange(managers[i].getConstraintsToString());
            }

            return result;
        }

        public int getSidewalkIndex()
        {
            return (_managers[typeof(SidewalkConstraint)] as SidewalkConstraintManager).getSidewalkIndex();
        }
    }
}