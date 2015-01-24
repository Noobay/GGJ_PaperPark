using System;
using System.Xml.Serialization;
using UnityEngine;

namespace Assets.Scripts.General
{
    public sealed class GameRangeAttribute
    {
        [XmlAttribute(Constants.MAX_XML)]
        public double max;

        [XmlAttribute(Constants.MIN_XML)]
        public double min;

        public GameRangeAttribute(double min, double max)
        {
            this.max = max;
            this.min = min;
        }

        public GameRangeAttribute() { }
    }
}
