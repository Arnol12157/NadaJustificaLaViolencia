using UnityEngine;
using System.Collections;

public class BurbujasAleatorias : MonoBehaviour {

	public GameObject prefabBubble;
	GameObject newObject;
	public float contNewBubble;

	public TextMesh textBubble;
//	public string textInsideBubble;

	// Use this for initialization
	void Start ()
	{
		contNewBubble = 7f;
	}
	
	// Update is called once per frame
	void Update ()
	{
		contNewBubble = contNewBubble - Time.deltaTime;
		if (contNewBubble < 0)
		{
			Vector3 position = new Vector3 (Random.Range (-5.0f, 5.0f), 0, Random.Range (-6.0f, 6.0f));
			newObject = (GameObject)Instantiate (prefabBubble, position, Quaternion.identity);
			newObject.transform.parent = this.transform;
			newObject.transform.position = this.transform.position + position;
			contNewBubble = 7f;

			int randomText = Random.Range (0,10);
			if (randomText == 0)
			{
				textBubble.text="Sonrie";
			}
			else if (randomText == 1)
			{
				textBubble.text = "Ten Paciencia";
			}
			else if (randomText == 2)
			{
				textBubble.text = "No seas Pesimista";
			}
			else if (randomText == 3)
			{
				textBubble.text = "Se Perseverante";
			}
			else if (randomText == 4)
			{
				textBubble.text = "Te Quiero";
			}
			else if (randomText == 5)
			{
				textBubble.text = "Te Amo";
			}
			else if (randomText == 6)
			{
				textBubble.text = "Lo Siento";
			}
			else if (randomText == 7)
			{
				textBubble.text = "Perdon";
			}
			else if (randomText == 8)
			{
				textBubble.text = "Escuchame";
			}
			else if (randomText == 9)
			{
				textBubble.text = "No grites";
			}
			else if (randomText == 10)
			{
				textBubble.text = "Quieres un abrazo";
			}
		}
	}
}
