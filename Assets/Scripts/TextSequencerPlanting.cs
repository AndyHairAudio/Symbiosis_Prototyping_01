using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextSequencerPlanting : MonoBehaviour {
	
	GameObject playerObj;
	Text toolTipText;
	float timeOfShowing;
	
	void Start () {
		playerObj = GameObject.Find ("First Person Controller");
		toolTipText = gameObject.GetComponentInChildren<Text> ();
	}
	
	void Update () {
		if (playerObj.GetComponent<PlantingController> () || playerObj.GetComponent<PlantingUniqueController>()) {
			gameObject.GetComponent<Image> ().enabled = true;
			toolTipText.enabled = true;
		} else {
			gameObject.GetComponent<Image> ().enabled = false;
			toolTipText.enabled = false;		
		}
	}

}

