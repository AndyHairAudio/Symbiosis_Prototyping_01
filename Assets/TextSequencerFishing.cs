using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextSequencerFishing : MonoBehaviour {

	GameObject playerObj;
	FishingController fishinCont;
	bool hasBeenShown;
	Text toolTipText;
	
	void Start () {
		playerObj = GameObject.Find ("First Person Controller");
		toolTipText = gameObject.GetComponentInChildren<Text> ();
	}

	void Update () {
		if (playerObj.GetComponent<FishingController> () != null && !hasBeenShown) {
			hasBeenShown = true;
			StartCoroutine (ShowTooltip());
		}
	}

	IEnumerator ShowTooltip (){
		gameObject.GetComponent<Image> ().enabled = true;
		toolTipText.enabled = true;

		yield return new WaitForSeconds (3.0f);

		gameObject.GetComponent<Image> ().enabled = false;
		toolTipText.enabled = false;
	}
}
