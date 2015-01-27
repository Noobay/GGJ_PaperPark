using UnityEngine;
using System.Collections;
using Assets.Scripts.Constraints;
using UnityEngine.UI;

public class ParkValidator : MonoBehaviour {
	
	public ParkingScene psd;

	private Button button;

	public Text ValidateResult;

	public GameManager gMan;

	public Animator WinAnimator, LoseAnimator;


	public float pitchChange = 0.1f;

	private AudioSource audSource;
	private float pitch;
	// Use this for initialization
	void Start () {
	
		audSource = GetComponent<AudioSource>();
		button = GetComponent<Button>();
	
		pitch = audSource.pitch;
	}
	
	// Update is called once per frame
	public void ActUponDecision(bool decision)
	{
		try{
			if(psd.validateUserInputByConstraints() == decision)
			{

				ValidateResult.text = "You are able to park here!";
				PlayerWin ();
			}
			else
			{
				ValidateResult.text = "You are ERROR!";
				PlayerFailure();
			}

			ResetScene();
		}
		catch (System.IO.FileNotFoundException e)
		{			
			ValidateResult.text = "No more levels to load";
		}
	}

	private void SetPitch(float pitchDiff)
	{
		pitch += pitchDiff;
		pitch = Mathf.Clamp(pitch,0.1f,1f);
		audSource.pitch = pitch;
	}
	private void ResetScene()
	{
		psd.requestNewSceneData();
		gMan.CreateNewScene();
	}

	private void PlayerFailure()
	{

		//TODO: Play some animations, lower score
		LoseAnimator.SetTrigger ("Lose");
		SetPitch (-pitchChange);

	}
	private void PlayerWin()
	{
		
		//TODO: Play some animations, lower score
		WinAnimator.SetTrigger ("Win");
		SetPitch (pitchChange);
		
	}
}
