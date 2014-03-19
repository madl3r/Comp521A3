using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public  class BehaviorNode : MonoBehaviour {


	public enum mattsBool {False, True, Meh};

	// Use this for initialization
	public List<BehaviorNode> children;
	public BehaviorNode parent = null;

	public bool isMyTurn;
	public mattsBool theRetVal;

	void Start()
	{

	}


	void Update()
	{
		if(!isMyTurn)
			return;
		Execute();
	}

	public void setTurn(mattsBool success)
	{
		theRetVal = success;
		isMyTurn = true;
	}

	public virtual void Execute()
	{
		Debug.Log("In the abstract execute");
	}

}
