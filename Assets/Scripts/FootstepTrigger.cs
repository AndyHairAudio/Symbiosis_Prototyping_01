using UnityEngine;
using System.Collections;

public class FootstepTrigger : MonoBehaviour {

	CharacterController controllerFinder;
	bool stillMoving;
	bool routineRunning;
	float footstepInterval;

	// Use this for initialization
	void Start () {
		controllerFinder = this.GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {

				if (controllerFinder.velocity.magnitude < 0.5) {
						stillMoving = false;
				}
				if (controllerFinder.velocity.magnitude > 0.5) {
						if (!routineRunning) {
								routineRunning = true;
								StartCoroutine (FootstepTiming ());
						}
						stillMoving = true;
				}

				if (controllerFinder.velocity.magnitude > 4) {
						footstepInterval = 0.45f;
				} else if (controllerFinder.velocity.magnitude > 3 && controllerFinder.velocity.magnitude < 4) {
						footstepInterval = 0.5f;
				} else if (controllerFinder.velocity.magnitude > 2 && controllerFinder.velocity.magnitude < 3) {
						footstepInterval = 0.6f;
				} else if (controllerFinder.velocity.magnitude > 1 && controllerFinder.velocity.magnitude < 2) {
						footstepInterval = 0.75f;
				}
	}

	IEnumerator FootstepTiming (){

		while (stillMoving) {

			AkSoundEngine.PostEvent ("Play_Footsteps", this.gameObject);

			yield return new WaitForSeconds (footstepInterval);
		}

		routineRunning = false;
	}
}
