using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreTrack : MonoBehaviour {

	ObjectCollector objCollect;
	int playerScore = 0;
	Text scoreTextComp;

	// Use this for initialization
	void Start () {
		objCollect = GameObject.Find ("First Person Controller").GetComponent<ObjectCollector> ();
		scoreTextComp = gameObject.GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		playerScore = objCollect.playerScore;
		string scoreString = playerScore.ToString ("###");
		scoreTextComp.text = scoreString;
	}
}
