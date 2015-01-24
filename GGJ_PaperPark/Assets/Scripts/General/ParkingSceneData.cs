using Assets.Scripts.Constraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Assets.Scripts.General
{
    [XmlRoot(Constants.PARKING_SCENE_XML)]
    public class ParkingSceneData
    {
        [XmlArray(Constants.LIST_CONSTRAINT_XML)]
        [XmlArrayItem((Constants.CONSTRAINT_XML))]
        public List<IRangeConstraint> Constraints = new List<IRangeConstraint>();
    }
}
