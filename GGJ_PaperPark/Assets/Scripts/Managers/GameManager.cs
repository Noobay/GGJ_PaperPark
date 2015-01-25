using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Constraints;
using Assets.Scripts.General;
using Assets.UI;

public class GameManager : MonoBehaviour {

	public Sprite[] CarSprites;
	public Sprite[] Pavements;
	public Text[] Entries;

	public Image playerSpawn;

	public Image sceneImage;

	private GameObject tempObject;
	private List<string> stringConstraints;

	private ParkingScene sign;
	public Text signInfo;

	void Start()
	{	
		sign = GetComponent<ParkingScene>();
		signInfo.text = string.Empty;

		CreateNewScene ();

		stringConstraints = sign.getConstraintsToString();
		
	}


	public void CreateNewScene()
	{

		sceneImage.sprite = Pavements[sign.getSidewalkIndex()];
	
		InitializePlayer();
		GetConstraintsToSignText();
		populateEntries();

	}
	void InitializePlayer()
	{
		playerSpawn.sprite = CarSprites[(int)CarColorWrapper.GetCarColor()];
		
	}
	void GetConstraintsToSignText()
	{
		signInfo.text = string.Empty;
		stringConstraints = sign.getConstraintsToString();
		for(short i=0;i<stringConstraints.Count;i++)
		{
			signInfo.text += stringConstraints[i]+Constants.NEWLINE;
		}

	}

	void populateEntries()
	{
		for(short i=0;i < Constants.NUM_OF_SIDEWALK_COLORS;i++)
		{
			Entries[i].text = Constants.GetSidewalkConstraint(i).ToString ();
		}
	}
}
