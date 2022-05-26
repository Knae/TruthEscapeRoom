using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticVariables : MonoBehaviour
{
    [Header("Game Variables")]
    [SerializeField] static public int iDay = 1;
	[SerializeField] static public bool bHasBathed = false;
	[SerializeField] static public bool bHadBreakfast = false;


	private void Awake()
	{
        DontDestroyOnLoad(transform.gameObject);
	}

	public void NextDay()
	{
		bHasBathed = false;
		bHadBreakfast = false;
	}
}
