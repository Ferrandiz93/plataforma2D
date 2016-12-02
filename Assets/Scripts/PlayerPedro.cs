using UnityEngine;
using System.Collections;

public class PlayerPedro : MonoBehaviour {


	public float velocidad = 5f;
	public float fsalto = 10f;
	public float power = 1f;
	public bool tocando_suelo = false;

	public AudioClip sonido_salto;
	public AudioClip sonido_herir;
	public AudioClip sonido_moneda;

	private Animator animator;
	private Rigidbody2D rb;
	private GameControlScript gcs;
		private AudioSource audio;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody2D> ();
		gcs = GameObject.Find ("GameControl").GetComponent<GameControlScript> ();
		audio = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		animator.SetFloat ("velocidad", Mathf.Abs(rb.velocity.x));
		if (Input.GetKey ("right")) 
		{
			rb.velocity = new Vector2 (velocidad,rb.velocity.y);
			transform.localScale= new Vector3(1,1,1);
			animator.SetFloat ("velocidad", 1f);
		}

		else if (Input.GetKey ("left")) 
		{
			rb.velocity = new Vector2 (-velocidad,rb.velocity.y);
			transform.localScale= new Vector3(-1,1,1);	
			animator.SetFloat ("velocidad", 1f);
		}

		if (Input.GetKeyDown (KeyCode.Space) && tocando_suelo) {
			animator.SetBool  ("jump", true);
			rb.AddForce (transform.up*fsalto);
			audio.PlayOneShot (sonido_salto);
		
		}

		if (Input.GetKeyUp (KeyCode.Space)) {
			animator.SetBool ("jump", false);
		}

		if (Input.GetKeyUp ("right")) {
			animator.SetFloat ("velocidad", 0f);

		}

		if (Input.GetKeyUp ("left")) {
			animator.SetFloat ("velocidad", 0f);

		}
			
	}

	void OnTriggerEnter2D(Collider2D objeto){
		if (objeto.tag == "Suelo") {
			tocando_suelo = true;
			animator.SetBool ("jump", false);	
		}
	}

	void OnTriggerStay2D(Collider2D objeto){
		if (objeto.tag == "Suelo") {
			tocando_suelo = true;
			animator.SetBool ("jump", false);	
		}
	}

	void OnTriggerExit2D(Collider2D objeto){
		if (objeto.tag == "Suelo") {
			tocando_suelo = false;
		}
	}
	void OnCollisionEnter2D (Collision2D col){
		if (col.gameObject.tag == "Muerte") {
			Invoke ("muerte", 1);
			gcs.respawn ();
			audio.PlayOneShot (sonido_herir);

		}
	}
	
	void muerte(){
		gcs.respawn ();
	}
					
}