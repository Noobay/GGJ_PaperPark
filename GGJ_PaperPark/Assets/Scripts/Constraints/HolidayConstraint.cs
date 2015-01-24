using Assets.Scripts.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Assets.Scripts.Constraints
{
    [XmlRoot(Constants.CONSTRAINT_XML)]
    public class HolidayConstraint : IConstraint
    {
        [XmlAttribute(Constants.HOLIDAY_XML)]
        public string holiday { get; private set; }

        [XmlAttribute(Constants.ALLOWED_XML)]
        public bool isConAllowed { get; private set; }
        
        public HolidayConstraint(bool isConAllowed, string holiday)
        {
            this.isConAllowed = isConAllowed;
            this.holiday = holiday;
        }

        public HolidayConstraint() { }

        public bool isUserInputLegal(params object[] inputs)
        {
            if (inputs == null || !(inputs[0] is string))
            {
                return false;
            }

            if (UserInput.IsHolidayNow((string)inputs[0]))
            {
                return isConAllowed;
            }
            else
            {
                return !isConAllowed;
            }
        }

        public override string ToString()
        {
            return "A car " + ((isConAllowed) ? ("May") : ("May not")) + " park during " + holiday;
        }
    }
}
