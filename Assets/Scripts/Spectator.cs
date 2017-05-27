using UnityEngine;
using System.Collections;

public class Spectator : MonoBehaviour {

	public int Look; // 0 = normal, 1=droite, 2 = haut, 3 = gauche
	private int MisdirectionCount;

	public Animator anim;


	public IEnumerator ChangeLook (float Misdirectiontime, int NewLook){

		MisdirectionCount++;
		Look = NewLook;

		// exception du spectateur de gauche
		if (transform.localScale.x < 0 && (Look == 1 || Look == 3)) {
			if (Look == 1)
				anim.SetInteger ("Look", 3);
			if (Look == 3)
				anim.SetInteger ("Look", 1);
		}

		else
		anim.SetInteger ("Look", Look);
		
		
		yield return new WaitForSeconds (Misdirectiontime);
		MisdirectionCount--;

		if (MisdirectionCount == 0) {
			Look = 0;
			anim.SetInteger ("Look", Look);
		}

	}


	// Use this for initialization
	void Start () {

		MisdirectionCount = 0;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
