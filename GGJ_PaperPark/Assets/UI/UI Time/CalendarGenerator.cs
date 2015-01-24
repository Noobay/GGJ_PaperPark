using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Globalization;
using System.Collections.Generic;

public class CalendarGenerator : MonoBehaviour {

	const int NUM_OF_TRIES = 4;

	public static Dictionary<int, NameIntPair> holidays;

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

		holidays = GenerateDayPairs();

		List<NameIntPair> holidaysToWrite = new List<NameIntPair>();

		// Go through the days.
		for(daysIterator = 0; daysIterator < daysInMonth; daysIterator++)
		{
			// Check if holiday.
			if(holidays.ContainsKey(daysIterator))
			{
				holidaysToWrite.Add(new NameIntPair(holidays[daysIterator])); 
			}

			currentDay = daysIterator%daysInWeek;
			string textToWrite = (daysIterator+1)+"\r\n"+
								  HolidayInDay(holidaysToWrite)+
								  "\r\n"+dtfi.DayNames[currentDay];

			tempObject = (GameObject)Instantiate(Cell); 
			tempObject.transform.GetChild(0).GetComponent<Text>().text = textToWrite;
			tempObject.GetComponent<RectTransform>().SetParent(Calendar_Dates);
		}
	}

	string HolidayInDay(List<NameIntPair> holidaysToWrite)
	{
		string HolidayString = string.Empty;
		// Check if we are writing holidays.
		for (int i = 0; i < holidaysToWrite.Count; i++) 
		{
			if(i>0)
			{
				HolidayString += "\r\n";
			}

			HolidayString += holidaysToWrite[i].name;
			holidaysToWrite[i].value--;
			if(holidaysToWrite[i].value==0)
			{
				holidaysToWrite.RemoveAt(i);
			}
		}
		return HolidayString;
	}

	public Dictionary<int,NameIntPair> GenerateDayPairs()
	{
		Dictionary<int,NameIntPair> _dayList = new Dictionary<int,NameIntPair>();

		int holidaysInMonth = Random.Range (1, GameData.HolidayNameLengthPairs.Length - 1);

		// Populate holidays
		for(short i=0; i < GameData.holidayNames.Length; i++)
		{
			int randomDate = Random.Range(0, daysInMonth - 1);
			int j=0;
			for(;(_dayList.ContainsKey(randomDate)) && j < NUM_OF_TRIES;j++)
			{
				randomDate = Random.Range(0, daysInMonth - 1);
			}
			if(j==NUM_OF_TRIES)
			{
				break;
			}

			_dayList.Add(randomDate, GameData.HolidayNameLengthPairs[i]);
		}

		return _dayList;

	}

	public static string TodaysHolidays(int todaysDay)
	{
		string holidayString   = string.Empty;
		string thisHolidayName = string.Empty;

		for(short i=0; i<GameData.holidayNames.Length; i++)
		{
			thisHolidayName = GameData.holidayNames[i];
			if(holidays[todaysDay].name.Contains(thisHolidayName))
			{
				holidayString += thisHolidayName;
			}
		}
		return holidayString;
 	}

	public static bool isHolidayToday(int todaysDay, string holidayName)
	{
		string todaysHolidays = TodaysHolidays(todaysDay);

		if(todaysHolidays != string.Empty && todaysHolidays.Contains(holidayName))
		{
			return true;
		}
		return false;
	}
}
