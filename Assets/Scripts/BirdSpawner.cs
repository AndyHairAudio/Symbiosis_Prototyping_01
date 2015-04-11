using UnityEngine;
using System.Collections;

public class BirdSpawner : MonoBehaviour {
	
	public float spawnRateMultiplier = 1.0f;
	public GameObject birdPrefab;
	GameObject[] birdObjs;
	GameObject[] fruitObjs;
	public bool birdPopMaxed;
	
	// Use this for initialization
	void Start () {
		StartCoroutine (BirdCreator (30.0f));
		StartCoroutine (ResourceDecay (1.0f));
	}
	
	void Update () {
		birdObjs = GameObject.FindGameObjectsWithTag ("Bird");
		fruitObjs = GameObject.FindGameObjectsWithTag ("TreeFruit");
		
		if (birdObjs.Length >= 20) {
			birdPopMaxed = true;
		} else {
			birdPopMaxed = false;
		}

		if (spawnRateMultiplier < 1.0f){
			spawnRateMultiplier = 1.0f;
		}

		if (fruitObjs.Length <= 10) {
						spawnRateMultiplier = 1.0f;
				} else if (fruitObjs.Length > 10 && fruitObjs.Length <= 20) {
						spawnRateMultiplier = 2.0f;
				} else if (fruitObjs.Length > 20 && fruitObjs.Length <= 30) {
						spawnRateMultiplier = 3.0f;
				} else if (fruitObjs.Length > 30 && fruitObjs.Length <= 40) {
						spawnRateMultiplier = 4.0f;
				} else if (fruitObjs.Length > 40 && fruitObjs.Length <= 50) {
						spawnRateMultiplier = 5.0f;
				} else {
						spawnRateMultiplier = 6.0f;
				}
	}
	
	IEnumerator BirdCreator (float spawnTimer){
		
		while (true) {
			yield return new WaitForSeconds (spawnTimer / spawnRateMultiplier);

			if(!birdPopMaxed){
				Instantiate (birdPrefab, new Vector3(Random.Range (this.transform.position.x - 30, this.transform.position.x + 30), this.transform.position.y, Random.Range(this.transform.position.z - 30, this.transform.position.z + 30)), Quaternion.Euler (0, Random.Range (0, 360), 0));
				print ("spawning");
			}
		}
	}
	
	IEnumerator ResourceDecay (float decayTimer){
		
		while (true) {
			yield return new WaitForSeconds (decayTimer);
			
			if(spawnRateMultiplier > 1.0f){
				spawnRateMultiplier = spawnRateMultiplier - 0.01f;
			}
		}
	}
}
