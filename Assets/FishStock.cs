using UnityEngine;
using System.Collections;

public class FishStock : MonoBehaviour {

	public float spawnRateMultiplier = 10.0f;
	public GameObject fishPrefab;

	// Use this for initialization
	void Start () {
		StartCoroutine (FishSpawner (20.0f));
		StartCoroutine (ResourceDecay (0.2f));
	}

	void Update () {
		GameObject fpController = GameObject.FindGameObjectWithTag ("Player");
		ObjectCollector objCollectorPlayer = fpController.GetComponent<ObjectCollector> ();

		if (objCollectorPlayer.fishFedThisFrame) {
			spawnRateMultiplier = spawnRateMultiplier - 2.0f;
		}

		if (spawnRateMultiplier < 5.0f) {
			spawnRateMultiplier = 5.0f;
		}

		if (spawnRateMultiplier > 20.0f) {
			spawnRateMultiplier = 20.0f;
		}
	}

	IEnumerator FishSpawner (float spawnTimer){
	
		while (true) {
			yield return new WaitForSeconds (spawnTimer * (spawnRateMultiplier/10.0f));

			Instantiate (fishPrefab, new Vector3(Random.Range (this.transform.position.x - 30, this.transform.position.z + 30), this.transform.position.y, Random.Range(this.transform.position.z - 30, this.transform.position.z + 30)), Quaternion.Euler (0, Random.Range (0, 360), 0));
			
			Debug.Log ("spawning fish");
		}
	}

	IEnumerator ResourceDecay (float decayTimer){

		while (true) {
			yield return new WaitForSeconds (decayTimer);

			spawnRateMultiplier = spawnRateMultiplier + 0.01f;
		}
	}
}
