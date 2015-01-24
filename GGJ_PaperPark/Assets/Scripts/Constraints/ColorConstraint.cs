using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Constraints
{
    public class ColorConstraint : IConstraint
    {
        Assets.Scripts.General.Constants.CarColor color;

        public ColorConstraint(bool isConAllowed, Assets.Scripts.General.Constants.CarColor color)
        {
            this.color = color;
            this.isConAllowed = isConAllowed;
        }

        public override string ToString()
        {
            return ("Cars of the color " + this.color.ToString() + " " + 
                    ((isConAllowed) ? ("May") : ("May not")) + 
                    (" park in this spot."));
        }

        public bool isConAllowed { get; private set; }

        public bool isUserInputLegal(params object[] inputs)
        {
            if (inputs == null || !(inputs[0] is Assets.Scripts.General.Constants.CarColor))
            {
                return false;
            }

            if(inputs[0].Equals(color))
            {
                return isConAllowed;
            }
            else
            {
                return !isConAllowed;
            }
        }
    }
}
