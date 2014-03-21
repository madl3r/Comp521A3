using UnityEngine;
using System.Collections;

public class AdventurerCollision : MonoBehaviour {

	public Adventurer thief;
	public Material seenColor;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnTriggerEnter(Collider c)
	{

		if (c.gameObject.tag == "visionLines" && c.gameObject.renderer.material.color == seenColor.color)
		{
			Debug.Log("~~~~~~~~~~~~~~GOT SPOTTED~~~~~~~~~~~~~");
			GameObject.Destroy(thief.gameObject);
		}
		else if (c.gameObject.tag == "treasureTag")
		{
			GameObject.Destroy(c.gameObject);
			thief.score++;
		}
		
	}

	void OnCollisionEnter(Collision c)
	{
		transform.position += Vector3.Normalize(transform.position - c.gameObject.transform.position) * 0.12f;
	}

}
