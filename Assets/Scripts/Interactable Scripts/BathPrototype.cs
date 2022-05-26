using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BathPrototype : Interactable
{
	public override void Interaction()
	{
		//base.Interaction();
		if(!StaticVariables.bHasBathed)
		{
			Debug.Log("Player activated bath on day " + StaticVariables.iDay);
			StaticVariables.bHasBathed = true;
		}

	}

	public override void DisplayEPrompt()
	{
		if (!StaticVariables.bHasBathed)
		{
			base.DisplayEPrompt();
		}
		else
		{
			Debug.Log("Already bathed");
		}
	}
}
