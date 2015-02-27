using UnityEngine;
using System.Collections;

public class SeedGenerator : MonoBehaviour {

	public bool sapBool;
	public bool bushBool;
	public bool sTreeBool;
	public bool mTreeBool;
	public bool bTreeBool;
	public float minSpawnTime = 60.0f;
	public float maxSpawnTime = 120.0f;
	public GameObject fruitPrefab;
	public int seedsSpawned = 0;
	public float treeEnergy = 0.0f;

	void Awake(){
		StartCoroutine (GrowingTree (0.05f));
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

			if(treeEnergy >= 0){
				sapBool = true;
				AkSoundEngine.SetSwitch("Tree_States", "Sapling",this.gameObject);
				if(treeEnergy >= 20){
					bushBool = true;
					AkSoundEngine.SetSwitch("Tree_States", "Bush",this.gameObject);
					if(treeEnergy >= 40){
						AkSoundEngine.SetSwitch ("Tree_States", "STree",this.gameObject);
						sTreeBool = true;
						if(treeEnergy >= 60){
							AkSoundEngine.SetSwitch ("Tree_States", "MTree",this.gameObject);
							mTreeBool = true;
							if(treeEnergy >= 80){
								AkSoundEngine.SetSwitch ("Tree_States", "BTree",this.gameObject);
								bTreeBool = true;
							}
						}
					}
				}
			}
		}
	}
}
