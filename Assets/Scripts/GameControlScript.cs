using UnityEngine;
using System.Collections;

public class GameControlScript : MonoBehaviour {

	private Vector3 punto_inicio;
	public GameObject player;
	public bool vivo = true;

	void Start(){
		punto_inicio = player.transform.position;
	}

	public void respawn(){
		player.transform.position = punto_inicio;
		player.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
	}

	public void checkpoint(Vector3 nuevo_punto){
		punto_inicio = nuevo_punto;
	}
		
}
