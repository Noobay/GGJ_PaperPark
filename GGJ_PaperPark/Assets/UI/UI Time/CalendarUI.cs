using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Globalization;
using System.Collections.Generic;
using Assets.Scripts.General;
using Assets.Scripts.Generators;

public class CalendarGenerator : MonoBehaviour {

	const int NUM_OF_TRIES = 4;

	public static Dictionary<int, NameIntPair> holidays;

	public Text monthText;

	public Transform Calendar_Dates;
	public GameObject Cell;

	private int daysIterator;
	private int currentDay;

	private GameObject tempObject;

    public void GenerateCurrentMonthInfo()
    {
        DateTimeFormatInfo dtfi = DateTimeFormatInfo.CurrentInfo;
        monthText.text = dtfi.MonthNames[MakeTime.gameDateTime.Month];

        holidays = CalendarWrapper.GenerateDayPairs();

        List<NameIntPair> holidaysToWrite = new List<NameIntPair>();

        // Go through the days.
        for (daysIterator = 0; daysIterator < CalendarWrapper.daysInMonth; daysIterator++)
        {
            // Check if holiday.
            if (holidays.ContainsKey(daysIterator))
            {
                holidaysToWrite.Add(new NameIntPair(holidays[daysIterator]));
            }

            currentDay = daysIterator % Constants.DAYS_IN_WEEK;
            string textToWrite = (daysIterator + 1) + "\r\n" +
                                  HolidayInDay(holidaysToWrite) +
                                  "\r\n" + dtfi.DayNames[currentDay];

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
            if (i > 0)
            {
                HolidayString += "\r\n";
            }

            HolidayString += holidaysToWrite[i].name;
            holidaysToWrite[i].value--;
            if (holidaysToWrite[i].value == 0)
            {
                holidaysToWrite.RemoveAt(i);
            }
        }
        return HolidayString;
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
