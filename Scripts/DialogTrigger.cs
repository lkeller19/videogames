using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
	public Dialog dialog;  // allows us to access the Dialog class
	// this creates an instance of the dialog class for an individual character

	public void TriggerDialog()
	{

		FindObjectOfType<DialogManager>().StartDialog(dialog);

		//we then locate the Dialog Manager game object and call a function inside of
		// it with the instance of dialog attached to a specific game object

	}
}
