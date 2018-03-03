using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void buttonPress(){
		Debug.Log ("HI");
		STATICWalkingScene.firstLoaded = true; 
		Debug.Log (STATICWalkingScene.firstLoaded);
		Application.LoadLevel("WalkingScene"); 

	
	
	}
}
