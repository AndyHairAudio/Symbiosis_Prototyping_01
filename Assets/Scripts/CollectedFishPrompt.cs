using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CollectedFishPrompt : MonoBehaviour {
	
	Image[] images;
	ObjectCollector objCollect;
	public int fishCollected;
	
	// Use this for initialization
	void Start () {
		objCollect = GameObject.Find ("First Person Controller").GetComponent<ObjectCollector> ();
		images = gameObject.GetComponentsInChildren<Image> ();
	}
	
	// Update is called once per frame
	void Update () {
		fishCollected = objCollect.fishCollected;
		
		if (fishCollected > 0) {
			
			images [0].enabled = true;
			images [1].enabled = true;
			images [2].enabled = true;
		} 
		else {
			foreach (Image item in images) {
				item.enabled = false;
			}
		}
	}
}
