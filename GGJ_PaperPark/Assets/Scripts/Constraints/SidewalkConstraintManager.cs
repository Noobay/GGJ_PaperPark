using Assets.Scripts.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Assets.Scripts.Constraints
{
    public class SidewalkConstraintManager
    {
        IConstraint constraint;
        
        public SidewalkConstraintManager(int index)
        {
            constraint = UserInput.GetSidewalkConstraint(index);
        }

        public bool validateUserInputByConstraints()
        {
            return constraint.isUserInputLegal(UserInput.GetCarColor());
        }
    }
}
