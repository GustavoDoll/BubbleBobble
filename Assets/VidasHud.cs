using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidasHud : MonoBehaviour {
	public static Animator heart;
	public static int vidas;

	void Start(){
		

		heart = GetComponent<Animator> ();
	}
	// Update is called once per frame
	void Update () {
		if (vidas == 3) {
			heart.SetBool ("Heart1", true);
			
		}
		if (vidas == 2) {
			heart.SetBool ("Heart2", true);

		}
		if (vidas == 1) {
			heart.SetBool ("Heart3", true);

		}
		if (vidas == 0) {
			heart.SetBool ("Heart4", true);

		}
	}
}
