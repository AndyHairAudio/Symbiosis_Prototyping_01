using UnityEngine;
using System.Collections;

public class ShadeManager : MonoBehaviour {

	public int playerHeat = 0;
	bool inShade = false;

	// Use this for initialization
	void Start () {
		StartCoroutine(Shaded(1.0f));
		StartCoroutine(ShadeTimer(1.0f));
	}
	
	// Update is called once per frame
	void Update () {
		if (playerHeat > 100) {
			playerHeat = 100;
		}
		if (playerHeat < 0) {
			playerHeat = 0;
		}
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Tree") {
			inShade = true;
		}
		if (other.tag != "Tree") {
			inShade = false;
		}
	}

	void OnTriggerExit(Collider other){
		if (other.tag == "Tree") {
			inShade = false;
		}
		if (other.tag != "Tree") {
			inShade = true;
		}
	}

	IEnumerator ShadeTimer (float shadeTime){
		while (true) {
			yield return new WaitForSeconds (shadeTime);
			if(! inShade){
				if(playerHeat < 100){
					playerHeat++;
					Debug.Log ("Player outside, heat: " + playerHeat);
				}
			}
		}
	}

	IEnumerator Shaded (float shadedTimer){
		while (true) {
			yield return new WaitForSeconds (shadedTimer);
			if (inShade) {
				if(playerHeat > 0){
					playerHeat = playerHeat - 5;
					Debug.Log ("Player in shade, heat: " + playerHeat);
				}
			}
		}
	}
}
