using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigocpto : MonoBehaviour {
	public float velocidade;
	SpriteRenderer sr;
	int direcao;
	Animator anim;
	public GameObject estouro;
	Rigidbody2D rb;
	AudioSource furySom;

	public  bool morto;
	public bool fury;
	public bool noChao;
	public Transform Chao;
	// Use this for initialization
	void Start () {
		sr = GetComponent<SpriteRenderer> ();
		anim = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody2D> ();
		furySom = GetComponent<AudioSource> ();

	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector2.left * velocidade * Time.deltaTime);
		if (transform.position.x < 0 && transform.position.y < -3.3) {
			transform.position = new Vector2 (transform.position.x,3.27f);
		}else if (transform.position.x > 0 && transform.position.y < -3.3) {
			transform.position = new Vector2 (transform.position.x,3.27f);
		} 
		noChao = Physics2D.Linecast (transform.position, Chao.transform.position, 1 << LayerMask.NameToLayer ("Chao"));

	}
	void OnCollisionEnter2D(Collision2D c){

		if (c.collider.tag=="Cenario") {
			velocidade *= -1;
			sr.flipX = false;

		}else if (c.collider.tag=="CenarioEsquerda") {
			sr.flipX = true;
			velocidade *= -1;
		}else if (c.collider.tag=="Bolha") {
			anim.SetBool ("Morto", true);
			gameObject.tag = "Morto";
			rb.gravityScale = -0.2f;
			gameObject.layer = 12;

			noChao = false;
			velocidade = 0;
			morto = true;
		}
		else if ( c.collider.tag=="Chao"  && morto) {
			anim.SetBool ("Ponto", true);
			Instantiate (estouro, transform.position, transform.rotation);
			gameObject.tag="Ponto";
			gameObject.layer = 10;
			rb.gravityScale = 1;
			morto = false;

		}else if (c.collider.tag=="Ponto" && !Supergame.JogandoSuper) {

			anim.SetBool ("Fury",true);
			furySom.Play ();
			gameObject.layer = 10;
			gameObject.layer = 9;
			fury = true;
			velocidade *= 2.0f;
			Destroy (c.gameObject);

		}else if (c.collider.tag=="Inimigo" && fury && Supergame.JogandoSuper) {
			c.gameObject.GetComponent<Animator> ().SetBool ("Fury", true);
			c.gameObject.GetComponent<Inimigocpto> ().velocidade *= 2.0f;
			c.gameObject.layer = 13;

		}else if (c.collider.tag=="Ponto" && Supergame.JogandoSuper) {
		anim.SetBool ("Fury",true);
		furySom.Play ();
		gameObject.layer = 13;
		fury = true;
		velocidade *= 2.0f;
		Destroy (c.gameObject);

	}
	}




}
