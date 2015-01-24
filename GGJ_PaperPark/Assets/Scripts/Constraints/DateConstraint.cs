using Assets.Scripts.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using UnityEngine;

namespace Assets.Scripts.Constraints
{
    [XmlRoot(Constants.CONSTRAINT_XML)]
    public class DateConstraint : RangeConstraint<DateTime>
    {
        public DateConstraint(bool isConAllowed, GameRangeAttribute range)
            : base(isConAllowed, range)
        {

        }

        public DateConstraint() 
        {
        }

        public override bool collides(IRangeConstraint other)
        {
            return IsIntersecting(((long)range.min), ((long)range.max), (long)other.range.min, (long)other.range.max);
        }

        public override string ToString()
        {
            return "A car " + ((isConAllowed) ? ("May") : ("May not")) + String.Format(" park between {0} and {1}", 
                                                            new DateTime((long)range.min),
                                                            new DateTime((long)range.max));
        }

        public override bool isUserInputLegal(params object[] inputs)
        {
            if (inputs == null || !(inputs[0] is long))
            {
                return false;
            }

            long userTime = ((long)inputs[0]);
            long min = ((long)range.min);
            long max = ((long)range.max);
            
            // If user time is in range of the dates
            if (userTime >= min && userTime <= max)
            {
                // Return the value of the is constraint allowed flag. 
                // E.x. if user time is between the dates and during this time is not allowed to park, return false
                return isConAllowed;
            }
            else
            {
                // Opposite of the above
                return !isConAllowed;
            }
        }
    }
}
