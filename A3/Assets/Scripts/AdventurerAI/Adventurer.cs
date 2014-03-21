using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Adventurer : MonoBehaviour {

	public List<GameObject> theWaypoints;
	public bool doneMoving;
	public GameObject[] theTreasures;

	public AdventurerBehaviorTree AdventurerBrain; 
	
	private GameObject[]allWayPoints;
	

	public int score;


	public bool atNextPoint;
	private Vector3 startPosition, nextPosition;
	private Vector3 velocity;
	public GameObject currentWaypoint, nextWaypoint;
	private int nextPointInList;
	private float speed;
	private float startTime;
	private float journeyLength;
	


	// Use this for initialization
	void Start () {

		score = 0;
		doneMoving = false;
		speed = 8.0f;
		atNextPoint = true;
		transform.LookAt(theWaypoints[0].transform);
		
		allWayPoints = GameObject.FindGameObjectsWithTag("wayPointTag");
		theTreasures = GameObject.FindGameObjectsWithTag("treasureTag");
		

		
		transform.position = theWaypoints[0].transform.position;
		currentWaypoint = theWaypoints[0];

		AdventurerBrain.Execute();

	}
	
	// Update is called once per frame
	void Update () {
//		transform.position += velocity;
		transform.rigidbody.velocity = Vector3.zero;
	}


	public void move()
	{
		startTime = Time.time;
		startPosition = transform.position;
		
		nextPosition = nextWaypoint.transform.position;
		
		journeyLength = Vector3.Distance(startPosition, nextPosition);

		//Debug.Log("~~~~~~~~!!!!!!!!!!!!!!!0000000MOVING TO: " + nextWaypoint.ToString());

		StartCoroutine(toNextWaypoint());
	}
	
	//Using coroutine so that waits feel good.
	//Lerps the door closed.
	IEnumerator toNextWaypoint()
	{
		float distCovered;// = (Time.time - startTime) * speed;
		float fracJourney = 0.0f;// = distCovered / journeyLength;
		while (fracJourney < 0.99f)
		{
			distCovered = (Time.time - startTime) * speed;
			fracJourney = distCovered / journeyLength;
			transform.position = Vector3.Lerp(startPosition, nextPosition, fracJourney);
			yield return new WaitForSeconds(0.005f);
		}
		
		//now that we're at the point we check to see if this point is inside of a room
		//If we're inside of a room let's hang out for a bit and look around.
		//DON'T DO THAT HERE, IN THE UPDATE METHOD IF WE DETECT A CLOSE ENOUGH GUARD, THEN CANCEL ALL COROUTINES 
		// AND THEN SWITCH TO HANG OUT MODE. ONCE DONE MOVE BACK TO THIS STATE FROM THE CURRENT TO THE PREVIOUS NEXT POINT.
		
		//lets us look for the next point in update!
		//yield return new WaitForSeconds(Random.Range(0.0f, 0.5f));
		//currentWaypoint = nextWaypoint;
		atNextPoint = true;
		doneMoving = true;
		yield break;
	}

}
