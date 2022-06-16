using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class RoomDoorPrototype : Interactable
{
	public override void Interaction()
	{
        //base.Interaction();
		if(StaticVariables.bReadyForWork())
		{
			Debug.Log("Moving to next scene");
			SceneManager.LoadScene("HallwayPrototypeScene",LoadSceneMode.Single);
		}
		else
		{
			Debug.Log("Still not ready for work");
		}

	}
}
