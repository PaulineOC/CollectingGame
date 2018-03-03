using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class STATICWalkingScene {
	private static bool isFading;                          // Flag used to determine if the Image is currently fading to or from black.



	public static bool firstLoaded;
	public static List<creature> spawnCreatures;

	//Timer information
	public static int seconds; 


	//Add 1 if in start , add 2 if in awake --> if even then awake is called multiple times when switching
	public static int testNum;

	//private static SceneController test;


	public static GameObject thisCreature;


	public static void walkingToBattleSceneChange(GameObject creature){

		Debug.Log ("walking scene STATIC");

		firstLoaded = false;


		//First Method: Load scene SINGLY --> therefore won't save 
//		Debug.Log(SceneManager.GetSceneByName("Battle").name);
//		//SceneManager.MoveGameObjectToScene(creature, );
//
//		SceneManager.LoadSceneAsync ("Battle", LoadSceneMode.Single);

//\
//		//Need to work additively - test 1
	
//		Scene oldScene = SceneManager.GetActiveScene ();		
//		Debug.Log("here is current scene " +SceneManager.GetActiveScene().name);
//
//		SceneManager.LoadScene ("Battle", LoadSceneMode.Additive);
//
//		Scene newScene  = SceneManager.GetSceneAt (SceneManager.sceneCount - 1);
//		SceneManager.SetActiveScene (newScene);
//		Debug.Log (newScene.name);
//		//SceneManager.SetActiveScene ();
//
//		SceneManager.UnloadScene("WalkingScene");
//				Debug.Log("DONE");

//
		//test 2
//		if(SceneManager.LoadSceneAsync("Battle", LoadSceneMode.Additive).isDone){
//			var scene = SceneManager.GetSceneByName("Battle");
//			SceneManager.SetActiveScene(scene);
//		}
//

		//test 3
		thisCreature=creature;


		if(SceneManager.LoadSceneAsync("Battle", LoadSceneMode.Single).isDone){
//			var scene = SceneManager.GetSceneByName("Battle");
//			SceneManager.SetActiveScene(scene);
			Debug.Log (thisCreature.name);
			Debug.Log (creature.name);


			//GameObject.Instantiate (creature,new Vector3(-4.0f,1.0f),Quaternion.identity);


		}




		//var loading = SceneManager.LoadSceneAsync("Battle", LoadSceneMode.Additive);
		//yield return loading;




//		if(SceneManager.LoadSceneAsync ("Battle", LoadSceneMode.Additive).isDone){
//			Debug.Log ("Successfully Loaded NEW scene");
//			Debug.Log (SceneManager.sceneCount);
//			Scene newScene  = SceneManager.GetSceneAt (SceneManager.sceneCount - 1);
//			Debug.Log (newScene.name);
//			//SceneManager.MoveGameObjectToScene(creature, newScene);
//
//
//			SceneManager.UnloadSceneAsync(){
//
//
//			}
//		};

			

		// Find the scene that was most recently loaded (the one at the last index of the loaded scenes).


//		Scene newlyLoadedScene = SceneManager.GetSceneAt (SceneManager.sceneCount - 1);
//		Debug.Log (newlyLoadedScene.name);
//		Debug.Log (newlyLoadedScene.buildIndex);
//
//		Scene oldScene = SceneManager.GetSceneAt (0);
//		SceneManager.UnloadSceneAsync (oldScene.name);

		// Set the newly loaded scene as the active scene (this marks it as the one to be unloaded next).
		//SceneManager.SetActiveScene (newlyLoadedScene);


//	
//		if(SceneManager.LoadSceneAsync ("Battle", LoadSceneMode.Additive).isDone){
//			Debug.
//
//		}

		//SceneManager.LoadSceneAsync (battle.name, LoadSceneMode.Single);

//

		//Debug.Log("moving fish");
		//SceneManager.MoveGameObjectToScene (creature,battle);

		//SceneManager.UnloadSceneAsync (SceneManager.GetActiveScene().buildIndex);
		//SceneManager.SetActiveScene (battle);



	}


//	private static IEnumerator Start ()
//	{
//
//		Debug.Log ("entry point in start");
//		// Set the initial alpha to start off with a black screen.
//		faderCanvasGroup.alpha = 1f;
//
//		// Write the initial starting position to the playerSaveData so it can be loaded by the player when the first scene is loaded.
//		playerSaveData.Save (PlayerMovement.startingPositionKey, initialStartingPositionName);
//
//
//		// Start the first scene loading and wait for it to finish.
//		yield return StartCoroutine (LoadSceneAndSetActive (startingSceneName));
//
//
//		//start calls load scene and set active
//
//		// Once the scene is finished loading, start fading in.
//		StartCoroutine (Fade (0f));
//	}
//
//


//	private static IEnumerator LoadSceneAndSetActive (string sceneName)
//	{
//		Debug.Log ("In load Scene and Set Active");
//		// Allow the given scene to load over several frames and add it to the already loaded scenes (just the Persistent scene at this point).
//		yield return hi.LoadSceneAsync (sceneName, LoadSceneMode.Additive);
//
////		// Find the scene that was most recently loaded (the one at the last index of the loaded scenes).
////		Scene newlyLoadedScene = hi.GetSceneAt (hi.sceneCount - 1);
////
//		// Set the newly loaded scene as the active scene (this marks it as the one to be unloaded next).
//		SceneManager.SetActiveScene (newlyLoadedScene);
//	}
//

}
