using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedPrototype : Interactable
{
	[Header("Bed Textures")]
	[SerializeField] GameObject Bed_Made;
	[SerializeField] GameObject Bed_NotMade;

	public override void Interaction()
	{
		//base.Interaction();
		StaticVariables.bMadeBed = true;
		if(Bed_Made != null && Bed_NotMade!=null)
		{
			Bed_Made.SetActive(true);
			Bed_NotMade.SetActive(false);
		}
		else
		{
			Debug.Log("Bed does not have appropriate textures assigned");
		}

		Debug.Log("Player made the bed on day " + StaticVariables.iDay);
		HidePrompt();
	}

	public override void DisplayEPrompt()
	{
		if ( !StaticVariables.bMadeBed && StaticVariables.bAlarmOff)
		{
			base.DisplayEPrompt();
		}
		else if(!StaticVariables.bAlarmOff)
		{
			Debug.Log("Alarm is still on");
		}
		else
		{
			Debug.Log("Bed is already made");
		}
	}
}
