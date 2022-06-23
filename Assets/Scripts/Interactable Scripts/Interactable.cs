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
	[SerializeField] private GameObject prefabPrompt;
	private GameObject Prompt;
	private Vector2 v2Size;
	private Vector3 v3Pos;  //Position of E Prompt when created
	private bool bDisplayedPrompt = false;

	// Start is called before the first frame update
	void Start()
	{
		//If this object is tagged as interactable, then calculate its size
		//and the position where the prompt should appear
		if(gameObject.tag == "Interactable")
		{
			BoxCollider2D collider = this.GetComponent<BoxCollider2D>();
			if(collider != null)
			{
				v2Size = collider.size;
				v3Pos = collider.transform.position;
			}
			else
			{
				Debug.Log("ERROR:Interactable named \"" + this.name + "has no collision.");
			}

			//Move position of EPrompt to be above the object
			//v3Pos.y += (v2Size.y / 2) + 0.2f;
		}	 
	}

	/// <summary>
	/// This should contain whatever actions or events to be executed when
	/// player interacts with object containing this script
	/// </summary>
	public virtual void Interaction()
	{
		Debug.Log("ERROR:Called parent interaction function. Object may not have a reaction to player.");
	}

	/// <summary>
	/// Instantiate(create) the prompt prefab at the previously
	/// calculated position
	/// </summary>
	public virtual void DisplayEPrompt()
	{
		Debug.Log("Press 'E'");

		Prompt = Instantiate(prefabPrompt);
		Prompt.transform.position = v3Pos;
		bDisplayedPrompt = true;
	}

	/// <summary>
	/// Destroy the previously instantiated
	/// </summary>
	public virtual void HidePrompt()
	{
		Debug.Log("Dont' Press 'E'");
		Destroy(Prompt);
		Prompt = null;
		bDisplayedPrompt = false;
	}

	public bool GetIfPromptDisplayed()
	{
		return bDisplayedPrompt;
	}
}
