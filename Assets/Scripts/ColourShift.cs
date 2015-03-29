using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ColourShift : MonoBehaviour {

	float colourFloat = 0.0f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		colourFloat = colourFloat + (0.1f * Time.deltaTime);

		if (colourFloat == 359.0f) {
						colourFloat = 0.0f;
		}
	}
}
