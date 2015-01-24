using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class NameIntPair {
	
	public string name;
	public int value;
	

	public NameIntPair(string vName, int vLength)
	{
		name   = vName;
		value  = vLength;
	}

	public static void ShufflePair(NameIntPair[] pair,int Range)
	{
		int pavementTypesLeft = Range;
		int selectedNumber;
		short i = 0;

		List<int> selectionList = new List<int>();
		

		for(i=0; i<Range; i++)
		{
			selectionList.Add (i);
		}

		for(i=0; i<pavementTypesLeft; pavementTypesLeft --)
		{
			selectedNumber = selectionList[UnityEngine.Random.Range(0, pavementTypesLeft)];
			pair[pavementTypesLeft-1].value = selectedNumber;
			selectionList.Remove(selectedNumber);
	 	}
	}
}