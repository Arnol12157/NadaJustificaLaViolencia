using UnityEngine;
using System.Collections;

public class Idea : MonoBehaviour {

	public GameObject gameobjectPlayerIdea;
	public PlayerMovementNavMesh scriptgameobjectPlayerIdea;
	public bool flagIsBubblePluf;

	public GameObject imageIdea;
	public GameObject playerIdea;
	public bool verPlayerIdea;
	public float timePlayerIdea;
	Vector3 aumento=new Vector3(0f,3f,0f);

	// Use this for initialization
	void Start ()
	{
		imageIdea.SetActive (false);
		verPlayerIdea = false;
		timePlayerIdea = 2f;
		scriptgameobjectPlayerIdea = gameobjectPlayerIdea.GetComponent<PlayerMovementNavMesh> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		flagIsBubblePluf = scriptgameobjectPlayerIdea.isBubblePluf;
		if(flagIsBubblePluf)
		{
			verPlayerIdea = true;
		}
		if (verPlayerIdea==true)
		{
			imageIdea.SetActive (true);
			imageIdea.transform.position = playerIdea.transform.position+aumento;
			imageIdea.SetActive (true);
			timePlayerIdea = timePlayerIdea - Time.deltaTime;
			if (timePlayerIdea < 0)
			{
				timePlayerIdea = 2f;
				verPlayerIdea = false;
				imageIdea.SetActive (false);
			}
		}
	}
}
