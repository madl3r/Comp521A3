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

		if (c.gameObject.tag == "visionLines")
		{
			Debug.Log("GOT SPOTTED");
		}
		else if (c.gameObject.tag == "treasureTag")
		{
			GameObject.Destroy(c.gameObject);
		}
		
	}

	void OnCollisionEnter(Collision c)
	{
		//transform.position += Vector3.Normalize(transform.position - c.gameObject.transform.position) * 0.12f;
	}

}
