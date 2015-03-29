using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InteractionTipFish : MonoBehaviour {
	
	public bool canFish;
	Image[] images;
	Text promptText;
	ObjectCollector objCollect;
	
	// Use this for initialization
	void Start () {
		objCollect = GameObject.Find ("First Person Controller").GetComponent<ObjectCollector> ();
		promptText = gameObject.GetComponentInChildren<Text> ();
		images = gameObject.GetComponentsInChildren<Image> ();
		canFish = objCollect.ableToFish;
	}
	
	// Update is called once per frame
	void Update () {
		canFish = objCollect.ableToFish;
		if (canFish) {
			images[0].enabled = true;
			images[1].enabled = true;
			promptText.enabled = true;
		} else if(!canFish) {
			images[0].enabled = false;
			images[1].enabled = false;
			promptText.enabled = false;
		}
	}
}
