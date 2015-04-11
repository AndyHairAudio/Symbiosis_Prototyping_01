using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InteractionTipPlantUniqueTree : MonoBehaviour {
	
	public bool canPlantTree;
	Image[] images;
	Text promptText;
	ObjectCollector objCollect;
	
	// Use this for initialization
	void Start () {
		objCollect = GameObject.Find ("First Person Controller").GetComponent<ObjectCollector> ();
		promptText = gameObject.GetComponentInChildren<Text> ();
		images = gameObject.GetComponentsInChildren<Image> ();
		canPlantTree = objCollect.rayHittingUniqueTerrain;
	}
	
	// Update is called once per frame
	void Update () {
		canPlantTree = objCollect.rayHittingUniqueTerrain;
		if (canPlantTree) {
			images[0].enabled = true;
			images[1].enabled = true;
			promptText.enabled = true;
		} else if(!canPlantTree) {
			images[0].enabled = false;
			images[1].enabled = false;
			promptText.enabled = false;
		}
	}
}
