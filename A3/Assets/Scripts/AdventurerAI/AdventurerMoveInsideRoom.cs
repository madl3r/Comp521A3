using UnityEngine;
using System.Collections;

public class AdventurerMoveInsideRoom : BehaviorNode {
	
	public Adventurer thief;
	
	private bool doneThisRoom, startedThisRoom;
	private int roomTreasureCount;
	//private GameObject[] theseTreasures;
	private GameObject thisTreasure;

	// Use this for initialization
	void Start () {
		doneThisRoom = false;
		startedThisRoom = false;
		thisTreasure = null;
	}
	
	
	public override void Execute()
	{
		//Debug.Log("~~~~~~~~~~~~~~~~In adventurerInsideMove");
		if (!startedThisRoom)
		{
			//Debug.Log("Starting a new room ~~~~~~~~~~~~~~~~~~~~~~~~8=======================D~~~~~~~~~~~~~");
			doneThisRoom = false;
			startedThisRoom = true;
			roomTreasureCount = 3;
		}

		//If we don't have a target treasure... find one!!
		if (thisTreasure == null && roomTreasureCount > 0)
		{
			//Debug.Log("Getting a new treasure for " + thief.currentWaypoint.ToString() + "  &&&&&&&&&&&&&&&&&%%%%%%%%%%%%%%%%%");
			roomTreasureCount--; //if we're here that means that we must have picked one up.
			float wpDistance;
			float thisDistance;
			foreach (GameObject t in thief.theTreasures)
			{
				if (t != null)
				{
					if (thisTreasure == null)
						thisTreasure = t;

					thisDistance = Mathf.Abs((thisTreasure.transform.position - thief.currentWaypoint.transform.position).magnitude);
					wpDistance = Mathf.Abs((t.transform.position - thief.currentWaypoint.transform.position).magnitude);

					if (wpDistance < thisDistance)
					{
						thisTreasure = t;
					}
				}
			}
		}
		//We must have a treasure to go to... move towards it!
		else if (roomTreasureCount > 0)
		{
			thief.transform.position += (thisTreasure.transform.position - thief.transform.position).normalized * 0.2f;
		}

		//then move towards the thiefs current waypoint.
		if (roomTreasureCount <= 0)
		{
//			Debug.Log(thief.currentWaypoint.ToString());
//			Debug.Log("Trying to leaave");
//
//			Debug.Log("1: " + thief.transform.position);

			thief.transform.position += ((thief.currentWaypoint.transform.position - thief.transform.position).normalized)  * 0.2f;

//			Debug.Log(thief.transform.position);
			//thief.transform.position = thief.currentWaypoint.transform.position;

//			Debug.Log((thief.currentWaypoint.transform.position - thief.transform.position).magnitude);

			if ((thief.currentWaypoint.transform.position - thief.transform.position).magnitude < 0.5f)
			{
//				Debug.Log("MADE IT THERE!");
				doneThisRoom = true;
			}
		}

		//Current (maybe next?) waypoint should be closest to the two treasures in this room.

		if (doneThisRoom)
		{
//			Debug.Log("00000000000000LEAVING dah room");
			theRetVal = mattsBool.True;
			parent.setTurn(theRetVal);
			startedThisRoom = false;
			thisTreasure = null;
			isMyTurn = false;
			return;
		}

	}
}
