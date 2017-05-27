using UnityEngine;
using System.Collections;

public class UICase : MonoBehaviour {

	public Vector3 SideOffset;
	public Vector3 UpOffset;

	public int possibilities; // 1 = partout, 2 = que sur les cotés, 3 = que sur le plafond;

	public GameObject MisdirectionPrefab; // objet à invoquer

	private GameObject MisdirectionLeft;
	private GameObject MisdirectionRight;
	private GameObject MisdirectionUp;

	public GameObject SpawnLeft;
	public GameObject SpawnRight;
	public GameObject SpawnUp;

	public GameObject buttonLeftPrefab;
	public GameObject buttonRightPrefab;
	public GameObject buttonUpPrefab;

	private GameObject buttonLeft;
	private GameObject buttonRight;
	private GameObject buttonUp;


	void OnMouseDown(){


			buttonLeft = GameObject.FindGameObjectWithTag ("left");
		if (buttonLeft)
			Destroy (buttonLeft);
		buttonLeft = GameObject.FindGameObjectWithTag ("right");
		if (buttonLeft)
			Destroy (buttonLeft);
		buttonLeft = GameObject.FindGameObjectWithTag ("up");
		if (buttonLeft)
			Destroy (buttonLeft);
	

		if (possibilities == 1 && !buttonLeft && !buttonRight && !buttonUp) {

			buttonLeft = Instantiate (buttonLeftPrefab, this.transform.position - SideOffset, transform.rotation) as GameObject;
			buttonRight = Instantiate (buttonRightPrefab, this.transform.position + SideOffset, transform.rotation) as GameObject;
			buttonUp = Instantiate (buttonUpPrefab, this.transform.position + UpOffset, transform.rotation) as GameObject;

			buttonLeft.GetComponent<ArrowButton> ().IsLinkedTo = this.gameObject;
			buttonRight.GetComponent<ArrowButton> ().IsLinkedTo = this.gameObject;
			buttonUp.GetComponent<ArrowButton> ().IsLinkedTo = this.gameObject;
		}

		if (possibilities == 2 && !buttonRight && !buttonLeft) {
			
			buttonLeft = Instantiate (buttonLeftPrefab, this.transform.position - SideOffset, transform.rotation) as GameObject;
			buttonRight = Instantiate (buttonRightPrefab, this.transform.position + SideOffset, transform.rotation) as GameObject;


			buttonLeft.GetComponent<ArrowButton> ().IsLinkedTo = this.gameObject;
			buttonRight.GetComponent<ArrowButton> ().IsLinkedTo = this.gameObject;
		}

		if (possibilities == 3 && !buttonUp) {

			buttonUp = Instantiate (buttonUpPrefab, this.transform.position + UpOffset, transform.rotation) as GameObject;

			buttonUp.GetComponent<ArrowButton> ().IsLinkedTo = this.gameObject;
		}

		//StartCoroutine (ArrowsVanish ());

	}

	IEnumerator ArrowsVanish (){

		yield return new WaitForSeconds (5.0f);
		if (buttonLeft)
			Destroy (buttonLeft);
		if (buttonRight)
			Destroy (buttonRight);
		if (buttonUp)
			Destroy (buttonUp);
	}


	public void SpawnToTheLeft (){

		if (!MisdirectionLeft)
			MisdirectionLeft = Instantiate (MisdirectionPrefab, SpawnLeft.transform.position, SpawnLeft.transform.rotation) as GameObject;
		else
			Destroy (MisdirectionLeft);
	}

	public void SpawnToTheRight (){

		if(!MisdirectionRight)
		MisdirectionRight = Instantiate (MisdirectionPrefab, SpawnRight.transform.position ,SpawnRight.transform.rotation) as GameObject;
		else
			Destroy (MisdirectionRight);
	}

	public void SpawnToTheUp (){

		if(!MisdirectionUp)
		MisdirectionUp = Instantiate (MisdirectionPrefab, SpawnUp.transform.position ,SpawnUp.transform.rotation) as GameObject;
		else
			Destroy (MisdirectionUp);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
