public static class GameData
{

		public static readonly string[] holidayNames = {"Prickle-Prickle", "Quansa", "Disco Day","Cheese Waffle Mayhem"};
		public static readonly NameIntPair[] NameLengthPairs;
			

		public static NameIntPair[] PavementType;

		static GameData()
		{
			NameLengthPairs = new NameIntPair[] 
			{
				new NameIntPair(holidayNames[0],       5),
				new NameIntPair(holidayNames[1],       8),
				new NameIntPair(holidayNames[2],       1),
				new NameIntPair(holidayNames[3],      12)
					
			};

			PavementType =  new NameIntPair[]
			{
				new NameIntPair("Green/Pink",0),
				new NameIntPair("Purple/Orange",0),
				new NameIntPair("Orange/White",0),
				new NameIntPair("Purple/White",0),
				new NameIntPair("Brown/Yellow",0)
			};
		}

}