using UnityEngine;
using System.Collections;
[RequireComponent (typeof(AudioSource))] //Este objeto tiene el componente que quieres//

public class moneda : MonoBehaviour {
	private Rigidbody2D rb;
	GameObject texto_moneda;
	AudioSource audio;
	control_monedas ctrl_moneda;
	public int valor = 1;

	void Start () {
		Destroy (gameObject, 3);
		rb = GetComponent<Rigidbody2D> ();
		audio = GetComponent<AudioSource> ();
		rb.AddForce (new Vector2 (Random.Range (-100, 100), 100));
		texto_moneda = GameObject.Find ("texto_moneda");
		ctrl_moneda = texto_moneda.GetComponent<control_monedas> (); 

	}
	void Update () {
			
		}


    // función para controlar cuando un objeto entra en el trigger
    void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Player") {
			audio.Play ();
			ctrl_moneda.suma_monedas (valor);
			Destroy (gameObject, 0.1f);
		}
    }

    // función para controlar cuando un objeto sale del trigger
    void OnTriggerExit2D(Collider2D col)
    {
        
    }
    // función para controlar cuando un objeto permanece en el trigger
    void OnTriggerStay2D(Collider2D col)
    {
        
    }
}