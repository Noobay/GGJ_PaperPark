using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Globalization;

public class GenerateCalendar : MonoBehaviour {
	
	public Text monthText;

	public Transform Calendar_Dates;
	public GameObject Cell;


	private int daysInMonth;
	private int daysIterator;

	public static GenerateCalendar gCal;

	void Awake()
	{
		gCal = this;
	}



	void GetCurrentMonthInfo()
	{
		DateTimeFormatInfo dtfi = DateTimeFormatInfo.CurrentInfo;
		monthText.text = dtfi.MonthNames[MakeTime.gameDateTime.Month];

		daysInMonth = System.DateTime.DaysInMonth(MakeTime.gameDateTime.Year,MakeTime.gameDateTime.Month);

		for(daysIterator = 0; daysIterator <= daysInMonth; daysIterator++)
		{
			((GameObject)Instantiate(Cell)).transform.SetParent(Calendar_Dates);
		}
	}
}
