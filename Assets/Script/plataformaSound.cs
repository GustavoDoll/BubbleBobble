﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plataformaSound : MonoBehaviour {
	public GameObject estouro;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionEnter2D(Collision2D c){
		if (c.collider.tag=="Morto"||c.collider.tag=="Bolha") {
			Instantiate (estouro, transform.position, transform.rotation);
		}

	}
}
