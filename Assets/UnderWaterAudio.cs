using UnityEngine;
using System.Collections;

public class UnderWaterAudio : MonoBehaviour {


	
	void OnTriggerStay (Collider other){

		if (other.tag == "LakeWaterCollider") {
			AkSoundEngine.SetRTPCValue ("Underwater", 100.0f);
		}
	}

	void OnTriggerExit (Collider other){

		if (other.tag == "LakeWaterCollider") {
			AkSoundEngine.SetRTPCValue("Underwater", 0.0f);
		}
	}
}
