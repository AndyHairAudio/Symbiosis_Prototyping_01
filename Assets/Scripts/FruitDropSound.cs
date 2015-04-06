using UnityEngine;
using System.Collections;

public class FruitDropSound : MonoBehaviour {

	float timeOfStart;
	bool hasBeenPlayed = false;

	void Awake(){
		timeOfStart = Time.time;
		StartCoroutine (Decay (1.0f));
	}

	IEnumerator Decay (float decayTimer){

		while (true) {
			yield return new WaitForSeconds (decayTimer);

			if(timeOfStart + Random.Range (60.0f, 120.0f) < Time.time){
				Destroy(this.gameObject);
			}
		}

	}

	void OnTriggerEnter (Collider other)
	{
		if (other.collider.tag == "ForestTerrain" && hasBeenPlayed == false) {
			
			AkSoundEngine.PostEvent("Play_Falling_Fruit", this.gameObject);
			hasBeenPlayed = true;
		}
	}
}
