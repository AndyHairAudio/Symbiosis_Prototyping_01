using UnityEngine;
using System.Collections;

public class LightDimmer : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		GameObject healthObject = GameObject.Find ("First Person Controller");
		ObjectCollector collectorComponent = healthObject.GetComponent<ObjectCollector> ();

		float healthInt = collectorComponent.playerHealth;
		float healthIntensity = ((healthInt * 0.01f) / 2) + 0.25f;

		light.intensity = healthIntensity;
	}
}
