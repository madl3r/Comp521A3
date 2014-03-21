using UnityEngine;
using System.Collections;

public class AdventurerMoveNode : BehaviorNode {
	
	public Adventurer thief;
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	
	public override void Execute()
	{
		if (thief.atNextPoint && !thief.doneMoving)
		{
			//Debug.Log("THIEF~~~~~~~~~~~~~~~ORDERING TO MOVE");
			//Debug.Log("TRYING TO MOOOOVE");
			thief.atNextPoint = false;
			thief.doneMoving = false;
			thief.move();
		}
		
		if (thief.doneMoving)
		{
			//Debug.Log("THIEF Finished Moving");
			theRetVal = mattsBool.True;
			parent.setTurn(theRetVal);
			isMyTurn = false;
		}
		
		//		Debug.Log("~~~~~~~~~~~~~~~~~~~~Did moving take any time?!");
	}
}
