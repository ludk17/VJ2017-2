using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour {

	public int velocidad;
	public int fuerzaSalto;

	private Rigidbody2D rb;
	public Animator animator;

	private const int QUIETO = 0;
	private const int CORRER = 1;
	private const int SALTAR = 2;
	private const int ATACAR = 3;
	private const int PLANEAR = 4;

	public int saltos = 0;
	public bool estaEnElSuelo = true;
	public bool estaAtacando = false;

	private int estado = 0;


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

		MoverseALaDerecha ();
		MoverALaIzquierda();



		if (Input.GetKeyDown (KeyCode.Space) && saltos < 2) {
			animator.SetInteger ("Estado", SALTAR);
			rb.velocity = new Vector2(rb.velocity.x ,fuerzaSalto);
			estaEnElSuelo = false;
			saltos++;
		}

		if (Input.GetKeyDown (KeyCode.X)) {			
			Debug.Log ("Atacar");
			animator.SetInteger ("Estado", ATACAR);
			estaAtacando = true;
		}

		if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.5 && 
			!animator.IsInTransition(0) && 
			animator.GetCurrentAnimatorStateInfo(0).IsName("Atack")) {
			estaAtacando = false;
			animator.SetInteger ("Estado", QUIETO);
		}


		if (Input.GetKey (KeyCode.Z)) {			
			rb.gravityScale = (float)0.2;
			animator.SetInteger ("Estado", PLANEAR);
		}

		if (Input.GetKeyUp (KeyCode.Z)) {
			rb.gravityScale = (float)1;
			animator.SetInteger ("Estado", QUIETO);
		}

		//if (Input.GetKeyUp (KeyCode.X)) {
			//animator.SetInteger ("Estado", QUIETO);		
			//estaAtacando = false;
		//}

	}


	void OnCollisionEnter2D (Collision2D collision)
	{
		if(collision.gameObject.tag == "Enemigo")
		{
			if (!estaAtacando) {
				Debug.Log ("Morir");
				Destroy (gameObject);
			} else {
				Destroy (collision.gameObject);
			}
		}

	}

	private void MoverseALaDerecha()
	{
		if (Input.GetKey (KeyCode.RightArrow)) {
			animator.SetInteger ("Estado", CORRER);
			rb.velocity = new Vector2(velocidad, rb.velocity.y);
			transform.localScale = new Vector3(1, 1, 1);
		}

		if (Input.GetKeyUp (KeyCode.RightArrow)) {
			animator.SetInteger ("Estado", QUIETO);
			rb.velocity = new Vector2(0, rb.velocity.y);
			transform.localScale = new Vector3(1, 1, 1);
		}

	}

	private void MoverALaIzquierda()
	{
		if (Input.GetKey (KeyCode.LeftArrow)) {
			animator.SetInteger ("Estado", CORRER);
			rb.velocity = new Vector2(velocidad * -1, rb.velocity.y);
			transform.localScale = new Vector3(-1, 1, 1);
			estado = CORRER;
		}

		if (Input.GetKeyUp (KeyCode.LeftArrow)) {
			animator.SetInteger ("Estado", QUIETO);
			rb.velocity = new Vector2(0, rb.velocity.y);
			transform.localScale = new Vector3(-1, 1, 1);
			estado = QUIETO;
		}
	}
}
