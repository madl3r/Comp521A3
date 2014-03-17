using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Sequencer : Behavior{

	public Sequencer()
	{
		children = new List<Behavior>();
		
	}

	
	public bool Execute()
	{
		Debug.Log("DAAAHHH SEQUENCER EXECUTE");
		return true;
	}

}
