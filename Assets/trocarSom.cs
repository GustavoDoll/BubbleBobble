using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trocarSom : MonoBehaviour {

	public AudioSource somSuper;
	public AudioSource somNormal;
	void start(){
		Destroy (gameObject,0.3f);
	}
	void Update(){
		if (!Jogador.Normalgame) {
			somNormal.Stop ();

		}else if (Jogador.Normalgame) {
			somSuper.Stop ();
		}
	}
}

