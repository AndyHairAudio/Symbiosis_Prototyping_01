using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InteractionTipCollectFruit : MonoBehaviour {

	public bool lookingAtFruit;
	Image[] images;
	Text promptText;
	ObjectCollector objCollect;

	// Use this for initialization
	void Start () {
		objCollect = GameObject.Find ("First Person Controller").GetComponent<ObjectCollector> ();
		promptText = gameObject.GetComponentInChildren<Text> ();
		images = gameObject.GetComponentsInChildren<Image> ();
		lookingAtFruit = objCollect.rayHittingFruit;
	}
	
	// Update is called once per frame
	void Update () {
		lookingAtFruit = objCollect.rayHittingFruit;
		if (lookingAtFruit) {
			images[0].enabled = true;
			images[1].enabled = true;
			promptText.enabled = true;
		} else if(!lookingAtFruit) {
			images[0].enabled = false;
			images[1].enabled = false;
			promptText.enabled = false;
		}
	}
}
