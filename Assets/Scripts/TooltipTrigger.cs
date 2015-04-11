using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TooltipTrigger : MonoBehaviour {

	public bool playerNearForestMonolith;
	public bool playerNearLakeMonolith;
	public bool playerNearCliffMonolith;
	public bool playerNearMushroomMonolith;

	void OnTriggerStay (Collider other) {

		if (other.collider.tag == "ForestMonolith") {
			playerNearForestMonolith = true;
		}

		if(other.collider.tag == "LakeMonolith"){
			playerNearLakeMonolith = true;
		}

		if (other.collider.tag == "CliffMonolith") {
			playerNearCliffMonolith = true;
		}
		
		if(other.collider.tag == "MushroomMonolith"){
			playerNearMushroomMonolith = true;
		}
	}

	void OnTriggerExit(Collider other) {

		if (other.collider.tag == "ForestMonolith") {
			playerNearForestMonolith = false;
		}
		
		if (other.collider.tag == "LakeMonolith") {
			playerNearLakeMonolith = false;
		}

		if (other.collider.tag == "CliffMonolith") {
			playerNearCliffMonolith = false;
		}
		
		if(other.collider.tag == "MushroomMonolith"){
			playerNearMushroomMonolith = false;
		}
	}
}
