using UnityEngine;
using System.Collections;

public class FruitDropSound : MonoBehaviour {
	
	bool hasBeenPlayed = false;
	float timeStarted;
	float decayRandomLength;

	void Start (){
		timeStarted = Time.time;
		decayRandomLength = Random.Range (180.0f, 240.0f);
		StartCoroutine (DecayTime (1.0f));
	}

	IEnumerator DecayTime (float decayTimer){

		while (true) {
			yield return new WaitForSeconds (decayTimer);

			if((timeStarted + decayRandomLength) < Time.time){
				Destroy(gameObject);
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
