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
        private int sideColorIndexField;

        [XmlIgnore]
        public bool isConAllowed { get; private set; } // Not is use

        [XmlAttribute(Constants.SIDEWALK_COLOR_XML)]
        public int sideColorIndex
        {
            get
            {
                return sideColorIndexField; 
            }
            private set
            {
                // First, set index
                sideColorIndexField = value;

                // Now, get constraint by the index, then generate its manager
                IConstraint constraint = Constants.GetSidewalkConstraint(sideColorIndex);
                referencedConstraintManager = ConstraintMangerFactory.getManager(constraint.GetType());
                referencedConstraintManager.tryAddConstraint(constraint);
            }
        }

        [XmlIgnore]
        private ConstraintManager referencedConstraintManager { get; set; }
        
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

            return referencedConstraintManager.validateUserInputByConstraints();
        }

        public override string ToString()
        {
            // Has to be only one constraint in the manager
            //return referencedConstraintManager.getConstraintsToString().FirstOrDefault();

            // This is empty because it's top secret!!
            return string.Empty;
        }
    }
}
