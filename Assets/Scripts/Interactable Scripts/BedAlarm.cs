using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedAlarm : Interactable
{
	[Header("AttachedObjects")]
	[SerializeField] GameObject objAlarmSfxPrefab;
	[Header("DebugVariables")]
	[SerializeField] private GameObject objAlarmSfx;
	[SerializeField] private float fCount = 0.0f;
	[SerializeField] private const float kfDisplayFXPeriod = 2.0f; 
	[SerializeField] private const float kfHideFXPeriod = 0.5f; 


	public override void Interaction()
	{
		//base.Interaction();
		StaticVariables.bAlarmOff = true;
		Debug.Log("Player turned off the alarm on day " + StaticVariables.iDay);
		HidePrompt();
	}

	public override void DisplayEPrompt()
	{
		if (!StaticVariables.bAlarmOff)
		{
			base.DisplayEPrompt();
		}
		else
		{
			Debug.Log("Alarm is already off");
		}
	}

	private void Update()
	{
		fCount -= Time.deltaTime;
		if ( fCount <= 0 && !StaticVariables.bAlarmOff)
		{
			if(objAlarmSfx == null)
			{
				objAlarmSfx = Instantiate(objAlarmSfxPrefab);
				objAlarmSfx.transform.position = transform.position;
				fCount = kfDisplayFXPeriod;
			}
			else
			{
				Destroy(objAlarmSfx);
				objAlarmSfx = null;
				fCount = kfHideFXPeriod;
			}
		}
		else if(objAlarmSfx!=null & StaticVariables.bAlarmOff)
		{
			Destroy(objAlarmSfx);
			objAlarmSfx = null;
			fCount = 0;
		}
	}
}
