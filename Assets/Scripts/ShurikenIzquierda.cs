using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShurikenIzquierda : MonoBehaviour {

	public int velocidad = 5;

	Rigidbody2D rb;

	private Jugador jugador;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		jugador = FindObjectOfType(typeof(Jugador)) as Jugador;
	}
	
	// Update is called once per frame
	void Update () {
		rb.velocity = new Vector2 (velocidad * -1, rb.velocity.y);
	}

	void OnCollisionEnter2D (Collision2D collision)
	{
		if(collision.gameObject.tag == "Enemigo")
		{			
			Destroy (collision.gameObject);
			Destroy (gameObject);
			jugador.Puntaje += 5;
			jugador.puntajeText.text = jugador.Puntaje.ToString();

		}

	}

}
