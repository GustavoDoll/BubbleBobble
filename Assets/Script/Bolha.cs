using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolha : MonoBehaviour {
	public AudioSource estouro;
	void Start(){
		StartCoroutine (tiro ());

	}
	void OnBecameInvisible(){
		Destroy (gameObject);

	}

	IEnumerator tiro(){
		yield return new WaitForSeconds (0.1f);
		transform.Translate (Vector2.left * 30.0f * Time.deltaTime);

	}
	void OnCollisionEnter2D(Collision2D c){
		if (c.collider.tag=="Inimigo" || c.collider.tag=="Ponto"|| c.collider.tag=="CenarioEsquerda") {
			Destroy (gameObject);
		}else if (c.collider.tag=="Chao") {
			Destroy (gameObject);

		}

	}
}
