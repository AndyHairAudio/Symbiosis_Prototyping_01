using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InteractionTipFeedFish : MonoBehaviour {
	
	public bool canFeedFish;
	Image[] images;
	Text promptText;
	ObjectCollector objCollect;
	
	// Use this for initialization
	void Start () {
		objCollect = GameObject.Find ("First Person Controller").GetComponent<ObjectCollector> ();
		promptText = gameObject.GetComponentInChildren<Text> ();
		images = gameObject.GetComponentsInChildren<Image> ();
		canFeedFish = objCollect.ableToFeedFish;
	}
	
	// Update is called once per frame
	void Update () {
		canFeedFish = objCollect.ableToFeedFish;
		if (canFeedFish) {
			images[0].enabled = true;
			images[1].enabled = true;
			promptText.enabled = true;
		} else if(!canFeedFish) {
			images[0].enabled = false;
			images[1].enabled = false;
			promptText.enabled = false;
		}
	}
}