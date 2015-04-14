using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class FishingController : MonoBehaviour {

	public enum Dpad{None,Right,Left,Up,Down} private bool flag = true;
	public bool beatThisFrameRef = false;
	public bool barThisFrameRef = false;
	float buttonPressWindowStart;
	MusicSync syncComponent;
	float initialDelay = 4.0f;
	int fishDistance = 50;
	int randomButtonSelection;
	public string selectedButtonString;
	GameObject fishingTextObj;
	GameObject fishingDistObj;
	GameObject fpController;
	GameObject wwiseGlobal;
	GameObject upArrow;
	GameObject downArrow;
	GameObject leftArrow; 
	GameObject rightArrow;
	Image upImage; Image downImage; Image leftImage; Image rightImage;
	ObjectCollector objCollector;
	Text fishingText;
	Text fishDistText;
	bool buttonPressFallsOnBeat;
	//bool betweenBeats;
	List<string> buttonLog = new List<string>();
	//bool canFailAgain = true;
	GameObject[] fishObjs;
	CharacterController controllerFinder;
	
	void Start (){
		AkSoundEngine.SetRTPCValue ("Interaction_Percussion", 100.0f);
		fishObjs = GameObject.FindGameObjectsWithTag ("Fish");
		upArrow = GameObject.Find ("Up");
		downArrow = GameObject.Find ("Down");
		leftArrow = GameObject.Find ("Left"); 
		rightArrow = GameObject.Find ("Right");
		upImage = upArrow.GetComponent<Image> ();
		downImage = downArrow.GetComponent<Image> ();
		leftImage = leftArrow.GetComponent<Image> ();
		rightImage = rightArrow.GetComponent<Image> ();
		fpController = GameObject.Find ("First Person Controller");
		objCollector = fpController.GetComponent<ObjectCollector> ();
		objCollector.timeOfLastAttemptedCatch = Time.time;
		controllerFinder = fpController.GetComponent<CharacterController> ();
		fishingTextObj = GameObject.Find ("Fish Distance");
		fishingDistObj = GameObject.Find ("FishDistanceNo");
		fishingText = fishingTextObj.GetComponent<Text> ();
		fishDistText = fishingDistObj.GetComponent<Text> ();
		fishingText.enabled = true;
		fishDistText.enabled = true;
		wwiseGlobal = GameObject.Find ("WwiseGlobal");
		syncComponent = wwiseGlobal.GetComponent<MusicSync> ();
		StartCoroutine (FishSequence ());
	}
	
	// Update is called once per frame
	void Update () {
		AkSoundEngine.SetRTPCValue ("Fish_Distance", fishDistance);
		PadControl();
		beatThisFrameRef = syncComponent.beatThisFrameGlow;
		barThisFrameRef = syncComponent.barThisFrame;

//		if (betweenBeats && buttonLog.Count > 0 && canFailAgain) {
//			fishDistance = fishDistance + 10;
//			print("adding 10");
//			canFailAgain = false;
//		}

		string tempString = fishDistance.ToString ("##");
		fishDistText.text = tempString;

		if (controllerFinder.velocity.x != 0 || controllerFinder.velocity.z != 0) {
			fishingText.enabled = false;
			fishDistText.enabled = false;
			downImage.enabled = false;
			upImage.enabled = false;
			leftImage.enabled = false;
			rightImage.enabled = false;
			objCollector.playerFishing = false;
			Destroy (this);
		}
	}

	IEnumerator FishSequence (){

		yield return new WaitForSeconds (initialDelay);

		while (!barThisFrameRef) 
		{yield return null;}
		
		AkSoundEngine.PostEvent("Play_testbeep2", this.gameObject);
		
		yield return new WaitForSeconds (0.1f);
		
		while (!beatThisFrameRef) 
		{yield return null;}
		
		AkSoundEngine.PostEvent("Play_testbeep2", this.gameObject);
		
		yield return new WaitForSeconds (0.1f);
		
		while (!beatThisFrameRef) 
		{yield return null;}
		
		AkSoundEngine.PostEvent("Play_testbeep2", this.gameObject);
		
		yield return new WaitForSeconds (0.1f);
		
		while (!beatThisFrameRef) 
		{yield return null;}
		
		AkSoundEngine.PostEvent("Play_testbeep2", this.gameObject);
		
		yield return new WaitForSeconds (0.1f);

		while(fishDistance > 0){

			while (!beatThisFrameRef) 
			{yield return null;}

			yield return new WaitForSeconds(0.05f);
			randomButtonSelection = Random.Range(1, 5);
			switch (randomButtonSelection)
			{
			case 1:
				selectedButtonString = "Down";
				downImage.enabled = true;
				break;
			case 2:
				selectedButtonString = "Left";
				leftImage.enabled = true;
				break;
			case 3:
				selectedButtonString = "Up";
				upImage.enabled = true;
				break;
			case 4:
				selectedButtonString = "Right";
				rightImage.enabled = true;
				break;
			default:
				selectedButtonString = "Empty";
				break;
			}

			yield return new WaitForSeconds (0.83f);

			downImage.color = Color.green;
			upImage.color = Color.green;
			leftImage.color = Color.green;
			rightImage.color = Color.green;

			//betweenBeats = false;
			buttonLog.Clear();

			while (!beatThisFrameRef) 
			{yield return null;}

			yield return new WaitForSeconds(0.3f);
			if(buttonLog.Count > 0){
				if(buttonLog[0] == selectedButtonString){
					if(buttonLog.Count >= 2){
						fishDistance = fishDistance + 10;
						AkSoundEngine.PostEvent("Play_Fish_Escaping", this.gameObject);
					}
					else{
						fishDistance = fishDistance - 10;
						AkSoundEngine.PostEvent("Play_Fishing_Reel", this.gameObject);
					}
				}
				else {
					fishDistance = fishDistance + 10;
					AkSoundEngine.PostEvent("Play_Fish_Escaping", this.gameObject);
				}
			} else {
				fishDistance = fishDistance + 10;
				AkSoundEngine.PostEvent("Play_Fish_Escaping", this.gameObject);
			}
			//betweenBeats = true;
			buttonLog.Clear ();
			downImage.color = Color.white;
			upImage.color = Color.white;
			leftImage.color = Color.white;
			rightImage.color = Color.white;
			downImage.enabled = false;
			upImage.enabled = false;
			leftImage.enabled = false;
			rightImage.enabled = false;
			//canFailAgain = true;
			if (fishDistance <= 0) {
				objCollector.fishCollected = objCollector.fishCollected + 1;
				AkSoundEngine.SetRTPCValue ("Interaction_Success_Rhythm", 100.0f);
				fishObjs = GameObject.FindGameObjectsWithTag ("Fish");
				Destroy(fishObjs[Random.Range (0, fishObjs.Length)]);
				fishingText.enabled = false;
				fishDistText.enabled = false;
				objCollector.playerFishing = false;
				objCollector.timeOfLastUniquePlant = Time.time;
				objCollector.successfulInteractions.Add(Time.time);
				//play success sound cue
				Destroy (this);
			}
			if(fishDistance >= 100){
				fishingText.enabled = false;
				fishDistText.enabled = false;
				objCollector.playerFishing = false;
				//play failure sound cue
				Destroy (this);
			}
		}
	}

	void PadControl(){
		if(Input.GetAxis("Combo1")==0.0 && Input.GetAxis("Combo2")==0.0){
			flag  = true;
		}
		if(Input.GetAxis("Combo1")==1f && flag ){
			StartCoroutine( "DpadControl",Dpad.Right);
		}
		if(Input.GetAxis("Combo1")==-1f && flag){
			StartCoroutine( "DpadControl",Dpad.Left);
		}
		if(Input.GetAxis("Combo2")==1f&& flag ){
			StartCoroutine( "DpadControl",Dpad.Up);
		}
		if(Input.GetAxis("Combo2")==-1f && flag ){
			StartCoroutine( "DpadControl",Dpad.Down);
		}
	}
	
	IEnumerator DpadControl(Dpad value){
		flag = false;
		yield return new WaitForSeconds(0f); // delay it as you wish
		if (value == Dpad.Right) { 
			buttonLog.Add("Right");
		}
		if(value==Dpad.Left){ 
			buttonLog.Add("Left");
		}
		if(value==Dpad.Up){ 
			buttonLog.Add("Up"); 
		}
		if(value == Dpad.Down){ 
			buttonLog.Add("Down");
		}
		StopCoroutine ("DpadControl");
	}
}
