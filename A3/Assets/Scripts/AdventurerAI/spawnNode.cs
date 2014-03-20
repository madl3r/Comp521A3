using UnityEngine;
using System.Collections;

public class spawnNode : BehaviorNode {

	public Adventurer thief;

	// Use this for initialization
	void Start () {
		
	}
	
	public override void Execute()
	{
		
		Debug.Log("Spawn the player");
		isMyTurn = false;
		theRetVal = mattsBool.False;
		parent.setTurn(theRetVal);
		//		Debug.Log("~~~~~~~~~~~~~~~~~~~~Did moving take any time?!");
	}
}
