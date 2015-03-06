using UnityEngine;
using System.Collections;

public class TerrainCollision : MonoBehaviour {

	void OnTriggerStay (Collider other)
	{
		if (other.collider.tag == "ForestTerrain") {

			transform.Translate (new Vector3(0, 0.1f, 0));
		}
	}
}
