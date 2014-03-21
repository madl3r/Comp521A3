using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GuardCheckCloseBuddies : BehaviorNode {

	public Guard thisGuard;

	public GameObject[] theGuards;

	private float StartedHangingOut = 0;
	private float smallestMag;

	// Use this for initialization
	void Start () {
		
	}
	
	public override void Execute()
	{
		isMyTurn = false;

		if (thisGuard.closeGuard)
		{
			theRetVal = mattsBool.True;
		}
		else
		{
			theRetVal = mattsBool.False;
		}
//		if (Time.time - StartedHangingOut > 10000)
//		{
//			StartedHangingOut = Time.time;
//			smallestMag = 1000.0f;
//			theGuards = GameObject.FindGameObjectsWithTag("guard");
//		
//			foreach (GameObject otherGuard in theGuards)
//			{
//				if (otherGuard != thisGuard && (otherGuard.transform.position - thisGuard.transform.position).magnitude < smallestMag)
//				{
//					smallestMag = (otherGuard.transform.position - thisGuard.transform.position).magnitude; 
//				}
//			}
//
//			if (smallestMag < 1.0f)
//				theRetVal = mattsBool.True;
//			else
//				theRetVal = mattsBool.False;
//
//		}
//		else
//		{
//			theRetVal = mattsBool.False;
//		}

		parent.setTurn(theRetVal);
	}
	
}