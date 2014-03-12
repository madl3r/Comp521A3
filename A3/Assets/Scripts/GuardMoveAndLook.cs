using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class GuardMoveAndLook : MonoBehaviour {

	public List<GameObject> theWaypoints;


	private GameObject[]allWayPoints;

	private bool atNextPoint, moving;
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

		speed = 4.0f;
		atNextPoint = true;
		moving = false;
		transform.LookAt(theWaypoints[0].transform);

		allWayPoints = GameObject.FindGameObjectsWithTag("wayPointTag");

		rand = Random.Range(0, allWayPoints.Length - 1);

		nextPointInList = rand % theWaypoints.Count;
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
			
			Debug.Log(currentWaypoint.name);
			
			if (Regex.IsMatch(currentWaypoint.name, "^*INSIDE"))
			{
				//Can only go to currentWaypoints name - INSIDE
				Debug.Log("Started inside of a room");
				//Debug.Log(currentWaypoint.name.Substring(0, currentWaypoint.name.Length - 6));
				nextWaypoint = GameObject.Find(name.Substring(0, currentWaypoint.name.Length - 6));

			}
			else if (currentWaypoint.name == "MiddleWaypoint")
			{
				//can go to any WaypointRoom#
				Debug.Log("IN DAH MIDDLE!!!!!");
				nextWaypoint = GameObject.Find("WaypointRoom" + Random.Range(1,6));
			}
			else if (Regex.IsMatch(currentWaypoint.name, "Way^*"))
			{
				//Can go to the next in the list, or the middle
				Debug.Log("STARED OUTSIDE OF A ROOM");

				//if didn't already look inside... look inside, otherwise go to the next in the list.
			}
			else
			{
				//can go to the next in the list.
				Debug.Log("SOME CORNER");
			}

			Debug.Log(nextWaypoint.name);

			transform.LookAt(theWaypoints[nextPointInList].transform);

		
			nextPosition = theWaypoints[nextPointInList].transform.position;


			journeyLength = Vector3.Distance(startPosition, nextPosition);

			StartCoroutine(toNextWaypoint());


			nextPointInList = (nextPointInList + 1) % theWaypoints.Count;

			moving = true;
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
		while (fracJourney < 0.95f)
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
