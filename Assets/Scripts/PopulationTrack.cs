using UnityEngine;
using System.Collections;

public class PopulationTrack : MonoBehaviour {

	public int treePop;
	public int fishPop;
	public int wolfPop;
	public int fruitPop;

	// Use this for initialization
	void Start () {
		StartCoroutine (PopTrack (1.0f));
	}
	
	IEnumerator PopTrack (float trackTimer){
		
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
