using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class somPlataforma : MonoBehaviour {
	public GameObject estouro;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
			
		
	}
	void OnCollisionEnter2D(Collision2D c){
		if (c.collider.tag =="Bolha") {
			Instantiate (estouro, transform.position, transform.rotation);
		}else if (c.collider.tag=="Morto") {
			Instantiate (estouro, transform.position, transform.rotation);
		}

	}
}
