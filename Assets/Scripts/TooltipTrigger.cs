using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TooltipTrigger : MonoBehaviour {

	public bool playerNearForestMonolith;
	public bool playerNearLakeMonolith;

	void OnTriggerStay (Collider other) {

		if (other.collider.tag == "ForestMonolith") {
			playerNearForestMonolith = true;
		}

		if(other.collider.tag == "LakeMonolith"){
			playerNearLakeMonolith = true;
		}

	}

	void OnTriggerExit(Collider other) {

		if (other.collider.tag == "ForestMonolith") {
			playerNearForestMonolith = false;
		}
		
		if (other.collider.tag == "LakeMonolith") {
			playerNearLakeMonolith = false;
		}
	}
}
