using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Globalization;

public class CalendarGenerator : MonoBehaviour {

	public Text monthText;

	public Transform Calendar_Dates;
	public GameObject Cell;


	private int daysInMonth;
	private int daysIterator;
	private int currentDay;

	private const int daysInWeek = 7;

	private GameObject tempObject;

	public void GenerateCurrentMonthInfo()
	{
		DateTimeFormatInfo dtfi = DateTimeFormatInfo.CurrentInfo;
		monthText.text = dtfi.MonthNames[MakeTime.gameDateTime.Month];

		daysInMonth = System.DateTime.DaysInMonth(MakeTime.gameDateTime.Year,MakeTime.gameDateTime.Month);

		for(daysIterator = 0; daysIterator < daysInMonth; daysIterator++)
		{
			currentDay = daysIterator%daysInWeek;

			tempObject = (GameObject)Instantiate(Cell); 
			tempObject.transform.GetChild(0).GetComponent<Text>().text = (daysIterator+1)+"\r\n\r\n"+dtfi.DayNames[currentDay];
			tempObject.GetComponent<RectTransform>().SetParent(Calendar_Dates);
		}
	}
}
