using UnityEngine;
using System.Collections;

public class ObjectCollector : MonoBehaviour {

	public int fruitCollected = 0;
	public GameObject treePrefab;
	public RaycastHit rayHit;
	public RaycastHit rayHitPlant;
	bool rayHittingFruit;
	bool rayHittingTerrain;
	public float playerHealth = 100.0f;

	void Awake (){
		StartCoroutine (HealthDecay (0.01f));
	}

	void Update (){

		if (playerHealth > 100) {
			playerHealth = 100;
		}
		
		if (playerHealth < 0) {
			playerHealth = 0;
		}

		if (fruitCollected > 3) {
			fruitCollected = 3;
		}
		
		if (fruitCollected < 0) {
			fruitCollected = 0;
		}

		if(playerHealth >= 80.0f && playerHealth < 100.0f){
			AkSoundEngine.SetState("Player_Health", "Healthy");
		}
		if(playerHealth >= 60.0f && playerHealth < 80.0f){
			AkSoundEngine.SetState("Player_Health", "Lively");
		}
		if(playerHealth >= 40.0f && playerHealth < 60.0f){
			AkSoundEngine.SetState("Player_Health", "Weak");
		}
		if(playerHealth >= 20.0f && playerHealth < 40.0f){
			AkSoundEngine.SetState("Player_Health", "Wounded");
		}
		if(playerHealth > 0.0f && playerHealth < 20.0f){
			AkSoundEngine.SetState("Player_Health", "Dying");
		}
		if(playerHealth == 0.0f){
			AkSoundEngine.SetState("Player_Health", "Dead");
		}

		Ray cameraRay = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
		if(Physics.Raycast(cameraRay, out rayHit, 5.0f)){
			if(rayHit.collider.tag == "TreeFruit"){
				rayHittingFruit = true;
			}
			else {
				rayHittingFruit = false;
			}
			if(Input.GetButton ("Fire1") && fruitCollected < 3 && rayHittingFruit) {
				rayHit.collider.gameObject.SetActive(false);
				fruitCollected++;
			}
		}

		Ray cameraRayPlant = Camera.main.ViewportPointToRay (new Vector3 (0.5f, 0.5f, 0f));
		
		if (Physics.Raycast (cameraRayPlant, out rayHitPlant, 10.0f)) {
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

		if (Input.GetButtonDown ("Eat")) {
			if (fruitCollected > 0) {
				playerHealth = playerHealth + 25;
				fruitCollected = fruitCollected - 1;
			}
		}
	}

	void OnGUI(){

		Texture2D mouseIcon = (Texture2D)Resources.Load("Mouse1ClickIcon", typeof(Texture2D));
		Texture2D fruitIcon = (Texture2D)Resources.Load("appleicon", typeof(Texture2D));
		
		if(rayHittingFruit){
			GUI.DrawTexture(new Rect(Screen.width/10 * 4.5f, Screen.height/10 * 7, 64, 64), mouseIcon, ScaleMode.ScaleToFit, true, 1.0F);
		}
		
		if (rayHittingTerrain){
			GUI.DrawTexture(new Rect(Screen.width/10 * 4.5f, Screen.height/10 * 7, 64, 64), mouseIcon, ScaleMode.ScaleToFit, true, 1.0F);
		}

		if (fruitCollected >= 1) {
			GUI.DrawTexture(new Rect(Screen.width/10 * 0.5f, Screen.height/10 * 8.5f, 32, 32), fruitIcon, ScaleMode.ScaleToFit, true, 1.0F);
			if(fruitCollected >= 2){
				GUI.DrawTexture(new Rect(Screen.width/10 * 0.75f, Screen.height/10 * 8.5f, 32, 32), fruitIcon, ScaleMode.ScaleToFit, true, 1.0F);
				if(fruitCollected == 3){
					GUI.DrawTexture(new Rect(Screen.width/10 * 1.0f, Screen.height/10 * 8.5f, 32, 32), fruitIcon, ScaleMode.ScaleToFit, true, 1.0F);
				}
			}
		}
	}

	IEnumerator HealthDecay (float decayTimer){
		
		while (true) {
			yield return new WaitForSeconds (decayTimer);
			playerHealth = playerHealth - 0.01f;
		}
	}
}
