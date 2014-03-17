using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Behavior {

	public List<Behavior> children;
	public Behavior parent;

	
	public Behavior()
	{
		children = new List<Behavior>();
		parent = null;
	}


	public bool Execute()
	{
		children.Add(new Selector());
		children[0].printName();
		Debug.Log("RUNNING THE EXECUTE");
		return true;
	}

	public void printName()
	{
		Debug.Log("SHOULD BE PRINTING SELECTORS NAME");
	}
}
