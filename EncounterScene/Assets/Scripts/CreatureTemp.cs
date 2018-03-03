using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureTemp: MonoBehaviour {

	//General Info
	public string name; //randomly generated, later details
	public Animator spriteAnimator;
	public string species;
	public List<string> petActions;

	//Encounter Info --> just save name of item/creature/action
	public List<string> encounterActions; 
	public int affectionThreshhold;
	public int strikes;
	//Worth more "affection points" if correct action performed 
	public List<string> moreEffectivePets ;
	//Encounter - Items 
	public Dictionary<string, int> effectiveItems;
	public List<string> dislikedItems;
	public List<string> instantFleeItems;
	//Encounter: Player Actions 
	public Dictionary <string, int> effectivePlayerActions;
	public List<string> dislikedPlayerActions;
	public List<string> instantFleePlayerActions;
	//Encounter: pet actions
	public Dictionary <string, int> effectivePetActions = new Dictionary <string, int>();
	public List<string> dislikedPetActions = new List<string>();
	public List<string> instantFleePetActions = new List<string>();



	//Spawning Data <-- Ignore this!! 
	public List<string> environments = new List<string> ();
	public string timeOfDay; 
	public List<string> weatherConditions;
	public string rarity;
	public int playerThreshold;
	public List <string> instantFleePets = new List<string>();
	//For when multiple animals spawn on the screen and player choose other animal: 
	public string multipleAnimalSpawnActivity; 
	public List<string> repelledByEquippedItem = new List<string> ();
	public List<string> attractedByEquippedItem = new List<string> ();
	public List<string> repelledByEquippedPet = new List<string> ();
	public List<string> attractedByEquippedPet = new List<string> ();




	public CreatureTemp(string species, string petActions){
		this.species= species;
		this.petActions = parseLists (petActions);
	}

	public void setCreatureEncounterFields(string encounterActions, string affectionThreshhold,string strikes, string moreEffectivePets,
		string effectiveItems, string dislikedItems, string instantFleeItems, 
		string effectivePlayerActions, string dislikedPlayerActions, string instantFleePlayerActions, 
		string effectivePetActions, string dislikedPetActions, string instantFleePetActions){

		this.encounterActions = parseLists(encounterActions);
		this.affectionThreshhold = int.Parse(affectionThreshhold);
		this.strikes = int.Parse (strikes);
		this.moreEffectivePets = parseLists(moreEffectivePets);
		//Items
		this.effectiveItems = parseDictionary (effectiveItems);
		this.dislikedItems = parseLists (dislikedItems);
		this.instantFleeItems = parseLists (instantFleeItems);
		//Player Actions
		this.effectivePlayerActions = parseDictionary(effectivePlayerActions);
		this.dislikedPlayerActions = parseLists (dislikedPlayerActions);
		this.instantFleePlayerActions = parseLists (instantFleePlayerActions);
		//Pets Actions
		this.effectivePetActions = parseDictionary (effectivePetActions);
		this.dislikedPetActions = parseLists (dislikedPetActions);
		this.instantFleePetActions = parseLists (instantFleePetActions);

	}
	public void setCreatureSpawnFields(string environment,string timeDay, string weatherCondition, string rarity,string threshhold,string instantFleePetTypes,string ifMultipleAnimalsActivity,
		string repelledByEItem,string attractedByEItem,
		string repelledbyEPet,string attractedByEPet){
		this.environments = parseLists(environment);
		this.timeOfDay = timeDay;
		this.weatherConditions = parseLists(weatherCondition);
		this.rarity = rarity;
		this.playerThreshold = int.Parse(threshhold);
		this.instantFleePets = parseLists (instantFleePetTypes);
		this.multipleAnimalSpawnActivity = ifMultipleAnimalsActivity;
		this.repelledByEquippedItem = parseLists (repelledByEItem);
		this.attractedByEquippedItem = parseLists (attractedByEItem);
		this.repelledByEquippedPet = parseLists (repelledbyEPet);
		this.attractedByEquippedPet = parseLists (attractedByEPet);

	}



	//public parse through List
	public List<string> parseLists(string field){
		if(field.Length > 0){
			string[] splitField = field.Split ('#');
			List<string> toReturn = new List<string> ();
			foreach (string eachItem in splitField) {
				toReturn.Add(eachItem);
			}
			return toReturn;
		}
		else {
			return null;
		}
	}

	public Dictionary<string, int> parseDictionary(string field){
		if (field.Length > 0) {
			Dictionary<string, int> toReturn = new Dictionary<string, int> ();
			string[] splitfield = field.Split ('#');
			foreach (string thisString in splitfield) {
				string[] splitByOtherChar = thisString.Split ('$');
				toReturn.Add (splitByOtherChar [0], int.Parse(splitByOtherChar [1]));
			
			}
			Debug.Log (toReturn.ToString());
			return toReturn;
//			string[] splitBy@ = splitfield.
		} 
		else {
			return null;
		}
	}



}
