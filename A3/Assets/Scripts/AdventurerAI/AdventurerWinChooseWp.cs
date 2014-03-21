using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;

public class AdventurerWinChooseWp : BehaviorNode {
	
	public Adventurer thief;
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	
	public override void Execute()
	{
		isMyTurn = false;
		//If outside of a room
		if (Regex.IsMatch(thief.currentWaypoint.name, "Way^*"))
		{
			thief.nextWaypoint = GameObject.Find("MiddleWaypoint");
			theRetVal = mattsBool.True;
		}
		else
		{
			theRetVal = mattsBool.False;
		}
		parent.setTurn(theRetVal);
	}



}
