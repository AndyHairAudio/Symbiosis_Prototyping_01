using UnityEngine;
using System.Collections;

public class BirdLife : MonoBehaviour {
	
	float timeSpawned;
	
	// Use this for initialization
	void Start () {
		timeSpawned = Time.time;
		StartCoroutine (DestroyBird (1.0f));
	}
	
	IEnumerator DestroyBird (float destroyTimer){
		
		while (true) {
			yield return new WaitForSeconds (destroyTimer);
			
			if((timeSpawned + Random.Range(20.0f, 40.0f)) < Time.time){
				Destroy (this.gameObject);
			}
		}
	}
}
