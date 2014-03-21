using UnityEngine;
using System.Collections;

public class visionLine : MonoBehaviour {
	
	
	public Material baseColor, hitColor;
	//public GameObject thisGuard;

	
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter(Collider c)
	{

		//Debug.Log("ENTERING A COLLISION");

		if (c.gameObject.tag == "Adventurer" )
		{
			Debug.Log("~~~~~~~~~~~~~~GAME OVER~~~~~~~~~~~~~~~~");
		}
		else if ((c.gameObject.tag == "guard" || c.gameObject.tag == "visionLines"))
		{
			;
		}
		else
		{
			transform.renderer.material.color = hitColor.color;
		}

//		if (!(c.gameObject.tag == "guard" && c.gameObject.tag == "visionLines"))
//		{
//			Debug.Log("HIT SOMETHING ELSE");
//			transform.renderer.material.color = hitColor.color;
//		}
	}
	
	void OnTriggerExit(Collider c)
	{
		if (!(c.gameObject.tag == "guard" && c.gameObject.tag == "visionLines"))
		{
			Debug.Log("~~~~ UN ~~~~HIT SOMETHING ELSE");
			transform.renderer.material.color = baseColor.color;
		}
	}
	
}
