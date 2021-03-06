﻿using Assets.Scripts.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using UnityEngine;

namespace Assets.Scripts.Constraints
{
    [XmlRoot(Constants.CONSTRAINT_XML)]
    public class HourConstraint : RangeConstraint<int>
    {
        public HourConstraint(bool isConAllowed, GameRangeAttribute range)
            : base(isConAllowed, range)
        {

        }

        public HourConstraint() 
        {

        }

        public override bool collides(IRangeConstraint other)
        {
            // TODO In the future when things are generated and pigs eat Tom's ass
            return false;
        }

        public override string ToString()
        {
            return "A car " + ((isConAllowed) ? ("May") : ("May not")) + String.Format(" park between {0}:00 and {1}:00",
                                                            range.min,
                                                            range.max);
        }

        public override bool isUserInputLegal(params object[] inputs)
        {
            if (inputs == null || !(inputs[0] is int))
            {
                return false;
            }

            int userHour = ((int)inputs[0]) % 24;
            int min = ((int)range.min);
            int max = ((int)range.max);

            // If user time is in range of the hours
            if ((userHour >= min && userHour < max) || (userHour < min && userHour >= max))
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

        protected override void calculateOffset()
        {
            int offset = UserInput.GetUserHour();

            // TODO: Hours of the day
            int cycle = 24;
            this.range.max = (this.range.max + offset) % cycle;
            this.range.min = (this.range.min + offset) % cycle;
        }
    }
}
