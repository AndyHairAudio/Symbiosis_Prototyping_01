using UnityEngine;
using System.Collections;

public class ObjectCollector : MonoBehaviour {

	public int fruitCollected = 0;
	public int fishCollected = 0;
	public GameObject treePrefab;
	public RaycastHit rayHitFruit;
	public RaycastHit rayHitPlant;
	public RaycastHit rayHitLake;
	bool rayHittingFruit;
	bool rayHittingTerrain;
	bool rayHittingLake;
	bool ableToFeedFish;
	bool ableToFish;
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
		AkSoundEngine.SetRTPCValue ("Eating_Fruit", 0.0f);
		AkSoundEngine.SetRTPCValue ("Planting_Trees", 0.0f);
		AkSoundEngine.SetRTPCValue ("Feeding_Fish", 0.0f);
		AkSoundEngine.SetRTPCValue ("Eating_Fish", 0.0f);
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
					fishCollected++;
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
	

	void OnGUI(){

		Texture2D mouseIcon = (Texture2D)Resources.Load("Mouse1ClickIcon", typeof(Texture2D));
		Texture2D fruitIcon = (Texture2D)Resources.Load("FruitIcon", typeof(Texture2D));
		Texture2D fishIcon = (Texture2D)Resources.Load ("fishcollected", typeof(Texture2D));
		Texture2D fishingIcon = (Texture2D)Resources.Load ("fishi-hi", typeof(Texture2D));
		Texture2D feedingIcon = (Texture2D)Resources.Load ("handWithSeeds", typeof(Texture2D));
		Texture2D plantingIcon = (Texture2D)Resources.Load ("treeAbstract", typeof(Texture2D));
		Texture2D controllerAIcon = (Texture2D)Resources.Load ("ControllerAButton", typeof(Texture2D));
		Texture2D controllerBIcon = (Texture2D)Resources.Load ("ControllerBButton", typeof(Texture2D));
		Texture2D controllerYIcon = (Texture2D)Resources.Load ("ControllerYButton", typeof(Texture2D));
		Texture2D controllerXIcon = (Texture2D)Resources.Load ("ControllerXButton", typeof(Texture2D));
		Texture2D controllerRBIcon = (Texture2D)Resources.Load ("ControllerRBButton", typeof(Texture2D));

		
		if(rayHittingFruit){
			GUI.DrawTexture(new Rect(Screen.width/10 * 5.5f, Screen.height/10 * 8.5f, 32, 32), controllerAIcon, ScaleMode.ScaleToFit, true, 1.0F);
		}

		if (rayHittingTerrain && ableToFeedFish != true){
			GUI.DrawTexture(new Rect(Screen.width/10 * 4.5f, Screen.height/10 * 7, 64, 64), plantingIcon, ScaleMode.ScaleToFit, true, 1.0F);
			GUI.DrawTexture(new Rect(Screen.width/10 * 4.5f, Screen.height/10 * 8.5f, 32, 32), controllerBIcon, ScaleMode.ScaleToFit, true, 1.0F);
		}

		if(ableToFish){
			GUI.DrawTexture(new Rect(Screen.width/10 * 3.5f, Screen.height/10 * 7, 64, 64), fishingIcon, ScaleMode.ScaleToFit, true, 1.0F);
			GUI.DrawTexture(new Rect(Screen.width/10 * 3.5f, Screen.height/10 * 8.5f, 32, 32), controllerAIcon, ScaleMode.ScaleToFit, true, 1.0F);
		}

		if(ableToFeedFish){
			GUI.DrawTexture(new Rect(Screen.width/10 * 2.5f, Screen.height/10 * 7, 64, 64), feedingIcon, ScaleMode.ScaleToFit, true, 1.0F);
			GUI.DrawTexture(new Rect(Screen.width/10 * 2.5f, Screen.height/10 * 8.5f, 32, 32), controllerRBIcon, ScaleMode.ScaleToFit, true, 1.0F);
		}

		if (fruitCollected >= 1) {
			GUI.DrawTexture(new Rect(Screen.width/10 * 0.5f, Screen.height/10 * 8.0f, 256/4, 256/4), fruitIcon, ScaleMode.ScaleToFit, true, 1.0F);
			GUI.DrawTexture(new Rect(Screen.width/10 * 0.5f, Screen.height/10 * 7.0f, 32, 32), controllerYIcon, ScaleMode.ScaleToFit, true, 1.0F);
			if(fruitCollected >= 2){
				GUI.DrawTexture(new Rect(Screen.width/10 * 1.0f, Screen.height/10 * 8.0f, 256/4, 256/4), fruitIcon, ScaleMode.ScaleToFit, true, 1.0F);
				if(fruitCollected == 3){
					GUI.DrawTexture(new Rect(Screen.width/10 * 1.5f, Screen.height/10 * 8.0f, 256/4, 256/4), fruitIcon, ScaleMode.ScaleToFit, true, 1.0F);
				}
			}
		}

		if (fishCollected > 0) {
			GUI.DrawTexture (new Rect (Screen.width / 10 * 9.0f, Screen.height / 10 * 8.0f, 64, 64), fishIcon, ScaleMode.ScaleToFit, true, 1.0F);
			GUI.DrawTexture(new Rect(Screen.width/10 * 9.0f, Screen.height/10 * 7.5f, 32, 32), controllerXIcon, ScaleMode.ScaleToFit, true, 1.0F);
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
