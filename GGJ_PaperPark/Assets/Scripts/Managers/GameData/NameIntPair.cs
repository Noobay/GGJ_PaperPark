using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class NameIntPair {
	
	public string name;
	public int value;
	

	public NameIntPair(string vName, int vValue)
	{
		name   = vName;
		value  = vValue;
	}

	public NameIntPair(NameIntPair other)
	{
		name   = other.name;
		value  = other.value;
	}

	public static void ShufflePair(NameIntPair[] pair,int Range)
	{
		int typesLeft = Range;
		int selectedNumber;
		short i = 0;

		List<int> selectionList = new List<int>();
		

		for(i=0; i<Range; i++)
		{
			selectionList.Add (i);
		}

		for(i=0; i<typesLeft; typesLeft --)
		{
			selectedNumber = selectionList[UnityEngine.Random.Range(0, typesLeft)];
			pair[typesLeft-1].value = selectedNumber;
			selectionList.Remove(selectedNumber);
	 	}
	}
}