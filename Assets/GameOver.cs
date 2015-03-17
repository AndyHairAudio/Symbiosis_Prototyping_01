using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine (GameOverScreen (1.0f));
	}

	IEnumerator GameOverScreen (float overTimer){

		while (true) {
						yield return new WaitForSeconds (overTimer);

						GameObject player = GameObject.FindGameObjectWithTag ("Player");
						ObjectCollector controller = player.GetComponent<ObjectCollector> ();

						if (controller.playerHealth <= 0) {

								this.gameObject.SetActive(false);
						}
				}
	}
}
