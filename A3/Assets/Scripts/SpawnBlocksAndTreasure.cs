using UnityEngine;
using System.Collections;

public class SpawnBlocksAndTreasure : MonoBehaviour {

	public GameObject obstacle1, obstacle2;

	// Use this for initialization
	void Start () {
		obstacle1.transform.position = obstacle1.transform.position + new Vector3 (Random.Range(-2.0f, 2.0f), 0, Random.Range(-2.2f, 2.2f));
		obstacle2.transform.position = obstacle2.transform.position + new Vector3 (Random.Range(-2.0f, 2.0f), 0, Random.Range(-2.2f, 2.2f));
	
	
		obstacle1.transform.Rotate (0, Random.Range(-45, 45), 0); 
		obstacle2.transform.Rotate (0, Random.Range(-45, 45), 0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
