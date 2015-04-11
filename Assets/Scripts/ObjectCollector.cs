﻿using UnityEngine;
using System.Collections;

public class ObjectCollector : MonoBehaviour {

	public int fruitCollected = 0;
	public int uniqueFruitCollected = 0;
	public int fishCollected = 0;
	public GameObject treePrefab;
	RaycastHit rayHitFruit;
	RaycastHit rayHitUniqueFruit;
	public RaycastHit rayHitPlant;
	RaycastHit rayHitLake;
	public bool rayHittingFruit;
	public bool rayHittingTerrain;
	public bool rayHittingUniqueTerrain;
	public bool rayHittingLake;
	public bool ableToFeedFish;
	public bool ableToFish;
	public bool playerFishing;
	public bool playerPlanting;
	public float playerHealth = 100.0f;
	public bool treeDiscovered = false;
	public float healthDecayRate = 0.1f;
	public bool fishFedThisFrame = false;
	public float timeOfLastFeed;
	public int playerScore = 0;
	GameObject[] fishObjs;
	public bool rayHittingUniqueFruit;

	void Awake (){
		StartCoroutine (HealthDecay (0.01f));
	}

	void Start(){
		AkSoundEngine.SetState ("Player_Events", "Empty");
		AkSoundEngine.PostTrigger ("Entered_World", GameObject.FindGameObjectWithTag ("WwiseGlobal"));
	}

	void Update (){
		fishFedThisFrame = false;

		if (playerHealth > 100) {
			playerHealth = 100;
		}
		
		if (playerHealth < 0) {
			playerHealth = 0;
			Debug.Log ("Game is actually over");
		}

		if (fruitCollected > 3) {
			fruitCollected = 3;
		}
		
		if (fruitCollected < 0) {
			fruitCollected = 0;
		}

		if (uniqueFruitCollected > 3) {
			uniqueFruitCollected = 3;
		}
		
		if (uniqueFruitCollected < 0) {
			uniqueFruitCollected = 0;
		}

		if (Time.time >= 179.5f && Time.time <= 180.5f) {
			AkSoundEngine.SetState ("Player_Events", "Entered_World");
			healthDecayRate = 0.25f;
		} 
		else if (Time.time >= 359.5f && Time.time <= 360.5f) {
			AkSoundEngine.SetState ("Player_Events", "Wandering");
			healthDecayRate = 0.5f;
		}
		else if (Time.time >= 539.5f && Time.time <= 540.5f) {
			AkSoundEngine.SetState ("Player_Events", "Collecting");
			healthDecayRate = 0.75f;
		} 
		else if (Time.time >= 719.5f && Time.time <= 720.5f) {
			healthDecayRate = 1.0f;
		}

		Ray cameraRay = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
		if(Physics.Raycast(cameraRay, out rayHitFruit, 5.0f)){
			if(rayHitFruit.collider.tag == "TreeFruit"){
				rayHittingFruit = true;
			}
			else {
				rayHittingFruit = false;
			}
			if(Input.GetButton ("Fire1") && fruitCollected < 3 && rayHittingFruit) {
				rayHitFruit.collider.gameObject.SetActive(false);
				AkSoundEngine.PostEvent("Play_Collect_Fruit", this.gameObject);
				fruitCollected++;
			}
		}

		Ray cameraUniqueRay = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
		if(Physics.Raycast(cameraUniqueRay, out rayHitUniqueFruit, 5.0f)){
			if(rayHitUniqueFruit.collider.tag == "UniqueTreeFruit"){
				rayHittingUniqueFruit = true;
			}
			else {
				rayHittingUniqueFruit = false;
			}
			if(Input.GetButton ("Fire1") && uniqueFruitCollected < 3 && rayHittingUniqueFruit) {
				rayHitUniqueFruit.collider.gameObject.SetActive(false);
				AkSoundEngine.PostEvent("Play_Collect_Fruit", this.gameObject);
				uniqueFruitCollected++;
			}
		}

		Ray cameraLakeRay = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
		if (Physics.Raycast (cameraLakeRay, out rayHitLake, 10.0f)) {
			if (rayHitLake.collider.tag == "Lakewater") {
				rayHittingLake = true;
			} else {
				rayHittingLake = false;
			}
			CharacterController controllerFinder = this.GetComponent<CharacterController> ();
			if (fishCollected < 1 && rayHittingLake) {
				ableToFish = true;
				if (Input.GetButtonDown ("Fire1") && controllerFinder.velocity.x == 0 && controllerFinder.velocity.y == 0 && controllerFinder.velocity.z == 0) {
					fishObjs = GameObject.FindGameObjectsWithTag("Fish");
					if(fishObjs.Length == 0){
						print ("no fish left to fish!");
					}
					else if(gameObject.GetComponent<FishingController>() == null){
						playerFishing = true;
					   gameObject.AddComponent<FishingController>();
					}
				}
			} else {
				ableToFish = false;
			}
			if (fruitCollected > 0 && rayHittingLake) {
				ableToFeedFish = true;
				if (Input.GetButtonDown ("Feed")) {
					Debug.Log ("feeding fish");
					fruitCollected--;
					fishFedThisFrame = true;
					timeOfLastFeed = Time.time;
					playerScore = playerScore + 30;
				}
			} else {
				ableToFeedFish = false;
			}
		}

		Ray cameraRayPlant = Camera.main.ViewportPointToRay (new Vector3 (0.5f, 0.5f, 0f));
		if (Physics.Raycast (cameraRayPlant, out rayHitPlant, 5.0f)) {
			if (rayHitPlant.collider.tag == "ForestTerrain") {
				if(fruitCollected > 0){
					rayHittingTerrain = true;
				}
				else {
					rayHittingTerrain = false;
				}

				if(uniqueFruitCollected > 0){
					rayHittingUniqueTerrain = true;
				}
				else {
					rayHittingUniqueTerrain = false;
				}
				
				if(Input.GetButtonDown ("Fire2") && fruitCollected > 0 && rayHittingTerrain){
					if(gameObject.GetComponent<PlantingController>() == null && gameObject.GetComponent<PlantingUniqueController>() == null){
						gameObject.AddComponent<PlantingController>();
						playerPlanting = true;
					}
				}

				if(Input.GetButtonDown ("Plant Special") && uniqueFruitCollected > 0 && rayHittingUniqueTerrain){
					if(gameObject.GetComponent<PlantingUniqueController>() == null && gameObject.GetComponent<PlantingController>() == null){
						gameObject.AddComponent<PlantingUniqueController>();
						playerPlanting = true;
					}
				}
			}
			else {
				rayHittingTerrain = false;
				rayHittingUniqueTerrain = false;
			}
		}

		if (Input.GetButtonDown ("Eat") && fruitCollected > 0) {
			playerHealth = playerHealth + 25;
			AkSoundEngine.PostEvent ("Play_Eat_Fruit", this.gameObject);
			fruitCollected = fruitCollected - 1;
		}

		if (Input.GetButtonDown ("Eat Special") && uniqueFruitCollected > 0) {
			playerHealth = playerHealth + 100;
			AkSoundEngine.PostEvent ("Play_Eat_Fruit", this.gameObject);
			uniqueFruitCollected = uniqueFruitCollected - 1;
		}

		if (Input.GetButtonDown ("Fire3") && fishCollected > 0) {
			StartCoroutine (EatenFish());
			fishCollected--;
			AkSoundEngine.PostEvent ("Play_Eat_Fruit", this.gameObject);
		}
	}

	IEnumerator HealthDecay (float decayTimer){
		
		while (true) {
			yield return new WaitForSeconds (decayTimer);
			playerHealth = playerHealth - (0.01f * healthDecayRate);
			AkSoundEngine.SetRTPCValue("Player_Health", playerHealth);
		}
	}

	IEnumerator EatenFish (){
		float totalHealthAdded = 0.0f;
		while (totalHealthAdded < 30.0f){
			yield return new WaitForSeconds (1.0f);
			playerHealth = playerHealth + 1.0f;
			totalHealthAdded = totalHealthAdded + 1.0f;
		}
	}
	
	void OnTriggerEnter (Collider other){
		if (other.collider.tag == "Tree" && treeDiscovered == false) {
			AkSoundEngine.PostTrigger ("Discovered_Tree", GameObject.FindGameObjectWithTag("WwiseGlobal"));
			treeDiscovered = true;
		}

		if (other.collider.tag == "ForestWorldZone") {

			AkSoundEngine.SetSwitch ("Player_Forest_Zone", "Forest_Floor", this.gameObject);
		} else if (other.collider.tag == "LakeWorldZone") {

			AkSoundEngine.SetSwitch ("Player_Forest_Zone", "Lakeside", this.gameObject);
		}
	}
}
