using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Parent class for interactable objects.
/// All such objects must have the Interaction function which
/// should execute whatever actions or animations needed
/// </summary>
public class Interactable : MonoBehaviour
{
	public virtual void Interaction()
	{
		Debug.Log("ERROR:Called parent interaction function. Object may not have a reaction to player.");
	}

	public virtual void DisplayEPrompt()
	{
		Debug.Log("Press 'E'");
	}

	public virtual void HidePrompt()
	{
		Debug.Log("Dont' Press 'E'");
	}
}
