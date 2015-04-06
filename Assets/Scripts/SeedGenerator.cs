using UnityEngine;
using System.Collections;

public class SeedGenerator : MonoBehaviour {
	
	public bool sapBool;
	public bool bushBool;
	public bool sTreeBool;
	public bool mTreeBool;
	public bool bTreeBool;
	public float minSpawnTime = 10.0f;
	public float maxSpawnTime = 20.0f;
	public GameObject fruitPrefab;
	public int seedsSpawned = 0;
	public float treeEnergy = 0.0f;
	float timeOfStart;
	float timeBecameBigTree;
	bool hasFinishedGrowing;

	void Awake(){
		StartCoroutine (GrowingTree (0.05f));
		AkSoundEngine.PostEvent ("Play_Plant_Tree", this.gameObject);
		AkSoundEngine.PostEvent ("Play_Tree_Emitter", this.gameObject);
		timeOfStart = Time.time;
	}

	void Update(){
		Vector3 one = new Vector3(0.1f, 0.1f, 0.1f);
		if (transform.localScale.x < 1.0f) {
			float speed = 0.02f;
			transform.localScale += one * speed * Time.deltaTime;
		}
	}
	
	// Use this for initialization
	IEnumerator Start () {
		
		while (seedsSpawned < 5) {
			yield return new WaitForSeconds (Random.Range (minSpawnTime, maxSpawnTime));
			
			if (sTreeBool || mTreeBool || bTreeBool) {
				Instantiate (fruitPrefab, new Vector3 (Random.Range (this.transform.position.x - 3, this.transform.position.x + 3), this.transform.position.y + 3, Random.Range (this.transform.position.z - 2, this.transform.position.z + 5)), Quaternion.identity);
				seedsSpawned++;
			}
			
		}
	}
	
	IEnumerator GrowingTree (float growthTimer){
		
		while (true) {
			yield return new WaitForSeconds (growthTimer);
			
			treeEnergy = treeEnergy + 0.05f;
			if(treeEnergy > 100){
				treeEnergy = 100;
			}
			if(treeEnergy < 0){
				treeEnergy = 0;
			}

			if((timeOfStart + 60.0f) < Time.time){
				AkSoundEngine.PostEvent("Stop_Tree_Emitter", this.gameObject);
			}
			
			if(treeEnergy >= 0){
				sapBool = true;
				
				if(treeEnergy >= 20){
					bushBool = true;
					
					if(treeEnergy >= 40){
						
						sTreeBool = true;
						if(treeEnergy >= 60){
							
							mTreeBool = true;
							if(treeEnergy >= 80 && !hasFinishedGrowing){
								timeBecameBigTree = Time.time;
								bTreeBool = true;
								hasFinishedGrowing = true;
							}
						}
					}
				}
			}
		}
	}

	IEnumerator DestroyTree (float destroyTimer){

		while (true) {
			yield return new WaitForSeconds (destroyTimer);

			if((timeBecameBigTree + 60.0f) < Time.time){
				Destroy (this.gameObject);
			}
		}
	}
}