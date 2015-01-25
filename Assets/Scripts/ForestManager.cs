using UnityEngine;
using System.Collections;

public class ForestManager : MonoBehaviour {

	public int zoneEnergy = 100;
	public bool playerChanneling = false;
	public bool playerWithdrawing = false;
	bool iterationBool = true;

	// Use this for initialization
	void Start () {
		StartCoroutine (Channeling (1.0f));
	}
	
	// Update is called once per frame
	void Update () {
		if (zoneEnergy > 100) {
			zoneEnergy = 100;
		}
		if (zoneEnergy < 0) {
			zoneEnergy = 0;
		}

		GameObject controllerObject = GameObject.Find ("First Person Controller");
		EnergyChannel portManager = controllerObject.GetComponent<EnergyChannel> ();
		playerChanneling = portManager.isChanneling;
		playerWithdrawing = portManager.isWithdrawing;
	}

	IEnumerator Channeling (float channelTimer){

		while(iterationBool) {
			yield return new WaitForSeconds (channelTimer);
			 if(playerChanneling){
				zoneEnergy = zoneEnergy + 5;
				Debug.Log ("Zone energy: " + zoneEnergy);
			 }
			if(playerWithdrawing){
				zoneEnergy = zoneEnergy - 5;
				Debug.Log ("Zone energy: " + zoneEnergy);
			}
		}
		Debug.Log ("coroutine has run");
	}
}
