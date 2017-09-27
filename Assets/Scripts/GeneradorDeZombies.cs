using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorDeZombies : MonoBehaviour {

	public GameObject zombie;

	// Use this for initialization
	void Awake () {
		InvokeRepeating ("CrearZombie", 0f, 5);
	}
	
	// Update is called once per frame
	private void CrearZombie()
	{
		Instantiate (zombie, transform.position, Quaternion.identity);
	}
}
