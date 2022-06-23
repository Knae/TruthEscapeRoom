using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventTrigger : MonoBehaviour
{
	[Header("Connected Objects")]
	[SerializeField] public DialogueFileReader DialogueObject;

	private void Awake()
	{
		if (DialogueObject == null)
		{
			DialogueObject = GameObject.Find("NeighbourSoundsDialogue").GetComponent<DialogueFileReader>();
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.tag == "Player" && !StaticVariables.bRoomEventExecuted)
		{

            Debug.Log("It is Day " + StaticVariables.iDay);
			StaticVariables.bRoomEventExecuted = true;
			ProcessEvent();
		}
	}

	private void ProcessEvent()
	{
		DialogueObject.SetNeighbourNextDoorSoundsStart();
	}
}
