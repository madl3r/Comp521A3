using UnityEngine;
using System.Collections;

public class visionLine : MonoBehaviour {
	
	
	public Material baseColor, hitColor;
	
	
	// Use this for initialization
	void Start () {
		Debug.Log("HUHHH...?");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnCollisionStay(Collision c)
	{
		Debug.Log("ENTERING A COLLISION");
	}
	
	void OnTriggerEnter(Collider c)
	{

		Debug.Log("ENTERING A COLLISION");
		
		if (!(c.gameObject.tag == "guard" && c.gameObject.tag == "visionLines"))
		{
			Debug.Log("HIT SOMETHING ELSE");
			transform.renderer.material.color = hitColor.color;
		}
	}
	
	void OnCollisionExit(Collision c)
	{
		if (!(c.gameObject.tag == "guard" && c.gameObject.tag == "visionLines"))
		{
			Debug.Log("~~~~ UN ~~~~HIT SOMETHING ELSE");
			transform.renderer.material.color = baseColor.color;
		}
	}
	
}
