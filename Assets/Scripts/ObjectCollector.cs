using UnityEngine;
using System.Collections;

public class ObjectCollector : MonoBehaviour {

	public int fruitCollected = 0;
	public int fishCollected = 0;
	public GameObject treePrefab;
	RaycastHit rayHitFruit;
	RaycastHit rayHitPlant;
	RaycastHit rayHitLake;
	public bool rayHittingFruit;
	public bool rayHittingTerrain;
	public bool rayHittingLake;
	public bool ableToFeedFish;
	public bool ableToFish;
	public bool playerFishing;
	public float playerHealth = 100.0f;
	public bool treeDiscovered = false;
	public float healthDecayRate = 0.1f;
	public bool fishFedThisFrame = false;

	void Awake (){
		StartCoroutine (HealthDecay (0.01f));
	}

	void Start(){
		AkSoundEngine.SetState ("Player_Events", "Entered_World");
		AkSoundEngine.PostTrigger ("Entered_World", this.gameObject);
	}

	void Update (){
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

		if (Time.time >= 59.5f && Time.time <= 60.5f) {
						healthDecayRate = 0.5f;
			AkSoundEngine.SetState ("Player_Events", "Wandering");
				} else if (Time.time >= 119.5f && Time.time <= 120.5f) {
						healthDecayRate = 1.0f;
			AkSoundEngine.SetState ("Player_Events", "Collecting");
				} else if (Time.time >= 179.5f && Time.time <= 180.5f) {
						healthDecayRate = 2.0f;
				} else if (Time.time >= 239.5f && Time.time <= 240.5f) {
						healthDecayRate = 4.0f;
				} else if (Time.time >= 299.5f && Time.time <= 300.5f) {
						healthDecayRate = 8.0f;
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
				fruitCollected++;
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
					gameObject.AddComponent<FishingController>();
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
				if(Input.GetButtonDown ("Fire2") && fruitCollected > 0 && rayHittingTerrain){
					Instantiate (treePrefab, rayHitPlant.point, Quaternion.Euler (0, Random.Range (0, 360), 0));
					fruitCollected--;
				}
			}
		}

		if (Input.GetButtonDown ("Eat") && fruitCollected > 0) {
			playerHealth = playerHealth + 25;
			AkSoundEngine.PostEvent ("Play_Eat_Fruit", this.gameObject);
			fruitCollected = fruitCollected - 1;
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
			AkSoundEngine.PostTrigger ("Discovered_Tree", this.gameObject);
			treeDiscovered = true;
		}

		if (other.collider.tag == "ForestWorldZone") {

			AkSoundEngine.SetSwitch ("Player_Forest_Zone", "Forest_Floor", this.gameObject);
		} else if (other.collider.tag == "LakeWorldZone") {

			AkSoundEngine.SetSwitch ("Player_Forest_Zone", "Lakeside", this.gameObject);
		}
	}
}
