using UnityEngine;
using System.Collections;

public class MusicSync : MonoBehaviour {

	public float timeOfLastBeat;
	public float timeSinceLastBeat;
	public bool beatThisFrameFish = false;
	public bool beatThisFrameGlow = false;
	public int treePop;
	public int fishPop;
	public int wolfPop;
	public int fruitPop;

	// Use this for initialization
	void Start () {
		AkSoundEngine.PostEvent ("Play_Player_Event_Manager", this.gameObject, (uint)AkCallbackType.AK_MusicSyncBeat | (uint)AkCallbackType.AK_MusicSyncBar, MusicCallback, this);
		StartCoroutine (PopulationTrack (1.0f));
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

	IEnumerator PopulationTrack (float trackTimer){

		while (true) {
			yield return new WaitForSeconds (trackTimer);

			GameObject[] treeObjs = GameObject.FindGameObjectsWithTag("Tree");
			treePop = treeObjs.Length;

			GameObject[] fishObjs = GameObject.FindGameObjectsWithTag("Fish");
			fishPop = fishObjs.Length;

			GameObject[] wolfObjs = GameObject.FindGameObjectsWithTag("Wolf");
			wolfPop = wolfObjs.Length;

			GameObject[] fruitObjs = GameObject.FindGameObjectsWithTag("TreeFruit");
			fruitPop = fruitObjs.Length;
		}

	}
}
