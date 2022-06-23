using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventTrigger : MonoBehaviour
{
	[Header("Connected Objects")]
	[SerializeField] public GameObject DialogueObject;

	private Text DialogueText;

	private void Awake()
	{
		//if(DialogueObject.GetComponentInChildren<Text>() != null)
		//{
		//	DialogueText = DialogueObject.GetComponentInChildren<Text>();
		//}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.tag == "Player" && !StaticVariables.bRoomEventExecuted)
		{

            Debug.Log("It is Day " + StaticVariables.iDay);
			StaticVariables.bRoomEventExecuted = true;
			//();
		}
	}

	private void ProcessEvent()
	{
		if(StaticVariables.iDay == 2)
		{
			//StartCoroutine(DisplayText("...CRASH....."));
		}
		if(StaticVariables.iDay ==3 )
		{
			//StartCoroutine(DisplayText("sob...sob...."));
		}
	}

	IEnumerator DisplayText(string _inText)
	{
		//DialogueObject.SetActive(true);
		//DialogueText.text = _inText;
		yield return new WaitForSecondsRealtime(2.5f);

		//DialogueObject.SetActive(false);
	}
}
