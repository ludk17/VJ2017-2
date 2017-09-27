using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuriken : MonoBehaviour {

	public Jugador jugador;
	public int velocidad = 5;

	Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		
			rb.velocity = new Vector2 (velocidad, rb.velocity.y);

	
	}
}
