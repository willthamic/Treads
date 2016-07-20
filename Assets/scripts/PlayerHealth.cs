using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	public float health = 100f;

	void  OnCollisionEnter2D(Collision2D c){
		if (c.gameObject.tag == "bullet" || c.gameObject.tag == "fragment")
			health -= 10f;
	}
}
