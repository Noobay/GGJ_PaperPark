using UnityEngine;
using System.Collections;
using Assets.Scripts.Constraints;
using UnityEngine.UI;

public class ParkValidator : MonoBehaviour {
	
	public ParkingScene psd;

	private Button button;

	public Text ValidateResult;

	public GameManager gMan;

	// Use this for initialization
	void Start () {

		button = GetComponent<Button>();
		button.onClick.AddListener(ActUponDecision);

	}
	
	// Update is called once per frame
	public void ActUponDecision()
	{
		if(psd.validateUserInputByConstraints())
		{
			ValidateResult.text = "You are able to park here!";
		}
		else
		{
			ValidateResult.text = "You are ERROR!";
			PlayerFailure();
		}
		psd.requestNewSceneData();
		gMan.CreateNewScene();
	}


	void PlayerFailure()
	{
		//TODO: Play some animations

	}
}
