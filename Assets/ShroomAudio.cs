using UnityEngine;
using System.Collections;

public class ShroomAudio : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (gameObject.tag == "Shroomed") {
			AkSoundEngine.SetRTPCValue("Mushroom_Effect", 100.0f);
		} else {
			AkSoundEngine.SetRTPCValue("Mushroom_Effect", 0.0f);
		}
	}
}
