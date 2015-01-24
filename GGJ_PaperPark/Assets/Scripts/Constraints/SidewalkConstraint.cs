using Assets.Scripts.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Assets.Scripts.Constraints
{
    [XmlRoot(Constants.CONSTRAINT_XML)]
    public class SidewalkConstraint : IConstraint
    {
        [XmlIgnore]
        public bool isConAllowed { get; private set; } // Not is use

        [XmlAttribute(Constants.SIDEWALK_COLOR_XML)]
        public int sideColorIndex { get; private set; }
        
        public SidewalkConstraint(int index)
        {
            isConAllowed = false;
            sideColorIndex = index % Constants.NUM_OF_SIDEWALK_COLORS;
        }

        public SidewalkConstraint() { }

        public bool isUserInputLegal(params object[] inputs)
        {
            // Generate a constraint and its manager by the index of the constraint. Get validity
            // Manager is used to give input to the constraint
            IConstraint constraint = Constants.GetSidewalkConstraint(sideColorIndex);
            ConstraintManager manager = ConstraintMangerFactory.getManager(constraint.GetType());
            manager.tryAddConstraint(constraint);
            return manager.validateUserInputByConstraints();
        }
    }
}
