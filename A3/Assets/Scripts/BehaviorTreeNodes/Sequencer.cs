using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Sequencer : BehaviorNode{


	private int index = -1;
	
	public override void Execute()
	{
		Debug.Log("IN THE SEQUENCER");
		isMyTurn = false;

		if (index == -1)
		{
			theRetVal = mattsBool.Meh;
		}
		else if (children[index].theRetVal == mattsBool.False)
		{
			Debug.Log("SEQUENCER FAILED");
			index = -1;
			theRetVal = mattsBool.False;
			parent.setTurn(theRetVal);
			return;
		}
		else if (index + 1 >= children.Count)
		{
			//we done, so return
			index = -1;
			theRetVal = mattsBool.True;
			parent.setTurn(theRetVal);
			return;
		}
		
		index += 1;
		children[index].setTurn(mattsBool.Meh);
		
		
	}

}
