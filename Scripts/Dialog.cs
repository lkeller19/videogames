using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Dialog
{
	public string name;  // these will show up in the inspector when attached to a monodevelop script
	[TextArea(3, 10)]       // sets the size of text area in inspector
	public string[] sentences;  // can add as many sentences as desired

}
