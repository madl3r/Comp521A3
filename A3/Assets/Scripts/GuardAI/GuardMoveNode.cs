using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;


public class GuardMoveNode : BehaviorNode {

	public Guard thisGuard;


	private List<GameObject> theWaypoints;
	
	private GameObject[]allWayPoints;
	
	private bool atNextPoint, checkedRoom;
	private Vector3 startPosition, nextPosition;
	private GameObject currentWaypoint, nextWaypoint;
	private int nextPointInList;
	private float speed;
	private float startTime;
	private float journeyLength;
	private int rand;
	
	
	float distCovered;// = (Time.time - startTime) * speed;
	float fracJourney = 0.0f;// = distCovered / journeyLength;
	

	// Use this for initialization
	void Start () {
		theWaypoints = thisGuard.theWaypoints;
		
		checkedRoom = false;
		speed = 4.0f;
		atNextPoint = true;
		
		allWayPoints = GameObject.FindGameObjectsWithTag("wayPointTag");
		

		currentWaypoint = thisGuard.currentWaypoint;
		nextWaypoint = currentWaypoint;
		
		Debug.Log(currentWaypoint.name);
		
	}


	public override void Execute()
	{



		if (thisGuard.atNextPoint && !thisGuard.doneMoving)
		{
			Debug.Log("~~~~~~~~~~~~~~~ORDERING TO MOVE");
			//Debug.Log("TRYING TO MOOOOVE");
			thisGuard.atNextPoint = false;
			thisGuard.doneMoving = false;
			thisGuard.move();
		}

		if (thisGuard.doneMoving)
		{
			Debug.Log("Finished Moving");
			theRetVal = mattsBool.True;
			parent.setTurn(theRetVal);
			isMyTurn = false;
		}

//		Debug.Log("~~~~~~~~~~~~~~~~~~~~Did moving take any time?!");
	}

	public void printName()
	{
		Debug.Log("In the guard move class.");
	}

}
