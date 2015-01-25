using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GUIEnergy : MonoBehaviour {

	public Text tempText;

	// Use this for initialization
	void Start () {
	
		StartCoroutine (EnergyChecker (0.1f));
		tempText = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator EnergyChecker (float timer){
		while (true) {
			yield return new WaitForSeconds(timer);

			GameObject playerObject = GameObject.Find("First Person Controller");
			ShadeManager tempManager = playerObject.GetComponent<ShadeManager>();

			int currentTemp = tempManager.playerHeat;
			string tempString = currentTemp.ToString();

			tempText.text = tempString;
		}
	}
}
