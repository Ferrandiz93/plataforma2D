using UnityEngine;
using System.Collections;

public class generador2 : MonoBehaviour {
	public GameObject[] monedas;
	private Transform posicion_de_salida;
	private GameObject moneda_nueva;
	private int numero_moneda;

	void Start(){
		posicion_de_salida = transform.Find ("posicion_de_salida").transform;
	}
	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Player") {
			numero_moneda = Random.Range (0,monedas.Length);
			moneda_nueva = (GameObject)Instantiate (monedas[numero_moneda], 
				posicion_de_salida.position, 
				transform.rotation);
		}
	}
	void OnTriggerEnter2D(Collider2D objeto){
		if (objeto.tag == "Player" && moneda_nueva == null) {
			moneda_nueva = (GameObject)Instantiate (monedas[0], 
				transform.position,
				transform.rotation);
		}

	}
}