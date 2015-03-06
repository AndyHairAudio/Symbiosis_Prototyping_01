using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealthUI : MonoBehaviour {

	Text healthText;

	// Use this for initialization
	void Start () {
		StartCoroutine (TreeChecker (1.0f));
		healthText = GetComponent<Text>();
	}

	IEnumerator TreeChecker (float timer){
		while (true) {
			yield return new WaitForSeconds(timer);
			GameObject playerController = GameObject.FindGameObjectWithTag("Player");
			ObjectCollector playerManager = playerController.GetComponent<ObjectCollector>();

			float currentHealth = playerManager.playerHealth;
			string tempString = currentHealth.ToString("##");
			
			healthText.text = tempString;
		}
	}
}
