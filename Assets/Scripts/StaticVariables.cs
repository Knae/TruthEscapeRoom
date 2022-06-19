using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // For accessing UI
using UnityEngine.SceneManagement; // For accessing scene related data

public class StaticVariables : MonoBehaviour
{
    [Header("Game Variables")]
    [SerializeField] static public int iDay = 1;
	[SerializeField] static public bool bHasBathed = false;
	[SerializeField] static public bool bHadBreakfast = false;
	[SerializeField] static public bool bMadeBed = false;
	[SerializeField] static public bool bAlarmOff = false;
	[SerializeField] static public bool bComputerOn = false;
	[SerializeField] static public int iNeighbourInteractions = 0; // Number of time player has interacted with neighbour (door)
	[SerializeField] static public bool bInteractingWithNeighbour = false; // If true, stops player movement

	[Header("Time Variables")]
	[SerializeField] static public float beginningHour = 9.0f;
	[SerializeField] static public float beginningMinute = 30.0f;
	[SerializeField] static public float hourForWork = 11.0f;
	[SerializeField] static public float day;
	[SerializeField] static private float realSecondsToIngameDay = 720f; // 12 minutes for 24 hours, two full rotation

	public Scene currentScene; // For accessing what the current scene is

	private void Start()
	{
		// Day start time
		day = (beginningHour + (beginningMinute / 60f)) / 12f;

		DontDestroyOnLoad(transform.gameObject);

	}

    private void Update()
    {
		// Get current scene and store in variable
		currentScene = SceneManager.GetActiveScene(); 

		// Increase Day time - as long as not in main menu
		if (currentScene.name != "Main Menu")
		{
			day += Time.deltaTime / realSecondsToIngameDay;
		}
	}

    static public void NextDay()
	{
		bHadBreakfast = false;
		bMadeBed = false;
		bAlarmOff = false;
		iDay++;

		// Reset Day start time on new day
		day = (beginningHour + (beginningMinute / 60f)) / 12f;
	}

	static public bool bReadyForWork()
	{
		return bHadBreakfast&&bMadeBed&&bAlarmOff;
	}
}
