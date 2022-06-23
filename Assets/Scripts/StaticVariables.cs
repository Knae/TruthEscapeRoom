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
	[SerializeField] static public int iNeighbourInteractions = 0; // Number of times player has interacted with neighbour (door)
	[SerializeField] static public bool bNeighbourInteractionComplete = false; // Flip this to true to make the neighbour interaction complete for that day
	[SerializeField] static public bool bInteractingWithNeighbour = false; // If true, stops player movement
	[SerializeField] static public bool bInteractingWithObject = false; // If true, stops player movement
	[SerializeField] static public bool bNeighbourInteractPlayerFrontDoor = false; // If true, then neighbour interacts with player front door
	[SerializeField] static public bool bRoomEventExecuted = false;

	[Header("Time Variables")]
	[SerializeField] static public float beginningHour = 7.0f;
	[SerializeField] static public float beginningMinute = 15.0f;
	[SerializeField] static public float hourForWork = 8.0f;
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

		Debug.Log("Day: " + iDay); // Show in debug
	}

    static public void NextDay()
	{
		bHadBreakfast = false;
		bMadeBed = false;
		bAlarmOff = false;
		iDay++;
		bNeighbourInteractionComplete = false;
		bRoomEventExecuted = false;
	}

	static public bool bReadyForWork()
	{
		return bHadBreakfast&&bMadeBed&&bAlarmOff;
	}

	static public void ResetClock()
    {
		// Reset Day start time on new day
		day = (beginningHour + (beginningMinute / 60f)) / 12f;
	}
}
