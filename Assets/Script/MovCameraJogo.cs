using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovCameraJogo : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (VidasHud.vidas == 0) {
			Vector3 pos = new Vector3 (0.0f, -7.5f, -10.0f);
			transform.position = Vector3.Lerp (transform.position, pos, 0.8f * Time.deltaTime);
		}
	}
}
