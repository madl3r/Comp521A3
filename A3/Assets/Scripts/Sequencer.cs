using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Sequencer : BehaviorNode{


	private int index = -1;
	
	public new void Execute()
	{
		
		if (index == -1)
		{
			theRetVal = mattsBool.Meh;
		}
		else if (index >= children.Count)
		{
			//we done, so return
			theRetVal = mattsBool.True;
			return;
		}
		else if (children[index].theRetVal == mattsBool.False)
		{
			theRetVal = mattsBool.False;
			return;
		}
		
		index += 1;
		children[index].setTurn(mattsBool.Meh);
		
		
	}

}
