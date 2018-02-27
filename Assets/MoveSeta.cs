using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveSeta : MonoBehaviour {
	public Vector2 posEsquerda;
	public Vector2 posDireita;
	public bool esquerda;
	public bool direita;
	 public AudioSource[] sons;
	AudioSource acerto;
	AudioSource transicao;
	// Use this for initialization
	void Start () {
		esquerda = true;
		acerto = sons [0];
		transicao = sons [1];
	}
	
	// Update is called once per frame
	void Update () {
		if (Jogador.gameOver && Input.GetKeyDown (KeyCode.LeftArrow)) {
			transform.position = posEsquerda;
			transicao.Play ();
			esquerda = true;
			direita = false;
		} else if (Input.GetKeyDown (KeyCode.Return) && esquerda) {
			StartCoroutine (delay2 ());
			acerto.Play ();
			Jogador.gameOver = false;
			if (Jogador.Normalgame == false) {
				Supergame.JogandoSuper = true;
			}
		} else if (Jogador.gameOver && Input.GetKeyDown (KeyCode.RightArrow)) {
			transform.position = posDireita;
			transicao.Play ();
			direita = true;
			esquerda = false;
		}else if (Input.GetKeyDown(KeyCode.Return)&& direita) {
				
				Jogador.gameOver = false;
				acerto.Play ();
			StartCoroutine (delay ());
			}

		}

	IEnumerator delay(){
		yield return new WaitForSeconds (0.4f);
		SceneManager.LoadScene ("Menu");
	}
	IEnumerator delay2(){
		yield return new WaitForSeconds (0.4f);
		SceneManager.LoadScene ("Jogo");
	}




}
