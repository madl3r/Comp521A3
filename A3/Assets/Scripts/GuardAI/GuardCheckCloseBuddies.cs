using UnityEngine;
using System.Collections;

public class GuardCheckCloseBuddies : BehaviorNode {
	
	// Use this for initialization
	void Start () {
		
	}
	
	public override void Execute()
	{
		Debug.Log("Looking for buddies");
		isMyTurn = false;
		theRetVal = mattsBool.False;
		parent.setTurn(theRetVal);
	}
	
}