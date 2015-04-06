using UnityEngine;
using System.Collections;

public class FishStock : MonoBehaviour {

	public float spawnRateMultiplier = 1.0f;
	public GameObject fishPrefab;
	GameObject[] fishObjs;
	bool fishPopMaxed;

	// Use this for initialization
	void Start () {
		StartCoroutine (FishSpawner (60.0f));
		StartCoroutine (ResourceDecay (1.0f));
	}

	void Update () {
		fishObjs = GameObject.FindGameObjectsWithTag ("Fish");

		if (fishObjs.Length >= 20) {
						fishPopMaxed = true;
				} else {
						fishPopMaxed = false;
				}

		GameObject fpController = GameObject.FindGameObjectWithTag ("Player");
		ObjectCollector objCollectorPlayer = fpController.GetComponent<ObjectCollector> ();

		if (objCollectorPlayer.fishFedThisFrame) {
			spawnRateMultiplier = spawnRateMultiplier + 2.0f;
		}

		if (spawnRateMultiplier > 5.0f) {
			spawnRateMultiplier = 5.0f;
		}
	}

	IEnumerator FishSpawner (float spawnTimer){
	
		while (true) {
			yield return new WaitForSeconds (spawnTimer / spawnRateMultiplier);

			if(!fishPopMaxed){
				Instantiate (fishPrefab, new Vector3(Random.Range (this.transform.position.x - 30, this.transform.position.x + 30), this.transform.position.y, Random.Range(this.transform.position.z - 30, this.transform.position.z + 30)), Quaternion.Euler (0, Random.Range (0, 360), 0));
			}
		}
	}

	IEnumerator ResourceDecay (float decayTimer){

		while (true) {
			yield return new WaitForSeconds (decayTimer);

			if(spawnRateMultiplier > 1.0f){
				spawnRateMultiplier = spawnRateMultiplier - 0.1f;
			}
		}
	}
}
