using UnityEngine;
using System.Collections;

public class GuardHangOutNode : BehaviorNode {

	// Use this for initialization
	void Start () {
	
	}

	public override void Execute()
	{
		
		//Debug.Log("Shouldn't be hanging out");
		isMyTurn = false;
		theRetVal = mattsBool.False;
		parent.setTurn(theRetVal);
		//		Debug.Log("~~~~~~~~~~~~~~~~~~~~Did moving take any time?!");
	}

}
