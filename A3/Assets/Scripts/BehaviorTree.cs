using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BehaviorTree : MonoBehaviour {
	
	public Behavior run;


	void Start()
	{
		run = new Behavior();
		run.Execute();
	}
	
	
	public void Execute()
	{

	}

	public void printName()
	{
		Debug.Log("HELLO BITCHES");
	}
	
	
}
