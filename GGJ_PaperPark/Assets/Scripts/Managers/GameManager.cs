using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Constraints;

public class GameManager : MonoBehaviour {

	ParkingScene sign;
	public Text signInfo;
	// Update is called once per frame
	void Start()
	{	
		sign = GetComponent<ParkingScene>();
		signInfo.text = string.Empty;

		List<string> stringConstraints = sign.getConstraintsToString();

		for(short i=0;i<stringConstraints.Count;i++)
		{
			signInfo.text += stringConstraints[i];
		}


	}
}
