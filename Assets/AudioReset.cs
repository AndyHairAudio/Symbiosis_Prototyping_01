using UnityEngine;
using System.Collections;

public class AudioReset : MonoBehaviour {

	// Use this for initialization
	void Start () {
		AkSoundEngine.SetRTPCValue ("Player_health", 100.0f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
