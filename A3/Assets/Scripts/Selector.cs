using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Selector : Behavior{

	public Selector()
	{
		children = new List<Behavior>();
		Debug.Log("WHAT THE ACTUAL FUCK");

	}

	public bool Execute()
	{
		Debug.Log("Selector EXECUTE");
		return true;
	}

	public void printName()
	{
		Debug.Log("NAAAAAMMME");
	}
}
