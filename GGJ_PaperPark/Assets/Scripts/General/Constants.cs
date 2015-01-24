using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Assets.Scripts.General
{
    public static class Constants
    {
        // XML attributes

        // Scene attributes
        public const string RANGE_XML = "Range";
        public const string CONSTRAINT_XML = "Constraint";
        public const string LIST_CONSTRAINT_XML = "ListConstraint";
        public const string TYPE_CONSTRAINT_XML = "ConstraintType";
        public const string MIN_XML = "min";
        public const string MAX_XML = "max";
        public const string ALLOWED_XML = "allowed";
        public const string HOLIDAY_XML = "holiday";
        public const string CAR_COLOR_XML = "color";
        public const string SIDEWALK_XML = "Sidewalk";
        public const string PARKING_SCENE_XML = "ParkingScene";

        // Scenes data path
        public const string XML_SCENE_DIR = @"Assets/ParkingSceneData/";

        // Temp constants
        public const string ASSEMBLY_CONSTRAINT_PATH = "Assets.Scripts.Constraints.";

        public enum CarColor
        {
            GREEN,
            RED,
            BLUE
        }
    }
}
