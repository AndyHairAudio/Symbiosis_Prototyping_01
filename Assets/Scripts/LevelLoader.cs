using UnityEngine;
using System.Collections;

public class LevelLoader : MonoBehaviour {

	public Texture2D fadeOverlay;
	public float fadeSpeed = 0.8f;
	public bool playerDead = false;

	private int drawDepth = 1000;
	private float alpha = 1.0f;
	private int fadeDirection = -1;

	bool levelLoading;

	public float timeOfLastInput = 120.0f;

	void Start(){
		if (Application.loadedLevelName == "TreeScene") {
			StartCoroutine (GameOverScreen (1.0f));
		}
	}

	void OnGUI(){

		Screen.showCursor = false;

		alpha += fadeDirection * fadeSpeed * Time.deltaTime;

		alpha = Mathf.Clamp01 (alpha);

		GUI.color = new Color (GUI.color.r, GUI.color.g, GUI.color.b, alpha);

		GUI.depth = drawDepth;

		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), fadeOverlay);

	}

	public float beginFade (int Direction){

		fadeDirection = Direction;

		return (fadeSpeed);

	}

	void OnLevelWasLoaded(){

		beginFade (-1);
	}
	
	// Update is called once per frame
	void Update () {
		if (Application.loadedLevelName == "MenuScene") {
			if (Input.GetButtonDown ("Fire1") || Input.GetButtonDown("Submit")) {
				if (!levelLoading) {
					levelLoading = true;
					StartCoroutine ("fadeoutTimer");
				}
			}
		}

		if (Input.anyKeyDown) {
			print ("press detected");
			timeOfLastInput = Time.time;
		}

		if ((timeOfLastInput + 120.0f) < Time.timeSinceLevelLoad && Application.loadedLevelName == "TreeScene"){
			StartCoroutine ("fadeoutTimer");
		}

		if (Input.GetButtonDown ("Back") && Application.loadedLevelName == "TreeScene") {
			StartCoroutine ("fadeoutTimer");
		}

		if (playerDead) {
			StartCoroutine ("fadeoutTimer");
		}
		
	}

	IEnumerator fadeoutTimer (){

		beginFade (1);

		AkSoundEngine.SetState ("Player_Events", "None");
		//AkSoundEngine.PostEvent ("Stop_All", this.gameObject);

		yield return new WaitForSeconds (1.0f);

		if (Application.loadedLevelName == "MenuScene"){
			Application.LoadLevel ("TreeScene");
		}
		else if (Application.loadedLevelName == "TreeScene"){
			Application.LoadLevel ("MenuScene");
		}
	}

	IEnumerator GameOverScreen (float overTimer){

		while (true) {
			yield return new WaitForSeconds (overTimer);
			
			GameObject player = GameObject.FindGameObjectWithTag ("Player");
			ObjectCollector controller = player.GetComponent<ObjectCollector> ();
			
			if (controller.playerHealth <= 0) {
				playerDead = true;
			}
		}
	}
}
