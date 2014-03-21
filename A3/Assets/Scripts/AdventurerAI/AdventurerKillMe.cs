using UnityEngine;
using System.Collections;

public class AdventurerKillMe : BehaviorNode {
	
	public Adventurer thief;
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	
	public override void Execute()
	{
		isMyTurn = false;

		Debug.Log("Trying to escape");
		GameObject middle = GameObject.Find("MiddleWaypoint");

//		//If outside of a room
//		if ((middle.transform.position - thief.transform.position).magnitude < 0.5f)
//		{
			Debug.Log("Close enough to the middle!");
			theRetVal = mattsBool.True;
		GameObject.Destroy(thief.gameObject);
//		}
		parent.setTurn(theRetVal);
	}
}
