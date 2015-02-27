using UnityEngine;
using System.Collections;

public class FruitDropSound : MonoBehaviour {

	bool hasBeenPlayed = false;

	void OnTriggerEnter (Collider other)
	{
		if (other.collider.tag == "ForestTerrain" && hasBeenPlayed == false) {
			
			AkSoundEngine.PostEvent("Play_Falling_Fruit", this.gameObject);
			hasBeenPlayed = true;
		}
	}
}
