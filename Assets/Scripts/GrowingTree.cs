using UnityEngine;
using System.Collections;

public class GrowingTree : MonoBehaviour {

	bool iterationBool = true; //Used to loop an energy check
	public int treeEnergy = 0; // The individual trees energy
	int forestEnergy; //Var to store zone energy
	public bool treeIsGrowing = false;
	public bool treeIsDecaying = false;

	void Awake () {
		StartCoroutine (EnergyChecker (5.0f)); // Start energy checker loop
		StartCoroutine (Sapling (5.0f));
		StartCoroutine (Bush (5.0f));
		StartCoroutine (SmallTree (5.0f));
		StartCoroutine (MediumTree (5.0f));
		StartCoroutine (BigTree (5.0f));
	}

	void Start (){
	}

	void Update () {
		if (treeEnergy > 100) {
			treeEnergy = 100;
		}
		if (treeEnergy < 0) {
			treeEnergy = 0;
		}

		Vector3 one = new Vector3(0.1f, 0.1f, 0.1f);
		if (treeIsGrowing && transform.localScale.x < 1.75f) {
			float speed = 0.02f;
			transform.localScale += one * speed * Time.deltaTime;
		}
		if (treeIsDecaying && transform.localScale.x > 0.25f) {
			float speed = 0.02f;
			transform.localScale -= one * speed * Time.deltaTime;
		}
	}

	IEnumerator EnergyChecker (float timer) {
		while (iterationBool) {
			yield return new WaitForSeconds (timer); //Continual loop, executing once per second
			GameObject zoneObject = GameObject.Find ("ForestZone"); //Grab the zone manager script
			ForestManager refManager = zoneObject.GetComponent<ForestManager> ();
			
			if (refManager.zoneEnergy <= 33) { //Check if zone energy is low
				treeEnergy--; //Decrease individual tree energy by one
				//Debug.Log ("Tree is decaying");
				treeIsGrowing = false;
				treeIsDecaying = true;
			}
			
			if (refManager.zoneEnergy > 33 && refManager.zoneEnergy <= 66) {
				//Debug.Log ("Tree is static");
				treeIsGrowing = false;
				treeIsDecaying = false;
			}
			
			if (refManager.zoneEnergy > 66 && refManager.zoneEnergy <= 100) {
				treeEnergy++;
				treeIsGrowing = true;
				treeIsDecaying = false;
				//Debug.Log ("Tree is growing");
			}
			forestEnergy = refManager.zoneEnergy; //Add current zone energy into public var
		}
	}

	IEnumerator Sapling (float sapTimer) {
		while (iterationBool) {
			yield return new WaitForSeconds(sapTimer);
			if(treeEnergy <= 20){
				if (treeEnergy == 19 && forestEnergy <= 33){
					Debug.Log("Stopping events for bush, as tree is turning into a sapling");
				}
				if(treeEnergy == 0 && forestEnergy >= 66){

				}
			}
		}
	}
	
	IEnumerator Bush (float bushTimer) {
		while (iterationBool) {
			yield return new WaitForSeconds(bushTimer);
			if (treeEnergy <= 40 && treeEnergy > 20) {
				if(treeEnergy == 21 && forestEnergy >= 66){
					Debug.Log ("Pushing events for sapling turning into a bush");
				}
				if(treeEnergy == 39 && forestEnergy <= 33){
					Debug.Log ("Stopping events for small tree, as tree is turning into a bush");
				}
			}
		}
	}

	IEnumerator SmallTree (float smallTreeTimer) {
		while (iterationBool) {
			yield return new WaitForSeconds(smallTreeTimer);
			if (treeEnergy <= 60 && treeEnergy > 40) {
				if(treeEnergy == 41 && forestEnergy >= 66){
					Debug.Log ("Pushing events for bush turning into a small tree");
				}
				if(treeEnergy == 59 && forestEnergy <= 33){
					Debug.Log ("Stopping events for medium tree, as tree is turning into a small tree");
				}
			}
		}
	}

	IEnumerator MediumTree (float medTreeTimer) {
		while (iterationBool) {
			yield return new WaitForSeconds(medTreeTimer);
			if (treeEnergy <= 80 && treeEnergy > 60) {
				if(treeEnergy == 61 && forestEnergy >= 66){
					Debug.Log ("Pushing events for small turning into a medium tree");
				}
				if(treeEnergy == 79 && forestEnergy <= 33){
					Debug.Log ("Stopping events for big tree, as tree is turning into a medium tree");
				}
			}
		}
	}

	IEnumerator BigTree (float bigTreeTimer) {
		while (iterationBool) {
			yield return new WaitForSeconds(bigTreeTimer);
			if (treeEnergy <= 100 && treeEnergy > 80) {
				if(treeEnergy == 81 && forestEnergy >= 66){
					Debug.Log ("Pushing events for medium turning into a big tree");
				}
			}
		}
	}
}
