using UnityEngine;
using System.Collections;

public class MusicSync : MonoBehaviour {

	public float timeOfLastBeat;
	public float timeSinceLastBeat;
	public float timeOfLastBar;
	public float timeSinceLastBar;
	public bool beatThisFrameFish = false;
	public bool beatThisFrameGlow = false;
	public bool barThisFrame = false;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(this.gameObject);

		AkSoundEngine.PostEvent ("Play_Player_Event_Manager", this.gameObject, (uint)AkCallbackType.AK_MusicSyncBeat | (uint)AkCallbackType.AK_MusicSyncBar, MusicCallback, this);
	}

	void MusicCallback (object in_cookie, AkCallbackType in_type, object in_callbackInfo)
	{
		if (in_type == AkCallbackType.AK_MusicSyncBeat) {
			timeOfLastBeat = Time.time;
			//AkSoundEngine.PostEvent ("Play_testbeep", this.gameObject);
		}

		if (in_type == AkCallbackType.AK_MusicSyncBar) {
			timeOfLastBar = Time.time;
			AkSoundEngine.PostEvent ("Play_testbeep", this.gameObject);
		}
	}

	void Update(){
		timeSinceLastBeat = Time.time - timeOfLastBeat;
		timeSinceLastBar = Time.time - timeOfLastBar;

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

		if(timeSinceLastBar < (Time.deltaTime * 5)){
			barThisFrame = true;
		}
		else {
			barThisFrame = false;
		}
	}
}
