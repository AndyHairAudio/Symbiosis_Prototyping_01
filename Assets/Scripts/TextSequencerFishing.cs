using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextSequencerFishing : MonoBehaviour {

	GameObject playerObj;
	Text toolTipText;
	
	void Start () {
		playerObj = GameObject.Find ("First Person Controller");
		toolTipText = gameObject.GetComponentInChildren<Text> ();
	}

	void Update () {
		if (playerObj.GetComponent<FishingController> ()) {
			gameObject.GetComponent<Image> ().enabled = true;
			toolTipText.enabled = true;
		} else {
			gameObject.GetComponent<Image> ().enabled = false;
			toolTipText.enabled = false;		
		}
	}
}
