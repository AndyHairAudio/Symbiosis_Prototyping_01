using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

	ObjectCollector playerManager;
	Slider healthSlider;
	float currentHealth;

	// Use this for initialization
	void Start () {
		playerManager = GameObject.FindGameObjectWithTag("Player").GetComponent<ObjectCollector>();
		healthSlider = gameObject.GetComponent<Slider> ();
		StartCoroutine (TreeChecker (0.1f));
	}
	
	IEnumerator TreeChecker (float timer){
		while (true) {
			yield return new WaitForSeconds(timer);
			
			currentHealth = playerManager.playerHealth;
			
			healthSlider.value = currentHealth;
		}
	}
}
