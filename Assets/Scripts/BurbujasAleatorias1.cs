using UnityEngine;
using System.Collections;

public class BurbujasAleatorias1 : MonoBehaviour {

	public GameObject prefabBubble;
	GameObject newObject;
	public float contNewBubble;

	public TextMesh textBubble;
//	public string textInsideBubble;

	// Use this for initialization
	void Start ()
	{
		contNewBubble = 10f;
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
			contNewBubble = 10f;

			int randomText = Random.Range (0,10);
			if (randomText == 0)
			{
				textBubble.text="Te Odio";
			}
			else if (randomText == 1)
			{
				textBubble.text = "Mentirosa";
			}
			else if (randomText == 2)
			{
				textBubble.text = "Orgullosa";
			}
			else if (randomText == 3)
			{
				textBubble.text = "Eres muy Impaciente";
			}
			else if (randomText == 4)
			{
				textBubble.text = "No te comportes asi";
			}
			else if (randomText == 5)
			{
				textBubble.text = "Ten Tolerancia";
			}
			else if (randomText == 6)
			{
				textBubble.text = "Se comprensivo";
			}
			else if (randomText == 7)
			{
				textBubble.text = "&&#/*-+@";
			}
			else if (randomText == 8)
			{
				textBubble.text = "Cierra tu Boca";
			}
			else if (randomText == 9)
			{
				textBubble.text = "Idiota";
			}
			else if (randomText == 10)
			{
				textBubble.text = "/*-*#%^";
			}
		}
	}
}
