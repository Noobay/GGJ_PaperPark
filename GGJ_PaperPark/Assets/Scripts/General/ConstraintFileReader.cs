using Assets.Scripts.Constraints;
using Assets.Scripts.General;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts.General
{
    public class ConstraintFileReader
    {
        private ParkingSceneData _data { get; set; }

        public ConstraintFileReader(string path)
        {
            _data = ReadConstraint(path);
        }

        //private ParkingSceneData ReadConstraint(string path)
        //{
        //    var serializer = new XmlSerializer(typeof(ParkingSceneData));
        //    var stream = new FileStream(path, FileMode.Open);
        //    var container = serializer.Deserialize(stream) as ParkingSceneData;
        //    stream.Close();

        //    return container;
        //}

        private ParkingSceneData ReadConstraint(string path)
        {
            var container = new ParkingSceneData();

            using (XmlReader reader = XmlReader.Create(path))
            {
                // Parse the file and display each of the nodes.
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        switch (reader.Name)
                        {
                            case Constants.TYPE_CONSTRAINT_XML:
                                container.Constraints.Add(parseConstraint(reader));
                                break;
                            default:
                                break;
                        }
                    }
                }
            }

            return container;
        }

        private IRangeConstraint parseConstraint(XmlReader reader)
        {
            Type constType;

            XElement constEle = XNode.ReadFrom(reader) as XElement;
            constType = Type.GetType(Constants.ASSEMBLY_CONSTRAINT_PATH + constEle.Value.Trim('\t', '\r', '\n'));
            XmlSerializer serializer = new XmlSerializer(constType);

            return serializer.Deserialize(reader) as IRangeConstraint;
        }

        public Dictionary<Type, RangeConstraintManager> GenerateSignConstraints()
        {
            // Define number of managers
            var managers = new Dictionary<Type, RangeConstraintManager>();

            _data.Constraints.ForEach(constraint => AddNewConstraint(managers, constraint));

            return managers;
        }

        //public List<Sidewalk>(){}

        private bool AddNewConstraint(Dictionary<Type, RangeConstraintManager> managers, IRangeConstraint constraint)
        {
            // First, check if a mananger exists for this type of constraint. If not, create a new one
            if (!managers.ContainsKey(constraint.GetType()))
            {
                managers.Add(constraint.GetType(), RangeConstraintMangerFactory.getManager(constraint.GetType()));
            }

            // Add new constraint
            return managers[constraint.GetType()].tryAddConstraint(constraint);
        }
    }
}
