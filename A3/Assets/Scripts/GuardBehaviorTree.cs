using UnityEngine;
using System.Collections;

public class GuardBehaviorTree : MonoBehaviour {

	public BehaviorNode root;
	public Guard thisGuard;
	
	void Start()
	{
		Debug.Log("In the start of the Brain");
	}
	
	
	public void Execute()
	{
		//		StartCoroutine(root.Execute());
		//for (int i = 0; i < 1; i++)
		//{		
			root.setTurn(BehaviorNode.mattsBool.Meh);
			//Debug.Log("~~~~~~~~~~~~Now after exectuing the root");
		//}
	}
	
	public void printName()
	{
		Debug.Log("Brain here!");	
	}
}
