using UnityEngine;
using System.Collections;

public class GuardHangOutNode : BehaviorNode {

	public Guard thisGuard;
	private float startTime;
	private bool started = false;
	private bool doneHangin = false;
	// Use this for initialization
	void Start () {
	
	}

	public override void Execute()
	{
		if (!started)
		{
			started = true;
			doneHangin = false;
			startTime = Time.time;
		}

//		Debug.Log("~~~~~~~~~~~~~~~~~~" + (Time.time - startTime));

		if (Time.time - startTime > 3f && !doneHangin)
		{
//			Debug.Log("~~~~~~~~~~~~~~~~~~~~~~~~~~~DONE WAITING");
			thisGuard.closeGuard = false;
			thisGuard.move();
			doneHangin = true; 

		}

		if (doneHangin && thisGuard.doneMoving)
		{
//			Debug.Log("POST HANGOUT MOVE DONE ~~~~~~~~~~~~~~~~");
			started = false;
			isMyTurn = false;
			theRetVal = mattsBool.True;
			parent.setTurn(theRetVal);
		}


		//		Debug.Log("~~~~~~~~~~~~~~~~~~~~Did moving take any time?!");
	}

}
