using Assets.Scripts.Constraints;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Assets.Scripts.General
{
    public static class Constants
    {
        // Privates
        static List<IConstraint> sidewalkConstraints;

        static Constants()
        {
            sidewalkConstraints = new List<IConstraint>();
            sidewalkConstraints.Add(new ColorConstraint(Utility.GetRandomBoolean(), Constants.CarColor.BLUE));
            sidewalkConstraints.Add(new ColorConstraint(Utility.GetRandomBoolean(), Constants.CarColor.RED));
            sidewalkConstraints.Add(new ColorConstraint(Utility.GetRandomBoolean(), Constants.CarColor.GREEN));
        }

        public static IConstraint GetSidewalkConstraint(int index)
        {
            return sidewalkConstraints[index % sidewalkConstraints.Count];
        }

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
        public const string SIDEWALK_COLOR_XML = "colorId";
        public const string PARKING_SCENE_XML = "ParkingScene";
		public const string NEWLINE           = "\r\n";
        // Others
        public const int DAYS_IN_WEEK = 7;

        // Scenes data path
        public static string XML_SCENE_DIR = System.IO.Path.Combine (UnityEngine.Application.streamingAssetsPath, "ParkingSceneData");

        // Temp constants
        public const string ASSEMBLY_CONSTRAINT_PATH = "Assets.Scripts.Constraints.";

        public enum CarColor
        {
            GREEN,
            RED,
            BLUE
        }

        public const int NUM_OF_SIDEWALK_COLORS = 5;
    }
}
