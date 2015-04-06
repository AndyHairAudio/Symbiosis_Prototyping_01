using UnityEngine;
using System.Collections;

public class InitialTrees : MonoBehaviour {

	float timeOfLastFruitSpawn;
	float randomDelay;
	public GameObject fruitPrefab;
	
	void Awake(){
		StartCoroutine (FruitSpawnInitial (1.00f));
		randomDelay = Random.Range (60.0f, 120.0f);
	}
	
	IEnumerator FruitSpawnInitial (float growthTimer){
		
		while (true) {
			yield return new WaitForSeconds (growthTimer);

			if ((timeOfLastFruitSpawn + randomDelay) < Time.time) {
				timeOfLastFruitSpawn = Time.time;
				Instantiate (fruitPrefab, new Vector3 (Random.Range (this.transform.position.x - 3, this.transform.position.x + 3), this.transform.position.y + 3, Random.Range (this.transform.position.z - 2, this.transform.position.z + 5)), Quaternion.identity);
				randomDelay = Random.Range (60.0f, 120.0f);
			}
		}
	}
}

