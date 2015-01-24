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
        public string color { get; private set; }

        [XmlAttribute(Constants.ALLOWED_XML)]
        public bool isConAllowed { get; private set; }

        public ColorConstraint(bool isConAllowed, Constants.CarColor color)
        {
            this.isConAllowed = isConAllowed;
            this.color = color.ToString();
        }

        public override string ToString()
        {
            return ("Cars of the color " + this.color + " " + 
                    ((isConAllowed) ? ("May") : ("May not")) + 
                    (" park in this spot."));
        }

        public bool isUserInputLegal(params object[] inputs)
        {
            if (inputs == null || !(inputs[0] is Constants.CarColor))
            {
                return false;
            }

            Constants.CarColor _carColor = 
                (Constants.CarColor)Enum.Parse(typeof(Constants.CarColor), color, true);

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
