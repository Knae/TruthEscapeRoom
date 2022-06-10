using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedAlarm : Interactable
{
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
}
