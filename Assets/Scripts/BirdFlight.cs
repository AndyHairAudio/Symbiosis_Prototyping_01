﻿using UnityEngine;
using System.Collections;

public class BirdFlight : MonoBehaviour {

	NavMeshAgent agentComp;
	GameObject[] targets;
	int targetSelector;

	// Use this for initialization
	void Start () {
		agentComp = gameObject.GetComponent<NavMeshAgent> ();
		targets = GameObject.FindGameObjectsWithTag("FlightTarget");
		targetSelector = Random.Range(0, targets.Length);
		agentComp.SetDestination (targets[targetSelector].transform.position);
	}

	void Update() {
		if (agentComp.remainingDistance < 20.0f) {
			targetSelector = Random.Range(0, targets.Length);
			agentComp.SetDestination (targets[targetSelector].transform.position);
		}
	}
}
