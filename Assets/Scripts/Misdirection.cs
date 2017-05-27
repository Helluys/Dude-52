using UnityEngine;
using System.Collections;

public class Misdirection : MonoBehaviour {

	public float MisdirectionTime;
	private GameObject[] Spectators;
	private int NewLook;
	public int NumberOfUses;


	void OnMouseDown(){

		NumberOfUses--;
		Spectators = GameObject.FindGameObjectsWithTag ("Spectator");

		foreach (GameObject Spectator in Spectators) {
			StartCoroutine( Spectator.GetComponent<Spectator>().ChangeLook(MisdirectionTime,NewLook));

		}

		if (NumberOfUses <= 0) {
			gameObject.GetComponent<BoxCollider2D> ().enabled = false;
			gameObject.GetComponent<SpriteRenderer> ().enabled = false;
			StartCoroutine (MisdirectionDestroy ());
		}
	}

	IEnumerator MisdirectionDestroy (){

		yield return new WaitForSeconds (5.0f);
		Destroy (gameObject);

	}

	// Use this for initialization
	void Start () {

		if (transform.position.y > 1)
			NewLook = 2;
		else {
			if (transform.position.x > 1)
				NewLook = 1;
			else
				NewLook = 3;
		}


	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
