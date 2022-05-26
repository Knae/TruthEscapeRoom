using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenPrototype : Interactable
{
	public override void Interaction()
	{
		//base.Interaction();
		if (!StaticVariables.bHadBreakfast)
		{
			Debug.Log("Player activated kitchen on day " + StaticVariables.iDay);
			StaticVariables.bHadBreakfast = true;
			HidePrompt();
		}
	}

	public override void DisplayEPrompt()
	{
		if (!StaticVariables.bHadBreakfast)
		{
			base.DisplayEPrompt();
		}
		else
		{
			Debug.Log("Already had breakfast");
		}
	}
}
