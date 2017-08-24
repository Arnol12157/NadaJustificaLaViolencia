using UnityEngine;
using System.Collections;

public class triggerBubble : MonoBehaviour {

	public PlayerMovementNavMesh scriptPlayer;
	public bool flagIsJumping;
	public bool ver;

	// Use this for initialization
	void Start ()
	{
		ver = false;
		scriptPlayer = gameObject.GetComponent<PlayerMovementNavMesh> ();
		flagIsJumping = scriptPlayer.isjumping;
	}
	
	// Update is called once per frame
	void Update ()
	{
		flagIsJumping = scriptPlayer.isjumping;
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Bubble")
		{
			if (flagIsJumping)
			{
				ver = true;
				Destroy (other.gameObject);
			}
		}
	}
}
