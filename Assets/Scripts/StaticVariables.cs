using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // For accessing UI

public class StaticVariables : MonoBehaviour
{
    [Header("Game Variables")]
    [SerializeField] static public int iDay = 1;
	[SerializeField] static public bool bHasBathed = false;
	[SerializeField] static public bool bHadBreakfast = false;
	[SerializeField] static public bool bMadeBed = false;
	[SerializeField] static public bool bAlarmOff = false;
	[SerializeField] static public bool bComputerOn = false;

	private void Start()
	{
        DontDestroyOnLoad(transform.gameObject);
	}

	static public void NextDay()
	{
		bHadBreakfast = false;
		bMadeBed = false;
		bAlarmOff = false;
		iDay++;
	}

	static public bool bReadyForWork()
	{
		return bHadBreakfast&&bMadeBed&&bAlarmOff;
	}
}
