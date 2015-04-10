using UnityEngine;
using System.Collections;

public class MusicSync : MonoBehaviour {

	public float timeOfLastBeat;
	public float timeSinceLastBeat;
	public bool beatThisFrameFish = false;
	public bool beatThisFrameGlow = false;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(this.gameObject);

		AkSoundEngine.PostEvent ("Play_Player_Event_Manager", this.gameObject, (uint)AkCallbackType.AK_MusicSyncBeat | (uint)AkCallbackType.AK_MusicSyncBar, MusicCallback, this);
	}

	void MusicCallback (object in_cookie, AkCallbackType in_type, object in_callbackInfo)
	{
		timeOfLastBeat = Time.time;
	}

	void Update(){
		timeSinceLastBeat = Time.time - timeOfLastBeat;

		if(timeSinceLastBeat < (Time.deltaTime * 10)){
			beatThisFrameFish = true;
		}
		else {
			beatThisFrameFish = false;
		}

		if(timeSinceLastBeat < (Time.deltaTime * 5)){
			beatThisFrameGlow = true;
		}
		else {
			beatThisFrameGlow = false;
		}
	}
}
