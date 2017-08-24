using UnityEngine;
using System.Collections;

public class destroyBubbles : MonoBehaviour {

	public float pointDestroy;

	// Use this for initialization
	void Start ()
	{
		pointDestroy = -24f;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(transform.position.y < pointDestroy)
		{
			Destroy (this.gameObject);
		}
	}
}
