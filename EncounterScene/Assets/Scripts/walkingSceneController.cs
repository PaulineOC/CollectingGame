using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class walkingSceneController : MonoBehaviour {


	public int correct;
	public GameObject reward;
	public GameObject prefabCreature;

	public GameObject creature;
	private bool isFading;


	public CanvasGroup faderCanvasGroup;            // The CanvasGroup that controls the Image used for fading to black.
	public float fadeDuration = 1f;                 


	//
	void Awake(){
		
		//Initialize the STATIC class's LISTS and variables
		STATICWalkingScene.spawnCreatures = new List<creature> ();
		STATICWalkingScene.testNum = 0;
		isFading = false;


	
//		//Timer information
//		STATICWalkingScene.seconds = 0;

//		Sprite[] allItems = Resources.LoadAll(name, typeof(Sprite)).Cast<Sprite>().ToArray();



	}


	// Use this for initialization
	void Start () {

		STATICWalkingScene.testNum += 1;

		if(STATICWalkingScene.firstLoaded==true){
			correct = 4;

			Debug.Log ("Start: generate characters to be spawned and save to STATIC class' lists ");
			//Loads the creatures as game objects
			STATICWalkingScene.spawnCreatures = randomCreatures (1);
			StartCoroutine (runTimer());
		}

	}
	
	// Update is called once per frame
	void Update () {
		//Coroutine for spawning animals on screen OR they all start off screen


		//Timer end
		if (STATICWalkingScene.seconds == 34) {
			StopCoroutine (runTimer ());
			STATICWalkingScene.seconds = 0;
			reward.GetComponent<SpriteRenderer> ().color = Color.blue;
			//Application.LoadLevel ();
		}
	}

	public List<creature> randomCreatures(int num){
		Debug.Log ("Spawn creatures to simulate preset list");
	
		List<creature> toSpawnAnimals = new List<creature>();
		for(int i=0;i<num;i++){
			creature toAdd = new creature (i);
			toSpawnAnimals.Add (toAdd);
		}
		Debug.Log (toSpawnAnimals.Count);
		return toSpawnAnimals;
	}

	public void spawnAnimal(){
		Debug.Log ("spawning creature");
		//Connect creature list to 

		int randomIndex = Random.Range(0,STATICWalkingScene.spawnCreatures.Count);
		creature spawnThis = STATICWalkingScene.spawnCreatures[randomIndex];
	
		//Actual CODE for Spawning Creature
		GameObject toSpawn= prefabCreature; 
		toSpawn.AddComponent<PolygonCollider2D> ();

		//Set fields for BATTLE information
		toSpawn.GetComponent<creature> ().spawned = true;
		toSpawn.GetComponent<creature> ().num = spawnThis.num;
		toSpawn.GetComponent<creature> ().sceneControl = this.gameObject;

		creature = toSpawn;

		//Need to spawn OFF SCREEN
		Instantiate (toSpawn,new Vector3(-4.0f,-2.0f),Quaternion.identity);
	}
		
	//Timer function for static class
	public IEnumerator runTimer(){
		while(true){
			//Debug.Log (STATICWalkingScene.seconds);
			yield return new WaitForSeconds (1);
			STATICWalkingScene.seconds++;


			if(STATICWalkingScene.seconds==10){
				Debug.Log ("spawning animal");
				spawnAnimal ();
			}
		}
	}
		
	public void triggeredCreature(GameObject creatureClick){
		Debug.Log ("walking scene triggered creature");
		if( creatureClick.GetComponent<creature>().spawned == true && STATICWalkingScene.firstLoaded ==true ){
			

			//UnityEngine.SceneManagement.SceneManager.MoveGameObjectToScene (creatureClick);


			reward.GetComponent<SpriteRenderer> ().color = Color.red;

			//Trying to do this from here? 

			//1. Save positions of all active items in scene
			//2. 
			StartCoroutine (FadeAndSwitchScenes ("Battle"));


			//STATICWalkingScene.walkingToBattleSceneChange (creatureClick);
//			SceneManager.LoadSceneAsync("Battle",LoadSceneMode.Single);


		}


		
	}



	// This is the coroutine where the 'building blocks' of the script are put together.
	private IEnumerator FadeAndSwitchScenes (string sceneName)
	{

		Debug.Log ("In fade and switch scenes");
		// Start fading to black and wait for it to finish before continuing.
		yield return StartCoroutine (Fade (1f));


		// Unload the current active scene.
		yield return SceneManager.UnloadSceneAsync (SceneManager.GetActiveScene ().buildIndex);

		// Start loading the given scene and wait for it to finish.
		yield return StartCoroutine (LoadSceneAndSetActive (sceneName));

		// Start fading back in and wait for it to finish before exiting the function.
		yield return StartCoroutine (Fade (0f));
	}

	private IEnumerator LoadSceneAndSetActive (string sceneName)
	{
		Debug.Log ("In load Scene and Set Active");
		// Allow the given scene to load over several frames and add it to the already loaded scenes (just the Persistent scene at this point).
		yield return SceneManager.LoadSceneAsync (sceneName, LoadSceneMode.Additive);

		// Find the scene that was most recently loaded (the one at the last index of the loaded scenes).
		Scene newlyLoadedScene = SceneManager.GetSceneAt (SceneManager.sceneCount - 1);

		yield return SceneManager.UnloadSceneAsync (SceneManager.GetSceneAt(0));

		// Set the newly loaded scene as the active scene (this marks it as the one to be unloaded next).
		SceneManager.SetActiveScene (newlyLoadedScene);

	}
		


	private IEnumerator Fade (float finalAlpha)
	{

		// Set the fading flag to true so the FadeAndSwitchScenes coroutine won't be called again.
		isFading = true;

		// Make sure the CanvasGroup blocks raycasts into the scene so no more input can be accepted.
		faderCanvasGroup.blocksRaycasts = true;

		// Calculate how fast the CanvasGroup should fade based on it's current alpha, it's final alpha and how long it has to change between the two.
		float fadeSpeed = Mathf.Abs (faderCanvasGroup.alpha - finalAlpha) / fadeDuration;

		// While the CanvasGroup hasn't reached the final alpha yet...
		while (!Mathf.Approximately (faderCanvasGroup.alpha, finalAlpha))
		{
			// ... move the alpha towards it's target alpha.
			faderCanvasGroup.alpha = Mathf.MoveTowards (faderCanvasGroup.alpha, finalAlpha,
				fadeSpeed * Time.deltaTime);

			// Wait for a frame then continue.
			yield return null;
		}

		// Set the flag to false since the fade has finished.
		isFading = false;

		// Stop the CanvasGroup from blocking raycasts so input is no longer ignored.
		faderCanvasGroup.blocksRaycasts = false;
	}


}
