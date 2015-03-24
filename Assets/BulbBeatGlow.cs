using UnityEngine;
using System.Collections;

public class BulbBeatGlow : MonoBehaviour {

	GameObject fpController;
	MusicSync musicCallback;
	Light lightComp;
	public bool beatNow = false;
	float timeLightEnabled;

	// Use this for initialization
	void Start () {
		StartCoroutine (GlowTimer(Random.Range(1.0f, 20.0f)));
		fpController = GameObject.Find ("First Person Controller");
		musicCallback = fpController.GetComponent<MusicSync> ();
		lightComp = gameObject.GetComponent<Light> ();
	}
	
	// Update is called once per frame
	void Update () {
		beatNow = musicCallback.beatThisFrame;

		if ((Time.time - timeLightEnabled) > 1.0f) {
			lightComp.enabled = false;
		}	

		if (lightComp.enabled) {
			lightComp.intensity = lightComp.intensity - 0.5f * (Time.deltaTime * 10.0f);
		}
	}

	IEnumerator GlowTimer (float glowWaitTimer){
			while (true) { 
				yield return new WaitForSeconds (glowWaitTimer);
				
				while (beatNow == false){
					yield return null;
				}
			lightComp.intensity = 3.0f;
				lightComp.enabled = true;
				timeLightEnabled = Time.time;
			}
	}
}
