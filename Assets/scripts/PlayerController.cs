using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private Rigidbody2D rb;
	private string name;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		name = gameObject.name;
		name = name.Substring(name.Length-1, 1);
	}
	
	void FixedUpdate () {
		float torqueInput = Input.GetAxis ("Horizontal" + name);
		float forceInput  = Input.GetAxis ("Vertical" + name);
		if (forceInput >= 0) {
			forceInput *= 20;
			torqueInput *= -10;
		} else {
			forceInput *= 15;
			torqueInput *= 9;
		}

		rb.AddRelativeForce (new Vector2 (forceInput, 0));
		rb.AddTorque (torqueInput);
	}
}
