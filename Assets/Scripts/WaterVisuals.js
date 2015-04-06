#pragma strict

var colorComp : ColorCorrectionCurves;
	colorComp = gameObject.GetComponent(ColorCorrectionCurves);
	var blurComp : Blur;
	blurComp = gameObject.GetComponent(Blur);
function Start () {
	
}

function Update () {

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