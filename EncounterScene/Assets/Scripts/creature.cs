using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creature : MonoBehaviour {
	public GameObject sceneControl;

	public bool spawned;
	public int num = 0;

	public string typeofday;


	//Creature Info: 

	public creature(int num){
		this.num = num;
		this.spawned = false;
	}

//	public creature(int number, GameObject sceneCtrl, GameObject prefab ){
//		this.sceneControl = sceneCtrl;
//		this.num = number;
//		spawned = false;
//
//	}
//
//	public void createThisObject(){
//		Instantiate (this.gameObject,new Vector3(-4.0f,-2.0f),Quaternion.identity);
//		this.thisCreature = me;
//
//	}
	// Use this for initialization
	void Start () {
		

	}
	
	// Update is called once per frame
	void Update () {
		
		
	}




	void OnMouseDown(){
		Debug.Log ("Mouse down");
		Debug.Log (sceneControl.gameObject.name);

		//this refers to the game object 
		//need to connect it to the creature class
		DontDestroyOnLoad(transform.gameObject);
		sceneControl.GetComponent<walkingSceneController>().triggeredCreature(this.gameObject);
	}





}
