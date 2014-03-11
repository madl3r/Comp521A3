using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GuardMoveAndLook : MonoBehaviour {

	public List<GameObject> theWaypoints;

	// Use this for initialization
	void Start () {
		transform.LookAt(theWaypoints[0].transform);
	}
	
	// Update is called once per frame
	void Update () {


	
	}
}
