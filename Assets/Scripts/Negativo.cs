using UnityEngine;
using System.Collections;

public class Negativo : MonoBehaviour {
	private Rigidbody2D rb;
	GameObject txt_moneda;
	control_monedas ctrl_moneda;

	// Use this for initialization
	void Start () {
		Destroy (gameObject, 6);
		rb = GetComponent<Rigidbody2D> ();
		rb.AddForce (new Vector2(Random.Range(-500,500),100));	
		txt_moneda = GameObject.Find ("TextoMoneda");
		ctrl_moneda = txt_moneda.GetComponent<control_monedas> ();
	}

	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Player") {
			ctrl_moneda.suma_monedas (-100);
			Destroy (gameObject);
		}
	}
}