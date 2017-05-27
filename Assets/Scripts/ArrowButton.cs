using UnityEngine;
using System.Collections;

public class ArrowButton : MonoBehaviour {

	public GameObject IsLinkedTo;

	private float x;
	private float y;
	private bool grow;


	void OnMouseDown(){

		if (gameObject.tag == "left")
			IsLinkedTo.GetComponent<UICase> ().SpawnToTheLeft ();
		
		if (gameObject.tag == "right")
			IsLinkedTo.GetComponent<UICase> ().SpawnToTheRight ();

		if (gameObject.tag == "up")
			IsLinkedTo.GetComponent<UICase> ().SpawnToTheUp ();

	}

	// Use this for initialization
	void Start () {
	
		grow = true;
		x = 1.2f;
		y = 1.2f;

	}
	
	// Update is called once per frame
	void Update () {

		if (x >= 1.5 && y >= 1.5)
			grow = false;

		if (grow == true) {
			x = x + Time.deltaTime / 2;
			y = y + Time.deltaTime / 2;
		}

		if (grow == false) {
			x = x - Time.deltaTime / 2;
			y = y - Time.deltaTime / 2;
			if (x <= 1.0 || y <= 1.0)
				grow = true;
		}

		this.gameObject.transform.localScale = new Vector3 (x, y, 1f);
		this.gameObject.GetComponent<SpriteRenderer> ().color = new Color (this.gameObject.GetComponent<SpriteRenderer> ().color.r, this.gameObject.GetComponent<SpriteRenderer> ().color.g, this.gameObject.GetComponent<SpriteRenderer> ().color.b, 2.0f - x);

	
	}
}
