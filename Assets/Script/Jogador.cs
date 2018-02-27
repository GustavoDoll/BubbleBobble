using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jogador : MonoBehaviour {
	public static bool Normalgame = true;
	Animator animator;
	public float velocidade;
	public float pulo;
	SpriteRenderer spriteRender;
	Rigidbody2D rb;
	public Transform PeD,PeE;
	bool noChaoE,noChaoD;
	public Transform pivotArma;
	public Transform Arma;
	public GameObject Bolha;
	public GameObject Score;
	BoxCollider2D Bx;
	public static float FireRate = 2.0f;
	float proximoTiro;
	bool  controlar;
	public BoxCollider2D colAnim;
	AudioSource coin;
	AudioSource jump;
	public GameObject death;
	public Text txtPontos;
	public GameObject seta;
	public GameObject canvas;
	public AudioSource trilha;
	public AudioSource GameOver;
	public AudioSource superGameSOm;
	Vector2 casa;
	public static bool morreu = false;
	Vector2 CamPos;
	public static bool gameOver = false;
	public GameObject botoesGameOver;

	public AudioSource[] sons;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		spriteRender = GetComponent<SpriteRenderer> ();
		rb = GetComponent<Rigidbody2D> ();
		Bx = GetComponent<BoxCollider2D> ();
		controlar = true;
		casa = new Vector2 (3.0f,-2.5f);
		transform.position = casa;

		//try again CLick
		if (!gameOver && Normalgame == true) {
			controlar = true;
			animator.SetBool ("Morto", false);
			transform.position = casa;
			StartCoroutine (Piscar ());
			VidasHud.vidas = 4;
			mainscript.pontos = 0;
			mainscript.rounds = 1;
			morreu = false;

		}
		//try again CLick
		if (!gameOver && !Normalgame){
			controlar = true;
			print ("Entrou NO LUGAR CERTO");
			animator.SetBool ("Morto", false);
			VidasHud.heart.SetBool ("Supergame", true);
			transform.position = casa;
			StartCoroutine (Piscar ());
			VidasHud.vidas = 2;
			mainscript.pontos = 0;
			mainscript.rounds = 1;
			morreu = false;

		}




	}
	
	// Update is called once per frame
	void Update () {
		
		print ("Super Game " + Supergame.SuperGame);
		print ("Jogando super " + Supergame.JogandoSuper);
		print ("Jogando Normal " + Normalgame);
		coin = sons [0];
		jump = sons [1];

		if (controlar == true) {
			
		
			float mover = Input.GetAxisRaw ("Horizontal") * velocidade * Time.deltaTime;
			transform.Translate (Vector2.right * mover);
			//Orientacao
			if (mover < 0) {
				spriteRender.flipX = false;
				pivotArma.transform.eulerAngles = new Vector3 (0.0f, 0.0f, 0.0f);

			} else if (mover > 0) {
				spriteRender.flipX = true;
				pivotArma.transform.eulerAngles = new Vector3 (0.0f, 180.0f, 0.0f);
			}
			//animacoes
			if (Input.GetButtonDown ("Jump") && Time.time > proximoTiro) {
				animator.SetBool ("Atirar", true);
		
			} else if (Input.GetButtonUp ("Jump") && Time.time > proximoTiro) {
				animator.SetBool ("Atirar", false);
				proximoTiro = Time.time + FireRate;
				Instantiate (Bolha, Arma.transform.position, Arma.transform.rotation);

			}
			if (Input.GetKeyDown (KeyCode.UpArrow) && (noChaoD && noChaoE)) {
				rb.velocity = new Vector2 (0.0f, pulo);
				animator.SetBool ("Pular", true);
				jump.Play ();

			} else if (Input.GetKeyUp (KeyCode.UpArrow)) {
				animator.SetBool ("Pular", false);
			}
			animator.SetFloat ("Andar", Mathf.Abs (Input.GetAxisRaw ("Horizontal"))); 
		}
		//limite Tela
		if (VidasHud.vidas > 0) {
			
		
			if (transform.position.x < 0 && transform.position.y < -3.3) {
				transform.position = new Vector2 (transform.position.x, 3.15f);
			} else if (transform.position.x > 0 && transform.position.y < -3.3) {
				transform.position = new Vector2 (transform.position.x, 3.15f);
			}
		}
		noChaoE = Physics2D.Linecast (transform.position, PeE.transform.position, 1 << LayerMask.NameToLayer ("Chao"));
		noChaoD = Physics2D.Linecast (transform.position, PeD.transform.position, 1 << LayerMask.NameToLayer ("Chao"));

		if (VidasHud.vidas == 0) {
			controlar = false;
			animator.SetBool ("Morto", true);
			rb.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeAll;
			Vector2 pos = new Vector2 (0.0f,-10.0f);
			transform.position = Vector2.Lerp (transform.position,pos,0.9f *Time.deltaTime);
			colAnim.GetComponent<BoxCollider2D> ().enabled = true;
			canvas.SetActive (false);
			trilha.Stop ();




		}

	}
	//serve para arrumar o som de game over retirando uma vida e saindo do lopping a cim

	void OnCollisionEnter2D(Collision2D c){
		if (c.collider.tag =="Inimigo") {
			if (VidasHud.vidas > 0 ) {
				VidasHud.vidas--;
				Instantiate (death, transform.position, transform.rotation);
				transform.position =  casa;
				StartCoroutine (Piscar ());

			}else if (c.collider.tag=="Cenario"|| c.collider.tag == "CenarioEsquerda") {
				Bx.enabled = true;
				rb.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.None;
				rb.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeRotation;
			}




		}else if (c.collider.tag=="Ponto") {
			coin.Play ();
			mainscript.pontos += 10;
			Instantiate (Score, c.transform.position, c.transform.rotation);
			Destroy (c.gameObject);
		

		}else if (c.collider.tag=="Frente") {
			animator.SetBool ("MortoIdle", true);
			botoesGameOver.SetActive (true);
			seta.SetActive (true);
			GameOver.Play ();
			superGameSOm.Stop ();
			gameOver = true;
		}

	}
	IEnumerator Piscar(){
		spriteRender.enabled = false;
		yield return new WaitForSeconds (0.2f);
		spriteRender.enabled = true;
		yield return new WaitForSeconds (0.2f);
		spriteRender.enabled = false;
		yield return new WaitForSeconds (0.2f);
		spriteRender.enabled = true;
		yield return new WaitForSeconds (0.2f);









	}


}
