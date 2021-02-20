using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
	public Text speakerName; // a reference to the text field in the dialog panel
	public Text convoContent; // ditto to other field
	public GameObject dialogPanel; // reference to the whole panel

	private Queue<string> sentences;

	public AudioClip collectedClip;
	public GhostController controller;

	// Use this for initialization
	void Start()
	{
		sentences = new Queue<string>();
	}

	public void StartDialog(Dialog dialog)
	{  //method called at start of a conversation
		Debug.Log("talk to " + dialog.name); // check to make sure this works
		speakerName.text = dialog.name;

		// first need to clear out any previous conversation that might linger in sentences array
		sentences.Clear();

		// then loop through the array and line up each sentence currently in it to prepare 
		foreach (string sentence in dialog.sentences)
		{

			sentences.Enqueue(sentence); // put each in the queue
		}
		// then call a method to actually display it

		DisplayNextSentence();
	}

	public void DisplayNextSentence()
	{

		// first check to see if we are at the end of convo and if so call end method

		if (sentences.Count == 0)
		{ // if array is empty

			EndConvo(); // call end method
			controller.PlaySound(collectedClip);
			return;     // leave the function
		}
		string sentence = sentences.Dequeue();  // otherwise pull sentence out of the queue
		convoContent.text = sentence;
		controller.PlaySound(collectedClip);
		//Debug.Log ("line is" + sentence); // display it

	}

	public void EndConvo()
	{
		Debug.Log("reached end of convo");
		dialogPanel.SetActive(false);

	}
}
