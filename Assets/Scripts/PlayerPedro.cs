using UnityEngine;
using System.Collections;

public class PlayerPedro : MonoBehaviour {


	public float velocidad = 5f;
	public float fsalto = 10f;
	public float power = 1f;
	public bool tocando_suelo = false;
	private Animator animator;
	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		animator.SetFloat ("velocidad_animator", Mathf.Abs(rb.velocity.x));
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

		if (Input.GetKeyDown (KeyCode.Space)) {
			animator.SetBool  ("jump", true);
			rb.AddForce (transform.up*fsalto);
		
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

	void OnTriggerEnterStay2D(Collider2D objeto){
		if (objeto.tag == "Suelo") {
			tocando_suelo = true;
		}
	}

	void OnTriggerExitStay2D(Collider2D objeto){
		if (objeto.tag == "Suelo") {
			tocando_suelo = false;
			animator.SetBool ("saltando", false);
		}
	}
}
