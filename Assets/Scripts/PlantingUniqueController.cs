using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PlantingUniqueController : MonoBehaviour {
	
	public enum Dpad{None,Right,Left,Up,Down} private bool flag = true;
	public bool beatThisFrameRef = false;
	public bool barThisFrameRef = false;
	float buttonPressWindowStart;
	MusicSync syncComponent;
	float initialDelay = 4.0f;
	int depthDug = 30;
	int randomButtonSelection;
	public string selectedButtonString;
	GameObject fpController;
	GameObject wwiseGlobal;
	GameObject upArrow;
	GameObject downArrow;
	GameObject leftArrow; 
	GameObject rightArrow;
	GameObject treePrefab;
	Image upImage; Image downImage; Image leftImage; Image rightImage;
	ObjectCollector objCollector;
	bool buttonPressFallsOnBeat;
	List<string> buttonLog = new List<string>();
	CharacterController controllerFinder;
	
	void Start (){
		AkSoundEngine.SetRTPCValue ("Interaction_Percussion", 100.0f);
		treePrefab = Resources.Load ("UniqueTree") as GameObject;
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
		objCollector.timeOfLastAttemptedUniquePlant = Time.time;
		controllerFinder = fpController.GetComponent<CharacterController> ();
		wwiseGlobal = GameObject.Find ("WwiseGlobal");
		syncComponent = wwiseGlobal.GetComponent<MusicSync> ();
		StartCoroutine (DigSequence ());
	}
	
	// Update is called once per frame
	void Update () {
		PadControl();
		beatThisFrameRef = syncComponent.beatThisFrameGlow;
		barThisFrameRef = syncComponent.barThisFrame;
		
		if (controllerFinder.velocity.x != 0 || controllerFinder.velocity.z != 0) {
			downImage.enabled = false;
			upImage.enabled = false;
			leftImage.enabled = false;
			rightImage.enabled = false;
			objCollector.playerPlanting = false;
			Destroy (this);
		}
	}
	
	IEnumerator DigSequence (){
		
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
		
		while (depthDug > 0) {
			
			while (!beatThisFrameRef) 
			{yield return null;}
			
			yield return new WaitForSeconds (0.05f);
			randomButtonSelection = Random.Range (1, 5);
			switch (randomButtonSelection) {
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
			buttonLog.Clear ();
			
			while (!beatThisFrameRef) 
			{yield return null;}
			
			yield return new WaitForSeconds(0.3f);
			if(buttonLog.Count > 0){
				if(buttonLog[0] == selectedButtonString){
					if(buttonLog.Count >= 2){
					}
					else{
						depthDug = depthDug - 10;
						AkSoundEngine.PostEvent("Play_Digging", this.gameObject);
					}
				}
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
			if (depthDug <= 0) {
				Instantiate (treePrefab, objCollector.rayHitPlant.point, Quaternion.Euler (0, Random.Range (0, 360), 0));
				objCollector.playerScore = objCollector.playerScore + 10;
				objCollector.uniqueFruitCollected = objCollector.uniqueFruitCollected - 1;
				AkSoundEngine.SetRTPCValue ("Interaction_Success_Rhythm", 100.0f);
				objCollector.playerPlanting = false;
				objCollector.timeOfLastUniquePlant = Time.time;
				objCollector.successfulInteractions.Add(Time.time);
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
