using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorDeSuelo : MonoBehaviour {

	public Jugador jugador;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		
		jugador.saltos = 0;
		jugador.estaEnElSuelo = true;
		jugador.animator.SetInteger ("Estado", 0);
		Debug.Log ("colision");

	}
}
