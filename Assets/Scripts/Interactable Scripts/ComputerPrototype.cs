using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerPrototype : Interactable
{

	[SerializeField] GameObject ComputerLight;

	public override void Interaction()
	{
		//base.Interaction();
		if (StaticVariables.bComputerOn)
		{
			//Debug.Log("Player made and ate on day " + StaticVariables.iDay);
			StaticVariables.bComputerOn = true;
			HidePrompt();
			ComputerLight.SetActive(true);
		}
		

	}

	public override void DisplayEPrompt()
	{
		if (StaticVariables.bComputerOn)
		{
			base.DisplayEPrompt();
		}
		else
		{
			Debug.Log("Already used computer");
		}
	}
}
