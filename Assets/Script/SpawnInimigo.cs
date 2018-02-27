using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnInimigo : MonoBehaviour {
	public GameObject inimigo;
	public /*static*/ int numeroInimigos;
	public /*static*/ float tempoSpawn;
	public float tempoStart;
	public Vector2 SpawnCordenadas;
	public /*static*/ float tempoDeEsperaWaves;
	public Text txtrounds;
	void Start () {
		StartCoroutine (Spawn ());

	}
	void Update(){
		txtrounds.text = mainscript.rounds.ToString ();
	}

	IEnumerator Spawn(){


			
		yield return new WaitForSeconds (tempoStart);
			

		while (true) {
				for (int i = 0; i < numeroInimigos; i++) {
					Vector2 pos = new Vector2 (Random.Range (-SpawnCordenadas.x, SpawnCordenadas.x), SpawnCordenadas.y);
					Instantiate (inimigo, pos, transform.rotation);
					yield return new  WaitForSeconds (tempoSpawn);
				if (Supergame.JogandoSuper == true) {
					tempoSpawn = 1.0f;
					numeroInimigos = 5;
					tempoDeEsperaWaves =3.0f;
				}
				}
			if (!Jogador.gameOver) {
				yield return new WaitForSeconds (tempoDeEsperaWaves);
				numeroInimigos++;
				mainscript.rounds++;
			}


		}
	}
}
