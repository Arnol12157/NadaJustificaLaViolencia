using UnityEngine;
using System.Collections;

public class moveLocation : MonoBehaviour {

	public GameObject locationParent;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		Vector3 positionLocation = new Vector3 (locationParent.transform.position.x, 1f, locationParent.transform.position.z);
		gameObject.transform.position = positionLocation;
	}
}
