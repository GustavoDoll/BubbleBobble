using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotoesMenu : MonoBehaviour {
	public AudioSource[] sons;
	 AudioSource error;
	 AudioSource acerto;


	public bool cima;
	public bool baixo;
	public Vector2 posCima;
	public Vector2 posBaixo;


	public void Entrar(){
		acerto.Play ();

	}
	public void Erro(){
		error.Play ();
	}


	void Start(){
		cima = true;
		error = sons [0];
		acerto = sons [1];

	}
	// Use this for initialization
	void Update () {
		
		if (Input.GetKeyDown (KeyCode.UpArrow) && movCamera.chegou) {
			transform.position = posCima;
			cima = true;
			baixo = false;
		} else if (Input.GetKeyDown (KeyCode.Return) && cima) {
			Entrar ();
			StartCoroutine (entrar ());
			Jogador.gameOver = false;
			Jogador.Normalgame = true;
			Supergame.SuperGame = false;
			Supergame.JogandoSuper = false;
		} else if (Input.GetKeyDown (KeyCode.DownArrow) && movCamera.chegou) {
			transform.position = posBaixo;
			baixo = true;
			cima = false;
		}else if (Input.GetKeyDown(KeyCode.Return) && baixo) {
			Supergame.SuperGame = true;
			Jogador.Normalgame = false;
			Entrar ();
			StartCoroutine (entrar ());
		}

	}

	IEnumerator entrar(){
		yield return new WaitForSeconds (0.5f);
		SceneManager.LoadScene ("Jogo");

	}
	

}
