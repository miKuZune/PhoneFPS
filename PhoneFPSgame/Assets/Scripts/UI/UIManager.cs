using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

	public GameObject movementJoystick;
	public GameObject turnJoyStick;
	public GameObject fireButton;

	// Use this for initialization
	void Start () {
		if (Application.isEditor) {
			HideAll ();	
			//if game = boring
			//inject code.fun
			//just fucking do it
		}
	}

	public void HideAll()
	{
		movementJoystick.SetActive (false);
		turnJoyStick.SetActive (false);
		fireButton.SetActive (false);
	}

}
