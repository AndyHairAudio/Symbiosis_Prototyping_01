using UnityEngine;
using System.Collections;

public class LakeScaler : MonoBehaviour {

	void Awake () {
		Vector3 initialScale = new Vector3 (transform.localScale.x, 0f, transform.localScale.z);
		transform.localScale = initialScale;
	}

	// Use this for initialization
	void Start () {
		StartCoroutine (LakeScaling (0.25f));
	}
	
	// Update is called once per frame
	void Update () {

	}

	IEnumerator LakeScaling (float scaleTimer) {

		while (true) {
			yield return new WaitForSeconds (scaleTimer);

			GameObject treeObject = GameObject.FindGameObjectWithTag ("Tree"); //Grab the zone manager script
			GrowingTree refManager = treeObject.GetComponent<GrowingTree> ();
			
			if (refManager.treeIsGrowing && transform.localScale.y < 100f) {
				float speed = 0.005f;
				Vector3 one = new Vector3 (transform.localScale.x, refManager.treeEnergy);
				transform.localScale += one * speed * Time.deltaTime;
			}
			if (refManager.treeIsDecaying && transform.localScale.x > 0f) {
				float speed = 0.005f;
				Vector3 one = new Vector3 (transform.localScale.x, refManager.treeEnergy);
				transform.localScale -= one * speed * Time.deltaTime;
			}

		}
	}
}
