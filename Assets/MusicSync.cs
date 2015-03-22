using UnityEngine;
using System.Collections;

public class MusicSync : MonoBehaviour {

	// Use this for initialization
	void Start () {
		AkSoundEngine.PostEvent ("Play_Player_Event_Manager", this.gameObject, (uint)AkCallbackType.AK_MusicSyncBeat | (uint)AkCallbackType.AK_MusicSyncBar, MusicCallback, this);
	}

	void MusicCallback (object in_cookie, AkCallbackType in_type, object in_callbackInfo)
	{
		
	}
}
