using UnityEngine;
using System.Collections;

public class InitialTrees : MonoBehaviour {
	
	public bool sapBool;
	public bool bushBool;
	public bool sTreeBool;
	public bool mTreeBool;
	public bool bTreeBool;
	public float minSpawnTime = 60.0f;
	public float maxSpawnTime = 120.0f;
	public float treeEnergy = 100.0f;
	
	void Awake(){
		StartCoroutine (GrowingTree (0.05f));
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

				if(treeEnergy >= 20){
					bushBool = true;

					if(treeEnergy >= 40){

						sTreeBool = true;
						if(treeEnergy >= 60){

							mTreeBool = true;
							if(treeEnergy >= 80){

								bTreeBool = true;
							}
						}
					}
				}
			}
		}
	}
}
