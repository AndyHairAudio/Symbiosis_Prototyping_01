#pragma strict

var waterVis : WaterVisuals;

function Start () {
	waterVis = gameObject.GetComponentInParent(WaterVisuals);
}

function Update () {
	if(waterVis.shroomed == true){
		gameObject.tag = "Shroomed";
	}
	else {
		gameObject.tag = "Untagged";
	}
}