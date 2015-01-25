using UnityEngine;
using System.Collections;

public class EnergyChannel : MonoBehaviour {

	public bool isChanneling;
	public bool isWithdrawing;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	void OnGUI(){
		isWithdrawing = false;
		isChanneling = false;
		Texture2D mouseIcon = (Texture2D)Resources.Load("Mouse1ClickIcon", typeof(Texture2D));
		RaycastHit rayHit;
		Ray cameraRay = new Ray (transform.position, transform.forward);
		Debug.DrawRay (transform.position, transform.forward * 5.0f);
		
		if(Physics.Raycast(cameraRay, out rayHit, 5.0f)){
			
			if(rayHit.collider.tag == "EnergyPort"){
				GUI.DrawTexture(new Rect(Screen.width/10 * 4.5f, Screen.height/10 * 7, 64, 64), mouseIcon, ScaleMode.ScaleToFit, true, 1.0F);
				if(Input.GetButton ("Fire1")) {
					isWithdrawing = false;
					isChanneling = true;
					//Debug.Log ("Channeling");
				}
				if(Input.GetButton ("Fire2")){
					isChanneling = false;
					isWithdrawing = true;
					//Debug.Log ("Channeling");
				}
			}
		}
	}
}
