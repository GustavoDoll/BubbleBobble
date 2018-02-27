using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Supergame : MonoBehaviour {
	public static bool SuperGame = false;
	public static bool JogandoSuper;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (SuperGame == true) {
			VidasHud.vidas = 2;
			VidasHud.heart.SetBool ("Supergame", true);
			Jogador.FireRate = 0.5f;
			/*SpawnInimigo.tempoSpawn = 1.0f;
			SpawnInimigo.numeroInimigos = 5;
			SpawnInimigo.tempoDeEsperaWaves = 3.0f;*/
			JogandoSuper = true;
			SuperGame = false;
		
		}
	}
}
