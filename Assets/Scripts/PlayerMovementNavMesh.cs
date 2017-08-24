using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
[DisallowMultipleComponent]
[RequireComponent(typeof(NavMeshAgent))]

public class PlayerMovementNavMesh : MonoBehaviour {

	public float contWinLose;
	public bool flagWinLose;

	public GameObject Smoke;
	public GameObject Aureola;

	public GameObject Win;
	public GameObject Lose;

	public GameObject AngerOne;
	public GameObject AngerTwo;
	public GUIBarScript scriptAngerOne;
	public GUIBarScript scriptAngerTwo;

	[SerializeField][Range(1,20)]
	private float speed = 10;					//how fast the player moves.

	private Vector3 targetPosition;				//donde nos moveremos
	const int LEFT_MOUSE_BUTTON = 0;			//si esta pulasdo el mouse.
	NavMeshAgent agent;

	public bool ismoving;
	public bool isjumping;
	public bool isBubblePluf;

	public float contIsJumping;

	Animator anim;

	void Awake()
	{
		agent = GetComponent<NavMeshAgent>();
	}

	void Start ()
	{
		flagWinLose = false;
		contWinLose = 4f;

		Smoke.SetActive (false);
		Aureola.SetActive (false);

		Win.SetActive (false);
		Lose.SetActive (false);

		scriptAngerOne = AngerOne.GetComponent<GUIBarScript> ();
		scriptAngerTwo = AngerTwo.GetComponent<GUIBarScript> ();

		isBubblePluf = false;
		contIsJumping = 1f;
		isjumping = false;
		ismoving = false;
		anim = gameObject.GetComponent<Animator> ();
		targetPosition = transform.position;		//set the target postion to where we are at the start
	}

	void Update ()
	{
		if(scriptAngerOne.Value >= 0.1 && scriptAngerOne.Value <=0.9)
		{
			Aureola.SetActive (false);
			Smoke.SetActive (false);
		}
		else if(scriptAngerOne.Value <= 0.15)
		{
			Aureola.SetActive (true);
		}
		else if(scriptAngerOne.Value >= 0.85)
		{
			Smoke.SetActive (true);
		}

		if (scriptAngerOne.Value <= 0)
		{
			Win.SetActive (true);
			flagWinLose = true;
			if(flagWinLose)
			{
				contWinLose=contWinLose-Time.deltaTime;
				if (contWinLose <= 0)
				{
					SceneManager.LoadScene ("Principal");
				}
			}
		}
		else if(scriptAngerOne.Value >= 1)
		{
			Lose.SetActive (true);
			flagWinLose = true;
			if(flagWinLose)
			{
				contWinLose=contWinLose-Time.deltaTime;
				if (contWinLose <= 0)
				{
					SceneManager.LoadScene ("Principal");
				}
			}
		}

		//si fue pulsado el mouse
		if (Input.GetKeyDown(KeyCode.Space))
		{
			isjumping = true;
		}
		else if (Input.GetMouseButton (LEFT_MOUSE_BUTTON))
		{
			SetTargetPosition ();
		}

		if (isjumping)
		{
			JumpPlayer ();
		}
		else if (ismoving)
		{
			MovePlayer ();
			isBubblePluf = false;
		}
		else
		{
			NotMovePlayer ();
			isBubblePluf = false;
		}

		scriptAngerOne.Value = scriptAngerOne.Value + 0.0001f;
		scriptAngerTwo.Value = scriptAngerTwo.Value + 0.0001f;
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Bubble" && contIsJumping < 1)
		{
			Destroy (other.gameObject);
			isBubblePluf = true;
			scriptAngerOne.Value = scriptAngerOne.Value - 0.1f;
			scriptAngerTwo.Value = scriptAngerTwo.Value - 0.1f;
		}
		else if (other.tag == "BubbleBad" && contIsJumping < 1)
		{
			Destroy (other.gameObject);
			isBubblePluf = true;
			scriptAngerOne.Value = scriptAngerOne.Value + 0.1f;
			scriptAngerTwo.Value = scriptAngerTwo.Value + 0.1f;
		}
	}

	void SetTargetPosition()
	{
		Plane plane = new Plane(Vector3.up, transform.position);
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		float point = 0f;
		
		if (plane.Raycast (ray, out point))
		{
			targetPosition = ray.GetPoint (point);
		}

		ismoving = true;
	}

	void MovePlayer()
	{
		anim.Play ("Run");

		//if we are at the target position, then stop moving
		if (transform.position == targetPosition)
		{
			ismoving = false;
		}

		agent.SetDestination(targetPosition);
		Debug.DrawLine(transform.position, targetPosition, Color.red);
	}

	void NotMovePlayer()
	{
		anim.Play ("Idle");
	}

	void JumpPlayer()
	{
		anim.Play ("Jump");
		contIsJumping = contIsJumping - Time.deltaTime;
		if(contIsJumping <= 0)
		{
			isjumping = false;
			contIsJumping = 1f;
		}
	}
}