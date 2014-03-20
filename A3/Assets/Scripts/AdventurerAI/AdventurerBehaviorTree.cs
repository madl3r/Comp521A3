using UnityEngine;
using System.Collections;

public class AdventurerBehaviorTree : MonoBehaviour {

	public BehaviorNode root;
	public Adventurer thief;
	
	void Start()
	{
		Debug.Log("In the start of the Brain");
	}
	
	
	public void Execute()
	{
		root.setTurn(BehaviorNode.mattsBool.Meh);
	}
	
	public void printName()
	{
		Debug.Log("Brain here!");	
	}
}
