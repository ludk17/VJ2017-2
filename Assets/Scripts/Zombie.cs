using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour {

	public int velocidad = 5;
	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {

		rb.velocity = new Vector2 (velocidad, rb.velocity.y);

	}

	public void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.collider.tag == "Caja") {
			velocidad *= -1;
			transform.localScale = new Vector3 (transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
		}
	}
}
