using UnityEngine;
using System.Collections;

public class FishLife : MonoBehaviour {

	float timeSpawned;

	// Use this for initialization
	void Start () {
		timeSpawned = Time.time;
		StartCoroutine (DestroyFish (1.0f));
	}

	IEnumerator DestroyFish (float destroyTimer){
		
		while (true) {
			yield return new WaitForSeconds (destroyTimer);
			
			if((timeSpawned + 60.0f) < Time.time){
				Destroy (this.gameObject);
			}
		}
	}
}
