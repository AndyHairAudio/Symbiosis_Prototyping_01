using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextSequencerLake : MonoBehaviour {
	
	TooltipTrigger tooltipTriggerComp;
	bool sequenceRunning;
	Text[] textCompChildren;
	
	// Use this for initialization
	void Start () {
		tooltipTriggerComp = GameObject.Find ("First Person Controller").GetComponent<TooltipTrigger> ();
		textCompChildren = gameObject.GetComponentsInChildren<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (tooltipTriggerComp.playerNearLakeMonolith) {
			gameObject.GetComponent<Image> ().enabled = true;
			if (!sequenceRunning) {
				if (Input.GetButtonDown ("Fire1")) {
					sequenceRunning = true;
					StartCoroutine ("LakeSequence");
				}
				textCompChildren [0].enabled = true;
			} else { 
				textCompChildren [0].enabled = false;
			}
		} else {
			gameObject.GetComponent<Image> ().enabled = false;
			sequenceRunning = false;
			StopCoroutine("LakeSequence");
			foreach (Text item in textCompChildren){
				item.enabled = false;
			}
		}
	}
	
	IEnumerator LakeSequence (){
		
		sequenceRunning = true;
		
		textCompChildren [0].enabled = false;
		
		yield return new WaitForSeconds (0.250f);
		
		textCompChildren [1].enabled = true;
		
		while (!Input.GetButtonDown ("Fire1")) {
			yield return null;
		}
		
		textCompChildren [1].enabled = false;
		
		yield return new WaitForSeconds (0.25f);
		
		textCompChildren [2].enabled = true;
		
		while (!Input.GetButtonDown ("Fire1")) {
			yield return null;
		}
		
		textCompChildren [2].enabled = false;
		
		yield return new WaitForSeconds (0.25f);
		
		textCompChildren [3].enabled = true;
		
		while (!Input.GetButtonDown ("Fire1")) {
			yield return null;
		}
		
		textCompChildren [3].enabled = false;
		
		yield return new WaitForSeconds (1.0f);
		
		sequenceRunning = false;
	}
}
