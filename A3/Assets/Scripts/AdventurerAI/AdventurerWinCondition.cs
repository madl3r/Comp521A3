using UnityEngine;
using System.Collections;

public class AdventurerWinCondition : BehaviorNode {
	
	public Adventurer thief;
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	
	public override void Execute()
	{
		isMyTurn = false;
		theRetVal = mattsBool.False;

		if (thief.score >= 16)
		{
			theRetVal = mattsBool.True;
		}

		parent.setTurn(theRetVal);
	}
}
