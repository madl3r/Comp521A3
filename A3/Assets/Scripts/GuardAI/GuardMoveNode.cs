using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;


public class GuardMoveNode : BehaviorNode {

	public Guard thisGuard;
		

	// Use this for initialization
	void Start () {
				
	}


	public override void Execute()
	{
		//Debug.Log("~~~~~~~~~~~~~~~~~~~~~~TRYING TO MOVE");
		if (thisGuard.atNextPoint && !thisGuard.doneMoving)
		{
			//Debug.Log("~~~~~~~~~~~~~~~ORDERING TO MOVE");
			//Debug.Log("TRYING TO MOOOOVE");
			thisGuard.atNextPoint = false;
			thisGuard.doneMoving = false;
			thisGuard.move();
		}



		if (thisGuard.doneMoving)
		{
			//Debug.Log("Finished Moving");
			theRetVal = mattsBool.True;
			parent.setTurn(theRetVal);
			isMyTurn = false;
		}

		if (thisGuard.closeGuard)
		{
			theRetVal = mattsBool.False;
			parent.setTurn(theRetVal);
			isMyTurn = false;
		}

//		Debug.Log("~~~~~~~~~~~~~~~~~~~~Did moving take any time?!");
	}

	public void printName()
	{
		Debug.Log("In the guard move class.");
	}

}
