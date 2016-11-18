using UnityEngine;
using System.Collections;

public class Muelle : MonoBehaviour {
	public Sprite muelle_presionado;
	public Sprite muelle_libre;
	private bool pisando = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D objeto){
		if (objeto.tag == "Player") {
			GetComponent<SpriteRenderer> ().sprite = muelle_presionado;
			pisando = true;
		}
	}

	void OnTriggerExit2D(Collider2D objeto){
		if (objeto.tag == "Player" && pisando == true) {
			GetComponent<SpriteRenderer> ().sprite = muelle_libre;
			pisando = false;
		}
	}
}
