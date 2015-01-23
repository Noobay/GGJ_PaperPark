using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MakeTime : MonoBehaviour {

	public Text yearMonthDayText, hourSecondText;	

	
	public int dayVariation = 365;
	public int hourVariation = 24;	
	public int secondVariation = 60;

	public int gameTimeScale;

	private int hours, seconds;

	private const string yearMonthDay = "Year : {0:yyyy} Month : {0:MM} Day : {0:dd}";
	private const string hourSeconds  = "Hours : {0:hh} Minutes: {0:mm} Seconds: {0:ss}";

	public static System.DateTime gameDateTime;

	public static MakeTime mTime;
	void Awake()
	{
		mTime = this;
	}
	// Use this for initialization
	void Initialize()
	{
		gameDateTime = GenerateDateTime();
		yearMonthDayText.text = string.Format(yearMonthDay, gameDateTime);

		hours = gameDateTime.Hour;
		seconds = gameDateTime.Second;

	}
	
	// Update is called once per frame
	void UpdateTime ()
	{
		gameDateTime = gameDateTime.AddSeconds(Time.deltaTime*gameTimeScale);

		hourSecondText.text = string.Format (hourSeconds , gameDateTime);
	
	}

	public System.DateTime GenerateDateTime()
	{
		System.DateTime thisDate;
	
		thisDate = new System.DateTime(System.DateTime.Now.Ticks);
		
		thisDate = thisDate.AddDays(Random.Range (-dayVariation,dayVariation)).
							AddHours (Random.Range(-hourVariation,hourVariation)).
							AddSeconds(Random.Range(-secondVariation,secondVariation));

		return thisDate;
	}
}
