using UnityEngine;
using System.Collections;

public class personaje : MonoBehaviour {
	public float velocidad = 5f;
	public float power = 14;
	private Animator animator;
	private Rigidbody2D rb;
	public float fuerza = 100f;
	public bool tocando_suelo = false;
	private GameControlScript gcs;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody2D> ();
		gcs = GameObject.Find ("GameControl").GetComponent<GameControlScript> ();
	}
	
	// Update is called once per frame
	void Update () {
		animator.SetFloat ("Velocidad", Mathf.Abs (rb.velocity.x));
		if (Input.GetKey (KeyCode.RightArrow)) {
			rb.velocity = new Vector2 (velocidad * power, rb.velocity.y);
			transform.localScale = new Vector3 (1, 1, 1);
	
		} else if (Input.GetKey (KeyCode.LeftArrow)) {
			rb.velocity = new Vector2 (-velocidad * power, rb.velocity.y);
			transform.localScale = new Vector3 (-1, 1, 1);
		}

		if (Input.GetKeyDown (KeyCode.UpArrow) && tocando_suelo) {
			Debug.Log ("Arriba Pulsado");
			GetComponent<Rigidbody2D> ().AddForce (Vector2.up * fuerza);
			animator.SetBool ("Salto", true);
		}
	}

	void OnTriggerStay2D(Collider2D objeto){
			if (objeto.tag == "Suelo") {
				animator.SetBool ("Salto", false);
				tocando_suelo = true;
			}
		}

	void OnTriggerExit2D(Collider2D objeto){
			if (objeto.tag == "Suelo") {
				tocando_suelo = false;
			}
		}
		
	void OnCollisionEnter2D (Collision2D col){
		if (col.gameObject.tag == "Muerte") {
			gcs.respawn ();
		}
	}
}
