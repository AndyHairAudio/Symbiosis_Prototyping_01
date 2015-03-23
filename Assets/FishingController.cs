using UnityEngine;
using System.Collections;

public class FishingController : MonoBehaviour {

	float timeOfInitiation;
	bool beatThisFrameRef = false;
	Texture2D controllerRBIcon = (Texture2D)Resources.Load ("ControllerRBButton", typeof(Texture2D));
	Texture2D controllerAIcon = (Texture2D)Resources.Load ("ControllerAButton", typeof(Texture2D));
	bool drawButtonIcon1 = false;
	bool drawButtonIcon2 = false;
	float drawTimerOne = 0.0f;
	float drawTimerTwo = 0.0f;
	float combo1PressTime;
	float sequenceBeginTime;

	// Use this for initialization
	void Awake () {
		timeOfInitiation = Time.time;
	}

	IEnumerator Start (){
		yield return new WaitForSeconds (2.0f);

		while (beatThisFrameRef == false) {
			yield return null;
		}
		sequenceBeginTime = Time.time;
		drawButtonIcon1 = true;

		yield return new WaitForSeconds (0.5f);

		while (beatThisFrameRef == false) {
			yield return null;
		}
		drawButtonIcon2 = true;
	}

	// Update is called once per frame
	void Update () {

		beatThisFrameRef = gameObject.GetComponent<MusicSync> ().beatThisFrame;

		if (Time.time - timeOfInitiation > 5.0f) {
			Destroy (this);
		}

		if (Input.GetButtonDown ("Combo1")) {
			combo1PressTime = Time.time;
			if((combo1PressTime - sequenceBeginTime) < 0.250f){
				print ("hitted it after " + (combo1PressTime - timeOfInitiation));
			}
		}
	}

	void OnGUI(){
		if (drawButtonIcon1 && drawTimerOne < 1.0f) {
			GUI.DrawTexture (new Rect (Screen.width / 2, Screen.height / 2, 256, 256), controllerRBIcon, ScaleMode.ScaleToFit, true, 1.0F);
			drawTimerOne = drawTimerOne + Time.deltaTime;
		}
		if (drawButtonIcon2 && drawTimerTwo < 1.0f) {
			GUI.DrawTexture (new Rect (Screen.width / 4, Screen.height / 4, 256, 256), controllerAIcon, ScaleMode.ScaleToFit, true, 1.0F);
			drawTimerTwo = drawTimerTwo + Time.deltaTime;
		}
	}
}
