using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class AdventurerChooseWaypoint : BehaviorNode {
	
	public Adventurer thief;
	
	
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
		
		theWaypoints = thief.theWaypoints;
		
		checkedRoom = false;
		speed = 4.0f;
		atNextPoint = true;
		
		allWayPoints = GameObject.FindGameObjectsWithTag("wayPointTag");
		
		
		currentWaypoint = thief.currentWaypoint;
		nextWaypoint = currentWaypoint;

		
	}
	
	
	public override void Execute()
	{
		isMyTurn = false;
		//Debug.Log("Choosing waypoint");
		
		if (thief.atNextPoint)
		{
			thief.doneMoving = false;
			//Debug.Log("thief ACTUALLY CHOOSING");

			currentWaypoint = nextWaypoint;
			thief.currentWaypoint = currentWaypoint;

//			currentWaypoint = thief.currentWaypoint;

			//Currently Inside of a room! so return false
			if (Regex.IsMatch(currentWaypoint.name, "^*INSIDE"))
			{
				if (!checkedRoom)
				{//RETURNING FALSE HERE, SO WILL GO TO INSIDE ROOM LOGIC
					//Debug.Log("~~~~~~~~~~INSIDE A ROOM");
					theRetVal = mattsBool.False;
					parent.setTurn(theRetVal);
					checkedRoom = true;
					return;
				}
				else
				{
					Debug.Log("Now leaving the room");
					nextWaypoint = GameObject.Find(currentWaypoint.name.Substring(0, currentWaypoint.name.Length - 6));
				}
					//
			}
			//If in the middle choose somewhere to start randomly for now
			else if (currentWaypoint.name == "MiddleWaypoint")
			{
				checkedRoom = false;
				nextWaypoint = GameObject.Find("WaypointRoom" + Random.Range(1,6)); //Be smarter later
			}
			//If outside of a room
			else if (Regex.IsMatch(currentWaypoint.name, "Way^*"))
			{
				//Can go to the next in the list, or the middle
				//	Debug.Log("STARED OUTSIDE OF A ROOM");
				
				//if didn't already look inside... look inside, otherwise go to the next in the list.
				if (!checkedRoom)
				{
					nextWaypoint = GameObject.Find(currentWaypoint.name + "INSIDE");
				}
				//Go to the next one on the list!
				else
				{
					for (int i = 0; i < theWaypoints.Count; i++)
					{
						if (theWaypoints[i].name.Equals(currentWaypoint.name))
						{
							//int j = currentWaypoint.name.Length - 1;

							nextWaypoint = theWaypoints[(i+1) % theWaypoints.Count];//GameObject.Find(currentWaypoint.name.Substring(0, j) + (1 + int.Parse(currentWaypoint.name.Substring(j, 1)) % 6));//

							//so that we don't always go to the middle on the last point.
							if ((i + 1) % theWaypoints.Count == 0)
								nextWaypoint = theWaypoints[1];

							//	Debug.Log("FOUND DAH WAYPOINT");
						}
					}
				}
				
				checkedRoom = false;
			}


			
//			if (Regex.IsMatch(currentWaypoint.name, "^*INSIDE"))
//			{
//				Debug.Log("~~~~~~~~~~INSIDE A ROOM");
//				theRetVal = mattsBool.False;
//				parent.setTurn(theRetVal);
//				return;
//			}
			thief.currentWaypoint = currentWaypoint;
			thief.nextWaypoint = nextWaypoint;

		}
		theRetVal = mattsBool.True;
		parent.setTurn(theRetVal);
	}
}
