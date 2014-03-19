using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Selector : BehaviorNode{

	private int index = -1;

	public override void Execute()
	{
		//Debug.Log("Selectors Eggsecute");

		if (index == -1)
		{
			theRetVal = mattsBool.Meh;
		}
		else if (index + 1 >= children.Count)
		{
			//we done, so return
			theRetVal = mattsBool.False;
			return;
		}
		else if (children[index].theRetVal == mattsBool.True)
		{
			theRetVal = mattsBool.True;
			return;
		}

		index += 1;
		children[index].setTurn(mattsBool.False);


	}

}
