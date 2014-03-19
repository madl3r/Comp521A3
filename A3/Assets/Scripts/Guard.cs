using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Guard : MonoBehaviour {

	public List<GameObject> theWaypoints;
	
	public GuardBehaviorTree MahBrain; 
	
	private GameObject[]allWayPoints;
	
	public bool atNextPoint;
	private Vector3 startPosition, nextPosition;
	public GameObject currentWaypoint, nextWaypoint;
	private int nextPointInList;
	private float speed;
	private float startTime;
	private float journeyLength;
	private int rand;

	private Quaternion startRotation, nextRotation;

	
	
	float distCovered;// = (Time.time - startTime) * speed;

	
	// Use this for initialization
	void Start () {
		
		MahBrain.printName();

		speed = 4.0f;
		atNextPoint = true;
		transform.LookAt(theWaypoints[0].transform);
		
		allWayPoints = GameObject.FindGameObjectsWithTag("wayPointTag");
		
		rand = Random.Range(0, allWayPoints.Length - 1);
		
		transform.position = allWayPoints[rand].transform.position;
		currentWaypoint = allWayPoints[rand];


		MahBrain.Execute();
		
	}
	
	// Update is called once per frame
	void Update () {
		

		
	}

	public void move(GameObject pCurrent, GameObject pNext)
	{
		startTime = Time.time;
		startPosition = transform.position;

		currentWaypoint = pCurrent;
		nextWaypoint = pNext;

		//transform.LookAt(nextWaypoint.transform);
		slerpLook (nextWaypoint);
		
		nextPosition = nextWaypoint.transform.position;
		
		journeyLength = Vector3.Distance(startPosition, nextPosition);
		
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
		yield return new WaitForSeconds(0.25f);
		atNextPoint = true;
		yield break;
	}

	public void slerpLook(GameObject target)
	{
		startTime = Time.time;
		startRotation = transform.rotation;
		nextRotation = Quaternion.LookRotation(target.transform.position - transform.position);

		StartCoroutine (slerpLookTowards());
	}

	IEnumerator slerpLookTowards()
	{
		do
		{
			Debug.Log((Time.time - startTime /startTime) * 0.025f);
			transform.rotation = Quaternion.Slerp(startRotation, nextRotation, (Time.time - startTime) * 5f);
			yield return new WaitForSeconds(0.005f);
		}while ((transform.rotation.eulerAngles - nextRotation.eulerAngles).magnitude > 0.1f);


		Debug.Log("done looking");
		yield break;
	}
	
	IEnumerator lookAroundRoom()
	{
		//look around the room for a bit and semi randomly.
		yield break;
	}

}
