using UnityEngine;
using System.Collections;
using Assets.Scripts.Constraints;
using UnityEngine.UI;

public class ParkValidator : MonoBehaviour {
	
	public ParkingScene psd;

	private Button button;

	// Use this for initialization
	void Start () {

		psd = new ParkingScene();

		button = GetComponent<Button>();
		button.onClick.AddListener(ActUponDecision);

	}
	
	// Update is called once per frame
	public void ActUponDecision()
	{
		if(psd.validateUserInputByConstraints())
		{
			psd.requestNewSceneData();	
		}
		PlayerFailure();
	}

	void PlayerFailure()
	{
		//TODO: Play some animations
		psd.requestNewSceneData();
	}
}
