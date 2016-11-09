using UnityEngine;
using System.Collections;

public class moneda : MonoBehaviour
{
	private Rigidbody2D rb;

	void Start () {
		Destroy (gameObject, 3);
		rb = GetComponent<Rigidbody2D> ();
		rb.AddForce (new Vector2 (Random.Range(-100,100),100));
	}
    // función para controlar cuando un objeto entra en el trigger
    void OnCollisionEnter2D(Collision2D col)
    {
		if (col.gameObject.tag == "Player") {

			//Collider2D col hace referencia al objeto que ha entrado
			Debug.Log ("Alguien me ha tocado");
			Destroy (gameObject);
		}
    }

    // función para controlar cuando un objeto sale del trigger
    void OnTriggerExit2D(Collider2D col)
    {
        Debug.Log("Han dejado de tocarme");
    }
    // función para controlar cuando un objeto permanece en el trigger
    void OnTriggerStay2D(Collider2D col)
    {
        Debug.Log("Me están tocando, me siento incomodo");
    }
}