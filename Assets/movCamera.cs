using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movCamera : MonoBehaviour {
	public static bool chegou;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = new Vector3 (0.0f, 0.0f,-1.0f);
		transform.position = Vector3.Lerp (transform.position, pos, 1.0f * Time.fixedDeltaTime);
		if (transform.position.y < 2) {
			chegou = true;
		}
	}
}
