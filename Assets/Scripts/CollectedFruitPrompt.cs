using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CollectedFruitPrompt : MonoBehaviour {

	Image[] images;
	ObjectCollector objCollect;
	public int fruitCollected;

	// Use this for initialization
	void Start () {
		objCollect = GameObject.Find ("First Person Controller").GetComponent<ObjectCollector> ();
		images = gameObject.GetComponentsInChildren<Image> ();
	}
	
	// Update is called once per frame
	void Update () {
		fruitCollected = objCollect.fruitCollected;

		if (fruitCollected > 0) {

			images [0].enabled = true;
			images [1].enabled = true;
			images [4].enabled = true;

			if (fruitCollected > 1) {
				images [2].enabled = true;

				if (fruitCollected == 3) {
					images [3].enabled = true;
				} 
				else {
					images [3].enabled = false;
				}
			}
			else{
				images[2].enabled = false;
			}
		} 
		else {
			foreach (Image item in images) {
				item.enabled = false;
			}
		}
	}
}
