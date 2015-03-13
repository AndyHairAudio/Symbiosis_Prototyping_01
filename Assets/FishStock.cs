using UnityEngine;
using System.Collections;

public class FishStock : MonoBehaviour {

	public float spawnRateMultiplier = 5.0f;
	public GameObject fishPrefab;

	// Use this for initialization
	void Start () {
		StartCoroutine (FishSpawner (1.0f));
	}

	IEnumerator FishSpawner (float spawnTimer){
	
		while (true) {
			yield return new WaitForSeconds (spawnTimer * spawnRateMultiplier);

			Instantiate (fishPrefab, new Vector3(Random.Range (this.transform.position.x - 30, this.transform.position.z + 30), this.transform.position.y, Random.Range(this.transform.position.z - 30, this.transform.position.z + 30)), Quaternion.Euler (0, Random.Range (0, 360), 0));
			
			Debug.Log ("spawning fish");
		}
	}
}
