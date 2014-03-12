﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class GuardMoveAndLook : MonoBehaviour {

	public List<GameObject> theWaypoints;


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

		checkedRoom = false;
		speed = 4.0f;
		atNextPoint = true;
		transform.LookAt(theWaypoints[0].transform);

		allWayPoints = GameObject.FindGameObjectsWithTag("wayPointTag");

		rand = Random.Range(0, allWayPoints.Length - 1);

		transform.position = allWayPoints[rand].transform.position;
		currentWaypoint = allWayPoints[rand];


	}
	
	// Update is called once per frame
	void Update () {

		if (atNextPoint)
		{
			atNextPoint = false;
			startTime = Time.time;
			startPosition = transform.position;

			//Choose the next waypoint to go to
			
			Debug.Log("The current waypoints name: " + currentWaypoint.name);
			
			if (Regex.IsMatch(currentWaypoint.name, "^*INSIDE"))
			{
				//Can only go to currentWaypoints name - INSIDE
				Debug.Log("Started inside of a room");
				//Debug.Log(currentWaypoint.name.Substring(0, currentWaypoint.name.Length - 6));
				Debug.Log(currentWaypoint.name.Substring(0, currentWaypoint.name.Length - 6));
				nextWaypoint = GameObject.Find(currentWaypoint.name.Substring(0, currentWaypoint.name.Length - 6));
				checkedRoom = true;

			}
			else if (currentWaypoint.name == "MiddleWaypoint")
			{
				//can go to any WaypointRoom#
				Debug.Log("IN DAH MIDDLE!!!!!");
				checkedRoom = false;
				nextWaypoint = GameObject.Find("WaypointRoom" + Random.Range(1,6));
			}
			else if (Regex.IsMatch(currentWaypoint.name, "Way^*"))
			{
				//Can go to the next in the list, or the middle
				Debug.Log("STARED OUTSIDE OF A ROOM");

				//if didn't already look inside... look inside, otherwise go to the next in the list.
				if (!checkedRoom)
				{
					nextWaypoint = GameObject.Find(currentWaypoint.name + "INSIDE");
				}
				else
				{
					rand = Random.Range(0, 7);

					if (rand == 0)
					{
						nextWaypoint = GameObject.Find("MiddleWaypoint");
						Debug.Log("HEADING THE ~~~~~~~~~~~~~~~~~~~~~~~~~~~~ MIDDDAIL");
					}
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

								Debug.Log("FOUND DAH WAYPOINT");
							}
						}
					}
					//otherwise maybe choose the center from here
				}

				checkedRoom = false;
			}
			else
			{
				//can go to the next in the list.
				Debug.Log("SOME CORNER");

				for (int i = 0; i < theWaypoints.Count; i++)
				{
					if (theWaypoints[i].name.Equals(currentWaypoint.name))
					{
						nextWaypoint = theWaypoints[(i+1) % theWaypoints.Count];//GameObject.Find(currentWaypoint.name.Substring(0, j) + (1 + int.Parse(currentWaypoint.name.Substring(j, 1)) % 6));//
						
						//so that we don't always go to the middle on the last point.
						if ((i + 1) % theWaypoints.Count == 0)
							nextWaypoint = theWaypoints[1];

						Debug.Log("FOUND DAH WAYPOINT");
					}
				}
			}

			Debug.Log("THE NEXT WAYPOINT IS: " + nextWaypoint.name);

			transform.LookAt(nextWaypoint.transform);

		
			nextPosition = nextWaypoint.transform.position;

			journeyLength = Vector3.Distance(startPosition, nextPosition);

			StartCoroutine(toNextWaypoint());
			currentWaypoint = nextWaypoint;
		}
	
	}

	//Using coroutine so that waits feel good.
	//Lerps the door closed.
	IEnumerator toNextWaypoint()
	{
//		float i = 0.0f;
//		while(i < 1.0f)
//		{
//			i += Time.deltaTime * 0.25f;
//			//Debug.Log(i);
//			transform.position = Vector3.Lerp(startPosition, nextPosition, i);
//			yield return new WaitForSeconds(0.005f);
//		}
		float distCovered;// = (Time.time - startTime) * speed;
		float fracJourney = 0.0f;// = distCovered / journeyLength;
		while (fracJourney < 0.99f)
		{
			distCovered = (Time.time - startTime) * speed;
			fracJourney = distCovered / journeyLength;
			transform.position = Vector3.Lerp(startPosition, nextPosition, fracJourney);
			yield return new WaitForSeconds(0.005f);
		}
		atNextPoint = true;
		yield break;
	}
}
