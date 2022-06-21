using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class RoomDoorPrototype : Interactable
{
	private bool soundPlayed = false;
	public override void Interaction()
	{
        //base.Interaction();
		if(StaticVariables.bReadyForWork())
		{
			if (soundPlayed == false)
            {
				SoundManager.instance.Sound.PlayOneShot(SoundManager.instance.Door);
				soundPlayed = true;
			}
			Debug.Log("Moving to next scene");
			SceneManager.LoadScene("HallwayPrototypeScene",LoadSceneMode.Single);
		}
		else
		{
			Debug.Log("Still not ready for work");
		}

	}
}
