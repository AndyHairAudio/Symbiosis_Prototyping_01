using UnityEngine;
using System.Collections;

public class MusicSync : MonoBehaviour {

	public float timeOfLastBeat;
	public float timeSinceLastBeat;
	public bool beatThisFrame = false;

	// Use this for initialization
	void Start () {
		AkSoundEngine.PostEvent ("Play_Player_Event_Manager", this.gameObject, (uint)AkCallbackType.AK_MusicSyncBeat | (uint)AkCallbackType.AK_MusicSyncBar, MusicCallback, this);
	}

	void MusicCallback (object in_cookie, AkCallbackType in_type, object in_callbackInfo)
	{
		AkSoundEngine.PostEvent ("Play_testbeep", this.gameObject);
		timeOfLastBeat = Time.time;
	}

	void Update(){
		timeSinceLastBeat = Time.time - timeOfLastBeat;

		if(timeSinceLastBeat < 0.075f){
			beatThisFrame = true;
		}
		else {
			beatThisFrame = false;
		}
	}
}
