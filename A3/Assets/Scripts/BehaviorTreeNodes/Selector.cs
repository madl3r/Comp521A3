using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Selector : BehaviorNode{

	private int index = -1;

	public override void Execute()
	{
		Debug.Log("Selectors Eggsecute");
		isMyTurn = false;

		if (index == -1)
		{
			theRetVal = mattsBool.Meh;
		}
		else if (index + 1 >= children.Count)
		{
			//we done, so return
			index = -1;
			theRetVal = mattsBool.False;
			parent.setTurn(theRetVal);
			return;
		}
		else if (children[index].theRetVal == mattsBool.True)
		{
			index = -1;
			theRetVal = mattsBool.True;
			parent.setTurn(theRetVal);
			return;
		}

		index += 1;
		children[index].setTurn(mattsBool.Meh);


	}

}
