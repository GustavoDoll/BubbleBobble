using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class botaoAparece : MonoBehaviour {
	CanvasGroup Botoes;

	void Start(){
		
		 Botoes = GetComponent<CanvasGroup> ();
		Botoes.alpha = 0;
		StartCoroutine (Fade ());
	}
	IEnumerator Fade (){
		while(Botoes.alpha < 1){                   //use "< 1" when fading in
			Botoes.alpha += Time.deltaTime/5;    //fades out over 1 second. change to += to fade in    
			yield return null;
		}
	}


}
