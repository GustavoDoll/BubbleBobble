using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mainscript : MonoBehaviour {
	public static int pontos = 000;
	public static int rounds = 1;
	public GameObject jogador;
	public Text txtPontos;
	public Text txtPontosTotal;
	public Text highScore;
	public Text txtRoundTotal;
	public Text highRound;
	void Start(){
		highScore.text = "High Score: " + PlayerPrefs.GetInt ("HighScore", 0).ToString();
		highRound.text = "High Round: " + PlayerPrefs.GetInt ("HighRound", 0).ToString ();
	}
	void Update(){
		txtPontos.text = "Score: " + pontos.ToString ();
		txtPontosTotal.text = "Your Score: " + pontos.ToString ();
		txtRoundTotal.text = "Your Round: " + rounds.ToString ();
		if (pontos > PlayerPrefs.GetInt("HighScore",0)) {
			PlayerPrefs.SetInt ("HighScore", pontos);
			highScore.text = "High Score: " + pontos.ToString ();
		}
		if (rounds > PlayerPrefs.GetInt("HighRound",0)) {
			PlayerPrefs.SetInt ("HighRound", rounds);
			highRound.text = "High Round: "+ rounds.ToString();
			
		}
	}
	void OnCollisionEnter2D(Collision2D c){
		if (jogador.GetComponent<Collider>().tag =="Ponto") {
			pontos += 10;
		}

	}

}

