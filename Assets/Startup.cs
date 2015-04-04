using UnityEngine;
using System.Collections;

public class Startup : MonoBehaviour {

	IEnumerator Start (){

		yield return new WaitForSeconds (3.0f);

		Application.LoadLevel ("MenuScene");
	}
}
