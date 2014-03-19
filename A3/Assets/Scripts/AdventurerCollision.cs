using UnityEngine;
using System.Collections;

public class AdventurerCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnTriggerEnter(Collider c)
	{
		//"Destroy" the wall 
		if (c.gameObject.tag == "visionLines")
		{
			Debug.Log("GOT SPOTTED");
		}
		
		//Destroy(gameObject); //remove from the scene the gameobject
		
	}

}
