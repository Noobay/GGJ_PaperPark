using Assets.Scripts.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Assets.Scripts.Constraints
{
    [XmlRoot(Constants.CONSTRAINT_XML)]
    public class ColorConstraint : IConstraint
    {
        [XmlAttribute(Constants.CAR_COLOR_XML)]
        string color;

        [XmlAttribute(Constants.ALLOWED_XML)]
        public bool isConAllowed { get; private set; }

        public ColorConstraint(bool isConAllowed, Assets.Scripts.General.Constants.CarColor color)
        {
            this.isConAllowed = isConAllowed;
        }

        public override string ToString()
        {
            return ("Cars of the color " + this.color.ToString() + " " + 
                    ((isConAllowed) ? ("May") : ("May not")) + 
                    (" park in this spot."));
        }

        public bool isUserInputLegal(params object[] inputs)
        {
            if (inputs == null || !(inputs[0] is Assets.Scripts.General.Constants.CarColor))
            {
                return false;
            }

            Assets.Scripts.General.Constants.CarColor _carColor = 
                (Assets.Scripts.General.Constants.CarColor)Enum.Parse(typeof(Assets.Scripts.General.Constants.CarColor), color, true);

            if(inputs[0].Equals(_carColor))
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
