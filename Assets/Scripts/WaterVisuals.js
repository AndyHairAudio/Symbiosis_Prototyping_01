#pragma strict

var colorComp : ColorCorrectionCurves;
colorComp = gameObject.GetComponent(ColorCorrectionCurves);
var blurComp : Blur;
blurComp = gameObject.GetComponent(Blur);
var vignette : Vignetting;
vignette = gameObject.GetComponent(Vignetting);
var timeOfMushroomEat : float;
var camz : Camera;
var shroomObj : GameObject;
var shroomed = false;
	
function Start () {
	camz = this.GetComponent(Camera);
}

function Update() {
	var ray = camz.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0f));
	var hit : RaycastHit;
	if (Physics.Raycast(ray, hit, 10.0f)){
		Debug.DrawLine (ray.origin, hit.point);
		if(hit.transform.tag == "Mushrooms"){
		print("Hitting mushrooms");
			if(Input.GetButtonDown("Fire1")){
				vignette.chromaticAberration = 0.0f;
				StartCoroutine (VisualDistort());
				timeOfMushroomEat = Time.time;
				vignette.enabled = true;
				shroomed = true;
			}
		}
	}
	if ((timeOfMushroomEat + 120.0f) < Time.time){
		vignette.enabled = false;
		shroomed = false;
	}	
}

function VisualDistort (){
	while(true){
		yield WaitForSeconds (0.05f);
		if(vignette.chromaticAberration < 120.0f){
			vignette.chromaticAberration = vignette.chromaticAberration + 0.25f;
		}
	}
}

function OnTriggerStay (other : Collider){
	if (other.tag == "LakeWaterCollider") {
			colorComp.enabled = true;
			blurComp.enabled = true;
		}
}

function OnTriggerExit (other : Collider){
	if (other.tag == "LakeWaterCollider") {
			colorComp.enabled = false;
			blurComp.enabled = false;
		}

}