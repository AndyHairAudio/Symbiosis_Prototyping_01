using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TreeHealthUI : MonoBehaviour {

	public Text treeText;

	// Use this for initialization
	void Start () {
		StartCoroutine (TreeChecker (1.0f));
		treeText = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator TreeChecker (float timer){
		while (true) {
			yield return new WaitForSeconds(timer);
			
			GrowingTree treeManager = GetComponentInParent<GrowingTree>();
			
			int currentHealth = treeManager.treeEnergy;
			string tempString = currentHealth.ToString();
			
			treeText.text = tempString;
		}
	}
}
