using UnityEngine;
using System.Collections;
using Assets.Scripts.General;
using System.Xml.Serialization;
using System;

namespace Assets.Scripts.Constraints
{
    [XmlRoot(Constants.CONSTRAINT_XML)]
    public abstract class RangeConstraint<T> : IRangeConstraint
    {
        [XmlIgnore]
        private GameRangeAttribute myVar;

        [XmlAttribute(Constants.TYPE_CONSTRAINT_XML)]
        private Type classType { get {return this.GetType();} }
        [XmlElement(Constants.RANGE_XML)]
        public GameRangeAttribute range
        {
            get { return myVar; }
            protected set
            {
                myVar = value;
                calculateOffset();
            }
        }

        [XmlAttribute(Constants.ALLOWED_XML)]
        public bool isConAllowed { get; private set; }

        protected abstract void calculateOffset();

        public RangeConstraint(bool isConAllowed, GameRangeAttribute range)
        {
            this.isConAllowed = isConAllowed;
            this.range = range;
        }

        protected RangeConstraint() { }

        public abstract bool collides(IRangeConstraint other);

        public abstract bool isUserInputLegal(params object[] inputs);

        protected bool IsIntersecting(long a1, long a2, long b1, long b2)
        {
            long distance = (long)Mathf.Abs(a1 - b1);

            return (distance < a2 - a1) || (distance < b2 - b1);
        }
    }
}